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

namespace Save_Pass
{
    public partial class AddCombo : Form
    {
        public AddCombo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region AES

            string line = File.ReadLines("Users\\" + label4.Text + "\\salt.txt").Skip(1).Take(1).First();
            string DecryptKey = AesCryp.Decrypt(line);

            AesCryp.Key = DecryptKey;
            string ProviderAes = AesCryp.Encrypt(textBox1.Text);
            string EmailAes = AesCryp.Encrypt(textBox2.Text);
            string PasswordAes = AesCryp.Encrypt(textBox3.Text);
            AesCryp.Key = "5j2gfx0y5m9mb1x6ejtz384p9b4hf5nq";

            #endregion AES

            #region CreateCombo

            string Dir = ("Users\\" + label4.Text + "\\Combos" + "\\" + textBox1.Text + " - " + textBox2.Text + ".txt");
            
            if (File.Exists(Dir))
            {
                MessageBox.Show("Combo Already Exists");
            }
            else
            {
                File.WriteAllText(Dir, EmailAes + " " + PasswordAes);

                MessageBox.Show("Combo Successfully Added");
            }

            #endregion CreateCombo
        }

        private void button2_Click(object sender, EventArgs e)
        {
            #region ImportPHP

            Stream myStream = null;
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Text File";
            theDialog.Filter = "TXT files|*.txt";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                string[] ReadLine = File.ReadAllLines(theDialog.FileName);
                int Worked = 0;
                int DidntWork = 0;

                foreach (string line in ReadLine)
                {
                    var splitt = line.Split(new string[] { "," }, StringSplitOptions.None);

                    string ReadKey = File.ReadLines("Users\\" + label4.Text + "\\salt.txt").Skip(1).Take(1).First();
                    string EncryptKey = AesCryp.Decrypt(ReadKey);
                    AesCryp.Key = EncryptKey;
                    string Username = AesCryp.Encrypt(splitt[1]);
                    string Password = AesCryp.Encrypt(splitt[2]);
                    string Name = AesCryp.Encrypt(splitt[4]);

                    AesCryp.Key = "5j2gfx0y5m9mb1x6ejtz384p9b4hf5nq";

                    string Dir = ("Users\\" + label4.Text + "\\Combos" + "\\" + splitt[4] + " - " + splitt[1] + ".txt");

                    if (File.Exists(Dir))
                    {
                        DidntWork++;
                    }
                    else if (splitt[1] == "" || splitt[2] == "" || splitt[4] == "")
                    {
                        DidntWork++;
                    }
                    else
                    {
                        File.WriteAllText(Dir, Username + " " + Password);

                        Worked++;
                    }
                }

                MessageBox.Show("Successfully Imported: " + Worked + " Accounts  (" + DidntWork + " Were not Imported!)");
            }

            #endregion ImportPHP
        }

        private void AddCombo_Load(object sender, EventArgs e)
        {

        }
    }
}