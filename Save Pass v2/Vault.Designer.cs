
namespace Save_Pass_v2
{
    partial class Vault
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Vault));
            this.refreshButton = new System.Windows.Forms.Button();
            this.comboList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // refreshButton
            // 
            this.refreshButton.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshButton.Location = new System.Drawing.Point(207, 303);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(139, 34);
            this.refreshButton.TabIndex = 12;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // comboList
            // 
            this.comboList.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboList.ForeColor = System.Drawing.Color.Black;
            this.comboList.FormattingEnabled = true;
            this.comboList.HorizontalScrollbar = true;
            this.comboList.ItemHeight = 14;
            this.comboList.Location = new System.Drawing.Point(12, 6);
            this.comboList.Name = "comboList";
            this.comboList.Size = new System.Drawing.Size(333, 270);
            this.comboList.Sorted = true;
            this.comboList.TabIndex = 11;
            this.comboList.TabStop = false;
            this.comboList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.comboList_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(107, 286);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 14);
            this.label1.TabIndex = 10;
            this.label1.Text = "Double Click a Combo";
            // 
            // comboButton
            // 
            this.comboButton.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboButton.Location = new System.Drawing.Point(12, 303);
            this.comboButton.Name = "comboButton";
            this.comboButton.Size = new System.Drawing.Size(139, 34);
            this.comboButton.TabIndex = 9;
            this.comboButton.Text = "Add Combo";
            this.comboButton.UseVisualStyleBackColor = true;
            this.comboButton.Click += new System.EventHandler(this.comboButton_Click);
            // 
            // Vault
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(355, 349);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.comboList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboButton);
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Vault";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vault";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Vault_FormClosing);
            this.Load += new System.EventHandler(this.Vault_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button comboButton;
        public System.Windows.Forms.ListBox comboList;
    }
}