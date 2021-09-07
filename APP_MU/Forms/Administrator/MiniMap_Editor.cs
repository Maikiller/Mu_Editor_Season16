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
            MiniMap.group = Convert.ToInt32(numericUpDown1.Value);
            MiniMap.index = 1672; //Colocar auto-incremento conforme que esta no banco
            MiniMap.x = Convert.ToInt32(numericUpDown4.Value);
            MiniMap.y = Convert.ToInt32(numericUpDown7.Value);
            MiniMap.type = int.Parse(comboBox2.Text);
            MiniMap.text = textBox7.Text;

            Sql_Querys sql_Querys = new();
            Connect.update(sql_Querys.SaveMiniMap);

            MessageBox.Show(MiniMap.WorldEntry);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            SaveMiniMap();
        }
    }
}
