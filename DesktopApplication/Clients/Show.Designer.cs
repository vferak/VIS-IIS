using System.ComponentModel;

namespace DesktopApplication.Clients
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.contactFirstNameLabel = new System.Windows.Forms.Label();
            this.contactLastNameLabel = new System.Windows.Forms.Label();
            this.contactEmailLabel = new System.Windows.Forms.Label();
            this.contactPhoneLabel = new System.Windows.Forms.Label();
            this.Edit = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(302, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Název";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(302, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Jméno kontaktu";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(302, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Příjmení kontaktu";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(302, 238);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "Email kontaktu";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(302, 301);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 9;
            this.label5.Text = "Telefon kontaktu";
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
            // nameLabel
            // 
            this.nameLabel.Location = new System.Drawing.Point(302, 59);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(100, 23);
            this.nameLabel.TabIndex = 11;
            // 
            // contactFirstNameLabel
            // 
            this.contactFirstNameLabel.Location = new System.Drawing.Point(302, 125);
            this.contactFirstNameLabel.Name = "contactFirstNameLabel";
            this.contactFirstNameLabel.Size = new System.Drawing.Size(100, 23);
            this.contactFirstNameLabel.TabIndex = 12;
            // 
            // contactLastNameLabel
            // 
            this.contactLastNameLabel.Location = new System.Drawing.Point(302, 191);
            this.contactLastNameLabel.Name = "contactLastNameLabel";
            this.contactLastNameLabel.Size = new System.Drawing.Size(100, 23);
            this.contactLastNameLabel.TabIndex = 13;
            // 
            // contactEmailLabel
            // 
            this.contactEmailLabel.Location = new System.Drawing.Point(302, 261);
            this.contactEmailLabel.Name = "contactEmailLabel";
            this.contactEmailLabel.Size = new System.Drawing.Size(100, 23);
            this.contactEmailLabel.TabIndex = 14;
            // 
            // contactPhoneLabel
            // 
            this.contactPhoneLabel.Location = new System.Drawing.Point(302, 324);
            this.contactPhoneLabel.Name = "contactPhoneLabel";
            this.contactPhoneLabel.Size = new System.Drawing.Size(100, 23);
            this.contactPhoneLabel.TabIndex = 15;
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
            // Show
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Edit);
            this.Controls.Add(this.contactPhoneLabel);
            this.Controls.Add(this.contactEmailLabel);
            this.Controls.Add(this.contactLastNameLabel);
            this.Controls.Add(this.contactFirstNameLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Show";
            this.Size = new System.Drawing.Size(800, 420);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Edit;

        private System.Windows.Forms.Label contactEmailLabel;
        private System.Windows.Forms.Label contactFirstNameLabel;
        private System.Windows.Forms.Label contactLastNameLabel;
        private System.Windows.Forms.Label contactPhoneLabel;

        private System.Windows.Forms.Label nameLabel;

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.Label label1;

        #endregion
    }
}