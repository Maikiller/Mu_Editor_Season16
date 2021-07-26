using APP_MU.Database;
using APP_MU.DataBase;
using APP_MU.Forms.Administrator;
using APP_MU.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_MU.Forms
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            config.database = "mu_online_login";
        }

        public void LoadData()
        {
            Sql_Querys sql_Querys = new();
            label2.Text = Connect.loadData(sql_Querys.authenticate).Rows[0].ItemArray[0].ToString();
            if (int.Parse(Connect.loadData(sql_Querys.authenticate).Rows[0].ItemArray[9].ToString()) == 2)
            {
                button2.Visible = true;
            }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormLogin login = new();
            login.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserForm userForm = new();
            userForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_main main = new();
            main.Show();
        }
    }
}