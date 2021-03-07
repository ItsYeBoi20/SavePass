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
    public partial class ResetPass : Form
    {
        public ResetPass()
        {
            InitializeComponent();
        }

        private void ResetPass_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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

            #region DecryptAES

            string line = File.ReadLines("Users\\" + encoded + "\\salt.txt").Skip(1).Take(1).First();
            string reset = File.ReadAllText("Users\\" + encoded + "\\reset.txt");
            string DecryptKey = AesCryp.Decrypt(line);

            AesCryp.Key = DecryptKey;
            string pwdencrypted = AesCryp.Encrypt(textBox3.Text);
            AesCryp.Key = "5j2gfx0y5m9mb1x6ejtz384p9b4hf5nq";

            #endregion DecryptAES

            #region Salt

            string readSalt = File.ReadLines("Users\\" + encoded + "\\salt.txt").Skip(0).Take(1).First();
            string decryptSalt = AesCryp.Decrypt(readSalt);
            int x = 0;
            Int32.TryParse(decryptSalt, out x);

            SaltHash usr = new SaltHash(pwdencrypted, x);
            string strHashedReset = usr.ComputeSaltedHash();

            #endregion Salt

            if (strHashedReset == reset)
            {
                if (textBox2.Text == "")
                {
                    MessageBox.Show("You have to choose a new Password!");
                }
                else
                {
                    #region AES

                    string ReadLine = File.ReadLines("Users\\" + encoded + "\\salt.txt").Skip(1).Take(1).First();
                    string DecryptLine = AesCryp.Decrypt(ReadLine);

                    AesCryp.Key = DecryptLine;
                    string PasswordEncrypted = AesCryp.Encrypt(textBox2.Text);
                    AesCryp.Key = "5j2gfx0y5m9mb1x6ejtz384p9b4hf5nq";

                    #endregion AES

                    #region SaltHash

                    string readSalt1 = File.ReadAllText("Users\\" + encoded + "\\salt.txt");
                    string decryptSalt1 = AesCryp.Decrypt(readSalt);
                    int i = 0;
                    Int32.TryParse(decryptSalt, out i);

                    SaltHash pwd = new SaltHash(PasswordEncrypted, i);
                    string strHashedPassword = pwd.ComputeSaltedHash();

                    #endregion SaltHash

                    File.WriteAllText("Users\\" + encoded + "\\password.txt", strHashedPassword);

                    MessageBox.Show("Password Successfully changed!");
                }
            }
            else
            {
                MessageBox.Show("Reset is Incorrect!");
            }
        }
    }
}
