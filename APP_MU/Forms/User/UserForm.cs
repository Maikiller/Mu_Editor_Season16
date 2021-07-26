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

namespace APP_MU.Forms
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
        }

        public void loadDate()
        {
            Sql_Querys sql_Querys = new();
            textBox3.Text = Connect.loadData(sql_Querys.authenticate).Rows[0].ItemArray[8].ToString();
            textBox1.Text = Connect.loadData(sql_Querys.authenticate).Rows[0].ItemArray[0].ToString();
            textBox2.Text = Connect.loadData(sql_Querys.authenticate).Rows[0].ItemArray[7].ToString();
            if (Connect.loadData(sql_Querys.authenticate).Rows[0].ItemArray[6].ToString() == "1")
            {
                checkBox1.Checked = true;
            }

            switch (int.Parse(Connect.loadData(sql_Querys.authenticate).Rows[0].ItemArray[9].ToString()))
            {
                case 0:
                    comboBox1.SelectedIndex = 0;
                    break;

                case 1:
                    comboBox1.SelectedIndex = 1;
                    break;

                case 2:
                    comboBox1.SelectedIndex = 2;
                    break;
            }
        }

        private void UserForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Main main = new();
            main.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            label5.Visible = false;
            textBox4.Visible = false;
            //button1.Visible = false;
            infoAccounts.secured = 0;
            if (checkBox1.CheckState == CheckState.Checked)
            {
                label5.Visible = true;
                textBox4.Visible = true;
                button1.Visible = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            label6.Visible = false;
            label7.Visible = false;
            label9.Visible = false;
            label8.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox8.Visible = false;
            textBox7.Visible = false;
            button2.Visible = false;
            if (checkBox2.CheckState == CheckState.Checked)
            {
                label6.Visible = true;
                label7.Visible = true;
                label9.Visible = true;
                label8.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox8.Visible = true;
                textBox7.Visible = true;
                button2.Visible = true;
            }
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            loadDate();
        }

        public void saveSecured()
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                infoAccounts.secured = 1;
            }
            infoAccounts.secured_code = textBox4.Text;

            MessageBox.Show(infoAccounts.secured_code.ToString());
            Sql_Querys sql_Querys = new();
            Connect.update(sql_Querys.changeSecureUpdate);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveSecured();
        }
    }
}