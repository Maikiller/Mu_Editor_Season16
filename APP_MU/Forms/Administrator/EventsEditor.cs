using APP_MU.Database;
using APP_MU.DataBase;
using APP_MU.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace APP_MU.Forms.Administrator
{
    public partial class EventsEditor : Form
    {
        public EventsEditor()
        {
            InitializeComponent();
            config.database = "mu_game";
        }

        public void LoadDataGrid()
        {
            Sql_Querys sql_Querys = new();

            dataGridView1.DataSource = Connect.loadData(sql_Querys.load_all_events);

        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            if (comboBox1.Text != "Select Server")
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
            }

            if (comboBox1.Text == "Select Server")
            {
                MessageBox.Show("Select Server");
            }
            else
            {
                ManageEvents.ServerID = int.Parse(comboBox1.Text);
                LoadDataGrid();
            }
        }

        private void EventsEditor_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            InjectDateComboBox();
        }

        public class Event
        {
            public string flag { get; set; }
            public int flag_valor { get; set; }

            public List<Event> list = new();

            public List<Event> ListFlags()
            {
                list.Add(new Event { flag = "BLOOD CASTLE", flag_valor = 0 });
                list.Add(new Event { flag = "DEVIL SQUARE", flag_valor = 1 });
                list.Add(new Event { flag = "CHAOS CASTLE", flag_valor = 2 });
                list.Add(new Event { flag = "ILLUSION TEMPLE", flag_valor = 3 });
                list.Add(new Event { flag = "CRYWOLF", flag_valor = 4 });
                list.Add(new Event { flag = "IMPERIAL FORTRESS", flag_valor = 5 });
                list.Add(new Event { flag = "RAKLION", flag_valor = 6 });
                list.Add(new Event { flag = "KANTURU", flag_valor = 7 });
                list.Add(new Event { flag = "INVASION", flag_valor = 8 });
                list.Add(new Event { flag = "CASTLE SIEGE", flag_valor = 9 });
                list.Add(new Event { flag = "HAPPY HOUR", flag_valor = 10 });
                list.Add(new Event { flag = "SCRAMBLE", flag_valor = 11 });
                list.Add(new Event { flag = "DUNGEON RACE", flag_valor = 12 });
                list.Add(new Event { flag = "LOSTTOWER RACE", flag_valor = 13 });
                list.Add(new Event { flag = "DOPPELGANGER", flag_valor = 14 });
                list.Add(new Event { flag = "CHAOS CASTLE SURVIVAL", flag_valor = 16 });
                list.Add(new Event { flag = "PROTECTOR OF ACHERON", flag_valor = 17 });
                list.Add(new Event { flag = "TORMENTED SQUARE", flag_valor = 18 });
                list.Add(new Event { flag = "ARKA WAR", flag_valor = 19 });
                list.Add(new Event { flag = "LAST MAN STANDING", flag_valor = 20 });
                list.Add(new Event { flag = "NIXIES LAKE", flag_valor = 21 });
                list.Add(new Event { flag = "LABYRINTH OF DIMENSIONS", flag_valor = 22 });
                list.Add(new Event { flag = "TORMENTED SQUARE SURVIVAL", flag_valor = 23 });
                list.Add(new Event { flag = "CASTLE DEEP", flag_valor = 24 });
                list.Add(new Event { flag = "WORLD BOSS", flag_valor = 26 });
                list.Add(new Event { flag = "SWAMP OF DARKNESS", flag_valor = 27 });
                list.Add(new Event { flag = "INSTANCED DUNGEON", flag_valor = 28 });
                return list;
            }
        }

        public class Invasion
        {
            public string flag { get; set; }
            public int flag_valor { get; set; }

            public List<Invasion> list = new();

            public List<Invasion> ListFlags()
            {
                list.Add(new Invasion { flag = "White Wizard", flag_valor = 0 });
                list.Add(new Invasion { flag = "Blue Event", flag_valor = 1 });
                list.Add(new Invasion { flag = "Underground", flag_valor = 2 });
                list.Add(new Invasion { flag = "New Year Day", flag_valor = 3 });
                list.Add(new Invasion { flag = "Red Dragon", flag_valor = 4 });
                list.Add(new Invasion { flag = "Summer", flag_valor = 5 });
                list.Add(new Invasion { flag = "Santa Event", flag_valor = 6 });
                list.Add(new Invasion { flag = "Moss Merchant", flag_valor = 7 });
                list.Add(new Invasion { flag = "Golden Invasion", flag_valor = 8 });
                list.Add(new Invasion { flag = "Lucky Coin", flag_valor = 9 });
                list.Add(new Invasion { flag = "Muun Invasion", flag_valor = 10 });
                list.Add(new Invasion { flag = "Sign of Elemental", flag_valor = 11 });
                list.Add(new Invasion { flag = "Summon the Demons", flag_valor = 12 });
                list.Add(new Invasion { flag = "Exiled from Exile", flag_valor = 13 });
                list.Add(new Invasion { flag = "Skeleton Sorcerer Invasion", flag_valor = 15 });
                return list;
            }
        }

        public void InjectDateComboBox()
        {
            var event_ = new Event();
            event_.ListFlags();
            comboBox2.DataSource = event_.list;
            comboBox2.DisplayMember = "flag";
            comboBox2.ValueMember = "flag_valor";

            var invasion = new Invasion();
            invasion.ListFlags();
            comboBox3.DataSource = invasion.list;
            comboBox3.DisplayMember = "flag";
            comboBox3.ValueMember = "flag_valor";

        }

        public void LoadDataClass()
        {
            comboBox3.Enabled = false;
            Sql_Querys sql_Querys = new();

            switch (int.Parse(Connect.loadData(sql_Querys.load_event_id).Rows[0].ItemArray[2].ToString()))
            {
                case 0:
                    ManageEvents.eventID_to_name = "BLOOD CASTLE";
                    break;

                case 1:
                    ManageEvents.eventID_to_name = "DEVIL SQUARE";
                    break;

                case 2:
                    ManageEvents.eventID_to_name = "CHAOS CASTLE";
                    break;

                case 3:
                    ManageEvents.eventID_to_name = "ILLUSION TEMPLE";
                    break;

                case 4:
                    ManageEvents.eventID_to_name = "CRYWOLF";
                    break;

                case 5:
                    ManageEvents.eventID_to_name = "IMPERIAL FORTRESS";
                    break;

                case 6:
                    ManageEvents.eventID_to_name = "RAKLION";
                    break;

                case 7:
                    ManageEvents.eventID_to_name = "KANTURU";
                    break;

                case 8:
                    ManageEvents.eventID_to_name = "INVASION";
                    comboBox3.Enabled = true;
                    break;

                case 9:
                    ManageEvents.eventID_to_name = "CASTLE SIEGE";
                    break;

                case 10:
                    ManageEvents.eventID_to_name = "HAPPY HOUR";
                    break;

                case 11:
                    ManageEvents.eventID_to_name = "SCRAMBLE";
                    break;

                case 12:
                    ManageEvents.eventID_to_name = "DUNGEON RACE";
                    break;

                case 13:
                    ManageEvents.eventID_to_name = "LOSTTOWER RACE";
                    break;

                case 14:
                    ManageEvents.eventID_to_name = "DOPPELGANGER";
                    break;

                case 16:
                    ManageEvents.eventID_to_name = "CHAOS CASTLE SURVIVAL";
                    break;

                case 17:
                    ManageEvents.eventID_to_name = "PROTECTOR OF ACHERON";
                    break;

                case 18:
                    ManageEvents.eventID_to_name = "TORMENTED SQUARE";
                    break;

                case 19:
                    ManageEvents.eventID_to_name = "ARKA WAR";
                    break;

                case 20:
                    ManageEvents.eventID_to_name = "LAST MAN STANDING";
                    break;

                case 21:
                    ManageEvents.eventID_to_name = "NIXIES LAKE";
                    break;

                case 22:
                    ManageEvents.eventID_to_name = "LABYRINTH OF DIMENSIONS";
                    break;

                case 23:
                    ManageEvents.eventID_to_name = "TORMENTED SQUARE SURVIVAL";
                    break;

                case 24:
                    ManageEvents.eventID_to_name = "CASTLE DEEP";
                    break;

                case 26:
                    ManageEvents.eventID_to_name = "WORLD BOSS";
                    break;

                case 27:
                    ManageEvents.eventID_to_name = "SWAMP OF DARKNESS";
                    break;

                case 28:
                    ManageEvents.eventID_to_name = "INSTANCED DUNGEON";
                    break;
            }

            switch (int.Parse(Connect.loadData(sql_Querys.load_event_id).Rows[0].ItemArray[3].ToString()))
            {
                case 0:
                    ManageEvents.invasionID_to_name = "White Wizard";
                    break;

                case 1:
                    ManageEvents.invasionID_to_name = "Blue Event";
                    break;

                case 2:
                    ManageEvents.invasionID_to_name = "Underground";
                    break;

                case 3:
                    ManageEvents.invasionID_to_name = "New Year Day";
                    break;

                case 4:
                    ManageEvents.invasionID_to_name = "Red Dragon";
                    break;


                case 5:
                    ManageEvents.invasionID_to_name = "Summer";
                    break;

                case 6:
                    ManageEvents.invasionID_to_name = "Santa Event";
                    break;

                case 7:
                    ManageEvents.invasionID_to_name = "Moss Merchant";
                    break;

                case 8:
                    ManageEvents.invasionID_to_name = "Golden Invasion";
                    break;

                case 9:
                    ManageEvents.invasionID_to_name = "Lucky Coin";
                    break;

                case 10:
                    ManageEvents.invasionID_to_name = "Muun Invasion";
                    break;

                case 11:
                    ManageEvents.invasionID_to_name = "Sign of Elemental";
                    break;

                case 12:
                    ManageEvents.invasionID_to_name = "Summon the Demons";
                    break;

                case 13:
                    ManageEvents.invasionID_to_name = "Exiled from Exile";
                    break;

                case 15:
                    ManageEvents.invasionID_to_name = "Skeleton Sorcerer Invasion";
                    break;


            }

            ManageEvents.duration = int.Parse(Connect.loadData(sql_Querys.load_event_id).Rows[0].ItemArray[4].ToString());
            ManageEvents.notify_time = int.Parse(Connect.loadData(sql_Querys.load_event_id).Rows[0].ItemArray[5].ToString());
            ManageEvents.hour = int.Parse(Connect.loadData(sql_Querys.load_event_id).Rows[0].ItemArray[6].ToString());
            ManageEvents.minute = int.Parse(Connect.loadData(sql_Querys.load_event_id).Rows[0].ItemArray[7].ToString());
            ManageEvents.day_of_week = int.Parse(Connect.loadData(sql_Querys.load_event_id).Rows[0].ItemArray[8].ToString());
            ManageEvents.day_of_month = int.Parse(Connect.loadData(sql_Querys.load_event_id).Rows[0].ItemArray[9].ToString());
            ManageEvents.season_event = int.Parse(Connect.loadData(sql_Querys.load_event_id).Rows[0].ItemArray[10].ToString());
            ManageEvents.exclusive_server = int.Parse(Connect.loadData(sql_Querys.load_event_id).Rows[0].ItemArray[11].ToString());
            comboBox2.Text = ManageEvents.eventID_to_name;
            comboBox3.Text = ManageEvents.invasionID_to_name;

            numericUpDown1.Value = ManageEvents.duration;
            numericUpDown2.Value = ManageEvents.hour;
            numericUpDown3.Value = ManageEvents.minute;
            numericUpDown4.Value = ManageEvents.notify_time;

            textBox1.Text = ManageEvents.day_of_week.ToString();
            textBox2.Text = ManageEvents.day_of_month.ToString();
            textBox3.Text = ManageEvents.exclusive_server.ToString();
            textBox4.Text = ManageEvents.season_event.ToString();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                ManageEvents.guid = int.Parse(row.Cells[11].Value.ToString());
                LoadDataClass();
            }
        }

        private void comboBox2_DropDownClosed(object sender, EventArgs e)
        {
            comboBox3.Enabled = true;
            if (comboBox2.SelectedValue.ToString() != "8")
            {
                comboBox3.Enabled = false;
            }
        }

        private void UpdateDate()
        {
            ManageEvents.eventID = int.Parse(comboBox2.SelectedValue.ToString());
            ManageEvents.invasionID = int.Parse(comboBox3.SelectedValue.ToString());
            ManageEvents.hour = Convert.ToInt32(numericUpDown2.Value);
            ManageEvents.minute = Convert.ToInt32(numericUpDown3.Value);
            ManageEvents.duration = Convert.ToInt32(numericUpDown1.Value);
            ManageEvents.notify_time = Convert.ToInt32(numericUpDown4.Value);
            ManageEvents.day_of_week = int.Parse(textBox1.Text);
            ManageEvents.day_of_month = int.Parse(textBox2.Text);
            ManageEvents.season_event = int.Parse(textBox4.Text);
            ManageEvents.exclusive_server = int.Parse(textBox3.Text);

            Sql_Querys sql_Querys = new();
            Connect.update(sql_Querys.update_event);
            LoadDataGrid();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateDate();
        }

        private void DeleteDate()
        {
            Sql_Querys sql_Querys = new();
            Connect.update(sql_Querys.delete_event);
            LoadDataGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteDate();
        }

        private void ADDEvent()
        {
            ManageEvents.ServerID = int.Parse(comboBox1.Text);
            ManageEvents.invasionID = int.Parse(comboBox3.SelectedValue.ToString());
            ManageEvents.eventID = int.Parse(comboBox2.SelectedValue.ToString());
            ManageEvents.duration = int.Parse(numericUpDown1.Value.ToString());
            ManageEvents.notify_time = int.Parse(numericUpDown4.Value.ToString());
            ManageEvents.hour = int.Parse(numericUpDown2.Value.ToString()); ;
            ManageEvents.minute = int.Parse(numericUpDown3.Value.ToString()); ;
            ManageEvents.day_of_week = int.Parse(textBox1.Text);
            ManageEvents.day_of_month = int.Parse(textBox2.Text);
            ManageEvents.season_event = int.Parse(textBox4.Text);
            ManageEvents.exclusive_server = int.Parse(textBox3.Text);

            Sql_Querys sql_Querys = new();
            Connect.update(sql_Querys.add_event);
            LoadDataGrid();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            ADDEvent();
        }
    }
}
