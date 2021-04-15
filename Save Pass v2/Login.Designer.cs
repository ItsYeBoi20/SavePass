
namespace Save_Pass_v2
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.rgsButton = new System.Windows.Forms.Button();
            this.pwdTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.usrTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lgnButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rgsButton
            // 
            this.rgsButton.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rgsButton.Location = new System.Drawing.Point(12, 75);
            this.rgsButton.Name = "rgsButton";
            this.rgsButton.Size = new System.Drawing.Size(80, 23);
            this.rgsButton.TabIndex = 13;
            this.rgsButton.Text = "Register";
            this.rgsButton.UseVisualStyleBackColor = true;
            this.rgsButton.Click += new System.EventHandler(this.rgsButton_Click);
            // 
            // pwdTextbox
            // 
            this.pwdTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pwdTextbox.Location = new System.Drawing.Point(100, 41);
            this.pwdTextbox.Name = "pwdTextbox";
            this.pwdTextbox.PasswordChar = '*';
            this.pwdTextbox.Size = new System.Drawing.Size(200, 21);
            this.pwdTextbox.TabIndex = 12;
            this.pwdTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pwdTextbox_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 11;
            this.label2.Text = "Password: ";
            // 
            // usrTextbox
            // 
            this.usrTextbox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usrTextbox.Location = new System.Drawing.Point(100, 9);
            this.usrTextbox.Name = "usrTextbox";
            this.usrTextbox.Size = new System.Drawing.Size(200, 22);
            this.usrTextbox.TabIndex = 10;
            this.usrTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.usrTextbox_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "Username: ";
            // 
            // lgnButton
            // 
            this.lgnButton.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lgnButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lgnButton.Location = new System.Drawing.Point(184, 75);
            this.lgnButton.Name = "lgnButton";
            this.lgnButton.Size = new System.Drawing.Size(117, 23);
            this.lgnButton.TabIndex = 8;
            this.lgnButton.Text = "Login";
            this.lgnButton.UseVisualStyleBackColor = true;
            this.lgnButton.Click += new System.EventHandler(this.lgnButton_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(311, 107);
            this.Controls.Add(this.rgsButton);
            this.Controls.Add(this.pwdTextbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.usrTextbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lgnButton);
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Save Pass v2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button rgsButton;
        private System.Windows.Forms.TextBox pwdTextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox usrTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button lgnButton;
    }
}

