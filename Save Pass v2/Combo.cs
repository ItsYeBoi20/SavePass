using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Save_Pass_v2
{
    public partial class Combo : Form
    {
        public static string aesCombo;
        public static string MD5usr;
        public static string IV;
        public static string Key;

        public Combo()
        {
            InitializeComponent();            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var tempFile = Path.GetTempFileName();
            var linesToKeep = File.ReadLines(@"Users\" + MD5usr).Where(l => l != aesCombo);

            File.WriteAllLines(tempFile, linesToKeep);

            File.Delete(@"Users\" + MD5usr);
            File.Move(tempFile, @"Users\" + MD5usr);

            if (File.Exists(@"Users\" + MD5usr))
            {
                if (textBox3.Text == "" || textBox1.Text == "" || textBox2.Text == "" || textBox3.Text.Contains(" ") || textBox1.Text.Contains(" ") || textBox2.Text.Contains(" "))
                {
                    MessageBox.Show("Fields cannot be blank or contain a space!");
                }
                else
                {
                    string combinedCombo = textBox3.Text + " " + textBox1.Text + " " + textBox2.Text;
                    Crypter.Aes.IV = IV;
                    Crypter.Aes.Key = Key;
                    string encryptedCombo = Crypter.Aes.Encrypt(combinedCombo);

                    int counter = 0;
                    string[] lines = File.ReadAllLines(@"Users\" + MD5usr);
                    foreach (string item in lines)
                    {
                        if (item == lines[0])
                        {
                        }
                        else
                        {
                            string decryptedLine = Crypter.Aes.Decrypt(item);
                            var splittLine = Regex.Split(decryptedLine, " ");
                            if (this.Text == splittLine[0] && textBox1.Text == splittLine[1])
                            {
                                counter++;
                            }
                        }
                    }

                    if (counter == 0)
                    {
                        File.AppendAllText(@"Users\" + MD5usr, encryptedCombo + Environment.NewLine);
                        MessageBox.Show("Combo changed successfully!");
                        this.Close();
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Combo already Exists!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Something went wrong!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void Combo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            button3.Enabled = true;
            button3.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this combo?", "Confirm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var tempFile = Path.GetTempFileName();
                var linesToKeep = File.ReadLines(@"Users\" + MD5usr).Where(l => l != aesCombo);

                File.WriteAllLines(tempFile, linesToKeep);

                File.Delete(@"Users\" + MD5usr);
                File.Move(tempFile, @"Users\" + MD5usr);
            }
            else if (dialogResult == DialogResult.No)
            {
            }
        }

        private void Combo_Load(object sender, EventArgs e)
        {
        }
    }
}
