using APP_MU.Database;
using APP_MU.DataBase;
using APP_MU.Models;
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

namespace APP_MU.Forms.Administrator
{
    public partial class Guild : Form
    {
        public Guild()
        {
            InitializeComponent();
            config.database = "mu_online_characters";
        }


        static public string DecodeFrom64(string dados)
        {
            try
            {
                byte[] dadosAsBytes = System.Convert.FromBase64String(dados);
                string resultado = System.Text.ASCIIEncoding.ASCII.GetString(dadosAsBytes);
                return resultado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadGuildList()
        {
            Sql_Querys sql_Querys = new();
            dataGridView1.DataSource = Connect.loadData(sql_Querys.loadGuildList).DefaultView.ToTable(true, "guid", "name", "hostil", "alliance", "notice", "score");
            dataGridView1.Columns[0].Visible = false;
        }


        private void Guild_Load(object sender, EventArgs e)
        {
            LoadGuildList();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex != this.dataGridView1.NewRowIndex)
            {
                e.Value = DecodeFrom64(e.Value.ToString());
            }
        }

        private void loadGuildMembers()
        {
            Sql_Querys sql_Querys = new();
            dataGridView2.DataSource = Connect.loadData(sql_Querys.loadGuildMembers);
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                GuildManage.idGuild = int.Parse(row.Cells[0].Value.ToString());
            }

            loadGuildMembers();
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string rank;
           
            if (e.ColumnIndex == 2 && e.RowIndex != this.dataGridView2.NewRowIndex)
            {
                switch (e.Value.ToString())
                {
                        case "32":
                        e.Value = "Battle Master";
                        break;

                        case "64":
                        e.Value = "Assistent";
                        break;

                        case "128":
                        e.Value = "Master";
                        break;

                    case "0":
                        e.Value = "Normal";
                        break;

                    case "255":
                        e.Value = "None";
                        break;
                }
            }
        }
    }
}
