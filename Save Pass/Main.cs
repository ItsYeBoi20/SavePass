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
using System.Text.RegularExpressions;

namespace Save_Pass
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            #region LoadIntoListBox

            string filepath = "Users\\" + label3.Text + "\\Combos";

            DirectoryInfo d = new DirectoryInfo(filepath);
            FileInfo[] Files = d.GetFiles("*.txt");
            foreach (FileInfo file in Files)
            {
                if (listBox1.Items.Contains(file.Name.Replace(".txt", "")))
                {

                }
                else
                {
                    listBox1.Items.Add(file.Name.Replace(".txt", ""));
                }
            }

            #endregion LoadIntoListBox
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            #region ShowClickedItem

            try
            {
                string SelectedItem = listBox1.SelectedItem.ToString();
                var tmp = SelectedItem.Split(new string[] { " - " }, StringSplitOptions.None);

                string ReadFile = File.ReadAllText("Users\\" + label3.Text + "\\Combos\\" + tmp[0] + " - " + tmp[1] + ".txt");
                var splitted = ReadFile.Split(new string[] { " " }, StringSplitOptions.None);

                string line = File.ReadLines("Users\\" + label3.Text + "\\salt.txt").Skip(1).Take(1).First();
                string DecryptKey = AesCryp.Decrypt(line);
                AesCryp.Key = DecryptKey;
                string emailDec = AesCryp.Decrypt(splitted[0]);
                string UserDec = AesCryp.Decrypt(splitted[1]);
                AesCryp.Key = "5j2gfx0y5m9mb1x6ejtz384p9b4hf5nq";

                string ReadSettings = File.ReadLines("Settings.ini").Skip(0).Take(1).First();
                if (ReadSettings == "ShowDetails = 0  | 0-1")
                {
                    Account_Details AC = new Account_Details();
                    AC.textBox1.Text = emailDec;
                    AC.textBox2.Text = UserDec;
                    AC.Email.Text = emailDec;
                    AC.Password.Text = UserDec;
                    AC.label3.Text = label3.Text;
                    AC.Text = (tmp[0]);
                    AC.Show();
                }
                else if (ReadSettings == "ShowDetails = 1  | 0-1")
                {
                    MessageBox.Show("Email: " + emailDec + Environment.NewLine + "Password: " + UserDec, "Account For: " + tmp[0]);
                }
                else
                {
                    MessageBox.Show("Problem with Settings File!");
                }

                #endregion ShowClickedItem
            }
            catch (Exception Ex)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            #region CloseAllForms

            Form1 obj = (Form1)Application.OpenForms["Form1"];
            obj.Close();

            #endregion CloseAllForms
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region ShowComboWindow

            AddCombo AddCombo = new AddCombo();
            AddCombo.label4.Text = label3.Text;
            AddCombo.Show();

            #endregion ShowComboWindow
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                }
                catch
                {

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            #region LoadIntoListBox

            string filepath = "Users\\" + label3.Text + "\\Combos";

            listBox1.Items.Clear();
            DirectoryInfo d = new DirectoryInfo(filepath);
            FileInfo[] Files = d.GetFiles("*.txt");
            foreach (FileInfo file in Files)
            {
                if (listBox1.Items.Contains(file.Name.Replace(".txt", "")))
                {

                }
                else
                {
                    listBox1.Items.Add(file.Name.Replace(".txt", ""));
                }
            }

            #endregion LoadIntoListBox
        }
    }
}