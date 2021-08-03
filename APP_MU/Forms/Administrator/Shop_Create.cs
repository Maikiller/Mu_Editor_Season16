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
    public partial class Shop_Create : Form
    {
        public Shop_Create()
        {
            InitializeComponent();
            config.database = "mu_game";
        }

        public void LoadNPC()
        {
            Sql_Querys sql_Querys0 = new();
            dataGridView1.DataSource = Connect.loadData(sql_Querys0.select_npc);
            Sql_Querys sql_Querys1 = new();
            dataGridView2.DataSource = Connect.loadData(sql_Querys1.selectModel);
            Sql_Querys sql_Querys2 = new();
            comboBox1.DataSource = Connect.loadData(sql_Querys2.selectWorld);
            comboBox1.DisplayMember = "name";
        }

        private void Shop_Create_Load(object sender, EventArgs e)
        {
            LoadNPC();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            NpcShop.world_name = comboBox1.Text;
            Sql_Querys sql_Querys = new();
            if (Connect.loadData(sql_Querys.selectWorldEntry).Rows.Count > 0)
            {
                NpcShop.world_entry = int.Parse(Connect.loadData(sql_Querys.selectWorldEntry).Rows[0].ItemArray[0].ToString());
            }
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                int idModel = int.Parse(row.Cells[0].Value.ToString());
                string nameModel = row.Cells[1].Value.ToString();
                textBox7.Text = nameModel;
                NpcShop.model_id_selected = idModel;
                NpcShop.npc_name = nameModel;
            }
        }

        public void ClearInputs()
        {
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;
            numericUpDown6.Value = 0;
            numericUpDown7.Value = 0;
            numericUpDown8.Value = 0;
            numericUpDown9.Value = 0;
            numericUpDown10.Value = 0;
            numericUpDown11.Value = 0;
            numericUpDown12.Value = 0;
            numericUpDown13.Value = 0;
            numericUpDown14.Value = 0;
            numericUpDown15.Value = 0;
            textBox1.Text = "0";
            textBox2.Text = "";
            textBox8.Text = "";
            textBox3.Text = "";
            textBox7.Text = "0";
        }

        public void InsertInputs()
        {
            //Insert Monster Table
            NpcShop.disabled = 0;
            NpcShop.server = int.Parse(textBox1.Text);
            NpcShop.id = Convert.ToInt32(numericUpDown1.Value);
            NpcShop.x1 = Convert.ToInt32(numericUpDown9.Value);
            NpcShop.y1 = Convert.ToInt32(numericUpDown10.Value);
            NpcShop.x2 = Convert.ToInt32(numericUpDown11.Value);
            NpcShop.y2 = Convert.ToInt32(numericUpDown12.Value);
            NpcShop.direction = Convert.ToInt32(numericUpDown13.Value);
            NpcShop.spawn_delay = Convert.ToInt32(numericUpDown2.Value);
            NpcShop.spawn_distance = Convert.ToInt32(numericUpDown3.Value);
            NpcShop.respawn_time_min = Convert.ToInt32(numericUpDown4.Value);
            NpcShop.respawn_time_max = Convert.ToInt32(numericUpDown5.Value);
            NpcShop.respawn_id = Convert.ToInt32(numericUpDown6.Value);
            NpcShop.move_distance = Convert.ToInt32(numericUpDown7.Value);
            NpcShop.elemental_attribute = Convert.ToInt32(numericUpDown8.Value);

            //Insert Shop_template Table
            NpcShop.guidCustomNPC = Convert.ToInt32(numericUpDown15.Value);
            NpcShop.npc_name = textBox8.Text;
            NpcShop.pk_count = Convert.ToInt32(numericUpDown14.Value);
            NpcShop.pk_text = textBox2.Text;

            if (checkBox1.CheckState == CheckState.Checked)
            {
                NpcShop.disabled = 1;
            }
        }

        public void SaveNPC()
        {
            InsertInputs();


            Sql_Querys sql_Querys = new();

            if (Connect.loadData(sql_Querys.load_custom_npc).Rows.Count > 0)
            {


                if (Connect.loadData(sql_Querys.load_custom_npc).Rows[0].ItemArray[15].ToString() == textBox8.Text)
                {
                    MessageBox.Show(textBox8.Text + " already exists");
                }
            }
            else
            {
                if (Connect.loadData(sql_Querys.verifierID).Rows.Count > 0)
                {
                    if (Connect.loadData(sql_Querys.verifierID).Rows[0].ItemArray[0].ToString() == NpcShop.id.ToString())
                        MessageBox.Show("This ID_Monster " + NpcShop.id + " is already in use. Recommended ID: 11000K upwards;");
                }
                else if (Connect.loadData(sql_Querys.verifierIDShop).Rows.Count > 0)
                {
                    if (Connect.loadData(sql_Querys.verifierIDShop).Rows[0].ItemArray[0].ToString() == NpcShop.guidCustomNPC.ToString())
                        MessageBox.Show("This ID_SHOP " + NpcShop.guidCustomNPC + " is already in use. Recommended ID: 240K upwards;");
                }
                else
                {
                    Connect.update(sql_Querys.insertNPC);
                    Connect.update(sql_Querys.insertShop);
                    MessageBox.Show("NPC Custom Create");
                    dataGridView1.DataSource = Connect.loadData(sql_Querys.select_npc);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == "" || textBox8.Text == "")
            {
                MessageBox.Show("Select Model or Insert Name");
            }
            else
            {
                SaveNPC();
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string name = row.Cells[1].Value.ToString();
                string idCustom = row.Cells[0].Value.ToString();
                NpcShop.npc_name = name;
                NpcShop.guidCustomNPC = int.Parse(idCustom);
                textBox3.Text = name;
            }
            LoadInputs();
        }

        public void DeleteNPC()
        {
            if (textBox3.Text == "")
                MessageBox.Show("Select NPC Shop");
            else
            {
                Sql_Querys sql_Querys = new();
                Connect.update(sql_Querys.delete_npc);
                dataGridView1.DataSource = Connect.loadData(sql_Querys.select_npc);
                ClearInputs();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteNPC();
        }

        public void LoadInputs()
        {
            checkBox1.Checked = false;
            Sql_Querys sql_Querys = new();

            if (Connect.loadData(sql_Querys.load_custom_npc).Rows.Count > 0)
            {
                numericUpDown1.Value = Convert.ToDecimal(Connect.loadData(sql_Querys.load_custom_npc).Rows[0].ItemArray[1].ToString());
                numericUpDown2.Value = Convert.ToDecimal(Connect.loadData(sql_Querys.load_custom_npc).Rows[0].ItemArray[9].ToString());
                numericUpDown3.Value = Convert.ToDecimal(Connect.loadData(sql_Querys.load_custom_npc).Rows[0].ItemArray[10].ToString());
                numericUpDown4.Value = Convert.ToDecimal(Connect.loadData(sql_Querys.load_custom_npc).Rows[0].ItemArray[11].ToString());
                numericUpDown5.Value = Convert.ToDecimal(Connect.loadData(sql_Querys.load_custom_npc).Rows[0].ItemArray[12].ToString());
                numericUpDown6.Value = Convert.ToDecimal(Connect.loadData(sql_Querys.load_custom_npc).Rows[0].ItemArray[13].ToString());
                numericUpDown7.Value = Convert.ToDecimal(Connect.loadData(sql_Querys.load_custom_npc).Rows[0].ItemArray[14].ToString());
                numericUpDown8.Value = Convert.ToDecimal(Connect.loadData(sql_Querys.load_custom_npc).Rows[0].ItemArray[16].ToString());
                numericUpDown9.Value = Convert.ToDecimal(Connect.loadData(sql_Querys.load_custom_npc).Rows[0].ItemArray[4].ToString());
                numericUpDown10.Value = Convert.ToDecimal(Connect.loadData(sql_Querys.load_custom_npc).Rows[0].ItemArray[5].ToString());
                numericUpDown11.Value = Convert.ToDecimal(Connect.loadData(sql_Querys.load_custom_npc).Rows[0].ItemArray[6].ToString());
                numericUpDown12.Value = Convert.ToDecimal(Connect.loadData(sql_Querys.load_custom_npc).Rows[0].ItemArray[7].ToString());
                numericUpDown13.Value = Convert.ToDecimal(Connect.loadData(sql_Querys.load_custom_npc).Rows[0].ItemArray[8].ToString());
                numericUpDown14.Value = Convert.ToDecimal(Connect.loadData(sql_Querys.load_custom_npc).Rows[0].ItemArray[18].ToString());
                numericUpDown15.Value = Convert.ToDecimal(Connect.loadData(sql_Querys.load_custom_npc).Rows[0].ItemArray[21].ToString());
                textBox1.Text = Connect.loadData(sql_Querys.load_custom_npc).Rows[0].ItemArray[0].ToString();
                textBox2.Text = Connect.loadData(sql_Querys.load_custom_npc).Rows[0].ItemArray[19].ToString();
                textBox8.Text = Connect.loadData(sql_Querys.load_custom_npc).Rows[0].ItemArray[15].ToString();
                textBox7.Text = Connect.loadData(sql_Querys.load_custom_npc).Rows[0].ItemArray[20].ToString();
                if (Connect.loadData(sql_Querys.load_custom_npc).Rows[0].ItemArray[17].ToString() == "1")
                {
                    checkBox1.Checked = true;
                }
            }
            else
                MessageBox.Show("NPC Shop Broken");
        }

        public void UpdateNPC()
        {
            if (textBox3.Text != "")
            {
                InsertInputs();
                Sql_Querys sql_Querys = new();
                Connect.update(sql_Querys.update_npc);
                MessageBox.Show("NPC Shop Update");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateNPC();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            String searchValue = textBox4.Text;
            int rowIndex = 0;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells[1].Value.ToString().Equals(searchValue))
                {
                    rowIndex = row.Index;
                    break;
                }
            }
            dataGridView2.Rows[rowIndex].Selected = true;
        }
    }
}