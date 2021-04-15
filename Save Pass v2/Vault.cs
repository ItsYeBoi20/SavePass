using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Save_Pass_v2
{
    public partial class Vault : Form
    {
        public static string login;
        public static string usr;
        public static string pwd;

        public Vault()
        {
            InitializeComponent();
        }

        private void comboButton_Click(object sender, EventArgs e)
        {
            AddCombo.MD5usr = login;
            AddCombo.IV = pwd;
            AddCombo.Key = usr;
            AddCombo ac = new AddCombo();
            ac.Show();
        }

        private void Vault_Load(object sender, EventArgs e)
        {
            refreshList();
        }

        private void Vault_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            refreshList();
        }

        public void refreshList()
        {            
            comboList.Items.Clear();
            string[] lines = File.ReadAllLines(@"Users\" + login);
            foreach (string item in lines)
            {
                if (item == lines[0])
                {
                }
                else
                {
                    Crypter.Aes.IV = pwd;
                    Crypter.Aes.Key = usr;
                    string decryptedCombo = Crypter.Aes.Decrypt(item);
                    var splittedCombo = Regex.Split(decryptedCombo, " ");
                    comboList.Items.Add(splittedCombo[0] + " - " + splittedCombo[1] + "   ﻿");
                }
            }
        }

        private void comboList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                string[] lines = File.ReadAllLines(@"Users\" + login);
                foreach (string item in lines)
                {
                    if (item == lines[0])
                    {
                    }
                    else
                    {
                        Crypter.Aes.IV = pwd;
                        Crypter.Aes.Key = usr;
                        string decryptedCombo = Crypter.Aes.Decrypt(item);
                        var splittedCombo = Regex.Split(decryptedCombo, " ");
                        var splittiedList = Regex.Split(comboList.SelectedItem.ToString(), " ");

                        if (splittiedList[0] == (splittedCombo[0]) && splittiedList[2] == (splittedCombo[1]))
                        {
                            Combo c = new Combo();
                            Combo.aesCombo = item;
                            Combo.MD5usr = login;
                            Combo.IV = pwd;
                            Combo.Key = usr;
                            c.textBox3.Text = splittedCombo[0];
                            c.textBox1.Text = splittedCombo[1];
                            c.textBox2.Text = splittedCombo[2];
                            c.Text = splittedCombo[0];
                            c.Show();
                        }
                    }
                }
            }
            catch
            { }
        }
    }
}
