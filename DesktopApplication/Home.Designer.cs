using System.ComponentModel;

namespace DesktopApplication
{
    partial class Home
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.iISToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.úkolyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.výpisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.klientiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novýToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.výpisToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.uživateléToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novýToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.výpisToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.dovolenéToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novýToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.výpisToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.ContentPanel = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.iISToolStripMenuItem, this.úkolyToolStripMenuItem, this.klientiToolStripMenuItem, this.uživateléToolStripMenuItem, this.dovolenéToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // iISToolStripMenuItem
            // 
            this.iISToolStripMenuItem.Name = "iISToolStripMenuItem";
            this.iISToolStripMenuItem.Size = new System.Drawing.Size(31, 20);
            this.iISToolStripMenuItem.Text = "IIS";
            // 
            // úkolyToolStripMenuItem
            // 
            this.úkolyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.novýToolStripMenuItem, this.výpisToolStripMenuItem});
            this.úkolyToolStripMenuItem.Name = "úkolyToolStripMenuItem";
            this.úkolyToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.úkolyToolStripMenuItem.Text = "Úkoly";
            // 
            // novýToolStripMenuItem
            // 
            this.novýToolStripMenuItem.Name = "novýToolStripMenuItem";
            this.novýToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.novýToolStripMenuItem.Text = "Nový";
            // 
            // výpisToolStripMenuItem
            // 
            this.výpisToolStripMenuItem.Name = "výpisToolStripMenuItem";
            this.výpisToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.výpisToolStripMenuItem.Text = "Výpis";
            this.výpisToolStripMenuItem.Click += new System.EventHandler(this.výpisToolStripMenuItem_Click);
            // 
            // klientiToolStripMenuItem
            // 
            this.klientiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.novýToolStripMenuItem1, this.výpisToolStripMenuItem1});
            this.klientiToolStripMenuItem.Name = "klientiToolStripMenuItem";
            this.klientiToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.klientiToolStripMenuItem.Text = "Klienti";
            // 
            // novýToolStripMenuItem1
            // 
            this.novýToolStripMenuItem1.Name = "novýToolStripMenuItem1";
            this.novýToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.novýToolStripMenuItem1.Text = "Nový";
            this.novýToolStripMenuItem1.Click += new System.EventHandler(this.novýToolStripMenuItem1_Click);
            // 
            // výpisToolStripMenuItem1
            // 
            this.výpisToolStripMenuItem1.Name = "výpisToolStripMenuItem1";
            this.výpisToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.výpisToolStripMenuItem1.Text = "Výpis";
            this.výpisToolStripMenuItem1.Click += new System.EventHandler(this.výpisToolStripMenuItem1_Click);
            // 
            // uživateléToolStripMenuItem
            // 
            this.uživateléToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.novýToolStripMenuItem2, this.výpisToolStripMenuItem2});
            this.uživateléToolStripMenuItem.Name = "uživateléToolStripMenuItem";
            this.uživateléToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.uživateléToolStripMenuItem.Text = "Uživatelé";
            // 
            // novýToolStripMenuItem2
            // 
            this.novýToolStripMenuItem2.Name = "novýToolStripMenuItem2";
            this.novýToolStripMenuItem2.Size = new System.Drawing.Size(102, 22);
            this.novýToolStripMenuItem2.Text = "Nový";
            // 
            // výpisToolStripMenuItem2
            // 
            this.výpisToolStripMenuItem2.Name = "výpisToolStripMenuItem2";
            this.výpisToolStripMenuItem2.Size = new System.Drawing.Size(102, 22);
            this.výpisToolStripMenuItem2.Text = "Výpis";
            // 
            // dovolenéToolStripMenuItem
            // 
            this.dovolenéToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.novýToolStripMenuItem3, this.výpisToolStripMenuItem3});
            this.dovolenéToolStripMenuItem.Name = "dovolenéToolStripMenuItem";
            this.dovolenéToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.dovolenéToolStripMenuItem.Text = "Dovolené";
            // 
            // novýToolStripMenuItem3
            // 
            this.novýToolStripMenuItem3.Name = "novýToolStripMenuItem3";
            this.novýToolStripMenuItem3.Size = new System.Drawing.Size(102, 22);
            this.novýToolStripMenuItem3.Text = "Nový";
            // 
            // výpisToolStripMenuItem3
            // 
            this.výpisToolStripMenuItem3.Name = "výpisToolStripMenuItem3";
            this.výpisToolStripMenuItem3.Size = new System.Drawing.Size(102, 22);
            this.výpisToolStripMenuItem3.Text = "Výpis";
            // 
            // ContentPanel
            // 
            this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentPanel.Location = new System.Drawing.Point(0, 24);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new System.Drawing.Size(800, 426);
            this.ContentPanel.TabIndex = 1;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ContentPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Home";
            this.Text = "Home";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel ContentPanel;

        private System.Windows.Forms.ToolStripMenuItem novýToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novýToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem novýToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem novýToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem výpisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem výpisToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem výpisToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem výpisToolStripMenuItem3;

        private System.Windows.Forms.ToolStripMenuItem dovolenéToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem klientiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uživateléToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem iISToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem úkolyToolStripMenuItem;

        #endregion
    }
}