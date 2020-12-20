using System.ComponentModel;

namespace DesktopApplication.UsersVacations
{
    partial class Show
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Edit = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.userLabel = new System.Windows.Forms.Label();
            this.dateFromLabel = new System.Windows.Forms.Label();
            this.contactLastNameLabel = new System.Windows.Forms.Label();
            this.acceptedLabel = new System.Windows.Forms.Label();
            this.dateToLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(302, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Uživatel";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(302, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Od";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(69, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Zpět";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Edit
            // 
            this.Edit.Location = new System.Drawing.Point(658, 36);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(75, 23);
            this.Edit.TabIndex = 16;
            this.Edit.Text = "Editovat";
            this.Edit.UseVisualStyleBackColor = true;
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(658, 65);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(75, 23);
            this.Delete.TabIndex = 17;
            this.Delete.Text = "Smazat";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // userLabel
            // 
            this.userLabel.Location = new System.Drawing.Point(302, 59);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(100, 23);
            this.userLabel.TabIndex = 11;
            // 
            // dateFromLabel
            // 
            this.dateFromLabel.Location = new System.Drawing.Point(302, 125);
            this.dateFromLabel.Name = "dateFromLabel";
            this.dateFromLabel.Size = new System.Drawing.Size(100, 23);
            this.dateFromLabel.TabIndex = 12;
            // 
            // contactLastNameLabel
            // 
            this.contactLastNameLabel.Location = new System.Drawing.Point(302, 203);
            this.contactLastNameLabel.Name = "contactLastNameLabel";
            this.contactLastNameLabel.Size = new System.Drawing.Size(100, 23);
            this.contactLastNameLabel.TabIndex = 13;
            // 
            // acceptedLabel
            // 
            this.acceptedLabel.Location = new System.Drawing.Point(302, 249);
            this.acceptedLabel.Name = "acceptedLabel";
            this.acceptedLabel.Size = new System.Drawing.Size(100, 23);
            this.acceptedLabel.TabIndex = 21;
            // 
            // dateToLabel
            // 
            this.dateToLabel.Location = new System.Drawing.Point(302, 183);
            this.dateToLabel.Name = "dateToLabel";
            this.dateToLabel.Size = new System.Drawing.Size(100, 23);
            this.dateToLabel.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(302, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 19;
            this.label5.Text = "Schváleno";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(302, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 18;
            this.label6.Text = "Do";
            // 
            // textLabel
            // 
            this.textLabel.Location = new System.Drawing.Point(302, 306);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(235, 95);
            this.textLabel.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(302, 283);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 22;
            this.label4.Text = "Text";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(658, 94);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 24;
            this.button2.Text = "Schválit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Show
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.acceptedLabel);
            this.Controls.Add(this.dateToLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Edit);
            this.Controls.Add(this.contactLastNameLabel);
            this.Controls.Add(this.dateFromLabel);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Show";
            this.Size = new System.Drawing.Size(800, 420);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button button2;

        private System.Windows.Forms.Label textLabel;

        private System.Windows.Forms.Label contactLastNameLabel;
        private System.Windows.Forms.Label dateFromLabel;
        private System.Windows.Forms.Label acceptedLabel;
        private System.Windows.Forms.Label dateToLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label userLabel;

        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Edit;

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Label label1;

        #endregion
    }
}