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
    public partial class TeleportGateCreator : Form
    {
        public TeleportGateCreator()
        {
            InitializeComponent();
            config.database = "mu_game";
        }


        private void LoadDates()
        {
            comboBox1.SelectedIndex = -1;

            Sql_Querys sql_Querys = new();
            comboBox1.DataSource = Connect.loadData(sql_Querys.selectWorld);
            comboBox1.DisplayMember = "name";

            comboBox2.DataSource = Connect.loadData(sql_Querys.selectWorld);
            comboBox2.DisplayMember = "name";
            dataGridView2.DataSource = Connect.loadData(sql_Querys.AllTeleportGates);
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
        }
        private void TeleportGateCreator_Load(object sender, EventArgs e)
        {
            LoadDates();
        }

        private static void LoadWorldEntry()
        {
            Sql_Querys sql_Querys = new();
            if (Connect.loadData(sql_Querys.selectWorldEntryTeleport).Rows.Count >0)
            {
                PortalLocation.worldID = int.Parse(Connect.loadData(sql_Querys.selectWorldEntryTeleport).Rows[0].ItemArray[0].ToString());
            }
            
        }
        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            TeleportGateDestiy.worldName = comboBox1.Text;
            LoadWorldEntry();
        }

        private void comboBox2_DropDownClosed(object sender, EventArgs e)
        {
            TeleportGateDestiy.worldName = comboBox2.Text;
            LoadWorldEntry();
        }


        private void AddDestinyTeleport()
        {
            if (comboBox1.Text == "Select World Destiny")
            {
                MessageBox.Show("Select World Destiny");
                return;
            }
            TeleportGateDestiy.x = Convert.ToInt32(numericUpDown1.Value);
            TeleportGateDestiy.y = Convert.ToInt32(numericUpDown2.Value);
            TeleportGateDestiy.description = textBox3.Text;
            TeleportGateDestiy.flag = 0;

            Sql_Querys sql_Querys = new();
            Connect.update(sql_Querys.InsertDestinyGate);
            textBox1.Text = Connect.loadData(sql_Querys.ReturnLastIDGate).Rows[0].ItemArray[0].ToString();
        }

        private void AddPortalLocation()
        {

            if (comboBox2.Text == "Select World Destiny")
            {
                MessageBox.Show("Select World Portal");
                return;
            }

            if (textBox2.Text == "")
            {
                MessageBox.Show("Insert ID Destiny");
                return;
            }
            PortalLocation.x = Convert.ToInt32(numericUpDown4.Value);
            PortalLocation.y = Convert.ToInt32(numericUpDown3.Value);
            PortalLocation.description = textBox4.Text;
            PortalLocation.flag = 1;
            PortalLocation.ID_Destiny = int.Parse(textBox2.Text);

            Sql_Querys sql_Querys = new();
            Connect.update(sql_Querys.InsertPortalLocation);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddDestinyTeleport();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddPortalLocation();
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                textBox5.Text = textBox2.Text = row.Cells[1].Value.ToString();
                PortalLocation.ID_Destiny = int.Parse(textBox5.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                MessageBox.Show("Insert ID Gate");
                return;
            }
            Sql_Querys sql_Querys = new();
            Connect.update(sql_Querys.DeleteGates);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Sql_Querys sql_Querys = new();
            dataGridView2.DataSource = Connect.loadData(sql_Querys.AllTeleportGates);

        }


    }
}
