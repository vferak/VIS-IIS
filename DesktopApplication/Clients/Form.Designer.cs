﻿using System.ComponentModel;

namespace DesktopApplication.Clients
{
    partial class Form
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
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.contactFirstNameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.contactLastNameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.contactEmailTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.contactPhoneTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(302, 62);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(194, 20);
            this.nameTextBox.TabIndex = 0;
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
            // contactFirstNameTextBox
            // 
            this.contactFirstNameTextBox.Location = new System.Drawing.Point(302, 128);
            this.contactFirstNameTextBox.Name = "contactFirstNameTextBox";
            this.contactFirstNameTextBox.Size = new System.Drawing.Size(194, 20);
            this.contactFirstNameTextBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(302, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Příjmení kontaktu";
            // 
            // contactLastNameTextBox
            // 
            this.contactLastNameTextBox.Location = new System.Drawing.Point(302, 194);
            this.contactLastNameTextBox.Name = "contactLastNameTextBox";
            this.contactLastNameTextBox.Size = new System.Drawing.Size(194, 20);
            this.contactLastNameTextBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(302, 238);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "Email kontaktu";
            // 
            // contactEmailTextBox
            // 
            this.contactEmailTextBox.Location = new System.Drawing.Point(302, 264);
            this.contactEmailTextBox.Name = "contactEmailTextBox";
            this.contactEmailTextBox.Size = new System.Drawing.Size(194, 20);
            this.contactEmailTextBox.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(302, 301);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 9;
            this.label5.Text = "Telefon kontaktu";
            // 
            // contactPhoneTextBox
            // 
            this.contactPhoneTextBox.Location = new System.Drawing.Point(302, 327);
            this.contactPhoneTextBox.Name = "contactPhoneTextBox";
            this.contactPhoneTextBox.Size = new System.Drawing.Size(194, 20);
            this.contactPhoneTextBox.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(362, 381);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Uložit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.contactPhoneTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.contactEmailTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.contactLastNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.contactFirstNameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameTextBox);
            this.Name = "Form";
            this.Size = new System.Drawing.Size(800, 420);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox contactFirstNameTextBox;
        private System.Windows.Forms.TextBox contactLastNameTextBox;
        private System.Windows.Forms.TextBox contactEmailTextBox;
        private System.Windows.Forms.TextBox contactPhoneTextBox;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.TextBox nameTextBox;

        #endregion
    }
}