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
    public partial class Account_Details : Form
    {
        public Account_Details()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            button3.Enabled = true;
            button3.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            #region AES

            string line = File.ReadLines("Users\\" + label3.Text + "\\salt.txt").Skip(1).Take(1).First();
            string EncryptKey = AesCryp.Decrypt(line);

            AesCryp.Key = EncryptKey;
            string EmailAes = AesCryp.Encrypt(textBox1.Text);
            string PasswordAes = AesCryp.Encrypt(textBox2.Text);
            AesCryp.Key = "5j2gfx0y5m9mb1x6ejtz384p9b4hf5nq";

            #endregion AES

            #region CreateCombo

            string Dir = ("Users\\" + label3.Text + "\\Combos" + "\\" + this.Text + " - " + textBox1.Text + ".txt");

            File.Delete("Users\\" + label3.Text + "\\Combos" + "\\" + this.Text + " - " + Email.Text + ".txt");

            File.WriteAllText(Dir, EmailAes + " " + PasswordAes);
            MessageBox.Show("Combo Successfully Added");

            button3.Enabled = false;
            button3.Visible = false;

            #endregion CreateCombo
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                File.Delete("Users\\" + label3.Text + "\\Combos" + "\\" + this.Text + " - " + Email.Text + ".txt");
                MessageBox.Show("Successfully Deleted a Combo!");
            }
            catch
            {

            }
        }

        private void Account_Details_Load(object sender, EventArgs e)
        {

        }
    }
}
