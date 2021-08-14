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
    public partial class Monster : Form
    {
        public Monster()
        {
            InitializeComponent();
            config.database = "mu_game";
        }


        private void LoadData()
        {
            Sql_Querys sql_Querys = new();
            dataGridView1.DataSource = Connect.loadData(sql_Querys.LoadMonster);
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[13].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView1.Columns[14].Visible = false;
            dataGridView1.Columns[15].Visible = false;

            comboBox1.DataSource = Connect.loadData(sql_Querys.selectWorld);
            comboBox1.DisplayMember = "name";
            comboBox1.SelectedIndex = -1;

            comboBox3.DataSource = Connect.loadData(sql_Querys.selectWorld);
            comboBox3.DisplayMember = "name";
            comboBox3.SelectedIndex = -1;

            comboBox2.DataSource = Connect.loadData(sql_Querys.loadAllMonster);
            comboBox2.DisplayMember = "name";
            comboBox2.SelectedIndex = -1;

        }

        private void Monster_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            MonsterSpot.nameWorldFind = comboBox1.Text;
            Sql_Querys sql_Querys = new();
            dataGridView1.DataSource = Connect.loadData(sql_Querys.LoadMonster_findtoWorld);
        }


        private void LoadMonsterID()
        {
            Sql_Querys sql_Querys = new();
            MonsterSpot.id = int.Parse(Connect.loadData(sql_Querys.nameMonster).Rows[0].ItemArray[0].ToString());
        }
        private void comboBox2_DropDownClosed(object sender, EventArgs e)
        {
            if (comboBox2.Text == "")
            {
                return;
            }
            MonsterSpot.nameMonster = comboBox2.Text;
            LoadMonsterID();
        }

        private void LoadWorldID()
        {
            Sql_Querys sql_Querys = new();
            MonsterSpot.WorldID = int.Parse(Connect.loadData(sql_Querys.selectWorldEntry).Rows[0].ItemArray[0].ToString());
        }
        private void comboBox3_DropDownClosed(object sender, EventArgs e)
        {
            if (comboBox3.Text == "")
            {
                return;
            }
            NpcShop.world_name = comboBox3.Text;
            LoadWorldID();
        }
        private void addMonster()
        {
            if (comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || comboBox4.Text == "")
            {
                MessageBox.Show("Insert Values");
                return;
            }
            MonsterSpot.x1 = int.Parse(textBox1.Text);
            MonsterSpot.y1 = int.Parse(textBox2.Text);
            MonsterSpot.x2 = int.Parse(textBox12.Text);
            MonsterSpot.y2 = int.Parse(textBox11.Text);
            MonsterSpot.direction = int.Parse(textBox3.Text);
            MonsterSpot.spawn_delay = int.Parse(textBox10.Text);
            MonsterSpot.respawn_id = int.Parse(textBox6.Text);
            MonsterSpot.move_distance = int.Parse(textBox5.Text);
            MonsterSpot.elemental_attribute = int.Parse(textBox4.Text);
            MonsterSpot.respawn_time_min = int.Parse(textBox14.Text);
            MonsterSpot.respawn_time_max = int.Parse(textBox13.Text);
            MonsterSpot.spawn_distance = int.Parse(textBox15.Text);
            MonsterSpot.itemBag = textBox7.Text;

            Sql_Querys sql_Querys1 = new();
            MonsterSpot.guid = int.Parse(Connect.loadData(sql_Querys1.lastInsertMonsterGUID).Rows[0].ItemArray[0].ToString()) + 1;
            Sql_Querys sql_Querys = new();
            Connect.update(sql_Querys.insertMonster);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addMonster();
            Sql_Querys sql_Querys = new();
            dataGridView1.DataSource = Connect.loadData(sql_Querys.LoadMonster_findtoWorld);
        }

        private void comboBox4_DropDownClosed(object sender, EventArgs e)
        {
            if (comboBox4.Text == "")
            {
                return;
            }
            MonsterSpot.server = int.Parse(comboBox4.Text);
        }

        private void deleteMonster()
        {
            if (MonsterSpot.id == null || MonsterSpot.guid == null)
            {
                MessageBox.Show("Select Monster");
                return;
            }
            Sql_Querys sql_Querys = new();
            Connect.loadData(sql_Querys.deleteMonster);
            textBox8.Text = null;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            deleteMonster();
            Sql_Querys sql_Querys = new();
            dataGridView1.DataSource = Connect.loadData(sql_Querys.LoadMonster_findtoWorld);
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                MonsterSpot.id = int.Parse(row.Cells[14].Value.ToString());
                MonsterSpot.guid = int.Parse(row.Cells[15].Value.ToString());
                textBox8.Text = row.Cells[0].Value.ToString();
            }
        }
    }
}
