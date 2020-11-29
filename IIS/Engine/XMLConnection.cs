﻿namespace IIS.Engine
{
    public class XMLConnection : Connection
    {
        public override Database<T> Create<T>(Model<T> model)
        {
            return new XML<T>(model);
        }
    }
}