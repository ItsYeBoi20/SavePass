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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Fields cannot be blank!");
            }
            else
            {
                #region AES

                string UserEncrypted = AesCryp.Encrypt(textBox1.Text);

                string GenerateAesKey = RandomString();
                AesCryp.Key = GenerateAesKey;
                string PasswordEncrypted = AesCryp.Encrypt(textBox2.Text);
                string ResetEncrypted = AesCryp.Encrypt(textBox3.Text);
                AesCryp.Key = "5j2gfx0y5m9mb1x6ejtz384p9b4hf5nq";
                string EncryptedAesKey = AesCryp.Encrypt(GenerateAesKey);


                #endregion AES

                #region MD5

                string username = UserEncrypted;
                byte[] encodedPassword = new UTF8Encoding().GetBytes(username);
                byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
                string encoded = BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();

                #endregion MD5

                if (Directory.Exists(@"Users\" + encoded))
                {
                    #region UserExistsWindow

                    MessageBox.Show("User Already Exists");

                    #endregion UserExistsWindow
                }
                else
                {
                    #region CreateSaltFile

                    Directory.CreateDirectory(@"Users\" + encoded);

                    int mySalt = SaltHash.CreateRandomSalt();
                    string stringsalt = mySalt.ToString();
                    string saltencrypted = AesCryp.Encrypt(stringsalt);

                    File.WriteAllText("Users\\" + encoded + "\\salt.txt", saltencrypted);

                    #endregion CreateSaltFile

                    #region SaltHash

                    string readSalt = File.ReadAllText("Users\\" + encoded + "\\salt.txt");
                    string decryptSalt = AesCryp.Decrypt(readSalt);
                    int x = 0;
                    Int32.TryParse(decryptSalt, out x);

                    SaltHash usr = new SaltHash(UserEncrypted, x);
                    string strHashedUsername = usr.ComputeSaltedHash();

                    SaltHash pwd = new SaltHash(PasswordEncrypted, x);
                    string strHashedPassword = pwd.ComputeSaltedHash();

                    SaltHash rst = new SaltHash(ResetEncrypted, x);
                    string strHashedReset = rst.ComputeSaltedHash();

                    string encryptUsername = AesCryp.Encrypt(strHashedUsername);

                    #endregion SaltHash

                    #region Create&Write

                    File.WriteAllText("Users\\" + encoded + "\\password.txt", strHashedPassword);
                    File.WriteAllText("Users\\" + encoded + "\\reset.txt", strHashedReset);

                    File.AppendAllText("Users\\" + encoded + "\\salt.txt", Environment.NewLine);
                    File.AppendAllText("Users\\" + encoded + "\\salt.txt", EncryptedAesKey);

                    File.AppendAllText("Users\\" + encoded + "\\salt.txt", Environment.NewLine);
                    File.AppendAllText("Users\\" + encoded + "\\salt.txt", encryptUsername);

                    Directory.CreateDirectory("Users\\" + encoded + "\\Combos");

                    MessageBox.Show("User Created Succefully!");

                    #endregion Create&Write
                }
            }
        }

        #region GenerateChar

        private static Random random = new Random();
        public static string RandomString(int length = 32)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        #endregion Generate

        private void Register_Load(object sender, EventArgs e)
        {

        }
    }
}
