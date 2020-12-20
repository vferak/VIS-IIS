using System.ComponentModel;

namespace DesktopApplication.Tasks
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
            this.button1 = new System.Windows.Forms.Button();
            this.Edit = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.clientLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.expectedTimeLabel = new System.Windows.Forms.Label();
            this.expectedDateLabel = new System.Windows.Forms.Label();
            this.rateLabel = new System.Windows.Forms.Label();
            this.eventsListBox = new System.Windows.Forms.ListBox();
            this.realTimeLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(196, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 24;
            this.label5.Text = "Sazba";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(458, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 23;
            this.label4.Text = "Očekávané datum";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(458, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 22;
            this.label3.Text = "Očekávaný čas";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(196, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 20;
            this.label2.Text = "Název";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(196, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 18;
            this.label1.Text = "Klient";
            // 
            // clientLabel
            // 
            this.clientLabel.Location = new System.Drawing.Point(196, 128);
            this.clientLabel.Name = "clientLabel";
            this.clientLabel.Size = new System.Drawing.Size(100, 23);
            this.clientLabel.TabIndex = 25;
            // 
            // titleLabel
            // 
            this.titleLabel.Location = new System.Drawing.Point(196, 64);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(182, 23);
            this.titleLabel.TabIndex = 26;
            // 
            // expectedTimeLabel
            // 
            this.expectedTimeLabel.Location = new System.Drawing.Point(458, 128);
            this.expectedTimeLabel.Name = "expectedTimeLabel";
            this.expectedTimeLabel.Size = new System.Drawing.Size(100, 23);
            this.expectedTimeLabel.TabIndex = 27;
            // 
            // expectedDateLabel
            // 
            this.expectedDateLabel.Location = new System.Drawing.Point(458, 198);
            this.expectedDateLabel.Name = "expectedDateLabel";
            this.expectedDateLabel.Size = new System.Drawing.Size(100, 23);
            this.expectedDateLabel.TabIndex = 28;
            // 
            // rateLabel
            // 
            this.rateLabel.Location = new System.Drawing.Point(196, 198);
            this.rateLabel.Name = "rateLabel";
            this.rateLabel.Size = new System.Drawing.Size(100, 23);
            this.rateLabel.TabIndex = 29;
            // 
            // eventsListBox
            // 
            this.eventsListBox.FormattingEnabled = true;
            this.eventsListBox.Location = new System.Drawing.Point(65, 232);
            this.eventsListBox.Name = "eventsListBox";
            this.eventsListBox.Size = new System.Drawing.Size(667, 173);
            this.eventsListBox.TabIndex = 30;
            // 
            // realTimeLabel
            // 
            this.realTimeLabel.Location = new System.Drawing.Point(458, 59);
            this.realTimeLabel.Name = "realTimeLabel";
            this.realTimeLabel.Size = new System.Drawing.Size(100, 23);
            this.realTimeLabel.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(458, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 31;
            this.label7.Text = "Reálný čas";
            // 
            // Show
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.realTimeLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.eventsListBox);
            this.Controls.Add(this.rateLabel);
            this.Controls.Add(this.expectedDateLabel);
            this.Controls.Add(this.expectedTimeLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.clientLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Edit);
            this.Controls.Add(this.button1);
            this.Name = "Show";
            this.Size = new System.Drawing.Size(800, 420);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label realTimeLabel;
        private System.Windows.Forms.Label label7;

        private System.Windows.Forms.ListBox eventsListBox;

        private System.Windows.Forms.Label clientLabel;
        private System.Windows.Forms.Label expectedDateLabel;
        private System.Windows.Forms.Label expectedTimeLabel;
        private System.Windows.Forms.Label rateLabel;
        private System.Windows.Forms.Label titleLabel;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Edit;

        private System.Windows.Forms.Button button1;

        #endregion
    }
}