using APP_MU.Database;
using APP_MU.DataBase;
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

namespace APP_MU.Forms.Administrator
{
    public partial class Admin_Accounts : Form
    {
        public Admin_Accounts()
        {
            InitializeComponent();
            config.database = "mu_online_login";
        }

        public void loadInfo()
        {
            comboBox1.SelectedIndex = 0;
            Sql_Querys sql_Querys = new();
            if (Connect.loadData(sql_Querys.admin_info_account).Rows.Count > 0)
            {
                textBox1.Text = Connect.loadData(sql_Querys.admin_info_account).Rows[0].ItemArray[7].ToString();
                textBox3.Text = Connect.loadData(sql_Querys.admin_info_account).Rows[0].ItemArray[8].ToString();
                comboBox1.SelectedIndex = int.Parse(Connect.loadData(sql_Querys.admin_info_account).Rows[0].ItemArray[9].ToString());
                textBox2.Text = Connect.loadData(sql_Querys.admin_info_account).Rows[0].ItemArray[0].ToString();
                textBox5.Text = Connect.loadData(sql_Querys.admin_info_account).Rows[0].ItemArray[13].ToString();
                textBox4.Text = Connect.loadData(sql_Querys.admin_info_account).Rows[0].ItemArray[12].ToString();
                textBox6.Text = Connect.loadData(sql_Querys.admin_info_account).Rows[0].ItemArray[11].ToString();
            }
            else
                MessageBox.Show("Player does not start the game");
        }

        public void saveInfo()
        {
            infoAccounts.email = textBox1.Text;
            infoAccounts.type_account = comboBox1.SelectedIndex;
            //infoAccounts.vip_status = checkBox1.Checked;
            infoAccounts.vip_duration = int.Parse(textBox6.Text);
            infoAccounts.credits = int.Parse(textBox4.Text);
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    infoAccounts.type_account = 0;
                    infoAccounts.blocked = 0;
                    break;

                case 1:
                    infoAccounts.type_account = 1;
                    infoAccounts.blocked = 1;
                    break;

                case 2:
                    infoAccounts.type_account = 2;
                    infoAccounts.blocked = 0;
                    break;
            }
            Sql_Querys sql_Querys = new();
            Connect.update(sql_Querys.admin_info_account_save);
        }

        private void Admin_Accounts_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            //Main main = new();
            //main.ShowDialog();
        }

        private void Admin_Accounts_Load(object sender, EventArgs e)
        {
            Sql_Querys sql_Querys = new();
            dataGridView1.DataSource = Connect.loadData(sql_Querys.admin_all_player);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string vid = row.Cells[0].Value.ToString();

                infoAccounts.account_id = infoAccounts.guid = int.Parse(vid);
            }
            loadInfo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveInfo();
        }
    }
}