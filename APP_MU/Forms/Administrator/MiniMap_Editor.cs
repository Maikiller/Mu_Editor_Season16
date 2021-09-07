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
    public partial class MiniMap_Editor : Form
    {
        public MiniMap_Editor()
        {
            InitializeComponent();

        }

        public void LoadInfos()
        {
            comboBox2.SelectedIndex = 0;
            Sql_Querys sql_Query = new();

            config.database = "mu_online_login";
            comboBox1.DataSource = Connect.loadData(sql_Query.IDServerList);
            comboBox1.DisplayMember = "server";
            config.database = "mu_game";
            comboBox3.DataSource = Connect.loadData(sql_Query.selectWorld);
            comboBox3.SelectedIndex = -1;
            if (MiniMap.Server == null)
            {
                return;
            }
            else
            {
                dataGridView2.DataSource = Connect.loadData(sql_Query.loadAllMinimap);
            }


        }

        private void MiniMap_Editor_Load(object sender, EventArgs e)
        {
            LoadInfos();
        }

        private void comboBox3_DropDownClosed(object sender, EventArgs e)
        {
            MiniMap.MapName = comboBox3.Text;
            MiniMap.Server = int.Parse(comboBox1.Text);
            Sql_Querys sql_Query = new();
            dataGridView2.DataSource = Connect.loadData(sql_Query.loadAllMinimap);
            MiniMap.WorldEntry = Connect.loadData(sql_Query.FindWorldEntry).Rows[0].ItemArray[0].ToString();
        }


        private void SaveMiniMap()
        {

            Sql_Querys sql_Querys = new();
            if (Connect.loadData(sql_Querys.loadAllMinimap).Rows.Count > -1)
                MiniMap.index = 1;


            if (Connect.loadData(sql_Querys.loadAllMinimap).Rows.Count > 0)
                MiniMap.index = int.Parse(Connect.loadData(sql_Querys.LastIndexMiniMap).Rows[0].ItemArray[0].ToString()) + 1;

            MiniMap.group = Convert.ToInt32(numericUpDown1.Value);
            MiniMap.x = Convert.ToInt32(numericUpDown4.Value);
            MiniMap.y = Convert.ToInt32(numericUpDown7.Value);
            //MiniMap.type = int.Parse(comboBox2.Text);
            MiniMap.text = textBox7.Text;

            Sql_Querys sql_Querys1 = new();
            Connect.update(sql_Querys1.SaveMiniMap);
            dataGridView2.DataSource = Connect.loadData(sql_Querys1.loadAllMinimap);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            SaveMiniMap();
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
            MiniMap.index = int.Parse(row.Cells[1].Value.ToString());
            MiniMap.Server = int.Parse(row.Cells[7].Value.ToString());

            numericUpDown1.Value = int.Parse(row.Cells[2].Value.ToString());
            numericUpDown4.Value = int.Parse(row.Cells[4].Value.ToString());
            numericUpDown7.Value = int.Parse(row.Cells[5].Value.ToString());
            comboBox2.Text = row.Cells[3].Value.ToString();
            textBox1.Text = row.Cells[1].Value.ToString();
            textBox7.Text = row.Cells[6].Value.ToString();
        }


        private void DeleteMinimap()
        {
            Sql_Querys sql_Querys = new();
            Connect.update(sql_Querys.DeleteMiniMap);
            dataGridView2.DataSource = Connect.loadData(sql_Querys.loadAllMinimap);
            textBox1.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DeleteMinimap();
        }

        private void UpdateMinimap()
        {
            //MiniMap.group = Convert.ToInt32(numericUpDown1.Value);
            //MiniMap.type = int.Parse(comboBox2.Text);
            MiniMap.x = Convert.ToInt32(numericUpDown4.Value);
            MiniMap.y = Convert.ToInt32(numericUpDown7.Value);
            MiniMap.text = textBox7.Text;

            Sql_Querys sql_Querys = new();
            Connect.update(sql_Querys.UpdateMiniMap);
            dataGridView2.DataSource = Connect.loadData(sql_Querys.loadAllMinimap);


        }
        private void button1_Click(object sender, EventArgs e)
        {
            UpdateMinimap();
        }

        private void comboBox2_DropDownClosed(object sender, EventArgs e)
        {
            switch (comboBox2.Text)
            {
                case "Doors":
                    MiniMap.type = 0;
                    MiniMap.group = 0;
                    break;
                case "Spot":
                    MiniMap.type = 1;
                    MiniMap.group = 1;
                    break;
                case "Quote":
                    MiniMap.type = 2;
                    MiniMap.group = 1;
                    break;
                case "Miner":
                    MiniMap.type = 3;
                    MiniMap.group = 1;
                    break;
                case "Potion":
                    MiniMap.type = 4;
                    MiniMap.group = 1;
                    break;
                case "Lock":
                    MiniMap.type = 5;
                    MiniMap.group = 1;
                    break;
                case "Icon ???":
                    MiniMap.type = 6;
                    MiniMap.group = 1;
                    break;

            }

        }
    }
}
