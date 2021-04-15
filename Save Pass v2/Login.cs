using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Save_Pass_v2
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lgnButton_Click(object sender, EventArgs e)
        {
            startLogin();
        }

        private void rgsButton_Click(object sender, EventArgs e)
        {
            Register rg = new Register();
            rg.Show();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void pwdTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                startLogin();
            }
        }

        private void usrTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                startLogin();
            }
        }

        private void startLogin()
        {
            if (usrTextbox.Text == "" || pwdTextbox.Text == "")
            {
                MessageBox.Show("Fields cannot be blank!");
            }
            else
            {
                string MD5user = Crypter.MD5.CreateMD5(usrTextbox.Text);
                if (File.Exists(@"Users\" + MD5user))
                {
                    string[] lines = File.ReadAllLines(@"Users\" + MD5user);

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

                    Crypter.Aes.IV = pwdB.ToString();
                    Crypter.Aes.Key = usrB.ToString();
                    string encryptedCombo = Crypter.Aes.Encrypt(usrTextbox.Text + ":" + pwdTextbox.Text);

                    if (encryptedCombo == lines[0])
                    {
                        Vault.login = MD5user;
                        Vault.usr = usrB.ToString();
                        Vault.pwd = pwdB.ToString();
                        Vault v = new Vault();
                        this.Hide();
                        v.Text = "Logged in as " + usrTextbox.Text;
                        v.Show();
                    }
                    else
                    {
                        MessageBox.Show("Username or Password is incorrect!");
                    }
                }
                else
                {
                    MessageBox.Show("User does not exist!");
                }
            }
        }
    }
}
