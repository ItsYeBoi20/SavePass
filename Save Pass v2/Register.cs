using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Save_Pass_v2
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void lgnButton_Click(object sender, EventArgs e)
        {
            if (usrTextbox.Text == "" || pwdTextbox.Text == "")
            {
                MessageBox.Show("Fields cannot be blank!");
            }
            else
            {
                if (!pwdTextbox.Text.Contains(":"))
                {
                    #region usrTextbox

                    StringBuilder usrB = new StringBuilder();
                    for (int i = 0; i < 32; i++)
                    {
                        usrB.Append(usrTextbox.Text[i % usrTextbox.Text.Length]);
                    }
                    byte[] Key = Encoding.Unicode.GetBytes(usrTextbox.Text);

                    #endregion usrTextbox

                    #region pwdTextbox

                    StringBuilder pwdB = new StringBuilder();
                    for (int i = 0; i < 16; i++)
                    {
                        pwdB.Append(pwdTextbox.Text[i % pwdTextbox.Text.Length]);
                    }
                    byte[] IV = Encoding.Unicode.GetBytes(pwdTextbox.Text);

                    #endregion pwdTextbox

                    string MD5user = Crypter.MD5.CreateMD5(usrTextbox.Text);

                    Crypter.Aes.IV = pwdB.ToString();
                    Crypter.Aes.Key = usrB.ToString();
                    string encryptedCombo = Crypter.Aes.Encrypt(usrTextbox.Text + ":" + pwdTextbox.Text);

                    if (File.Exists(@"Users\" + MD5user))
                    {
                        MessageBox.Show("User Already Exists");
                    }
                    else
                    {
                        Directory.CreateDirectory(@"Users\");
                        File.WriteAllText(@"Users\" + MD5user, encryptedCombo + Environment.NewLine);
                    }

                    Crypter.Aes.IV = "aaaaaaaaaaaaaaaa";
                    Crypter.Aes.Key = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                    MessageBox.Show("User Created Successfully");
                }
                else
                {
                    MessageBox.Show("Password cannot contain \":\"");
                }
            }
        }

        private void Register_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
