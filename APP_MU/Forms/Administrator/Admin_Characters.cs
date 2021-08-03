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
    public partial class Admin_Characters : Form
    {
        public Admin_Characters()
        {
            InitializeComponent();
            config.database = "mu_online_characters";
        }

        public void LoadAllCharacters()
        {
            Sql_Querys sql_Query = new();
            dataGridView1.DataSource = Connect.loadData(sql_Query.all_characters);
        }

        public void default_num()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            checkBox2.Checked = false;
            label_off.ForeColor = Color.FromArgb(255, 0, 0);
            label_off.Text = "offline";
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            textBox5.Text = "0";
            textBox6.Text = "0";
            textBox7.Text = "0";
            numericUpDown9.Value = 0;
            numericUpDown8.Value = 0;
            numericUpDown7.Value = 0;

            numericUpDown14.Value = 0;
            numericUpDown18.Value = 0;
            numericUpDown13.Value = 0;
            numericUpDown10.Value = 0;
            numericUpDown17.Value = 0;

            numericUpDown11.Value = 0;
            numericUpDown16.Value = 0;
            numericUpDown12.Value = 0;
            numericUpDown15.Value = 0;
        }

        public class RaceID
        {
            public string flag { get; set; }
            public int flag_valor { get; set; }

            public List<RaceID> list = new();

            public List<RaceID> ListFlags()
            {
                list.Add(new RaceID { flag = "DARK_WIZARD", flag_valor = 0 });
                list.Add(new RaceID { flag = "SOUL_MASTER", flag_valor = 1 });
                list.Add(new RaceID { flag = "GRAND_MASTER", flag_valor = 3 });
                list.Add(new RaceID { flag = "SOUL_WIZARD", flag_valor = 7 });
                list.Add(new RaceID { flag = "-------------" });
                list.Add(new RaceID { flag = "DARK_KNIGHT", flag_valor = 16 });
                list.Add(new RaceID { flag = "BLADE_KNIGHT", flag_valor = 17 });
                list.Add(new RaceID { flag = "BLADE_MASTER", flag_valor = 19 });
                list.Add(new RaceID { flag = "DRAGON_KNIGHT", flag_valor = 23 });
                list.Add(new RaceID { flag = "-------------" });
                list.Add(new RaceID { flag = "FAIRY_ELF", flag_valor = 32 });
                list.Add(new RaceID { flag = "MUSE_ELF", flag_valor = 33 });
                list.Add(new RaceID { flag = "HIGH_ELF", flag_valor = 35 });
                list.Add(new RaceID { flag = "NOBLE_ELF", flag_valor = 39 });
                list.Add(new RaceID { flag = "-------------" });
                list.Add(new RaceID { flag = "MAGIC_GLADIATOR", flag_valor = 48 });
                list.Add(new RaceID { flag = "DUEL_MASTER", flag_valor = 51 });
                list.Add(new RaceID { flag = "MAGIC_KNIGHT", flag_valor = 55 });
                list.Add(new RaceID { flag = "-------------" });
                list.Add(new RaceID { flag = "DARK_LORD", flag_valor = 64 });
                list.Add(new RaceID { flag = "LORD_EMPEROR", flag_valor = 67 });
                list.Add(new RaceID { flag = "EMPIRE_LORD", flag_valor = 71 });
                list.Add(new RaceID { flag = "-------------" });
                list.Add(new RaceID { flag = "SUMMONER", flag_valor = 80 });
                list.Add(new RaceID { flag = "BLOODY_SUMMONER", flag_valor = 81 });
                list.Add(new RaceID { flag = "DIMENSION_MASTER", flag_valor = 83 });
                list.Add(new RaceID { flag = "DIMENSIONER", flag_valor = 87 });
                list.Add(new RaceID { flag = "-------------" });
                list.Add(new RaceID { flag = "RAGE_FIGHTER", flag_valor = 96 });
                list.Add(new RaceID { flag = "FIST_MASTER", flag_valor = 99 });
                list.Add(new RaceID { flag = "FIST_BLASER", flag_valor = 106 });
                list.Add(new RaceID { flag = "-------------" });
                list.Add(new RaceID { flag = "GROW_LANCER", flag_valor = 112 });
                list.Add(new RaceID { flag = "MIRAGE_LANCER", flag_valor = 115 });
                list.Add(new RaceID { flag = "SHINING_LANCER", flag_valor = 119 });
                list.Add(new RaceID { flag = "-------------" });
                list.Add(new RaceID { flag = "RUNE_WIZARD", flag_valor = 128 });
                list.Add(new RaceID { flag = "RUNE_SPELL_MASTER", flag_valor = 129 });
                list.Add(new RaceID { flag = "GRAND_RUNE_MASTER", flag_valor = 131 });
                list.Add(new RaceID { flag = "MAJESTIC_RUNE_WIZARD", flag_valor = 135 });
                list.Add(new RaceID { flag = "-------------" });
                list.Add(new RaceID { flag = "SLAYER", flag_valor = 144 });
                list.Add(new RaceID { flag = "ROYAL_SLAYER", flag_valor = 145 });
                list.Add(new RaceID { flag = "MASTER_SLAYER", flag_valor = 147 });
                list.Add(new RaceID { flag = "SLAUGHTERER", flag_valor = 151 });
                list.Add(new RaceID { flag = "-------------" });
                list.Add(new RaceID { flag = "GUN_CRUSHER", flag_valor = 160 });
                list.Add(new RaceID { flag = "GUN_BREAKER", flag_valor = 161 });
                list.Add(new RaceID { flag = "MASTER_GUN_BREAKER", flag_valor = 163 });
                list.Add(new RaceID { flag = "HEIST_GUN_CRUSHER", flag_valor = 167 });
                return list;
            }
        }

        public void test()
        {
            var service = new RaceID();
            service.ListFlags();
            comboBox1.DataSource = service.list;
            comboBox1.DisplayMember = "flag";
            comboBox1.ValueMember = "flag_valor";
        }

        public void LoadAllCharactersDetail()
        {
            default_num();
            int result = 0;
            Sql_Querys sql_Query = new();
            if (Connect.loadData(sql_Query.all_character_detail).Rows.Count > 0)
            {
                textBox1.Text = Connect.loadData(sql_Query.all_character_detail).Rows[0].ItemArray[0].ToString();
                numericUpDown1.Value = int.Parse(Connect.loadData(sql_Query.all_character_detail).Rows[0].ItemArray[3].ToString());
                numericUpDown2.Value = int.Parse(Connect.loadData(sql_Query.all_character_detail).Rows[0].ItemArray[4].ToString());
                numericUpDown3.Value = int.Parse(Connect.loadData(sql_Query.all_character_detail).Rows[0].ItemArray[5].ToString());
                textBox7.Text = Connect.loadData(sql_Query.all_character_detail).Rows[0].ItemArray[6].ToString();
                textBox6.Text = Connect.loadData(sql_Query.all_character_detail).Rows[0].ItemArray[7].ToString();
                textBox5.Text = Connect.loadData(sql_Query.all_character_detail).Rows[0].ItemArray[8].ToString();
                numericUpDown9.Value = int.Parse(Connect.loadData(sql_Query.all_character_detail).Rows[0].ItemArray[9].ToString());
                numericUpDown8.Value = int.Parse(Connect.loadData(sql_Query.all_character_detail).Rows[0].ItemArray[10].ToString());
                numericUpDown7.Value = int.Parse(Connect.loadData(sql_Query.all_character_detail).Rows[0].ItemArray[11].ToString());

                numericUpDown14.Value = int.Parse(Connect.loadData(sql_Query.all_character_detail).Rows[0].ItemArray[12].ToString());
                numericUpDown18.Value = int.Parse(Connect.loadData(sql_Query.all_character_detail).Rows[0].ItemArray[13].ToString());
                numericUpDown13.Value = int.Parse(Connect.loadData(sql_Query.all_character_detail).Rows[0].ItemArray[14].ToString());
                numericUpDown10.Value = int.Parse(Connect.loadData(sql_Query.all_character_detail).Rows[0].ItemArray[15].ToString());
                numericUpDown17.Value = int.Parse(Connect.loadData(sql_Query.all_character_detail).Rows[0].ItemArray[16].ToString());

                numericUpDown11.Value = int.Parse(Connect.loadData(sql_Query.all_character_detail).Rows[0].ItemArray[17].ToString());
                numericUpDown16.Value = int.Parse(Connect.loadData(sql_Query.all_character_detail).Rows[0].ItemArray[18].ToString());
                numericUpDown12.Value = int.Parse(Connect.loadData(sql_Query.all_character_detail).Rows[0].ItemArray[19].ToString());
                numericUpDown15.Value = int.Parse(Connect.loadData(sql_Query.all_character_detail).Rows[0].ItemArray[20].ToString());
                textBox4.Text = Connect.loadData(sql_Query.all_character_detail).Rows[0].ItemArray[23].ToString();

                if (Connect.loadData(sql_Query.all_character_detail).Rows[0].ItemArray[2].ToString() == "1")
                {
                    label_off.ForeColor = Color.FromArgb(0, 255, 0);
                    label_off.Text = "online";
                }
                if (Connect.loadData(sql_Query.all_character_detail).Rows[0].ItemArray[22].ToString() == "2")
                {
                    checkBox2.Checked = true;
                }

                result = Convert.ToInt32(numericUpDown1.Value + numericUpDown2.Value + numericUpDown3.Value);

                textBox2.Text = result.ToString();
            }
        }

        private void Admin_Characters_Load(object sender, EventArgs e)
        {
            var service = new Service();
            service.ListFlags();
            ((ListBox)checkedListBox1).DataSource = service.list;
            ((ListBox)checkedListBox1).DisplayMember = "flag";
            ((ListBox)checkedListBox1).ValueMember = "flag_valor";
            LoadAllCharacters();
            test();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public class Service
        {
            public string flag { get; set; }
            public int flag_valor { get; set; }

            public List<Service> list = new();

            public List<Service> ListFlags()
            {
                list.Add(new Service { flag = "ADMIN PARTY", flag_valor = 1 });
                list.Add(new Service { flag = "ADMIN TRADE", flag_valor = 2 });
                list.Add(new Service { flag = "ADMIN GLOBAL", flag_valor = 4 });
                list.Add(new Service { flag = "ADMIN TRACE", flag_valor = 8 });
                list.Add(new Service { flag = "ADMIN KICK", flag_valor = 16 });
                list.Add(new Service { flag = "ADMIN EVENTS", flag_valor = 32 });
                list.Add(new Service { flag = "ADMIN MUTE", flag_valor = 64 });
                list.Add(new Service { flag = "ADMIN ITEM", flag_valor = 128 });
                list.Add(new Service { flag = "ADMIN ITEM_EVENT", flag_valor = 256 });
                list.Add(new Service { flag = "ADMIN BAN", flag_valor = 512 });
                list.Add(new Service { flag = "ADMIN POST", flag_valor = 1024 });
                list.Add(new Service { flag = "ADMIN TALK", flag_valor = 2048 });
                list.Add(new Service { flag = "ADMIN MOVE", flag_valor = 4096 });
                list.Add(new Service { flag = "ADMIN RELOAD", flag_valor = 8192 });
                list.Add(new Service { flag = "ADMIN MONSTER", flag_valor = 16384 });
                list.Add(new Service { flag = "ADMIN ZEN", flag_valor = 32768 });
                list.Add(new Service { flag = "ADMIN GUILD_TALK", flag_valor = 65536 });
                list.Add(new Service { flag = "ADMIN RESTRICTION", flag_valor = 131072 });
                list.Add(new Service { flag = "ADMIN SHUTDOWN", flag_valor = 262144 });
                list.Add(new Service { flag = "ADMIN PANEL", flag_valor = 524288 });
                list.Add(new Service { flag = "ADMIN BUFF", flag_valor = 1048576 });
                list.Add(new Service { flag = "ADMIN MASIVE", flag_valor = 2097152 });
                //list.Add(new Service { flag = "ADMIN_FLAG_ALL", flag_valor = 4194303 });
                return list;
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Service> servicosSelecionados = checkedListBox1.CheckedItems.OfType<Service>().ToList();
            //string descricaoServicos = servicosSelecionados.Select(x => x.flag).Aggregate((atual, proximo) => atual + ", " + proximo);
            int valorService = servicosSelecionados.Sum(x => x.flag_valor);
            Characters.admin_flags = valorService;
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string vid = row.Cells[0].Value.ToString();
                Characters.guid = int.Parse(vid);
                LoadAllCharactersDetail();
            }
        }

        private void checkBox2_CheckStateChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
            if (checkBox2.CheckState == CheckState.Checked)
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
            }
        }

        public void Save_Info()
        {
            Sql_Querys sql_Query = new();
            if (Connect.loadData(sql_Query.all_character_detail).Rows.Count > 0)
            {
                if (Connect.loadData(sql_Query.all_character_detail).Rows[0].ItemArray[2].ToString() == "0")
                {
                    Characters.authority = 0;
                    Characters.name = textBox1.Text;
                    Characters.level = Convert.ToInt32(numericUpDown1.Value);
                    Characters.level_master = Convert.ToInt32(numericUpDown2.Value);
                    Characters.level_majestic = Convert.ToInt32(numericUpDown3.Value);

                    Characters.experience = int.Parse(textBox7.Text);
                    Characters.experience_master = int.Parse(textBox6.Text);
                    //Characters.experience_majestic = int.Parse(textBox5.Text);

                    Characters.points = Convert.ToInt32(numericUpDown9.Value);
                    Characters.points_master = Convert.ToInt32(numericUpDown8.Value);
                    Characters.points_majestic = Convert.ToInt32(numericUpDown7.Value);

                    Characters.strength = Convert.ToInt32(numericUpDown14.Value);
                    Characters.energy = Convert.ToInt32(numericUpDown10.Value);

                    Characters.agility = Convert.ToInt32(numericUpDown18.Value);
                    Characters.leadership = Convert.ToInt32(numericUpDown17.Value);

                    Characters.vitality = Convert.ToInt32(numericUpDown13.Value);

                    Characters.money = Convert.ToInt32(numericUpDown11.Value);
                    Characters.goblin_points = Convert.ToInt32(numericUpDown16.Value);
                    Characters.add_fruit_points = Convert.ToInt32(numericUpDown12.Value);
                    Characters.dec_fruit_points = Convert.ToInt32(numericUpDown15.Value);
                    Characters.race = int.Parse(comboBox1.SelectedValue.ToString());

                    if (checkBox2.CheckState == CheckState.Checked)
                    {
                        Characters.authority = 2;
                    }

                    Sql_Querys sql_Querys = new();
                    Connect.update(sql_Querys.all_character_detail_save);
                    LoadAllCharacters();
                }
                else if (Connect.loadData(sql_Query.all_character_detail).Rows[0].ItemArray[2].ToString() == "1")
                {
                    MessageBox.Show("Character is online, disconnect! to be able to save");
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Save_Info();
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            Characters.admin_flags = 0;
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
            if (checkBox1.CheckState == CheckState.Checked)
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
                List<Service> servicosSelecionados = checkedListBox1.CheckedItems.OfType<Service>().ToList();
                //string descricaoServicos = servicosSelecionados.Select(x => x.flag).Aggregate((atual, proximo) => atual + ", " + proximo);
                int valorService = servicosSelecionados.Sum(x => x.flag_valor);
                Characters.admin_flags = valorService;
            }
        }

        private void comboBox1_DropDownClosed_1(object sender, EventArgs e)
        {
            Characters.race = int.Parse(comboBox1.SelectedValue.ToString());
        }
    }
}