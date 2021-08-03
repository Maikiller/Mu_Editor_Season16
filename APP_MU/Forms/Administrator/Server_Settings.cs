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
    public partial class Server_Settings : Form
    {
        public Server_Settings()
        {
            InitializeComponent();
            config.database = "mu_game";
        }

        public void LoadInfos()
        {
            //comboBox1.SelectedIndex = 1;
        }
        private void Server_Settings_Load(object sender, EventArgs e)
        {
            LoadInfos();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServerSettings.server_id = int.Parse(comboBox1.Text);
            Sql_Querys sql_Querys = new();
            dataGridView1.DataSource = Connect.loadData(sql_Querys.load_server_settings);
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            ServerSettings.key = row.Cells[0].Value.ToString();
            ServerSettings.value = row.Cells[1].Value.ToString();

            Sql_Querys sql_Querys = new();

            Connect.loadData(sql_Querys.update_server_settings);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
