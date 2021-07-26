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
            numericUpDown6.Value = 0;
            numericUpDown5.Value = 0;
            numericUpDown4.Value = 0;
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
                numericUpDown6.Value = int.Parse(Connect.loadData(sql_Query.all_character_detail).Rows[0].ItemArray[6].ToString());
                numericUpDown5.Value = int.Parse(Connect.loadData(sql_Query.all_character_detail).Rows[0].ItemArray[7].ToString());
                //numericUpDown4.Value = int.Parse(Connect.loadData(sql_Query.all_character_detail).Rows[0].ItemArray[8].ToString());
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
                numericUpDown15.Value = int.Parse(Connect.loadData(sql_Query.all_character_detail).Rows[0].ItemArray[20].ToString());
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public class Service
        {
            public string flag { get; set; }
            public int flag_valor { get; set; }

            public List<Service> list = new List<Service>();

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
            if (Connect.loadData(sql_Query.all_character_detail).Rows[0].ItemArray[2].ToString() == "0")
            {
                Characters.authority = 0;
                Characters.name = textBox1.Text;
                Characters.level = Convert.ToInt32(numericUpDown1.Value);
                Characters.level_master = Convert.ToInt32(numericUpDown2.Value);
                Characters.level_majestic = Convert.ToInt32(numericUpDown3.Value);

                Characters.experience = Convert.ToInt32(numericUpDown6.Value);
                Characters.experience_master = Convert.ToInt32(numericUpDown5.Value);
                Characters.experience_majestic = Convert.ToInt32(numericUpDown4.Value);

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
    }
}