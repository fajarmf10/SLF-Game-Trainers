using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory;
using MetroFramework.Forms;

namespace SLFTrainers
{
    public partial class Trainer : MetroForm
    {
        public Mem memLib = new Mem();
        public bool loaded = false;
        string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

        public Trainer()
        {
            InitializeComponent();
        }

        private void Trainer_Load(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy == false) backgroundWorker1.RunWorkerAsync();
        }

        private void loadGame()
        {
            if (loaded) return;

            loaded = memLib.OpenProcess("School Love and Friends");

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                loadGame();
                if (!loaded) continue;
                label_status.Invoke(new MethodInvoker(delegate
                {
                    label_status.Text = "Status: Activated!";
                }));
                label_current_hour.Invoke(new MethodInvoker(delegate
                {
                    int hour = memLib.readInt("UnityPlayer.dll+01098F5C,0x0,0x204,0x3c,0x2c,0xc");
                    if (hour < 10)
                        label_current_hour.Text = "0" + hour.ToString() + ":00";
                    else label_current_hour.Text = hour.ToString() + ":00";
                }));
                label_current_day.Invoke(new MethodInvoker(delegate
                {
                    int day = memLib.readInt("UnityPlayer.dll+01098F5C,0x0,0x204,0x3c,0x2c,0x10");
                    day = day - 1;
                    label_current_day.Text = days[day];
                }));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void metroLabel3_Click(object sender, EventArgs e)
        {

        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            if (memLib.OpenProcess("School Love and Friends"))
            {
                label_status.Text = "Status: Activated!";
                txt_money.Text = memLib.readInt("UnityPlayer.dll+01098F5C,0x0,0x204,0x3c,0x2c,0x28").ToString();
            }
            else label_status.Text = "Status: Failed! Antivirus or outdated?";
        }

        private void metroLabel14_Click(object sender, EventArgs e)
        {

        }

        private void btn_apply_money_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txt_money.Text)) {
                String money = txt_money.Text;
                memLib.writeMemory("UnityPlayer.dll+01098F5C,0x0,0x204,0x3c,0x2c,0x28", "int", money, "");
            }
        }

        private void btn_apply_hour_Click(object sender, EventArgs e)
        {
            if (cb_hour.SelectedItem == null)
            {
                return;
            }
            String hour = cb_hour.SelectedItem.ToString();
            memLib.writeMemory("UnityPlayer.dll+01098F5C,0x0,0x204,0x3c,0x2c,0xc", "int", hour, "");
        }

        private void cb_day_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_sub_hour_Click(object sender, EventArgs e)
        {
            int curhour = memLib.readInt("UnityPlayer.dll+01098F5C,0x0,0x204,0x3c,0x2c,0xc");
            if (curhour == 0) curhour = 24;
            memLib.writeMemory("UnityPlayer.dll+01098F5C,0x0,0x204,0x3c,0x2c,0xc", "int", (curhour-1).ToString(), "");
        }

        private void btn_add_hour_Click(object sender, EventArgs e)
        {
            int curhour = memLib.readInt("UnityPlayer.dll+01098F5C,0x0,0x204,0x3c,0x2c,0xc");
            if (curhour == 23) curhour = -1;
            memLib.writeMemory("UnityPlayer.dll+01098F5C,0x0,0x204,0x3c,0x2c,0xc", "int", (curhour + 1).ToString(), "");
        }

        private void btn_apply_day_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(cb_day.SelectedIndex);
            if (cb_day.SelectedIndex == -1)
            {
                return;
            }
            int day = cb_day.SelectedIndex;
            memLib.writeMemory("UnityPlayer.dll+01098F5C,0x0,0x204,0x3c,0x2c,0x10", "int", (day+1).ToString(), "");
        }

        private void btn_sub_day_Click(object sender, EventArgs e)
        {
            int curday = memLib.readInt("UnityPlayer.dll+01098F5C,0x0,0x204,0x3c,0x2c,0x10");
            if (curday == 1) curday = 8;
            memLib.writeMemory("UnityPlayer.dll+01098F5C,0x0,0x204,0x3c,0x2c,0x10", "int", (curday-1).ToString(), "");
        }

        private void btn_add_day_Click(object sender, EventArgs e)
        {
            int curday = memLib.readInt("UnityPlayer.dll+01098F5C,0x0,0x204,0x3c,0x2c,0x10");
            if (curday == 7) curday = 0;
            memLib.writeMemory("UnityPlayer.dll+01098F5C,0x0,0x204,0x3c,0x2c,0x10", "int", (curday+1).ToString(), "");
        }

        private void metroLink1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/SamuelShamm");
        }

        private void btn_reload_personal_skills_Click(object sender, EventArgs e)
        {
            txt_persuasion.Text = memLib.readInt("UnityPlayer.dll+01098F5C,0x0,0x204,0x3c,0x2c,0x5c").ToString();
            txt_stealth.Text = memLib.readInt("UnityPlayer.dll+01098F5C,0x0,0x204,0x3c,0x2c,0x60").ToString();
            txt_massage.Text = memLib.readInt("UnityPlayer.dll+01098F5C,0x0,0x204,0x3c,0x2c,0x64").ToString();
            txt_yoga.Text = memLib.readInt("UnityPlayer.dll+01098F5C,0x0,0x204,0x3c,0x2c,0x68").ToString();
            txt_taekwondo.Text = memLib.readInt("UnityPlayer.dll+01098F5C,0x0,0x204,0x3c,0x2c,0x6c").ToString();
            txt_breakdance.Text = memLib.readInt("UnityPlayer.dll+01098F5C,0x0,0x204,0x3c,0x2c,0x70").ToString();
        }

        private void btn_apply_persuasion_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txt_persuasion.Text))
            {
                memLib.writeMemory("UnityPlayer.dll+01098F5C,0x0,0x204,0x3c,0x2c,0x5c", "int", txt_persuasion.Text, "");
            }
        }

        private void btn_apply_stealth_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txt_stealth.Text))
            {
                memLib.writeMemory("UnityPlayer.dll+01098F5C,0x0,0x204,0x3c,0x2c,0x60", "int", txt_stealth.Text, "");
            }
        }

        private void btn_apply_massage_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txt_massage.Text))
            {
                memLib.writeMemory("UnityPlayer.dll+01098F5C,0x0,0x204,0x3c,0x2c,0x64", "int", txt_massage.Text, "");
            }
        }

        private void btn_apply_yoga_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txt_yoga.Text))
            {
                memLib.writeMemory("UnityPlayer.dll+01098F5C,0x0,0x204,0x3c,0x2c,0x68", "int", txt_yoga.Text, "");
            }
        }

        private void btn_apply_taekwondo_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txt_taekwondo.Text))
            {
                memLib.writeMemory("UnityPlayer.dll+01098F5C,0x0,0x204,0x3c,0x2c,0x6c", "int", txt_taekwondo.Text, "");
            }
        }

        private void btn_apply_breakdance_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txt_breakdance.Text))
            {
                memLib.writeMemory("UnityPlayer.dll+01098F5C,0x0,0x204,0x3c,0x2c,0x70", "int", txt_breakdance.Text, "");
            }
        }

        private void btn_reload_reputations_Click(object sender, EventArgs e)
        {
            txt_group_alice.Text = memLib.readInt("UnityPlayer.dll+01098F5C,0x0,0x204,0x3c,0x2c,0x1f4").ToString();
            txt_group_twins.Text = memLib.readInt("UnityPlayer.dll+01098F5C,0x0,0x204,0x3c,0x2c,0x1f8").ToString();
            txt_cheerleaders.Text = memLib.readInt("UnityPlayer.dll+01098F5C,0x0,0x204,0x3c,0x2c,0x1fc").ToString();
            txt_populars.Text = memLib.readInt("UnityPlayer.dll+01098F5C,0x0,0x204,0x3c,0x2c,0x200").ToString();
            txt_nerds.Text = memLib.readInt("UnityPlayer.dll+01098F5C,0x0,0x204,0x3c,0x2c,0x204").ToString();
            txt_outsiders.Text = memLib.readInt("UnityPlayer.dll+01098F5C,0x0,0x204,0x3c,0x2c,0x208").ToString();
            txt_teachers.Text = memLib.readInt("UnityPlayer.dll+01098F5C,0x0,0x204,0x3c,0x2c,0x20c").ToString();
        }

        private void btn_apply_alice_group_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txt_group_alice.Text))
            {
                memLib.writeMemory("UnityPlayer.dll+01098F5C,0x0,0x204,0x3c,0x2c,0x1f4", "int", txt_group_alice.Text, "");
            }
        }

        private void btn_apply_twins_group_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txt_group_twins.Text))
            {
                memLib.writeMemory("UnityPlayer.dll+01098F5C,0x0,0x204,0x3c,0x2c,0x1f8", "int", txt_group_twins.Text, "");
            }
        }

        private void btn_apply_cheerleaders_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txt_cheerleaders.Text))
            {
                memLib.writeMemory("UnityPlayer.dll+01098F5C,0x0,0x204,0x3c,0x2c,0x1fc", "int", txt_cheerleaders.Text, "");
            }
        }

        private void btn_apply_populars_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txt_populars.Text))
            {
                memLib.writeMemory("UnityPlayer.dll+01098F5C,0x0,0x204,0x3c,0x2c,0x200", "int", txt_populars.Text, "");
            }
        }

        private void btn_apply_nerds_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txt_nerds.Text))
            {
                memLib.writeMemory("UnityPlayer.dll+01098F5C,0x0,0x204,0x3c,0x2c,0x204", "int", txt_nerds.Text, "");
            }
        }

        private void btn_apply_outsiders_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txt_outsiders.Text))
            {
                memLib.writeMemory("UnityPlayer.dll+01098F5C,0x0,0x204,0x3c,0x2c,0x208", "int", txt_outsiders.Text, "");
            }
        }

        private void btn_apply_teachers_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txt_teachers.Text))
            {
                memLib.writeMemory("UnityPlayer.dll+01098F5C,0x0,0x204,0x3c,0x2c,0x20c", "int", txt_teachers.Text, "");
            }
        }

        private void btn_relationship_Click(object sender, EventArgs e)
        {
            
            RelationshipEditor re = new RelationshipEditor(memLib);
            re.ShowDialog();
        }
    }
}
