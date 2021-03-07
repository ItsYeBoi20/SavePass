using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Save_Pass
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            #region CreateRegisterWindow

            Register Register = new Register();
            Register.Show();

            #endregion CreateRegisterWindow
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                #region AES

                string usrencrypted = AesCryp.Encrypt(textBox1.Text);

                #endregion AES

                #region MD5

                string username = usrencrypted;
                byte[] encodedPassword = new UTF8Encoding().GetBytes(username);
                byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
                string encoded = BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();

                #endregion MD5

                #region ReadPasswordWithVibes

                string line = File.ReadLines("Users\\" + encoded + "\\salt.txt").Skip(1).Take(1).First();
                string DecryptKey = AesCryp.Decrypt(line);

                AesCryp.Key = DecryptKey;
                string pwdencrypted = AesCryp.Encrypt(textBox2.Text);
                AesCryp.Key = "5j2gfx0y5m9mb1x6ejtz384p9b4hf5nq";

                #endregion ReadPasswordWithVibes

                #region Login&CheckDir

                string dirName = new DirectoryInfo(@"Users\" + encoded).Name;

                if (Directory.Exists(@"Users\" + encoded))
                {
                    if (encoded == dirName)
                    {
                        #region SaltHash 

                        string line1 = File.ReadLines("Users\\" + encoded + "\\salt.txt").First();
                        string readpwd = File.ReadAllText("Users\\" + encoded + "\\password.txt");

                        string decryptSalt = AesCryp.Decrypt(line1);
                        int x = 0;
                        Int32.TryParse(decryptSalt, out x);

                        SaltHash pwd = new SaltHash(pwdencrypted, x);
                        string strHashedPassword = pwd.ComputeSaltedHash();

                        SaltHash usr = new SaltHash(usrencrypted, x);
                        string strHashedUsername = usr.ComputeSaltedHash();

                        string encryptUsername = AesCryp.Encrypt(strHashedUsername);

                        #endregion SaltHash

                        #region CheckUsername

                        string line3 = File.ReadLines("Users\\" + encoded + "\\salt.txt").Skip(2).Take(1).First();

                        #endregion CheckUsername

                        if (readpwd == strHashedPassword)
                        {
                            if (line3 == encryptUsername)
                            {
                                #region LoadMain

                                label3.Text = encoded;
                                Main main = new Main();
                                main.Text = "Current User: " + textBox1.Text;
                                main.label3.Text = encoded;
                                this.Hide();
                                main.Show();

                                #endregion LoadMain
                            }
                            else
                            {
                                MessageBox.Show("Password or Username incorrect!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Password or Username incorrect!");
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Password or Username incorrect!");
                }

                #endregion Login&CheckDir
            }
            catch
            {
                #region ErrorMessage

                MessageBox.Show("An Error occured!");

                #endregion ErrorMessage
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists ("Settings.ini"))
            {
                return;
            }
            else
            {
                File.WriteAllText("Settings.ini", "ShowDetails = 0  | 0-1" + Environment.NewLine);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ResetPass RP = new ResetPass();
            RP.Show();
        }
    }
}