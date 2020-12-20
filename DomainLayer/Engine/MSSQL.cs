using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;


namespace DomainLayer.Engine
{
    public class MSSQL<T> : Database<T>
    {
        private const string ConnectionString =
            "Server=dbsys.cs.vsb.cz\\STUDENT;Database=fer0101;User ID=fer0101;Password=aZ1kPBvC9x;";

        private const string Schema = "IIS.";
        
        private readonly SqlConnection _connection = new SqlConnection(ConnectionString);

        public MSSQL(Model<T> model) : base(model) {}
        
        public override T LoadOne()
        {
            return Load().FirstOrDefault();
        }

        public override IEnumerable<T> Load()
        {
            return LoadSql(BuildSelectQueryString());
        }

        public IEnumerable<T> LoadSql(string query)
        {
            return ExecuteReader(GetSqlCommandWithParameters(query));
        }

        public override void Save()
        {
            var query = IsInsert() ? BuildInsertQueryString() : BuildUpdateQueryString();
            if (query != null)
            {
                ExecuteNonQuery(GetSqlCommandWithParameters(query));
            }
        }

        public override void Delete()
        {
            if (LoadOne() != null)
            {
                var query = BuildDeleteQueryString();
                ExecuteNonQuery(GetSqlCommandWithParameters(query));
            }
        }

        public void RunProcedure(string procedureName)
        {
            ExecuteNonQuery(GetSqlCommandWithProcedure(procedureName));
        }
        
        private SqlCommand GetSqlCommandWithParameters(string query)
        {
            var command = new SqlCommand(query, _connection);
            AddParamsToQuery(command);
            return command;
        }

        private SqlCommand GetSqlCommandWithProcedure(string procedureName)
        {
            var command = GetSqlCommandWithParameters(procedureName);
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        private void AddParamsToQuery(SqlCommand command)
        {
            foreach (var property in typeof(T).GetProperties())
            {
                var value = property.GetValue(Model, null);
                if (!PropertyIsNotMapped(property) && value != null)
                {
                    // if (property.PropertyType == typeof(DateTime?))
                    // {
                    //     value = FormatDateTimeString(value.ToString());
                    // }
                    
                    command.Parameters.AddWithValue("@" + property.Name, value);
                }
            }
        }

        private string BuildSelectQueryString()
        {
            var queryString = $"SELECT * FROM {Schema + typeof(T).Name}";
            
            string whereString = null;
            foreach (var property in typeof(T).GetProperties())
            {
                var value = property.GetValue(Model, null);
                if (value == null || PropertyIsNotMapped(property)) continue;
                
                whereString = whereString == null ? " WHERE " : whereString + " AND ";
                whereString += FilterEquals(property.Name);
            }

            return queryString + whereString;
        }
        
        private string BuildInsertQueryString()
        {
            var queryString = $"INSERT INTO {Schema + typeof(T).Name}";

            string parametersString = null;
            string valuesString = null;
            foreach (var property in typeof(T).GetProperties())
            {
                var value = property.GetValue(Model, null);
                if (PropertyIsNotMapped(property) || PropertyIsKey(property) ||
                    !PropertyIsEditable(property) || !PropertyIsRequired(property) && value == null) continue;
                
                parametersString = parametersString == null ? "" : parametersString + ", ";
                parametersString += property.Name;

                valuesString = valuesString == null ? "" : valuesString + ", ";
                valuesString += "@" + property.Name;
            }

            return queryString + " ( " + parametersString + " ) " + " VALUES ( " + valuesString + " ) ";
        }
        
        private string BuildUpdateQueryString()
        {
            var queryString = $"UPDATE {Schema + typeof(T).Name}";

            string setString = null;
            string whereString = null;
            foreach (var property in typeof(T).GetProperties())
            {
                var value = property.GetValue(Model, null);
                if (PropertyIsKey(property))
                {
                    whereString = whereString == null ? " WHERE " : whereString + " AND ";
                    whereString += FilterEquals(property.Name);
                }
                else if (!PropertyIsNotMapped(property) && (PropertyIsRequired(property) || value != null))
                {
                    setString = setString == null ? " SET " : setString + ", ";
                    setString += FilterEquals(property.Name);
                }
            }

            return setString != null ? queryString + setString + whereString : null;
        }
        
        private string BuildDeleteQueryString()
        {
            var queryString = $"DELETE FROM {Schema + typeof(T).Name}";
            
            string whereString = null;
            foreach (var property in typeof(T).GetProperties())
            {
                if (PropertyIsKey(property) && property.GetValue(Model, null) != null)
                {
                    whereString = whereString == null ? " WHERE " : whereString + " AND ";
                    whereString += FilterEquals(property.Name);
                }
            }

            return queryString + whereString;
        }
        
        private string FilterEquals(string propertyName)
        {
            return propertyName + " = @" + propertyName;
        }
        
        private IEnumerable<T> ExecuteReader(SqlCommand command)
        {
            var result = new List<T>();

            try
            {
                _connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var model = (T)Activator.CreateInstance(typeof(T), new MSSQLConnection());
                    foreach (var property in typeof(T).GetProperties())
                    {
                        if (reader.GetSchemaTable().Rows.OfType<DataRow>()
                            .Any(row => row["ColumnName"].ToString() == property.Name))
                        {
                            var value = reader[property.Name];
                            property.SetValue(model, Convert.IsDBNull(value) ? null : value);
                        }
                    }

                    result.Add(model);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _connection.Close();
            }

            return result;
        }

        private void ExecuteNonQuery(SqlCommand command)
        {
            try
            {
                _connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}