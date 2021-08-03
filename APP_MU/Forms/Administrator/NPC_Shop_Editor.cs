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
    public partial class NPC_Shop_Editor : Form
    {
        public NPC_Shop_Editor()
        {
            InitializeComponent();
            config.database = "mu_game";
        }

        [Flags]
        public enum MyChechboxes
        {
            option1 = 1,
            option2 = 2,
            option3 = 4,
            option4 = 8,
            option5 = 16,
            option6 = 32,
        }

        public void LoadNpc()
        {
            Sql_Querys sql_Querys = new();
            comboBox1.DataSource = Connect.loadData(sql_Querys.select_npc_shop_name);
        }

        public void LoadNpcItems()
        {
            Sql_Querys sql_Querys1 = new();

            try
            {


                dataGridView1.DataSource = Connect.loadData(sql_Querys1.select_npc_shop_items).DefaultView.ToTable(true, "Item_Name", "Position_Bag", "durability", "guid");
                if (Connect.loadData(sql_Querys1.select_npc_shop_items).Rows.Count > 0)
                {
                    NpcShop.durability_quanty = int.Parse(Connect.loadData(sql_Querys1.select_npc_shop_items).Rows[0].ItemArray[2].ToString());
                }
                textBox1.Text = comboBox1.Text;
            }
            catch
            {
                MessageBox.Show("Add column [guid] auto-increment in mu_game.column");
            }



        }

        public void LoadItemDetail()
        {
            Sql_Querys sql_Querys = new();

            if (Connect.loadData(sql_Querys.select_item_npc).Rows.Count > 0)
            {
                textBox7.Text = Connect.loadData(sql_Querys.select_item_npc).Rows[0].ItemArray[0].ToString();
                numericUpDown1.Value = int.Parse(Connect.loadData(sql_Querys.select_item_npc).Rows[0].ItemArray[1].ToString());
                numericUpDown2.Value = int.Parse(Connect.loadData(sql_Querys.select_item_npc).Rows[0].ItemArray[2].ToString());
                numericUpDown6.Value = int.Parse(Connect.loadData(sql_Querys.select_item_npc).Rows[0].ItemArray[17].ToString());
                numericUpDown5.Value = int.Parse(Connect.loadData(sql_Querys.select_item_npc).Rows[0].ItemArray[5].ToString());
                textBox4.Text = Connect.loadData(sql_Querys.select_item_npc).Rows[0].ItemArray[8].ToString();
                textBox5.Text = Connect.loadData(sql_Querys.select_item_npc).Rows[0].ItemArray[9].ToString();
                textBox6.Text = Connect.loadData(sql_Querys.select_item_npc).Rows[0].ItemArray[10].ToString();
                textBox2.Text = Connect.loadData(sql_Querys.select_item_npc).Rows[0].ItemArray[11].ToString();
                textBox3.Text = Connect.loadData(sql_Querys.select_item_npc).Rows[0].ItemArray[12].ToString();
                numericUpDown8.Value = int.Parse(Connect.loadData(sql_Querys.select_item_npc).Rows[0].ItemArray[13].ToString());

                if (Connect.loadData(sql_Querys.select_item_npc).Rows[0].ItemArray[9].ToString() == "1")
                    checkBox9.Checked = true;
                if (Connect.loadData(sql_Querys.select_item_npc).Rows[0].ItemArray[3].ToString() == "1")
                    checkBox1.Checked = true;
                if (Connect.loadData(sql_Querys.select_item_npc).Rows[0].ItemArray[4].ToString() == "1")
                    checkBox8.Checked = true;

                // CheckBox's
                int sum = int.Parse(Connect.loadData(sql_Querys.select_item_npc).Rows[0].ItemArray[6].ToString());
                MyChechboxes checkeds = (MyChechboxes)sum;

                bool option1IsChecked = checkeds.HasFlag(MyChechboxes.option1);
                bool option2IsChecked = checkeds.HasFlag(MyChechboxes.option2);
                bool option3IsChecked = checkeds.HasFlag(MyChechboxes.option3);
                bool option4IsChecked = checkeds.HasFlag(MyChechboxes.option4);
                bool option5IsChecked = checkeds.HasFlag(MyChechboxes.option5);
                bool option6IsChecked = checkeds.HasFlag(MyChechboxes.option6);

                checkBox2.Checked = option1IsChecked;
                checkBox3.Checked = option2IsChecked;
                checkBox4.Checked = option3IsChecked;
                checkBox5.Checked = option4IsChecked;
                checkBox6.Checked = option5IsChecked;
                checkBox7.Checked = option6IsChecked;

                NpcShop.shopId = int.Parse(Connect.loadData(sql_Querys.select_item_npc).Rows[0].ItemArray[14].ToString());
                NpcShop.typeItem = int.Parse(Connect.loadData(sql_Querys.select_item_npc).Rows[0].ItemArray[15].ToString());
                NpcShop.indexItem = int.Parse(Connect.loadData(sql_Querys.select_item_npc).Rows[0].ItemArray[16].ToString());
            }
        }

        //Load onStart Form
        private void NPC_Shop_Editor_Load(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = -1;
            LoadNpc();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            NpcShop.name = comboBox1.Text;
            Sql_Querys sql_Querys = new();
            NpcShop.add_shop_GUID = int.Parse(Connect.loadData(sql_Querys.load_ID_shop).Rows[0].ItemArray[0].ToString());
            LoadNpcItems();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                checkBox1.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string item = row.Cells[0].Value.ToString();
                string guid = row.Cells[3].Value.ToString();
                string durability_quantity = row.Cells[2].Value.ToString();
                NpcShop.item = item;
                NpcShop.durability_quanty = int.Parse(durability_quantity);
                NpcShop.guid = int.Parse(guid);
            }
            LoadItemDetail();
        }

        public void UpdateItem()
        {
            NpcShop.level = Convert.ToInt32(numericUpDown1.Value);
            NpcShop.durability = Convert.ToInt32(numericUpDown2.Value);
            NpcShop.option = Convert.ToInt32(numericUpDown5.Value);
            NpcShop.skill = 0;
            NpcShop.luck = 0;
            NpcShop.ancient = 0;
            NpcShop.socket_1 = int.Parse(textBox4.Text);
            NpcShop.socket_2 = int.Parse(textBox5.Text);
            NpcShop.socket_3 = int.Parse(textBox6.Text);
            NpcShop.socket_4 = int.Parse(textBox2.Text);
            NpcShop.socket_5 = int.Parse(textBox3.Text);
            NpcShop.price = Convert.ToInt32(numericUpDown8.Value);
            NpcShop.position = Convert.ToInt32(numericUpDown6.Value);
            if (checkBox1.Checked == true)
                NpcShop.skill = 1;
            if (checkBox8.Checked == true)
                NpcShop.luck = 1;
            if (checkBox9.Checked == true)
                NpcShop.ancient = 1;

            int Check1 = checkBox2.CheckState == CheckState.Checked ? 1 : 0;
            int Check2 = checkBox3.CheckState == CheckState.Checked ? 2 : 0;
            int Check3 = checkBox4.CheckState == CheckState.Checked ? 4 : 0;
            int Check4 = checkBox5.CheckState == CheckState.Checked ? 8 : 0;
            int Check5 = checkBox6.CheckState == CheckState.Checked ? 16 : 0;
            int Check6 = checkBox7.CheckState == CheckState.Checked ? 32 : 0;

            int result = Check1 + Check2 + Check3 + Check4 + Check5 + Check6;

            NpcShop.excellent = result; // add points execelents

            Sql_Querys sql_Querys = new();
            Connect.update(sql_Querys.update_item_npc);
            LoadItemDetail();
            LoadNpcItems();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateItem();
        }

        //Load all items from database
        public void loadItem()
        {
            NpcShop.add_itemType = comboBox2.SelectedIndex;
            Sql_Querys sql_Querys = new();
            dataGridView2.DataSource = Connect.loadData(sql_Querys.load_itens).DefaultView.ToTable(true, "ID", "Item");
        }

        public void ChangeLabel()
        {
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    checkBox2.Text = "Mob Kill +mana/8";
                    checkBox3.Text = "Mob Kill +life/8";
                    checkBox4.Text = "Attack(Wizaedy) Speed +7";
                    checkBox5.Text = "Damage +2%";
                    checkBox6.Text = "Damage +level/20";
                    checkBox7.Text = "Exc Damage Rate +10%";
                    break;

                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                    checkBox2.Text = "Zen Drop +30%";
                    checkBox3.Text = "Def Sucess Rate +10%";
                    checkBox4.Text = "Reflect +5%";
                    checkBox5.Text = "Damage Decrease +4%";
                    checkBox6.Text = "Mana +4%";
                    checkBox7.Text = "HP +4%";
                    checkBox1.Text = "Skill";
                    checkBox8.Text = "Luck";
                    checkBox9.Text = "Ancient";
                    break;

                case 12:
                    checkBox2.Text = "Increase 5 Atacck(Wizard)Speed";
                    checkBox3.Text = "Increase Max AG by 50";
                    checkBox4.Text = "Increase chance true Damage 3%";
                    checkBox5.Text = "Inceases Mana by 125";
                    checkBox6.Text = "Inceases Life by 125";
                    checkBox7.Text = "---";
                    checkBox1.Text = "Skill";
                    checkBox8.Text = "Luck";
                    checkBox9.Text = "Ancient";
                    break;

                default:
                    checkBox2.Text = "---";
                    checkBox3.Text = "---";
                    checkBox4.Text = "---";
                    checkBox5.Text = "---";
                    checkBox6.Text = "---";
                    checkBox7.Text = "---";
                    checkBox1.Text = "---";
                    checkBox8.Text = "---";
                    checkBox9.Text = "---";
                    break;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeLabel();
            loadItem();
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                int ID = int.Parse(row.Cells[0].Value.ToString());
                NpcShop.add_itemIndex = ID;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sql_Querys sql_Querys = new();
            Connect.update(sql_Querys.insert_items);
            LoadNpcItems();
        }

        public void DeleteItems()
        {
            Sql_Querys sql_Querys = new();
            Connect.update(sql_Querys.delete_items);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteItems();
            LoadNpcItems();
        }
    }
}