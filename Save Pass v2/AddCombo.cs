using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Save_Pass_v2
{
    public partial class AddCombo : Form
    {
        public static string MD5usr;
        public static string IV;
        public static string Key;

        public AddCombo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"Users\" + MD5usr))
            {
                if (providerTextbox.Text == "" || emailTextbox.Text == "" || passwordTextbox.Text == "" || providerTextbox.Text.Contains(" ") || emailTextbox.Text.Contains(" ") || passwordTextbox.Text.Contains(" "))
                {
                    MessageBox.Show("Fields cannot be blank or contain a space!");
                }
                else
                {
                    string combinedCombo = providerTextbox.Text + " " + emailTextbox.Text + " " + passwordTextbox.Text;
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
                            if (providerTextbox.Text == splittLine[0] && emailTextbox.Text == splittLine[1])
                            {
                                counter++;
                            }
                        }
                    }

                    if (counter == 0)
                    {
                        File.AppendAllText(@"Users\" + MD5usr, encryptedCombo + Environment.NewLine);
                        MessageBox.Show("Combo added successfully!");
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

        private void AddCombo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Text File";
            theDialog.Filter = "TXT files|*.txt";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                label4.Text = theDialog.FileName;
                MessageBox.Show("Starting, might take a while!");
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string[] ReadLine = File.ReadAllLines(label4.Text);
            int Worked = 0;
            int DidntWork = 0;


            foreach (string item in ReadLine)
            {
                if (item == ReadLine[0])
                { }
                else
                {
                    try
                    {
                        int counter;
                        var splitLines = Regex.Split(item, ",");
                        Crypter.Aes.IV = IV;
                        Crypter.Aes.Key = Key;
                        string removeHttps = Regex.Replace(splitLines[0], "https://", "");
                        string removeHttp = Regex.Replace(removeHttps, "http://", "");
                        string removeWWW = Regex.Replace(removeHttp, "www.", "");
                        if (removeWWW != "" && splitLines[1] != "" && splitLines[2] != "")
                        {
                            string encryptedCombo = Crypter.Aes.Encrypt(removeWWW + " " + splitLines[1] + " " + splitLines[2]);
                            string[] lines = File.ReadAllLines(@"Users\" + MD5usr);
                            counter = 0;
                            foreach (string newitem in lines)
                            {
                                if (newitem == lines[0])
                                {
                                }
                                else
                                {
                                    Crypter.Aes.IV = IV;
                                    Crypter.Aes.Key = Key;
                                    string decryptedLine = Crypter.Aes.Decrypt(newitem);
                                    var splittLine = Regex.Split(decryptedLine, " ");
                                    if (removeWWW == splittLine[0] && splitLines[1] == splittLine[1])
                                    {
                                        counter++;
                                    }
                                }
                            }

                            if (counter == 0)
                            {
                                File.AppendAllText(@"Users\" + MD5usr, encryptedCombo + Environment.NewLine);
                                Worked++;
                            }
                            else
                            {
                                DidntWork++;
                            }
                        }
                        else
                        {
                            DidntWork++;
                        }
                    }
                    catch
                    {
                        DidntWork++;
                    }
                }
            }

            MessageBox.Show("Successfully Imported: " + Worked + " Accounts  (" + DidntWork + " Were not Imported!)");
        }
    }
}
