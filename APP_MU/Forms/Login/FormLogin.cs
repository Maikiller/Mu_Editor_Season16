using APP_MU.Database;
using APP_MU.DataBase;
using APP_MU.Forms;
using APP_MU.Forms.Administrator;
using APP_MU.Forms.Login;
using APP_MU.Models;
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

namespace APP_MU
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            config.database = "mu_online_login";
        }

        public void login()
        {
            //login dev local
            string name = "admin";
            string pass = "local";
            Admin_main admin = new();
            if (textBox1.Text == name && textBox2.Text == pass)
            {
                MessageBox.Show("Mod DEVELOP");
                admin.Show();
                return;
            }

            Account.account = textBox1.Text;
            Account.password = ComputeSha256Hash(textBox1.Text + ":" + textBox2.Text);

            Sql_Querys sql_Querys = new();

            if (Connect.loadData(sql_Querys.authenticate).Rows.Count >= 1)
            {
                this.Hide();
                Main main = new();
                main.ShowDialog();
            }
            else
                MessageBox.Show("account/password incorrect");
            textBox1.Text = "";
            textBox2.Text = "";
        }

        public static string ComputeSha256Hash(string pass)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(pass));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public void SavedText()
        {
            StreamWriter sw = new("Saved.txt");
            sw.WriteLine("----Account----");
            sw.WriteLine(textBox1.Text);
            sw.WriteLine("----DataBase----");
            sw.WriteLine(config.server);
            sw.WriteLine(config.user);
            sw.WriteLine(config.password);
            sw.WriteLine(config.port);
            sw.Close();
        }

        public void LoadText()
        {
            try
            {
                string[] lines = File.ReadAllLines("Saved.txt");
                if (lines.Length > 0)
                {
                    textBox1.Text = lines[1];
                    config.server = lines[3];
                    config.user = lines[4];
                    config.password = lines[5];
                    config.port = lines[6];
                }
            }
            catch
            {
                StreamWriter sw = new("Saved.txt");
                sw.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SavedText();
            login();
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            CreateAccount createAccount = new();
            createAccount.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            IPConfig iPConfig = new();
            iPConfig.ShowDialog();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            LoadText();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SavedText();
                login();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SavedText();
                login();
            }
        }
    }
}