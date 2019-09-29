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
    public partial class RelationshipEditor : MetroForm
    {
        Mem memLib;
        string currentPerson;
        string baseAddress = "UnityPlayer.dll+01098F5C,0x0,0x204,0x3c,0x2c,";
        Dictionary<string, string> relationAddr = new Dictionary<string, string>{
            {"Alice", "0x90" }, {"Mimi", "0x94" }, {"Maria", "0x98" } , {"Tenma", "0x100" }, {"Sharon", "0x104" },
            {"Vicky", "0xa8" }, {"Seth", "0xb4" }, {"Emily", "0xa0" }, {"Ako", "0x9c" }, {"Bill", "0xb0" },
            { "Chanise", "0xa4" }, {"Erwan", "0xd4" }, {"Mathew", "0xd0" }, {"Lee", "0xcc" }, {"Iris", "0xb8" },
            { "Mayo", "0xbc" }, {"Christy", "0xc0" }, {"Karly", "0xc4" }, {"Charlotte", "0xc8" }, {"Dan", "0xec" },
            { "Bryan", "0xf0" }, {"Beverly", "0xe8" }, {"Lily", "0xdc" }, {"Hailey", "0xe0" }, { "Margaret", "0xe4" },
            { "AvaMia", "0xd8" }
        };

        Dictionary<string, string> lustAddr = new Dictionary<string, string>{
            {"Alice", "0x108" }, {"Mimi", "0x10c" }, {"Maria", "0x110" } , {"Tenma", "0x15c" },
            {"Triss", "0x164" }, {"Vicky", "0x120" }, {"Emily", "0x118" }, {"Ako", "0x114" },
            {"Chanise", "0x11c" }, {"Iris", "0x128" }, {"Mayo", "0x12c" }, {"Christy", "0x130" },
            { "Karly", "0x134" }, {"Charlotte", "0x138" }, {"Beverly", "0x14c" }, {"Lily", "0x140" }, {"Hailey", "0x144" },
            { "Margaret", "0x148" }, {"AvaMia", "0x13c" }
        };

        Dictionary<string, string> lustOtherAddr = new Dictionary<string, string>{
            {"Alice", "0x154" }, {"Maria", "0x158" },
            { "Sharon", "0x160" }, {"Lee", "0x160" },
        };

        public RelationshipEditor(Mem memlib)
        {
            InitializeComponent();
            this.memLib = memlib;
            stats.Hide();
        }

        private void RelationTextChanged(object sender, EventArgs e)
        {
            int val;
            int i;
            if (!String.IsNullOrWhiteSpace(relation_val.Text))
            {
                if (int.TryParse(relation_val.Text, out i))
                {
                    if ((i <= 200) && (i >= 0))
                    {
                        relation_val.Text = i.ToString();
                        val = i;
                        trackbar_relation.Value = val;
                    }
                    else if (i > 200)
                    {
                        relation_val.Text = "200";
                        val = 200;
                        trackbar_relation.Value = val;
                    }
                    else
                    {
                        relation_val.Text = "0";
                        val = 0;
                        trackbar_relation.Value = val;
                    }
                }
                else
                {
                    val = 0;
                }
            }
            else
            {
                relation_val.Text = "0";
                val = 0;
                trackbar_relation.Value = val;
            }
            
            if(val <= 10) {
                relation_bar.Image = SLFTrainers.Properties.Resources.smiley_0;
            }
            else if ((val>10) && (val < 25))
            {
                //.5
                relation_bar.Image = SLFTrainers.Properties.Resources.smiley_1;
            }
            else if ((val>=25) && (val<37)) {
                //1
                relation_bar.Image = SLFTrainers.Properties.Resources.smiley_2;
            }
            else if ((val >= 37) && (val < 50))
            {
                //1.5
                relation_bar.Image = SLFTrainers.Properties.Resources.smiley_3;
            }
            else if ((val >= 50) && (val < 75))
            {
                //2
                relation_bar.Image = SLFTrainers.Properties.Resources.smiley_4;
            }
            else if ((val >= 75) && (val < 100))
            {
                //2.5
                relation_bar.Image = SLFTrainers.Properties.Resources.smiley_5;
            }
            else if ((val >= 100) && (val < 125))
            {
                //3
                relation_bar.Image = SLFTrainers.Properties.Resources.smiley_6;
            }
            else if ((val >= 125) && (val < 150))
            {
                //3.5
                relation_bar.Image = SLFTrainers.Properties.Resources.smiley_7;
            }
            else if (val >= 150)
            {
                //4
                relation_bar.Image = SLFTrainers.Properties.Resources.smiley_8;
            }
        }

        private void LustTextChanged(object sender, EventArgs e)
        {
            int val;
            int i;
            if (!String.IsNullOrWhiteSpace(lust_val.Text))
            {
                if (int.TryParse(lust_val.Text, out i))
                {
                    if ((i <= 200) && (i >= 0))
                    {
                        lust_val.Text = i.ToString();
                        val = i;
                        trackbar_lust.Value = val;
                    }
                    else if (i > 200)
                    {
                        lust_val.Text = "200";
                        val = 200;
                        trackbar_lust.Value = val;
                    }
                    else
                    {
                        lust_val.Text = "0";
                        val = 0;
                        trackbar_lust.Value = val;
                    }
                }
                else
                {
                    val = 0;
                }
            }
            else
            {
                lust_val.Text = "0";
                val = 0;
                trackbar_lust.Value = val;
            }
            if (val <= 10)
            {
                lust_bar.Image = SLFTrainers.Properties.Resources.coeur_0;
            }
            else if ((val > 10) && (val < 25))
            {
                //.5
                lust_bar.Image = SLFTrainers.Properties.Resources.coeur_1;
            }
            else if ((val >= 25) && (val < 37))
            {
                //1
                lust_bar.Image = SLFTrainers.Properties.Resources.coeur_2;
            }
            else if ((val >= 37) && (val < 50))
            {
                //1.5
                lust_bar.Image = SLFTrainers.Properties.Resources.coeur_3;
            }
            else if ((val >= 50) && (val < 75))
            {
                //2
                lust_bar.Image = SLFTrainers.Properties.Resources.coeur_4;
            }
            else if ((val >= 75) && (val < 100))
            {
                //2.5
                lust_bar.Image = SLFTrainers.Properties.Resources.coeur_5;
            }
            else if ((val >= 100) && (val < 125))
            {
                //3
                lust_bar.Image = SLFTrainers.Properties.Resources.coeur_6;
            }
            else if ((val >= 125) && (val < 150))
            {
                //3.5
                lust_bar.Image = SLFTrainers.Properties.Resources.coeur_7;
            }
            else if (val >= 150)
            {
                //4
                lust_bar.Image = SLFTrainers.Properties.Resources.coeur_8;
            }
        }

        private void LustToTextChanged(object sender, EventArgs e)
        {
            int val;
            int i;
            if (!String.IsNullOrWhiteSpace(lust_to_val.Text))
            {
                if (int.TryParse(lust_to_val.Text, out i))
                {
                    if ((i <= 200) && (i >= 0))
                    {
                        lust_to_val.Text = i.ToString();
                        val = i;
                        trackbar_lust_to.Value = val;
                    }
                    else if (i > 200)
                    {
                        lust_to_val.Text = "200";
                        val = 200;
                        trackbar_lust_to.Value = val;
                    }
                    else
                    {
                        lust_to_val.Text = "0";
                        val = 0;
                        trackbar_lust_to.Value = val;
                    }
                }
                else
                {
                    val = 0;
                }
            }
            else
            {
                lust_to_val.Text = "0";
                val = 0;
                trackbar_lust_to.Value = val;
            }
            if (val <= 10)
            {
                lust_to_bar.Image = SLFTrainers.Properties.Resources.coeur_0;
            }
            else if ((val > 10) && (val < 25))
            {
                //.5
                lust_to_bar.Image = SLFTrainers.Properties.Resources.coeur_1;
            }
            else if ((val >= 25) && (val < 37))
            {
                //1
                lust_to_bar.Image = SLFTrainers.Properties.Resources.coeur_2;
            }
            else if ((val >= 37) && (val < 50))
            {
                //1.5
                lust_to_bar.Image = SLFTrainers.Properties.Resources.coeur_3;
            }
            else if ((val >= 50) && (val < 75))
            {
                //2
                lust_to_bar.Image = SLFTrainers.Properties.Resources.coeur_4;
            }
            else if ((val >= 75) && (val < 100))
            {
                //2.5
                lust_to_bar.Image = SLFTrainers.Properties.Resources.coeur_5;
            }
            else if ((val >= 100) && (val < 125))
            {
                //3
                lust_to_bar.Image = SLFTrainers.Properties.Resources.coeur_6;
            }
            else if ((val >= 125) && (val < 150))
            {
                //3.5
                lust_to_bar.Image = SLFTrainers.Properties.Resources.coeur_7;
            }
            else if (val >= 150)
            {
                //4
                lust_to_bar.Image = SLFTrainers.Properties.Resources.coeur_8;
            }
        }

        private void metroTrackBar1_Scroll(object sender, EventArgs e)
        {
            relation_val.Text = trackbar_relation.Value.ToString();
        }

        private void metroTrackBar2_Scroll(object sender, EventArgs e)
        {
            lust_val.Text = trackbar_lust.Value.ToString();
        }

        private void metroTrackBar3_Scroll(object sender, EventArgs e)
        {
            lust_to_val.Text = trackbar_lust_to.Value.ToString();
        }

        private void btn_alice_Click(object sender, EventArgs e)
        {
            label_status.Text = "Status: ";
            currentPerson = "Alice";
            stats.Show();
            if (relationAddr.ContainsKey("Alice"))
            {
                relation_val.Text = memLib.readInt(baseAddress + relationAddr["Alice"]).ToString();
                metroLabel19.Show();
                trackbar_relation.Show();
                relation_val.Show();
                relation_bar.Show();
            }
            else
            {
                metroLabel19.Hide();
                trackbar_relation.Hide();
                relation_val.Hide();
                relation_bar.Hide();
            }
            if (lustAddr.ContainsKey("Alice"))
            {
                lust_val.Text = memLib.readInt(baseAddress + lustAddr["Alice"]).ToString();
                metroLabel29.Show();
                trackbar_lust.Show();
                lust_val.Show();
                lust_bar.Show();
            }
            else
            {
                metroLabel29.Hide();
                trackbar_lust.Hide();
                lust_val.Hide();
                lust_bar.Hide();
            }
            if (lustOtherAddr.ContainsKey("Alice"))
            {
                metroLabel30.ResetText();
                metroLabel30.Text = "Lust for Ako";
                lust_to_val.Text = memLib.readInt(baseAddress + lustOtherAddr["Alice"]).ToString();
                metroLabel30.Show();
                trackbar_lust_to.Show();
                lust_to_val.Show();
                lust_to_bar.Show();
            }
            else
            {
                metroLabel30.Hide();
                trackbar_lust_to.Hide();
                lust_to_val.Hide();
                lust_to_bar.Hide();
            }
        }

        private void btn_mimi_Click(object sender, EventArgs e)
        {
            label_status.Text = "Status: ";
            currentPerson = "Mimi";
            stats.Show();
            if (relationAddr.ContainsKey("Mimi"))
            {
                relation_val.Text = memLib.readInt(baseAddress + relationAddr["Mimi"]).ToString();
                metroLabel19.Show();
                trackbar_relation.Show();
                relation_val.Show();
                relation_bar.Show();
            }
            else
            {
                metroLabel19.Hide();
                trackbar_relation.Hide();
                relation_val.Hide();
                relation_bar.Hide();
            }
            if (lustAddr.ContainsKey("Mimi"))
            {
                lust_val.Text = memLib.readInt(baseAddress + lustAddr["Mimi"]).ToString();
                metroLabel29.Show();
                trackbar_lust.Show();
                lust_val.Show();
                lust_bar.Show();
            }
            else
            {
                metroLabel29.Hide();
                trackbar_lust.Hide();
                lust_val.Hide();
                lust_bar.Hide();
            }
            if (lustOtherAddr.ContainsKey("Mimi"))
            {
                metroLabel30.ResetText();
                metroLabel30.Text = "Lust for ";
                lust_to_val.Text = memLib.readInt(baseAddress + lustOtherAddr["Mimi"]).ToString();
                metroLabel30.Show();
                trackbar_lust_to.Show();
                lust_to_val.Show();
                lust_to_bar.Show();
            }
            else
            {
                metroLabel30.Hide();
                trackbar_lust_to.Hide();
                lust_to_val.Hide();
                lust_to_bar.Hide();
            }
        }

        private void btn_maria_Click(object sender, EventArgs e)
        {
            label_status.Text = "Status: ";
            currentPerson = "Maria";
            stats.Show();
            if (relationAddr.ContainsKey("Maria"))
            {
                relation_val.Text = memLib.readInt(baseAddress + relationAddr["Maria"]).ToString();
                metroLabel19.Show();
                trackbar_relation.Show();
                relation_val.Show();
                relation_bar.Show();
            }
            else
            {
                metroLabel19.Hide();
                trackbar_relation.Hide();
                relation_val.Hide();
                relation_bar.Hide();
            }
            if (lustAddr.ContainsKey("Maria"))
            {
                lust_val.Text = memLib.readInt(baseAddress + lustAddr["Maria"]).ToString();
                metroLabel29.Show();
                trackbar_lust.Show();
                lust_val.Show();
                lust_bar.Show();
            }
            else
            {
                metroLabel29.Hide();
                trackbar_lust.Hide();
                lust_val.Hide();
                lust_bar.Hide();
            }
            if (lustOtherAddr.ContainsKey("Maria"))
            {
                metroLabel30.ResetText();
                metroLabel30.Text = "Lust for Martin";
                lust_to_val.Text = memLib.readInt(baseAddress + lustOtherAddr["Maria"]).ToString();
                metroLabel30.Show();
                trackbar_lust_to.Show();
                lust_to_val.Show();
                lust_to_bar.Show();
            }
            else
            {
                metroLabel30.Hide();
                trackbar_lust_to.Hide();
                lust_to_val.Hide();
                lust_to_bar.Hide();
            }
        }

        private void btn_vicky_Click(object sender, EventArgs e)
        {
            label_status.Text = "Status: ";
            currentPerson = "Vicky";
            stats.Show();
            if (relationAddr.ContainsKey("Vicky"))
            {
                relation_val.Text = memLib.readInt(baseAddress + relationAddr["Vicky"]).ToString();
                metroLabel19.Show();
                trackbar_relation.Show();
                relation_val.Show();
                relation_bar.Show();
            }
            else
            {
                metroLabel19.Hide();
                trackbar_relation.Hide();
                relation_val.Hide();
                relation_bar.Hide();
            }
            if (lustAddr.ContainsKey("Vicky"))
            {
                lust_val.Text = memLib.readInt(baseAddress + lustAddr["Vicky"]).ToString();
                metroLabel29.Show();
                trackbar_lust.Show();
                lust_val.Show();
                lust_bar.Show();
            }
            else
            {
                metroLabel29.Hide();
                trackbar_lust.Hide();
                lust_val.Hide();
                lust_bar.Hide();
            }
            if (lustOtherAddr.ContainsKey("Vicky"))
            {
                metroLabel30.ResetText();
                metroLabel30.Text = "Lust for ";
                lust_to_val.Text = memLib.readInt(baseAddress + lustOtherAddr["Vicky"]).ToString();
                metroLabel30.Show();
                trackbar_lust_to.Show();
                lust_to_val.Show();
                lust_to_bar.Show();
            }
            else
            {
                metroLabel30.Hide();
                trackbar_lust_to.Hide();
                lust_to_val.Hide();
                lust_to_bar.Hide();
            }
        }

        private void btn_seth_Click(object sender, EventArgs e)
        {
            label_status.Text = "Status: ";
            currentPerson = "Seth";
            stats.Show();
            if (relationAddr.ContainsKey("Seth"))
            {
                relation_val.Text = memLib.readInt(baseAddress + relationAddr["Seth"]).ToString();
                metroLabel19.Show();
                trackbar_relation.Show();
                relation_val.Show();
                relation_bar.Show();
            }
            else
            {
                metroLabel19.Hide();
                trackbar_relation.Hide();
                relation_val.Hide();
                relation_bar.Hide();
            }
            if (lustAddr.ContainsKey("Seth"))
            {
                lust_val.Text = memLib.readInt(baseAddress + lustAddr["Seth"]).ToString();
                metroLabel29.Show();
                trackbar_lust.Show();
                lust_val.Show();
                lust_bar.Show();
            }
            else
            {
                metroLabel29.Hide();
                trackbar_lust.Hide();
                lust_val.Hide();
                lust_bar.Hide();
            }
            if (lustOtherAddr.ContainsKey("Seth"))
            {
                metroLabel30.ResetText();
                metroLabel30.Text = "Lust for ";
                lust_to_val.Text = memLib.readInt(baseAddress + lustOtherAddr["Seth"]).ToString();
                metroLabel30.Show();
                trackbar_lust_to.Show();
                lust_to_val.Show();
                lust_to_bar.Show();
            }
            else
            {
                metroLabel30.Hide();
                trackbar_lust_to.Hide();
                lust_to_val.Hide();
                lust_to_bar.Hide();
            }
        }

        private void btn_emily_Click(object sender, EventArgs e)
        {
            label_status.Text = "Status: ";
            currentPerson = "Emily";
            stats.Show();
            if (relationAddr.ContainsKey("Emily"))
            {
                relation_val.Text = memLib.readInt(baseAddress + relationAddr["Emily"]).ToString();
                metroLabel19.Show();
                trackbar_relation.Show();
                relation_val.Show();
                relation_bar.Show();
            }
            else
            {
                metroLabel19.Hide();
                trackbar_relation.Hide();
                relation_val.Hide();
                relation_bar.Hide();
            }
            if (lustAddr.ContainsKey("Emily"))
            {
                lust_val.Text = memLib.readInt(baseAddress + lustAddr["Emily"]).ToString();
                metroLabel29.Show();
                trackbar_lust.Show();
                lust_val.Show();
                lust_bar.Show();
            }
            else
            {
                metroLabel29.Hide();
                trackbar_lust.Hide();
                lust_val.Hide();
                lust_bar.Hide();
            }
            if (lustOtherAddr.ContainsKey("Emily"))
            {
                metroLabel30.ResetText();
                metroLabel30.Text = "Lust for ";
                lust_to_val.Text = memLib.readInt(baseAddress + lustOtherAddr["Emily"]).ToString();
                metroLabel30.Show();
                trackbar_lust_to.Show();
                lust_to_val.Show();
                lust_to_bar.Show();
            }
            else
            {
                metroLabel30.Hide();
                trackbar_lust_to.Hide();
                lust_to_val.Hide();
                lust_to_bar.Hide();
            }
        }

        private void btn_tenma_Click(object sender, EventArgs e)
        {
            label_status.Text = "Status: ";
            currentPerson = "Tenma";
            stats.Show();
            if (relationAddr.ContainsKey(currentPerson))
            {
                relation_val.Text = memLib.readInt(baseAddress + relationAddr[currentPerson]).ToString();
                metroLabel19.Show();
                trackbar_relation.Show();
                relation_val.Show();
                relation_bar.Show();
            }
            else
            {
                metroLabel19.Hide();
                trackbar_relation.Hide();
                relation_val.Hide();
                relation_bar.Hide();
            }
            if (lustAddr.ContainsKey(currentPerson))
            {
                lust_val.Text = memLib.readInt(baseAddress + lustAddr[currentPerson]).ToString();
                metroLabel29.Show();
                trackbar_lust.Show();
                lust_val.Show();
                lust_bar.Show();
            }
            else
            {
                metroLabel29.Hide();
                trackbar_lust.Hide();
                lust_val.Hide();
                lust_bar.Hide();
            }
            if (lustOtherAddr.ContainsKey(currentPerson))
            {
                metroLabel30.ResetText();
                metroLabel30.Text = "Lust for ";
                lust_to_val.Text = memLib.readInt(baseAddress + lustOtherAddr[currentPerson]).ToString();
                metroLabel30.Show();
                trackbar_lust_to.Show();
                lust_to_val.Show();
                lust_to_bar.Show();
            }
            else
            {
                metroLabel30.Hide();
                trackbar_lust_to.Hide();
                lust_to_val.Hide();
                lust_to_bar.Hide();
            }
        }

        private void btn_sharon_Click(object sender, EventArgs e)
        {
            label_status.Text = "Status: ";
            currentPerson = "Sharon";
            stats.Show();
            if (relationAddr.ContainsKey(currentPerson))
            {
                relation_val.Text = memLib.readInt(baseAddress + relationAddr[currentPerson]).ToString();
                metroLabel19.Show();
                trackbar_relation.Show();
                relation_val.Show();
                relation_bar.Show();
            }
            else
            {
                metroLabel19.Hide();
                trackbar_relation.Hide();
                relation_val.Hide();
                relation_bar.Hide();
            }
            if (lustAddr.ContainsKey(currentPerson))
            {
                lust_val.Text = memLib.readInt(baseAddress + lustAddr[currentPerson]).ToString();
                metroLabel29.Show();
                trackbar_lust.Show();
                lust_val.Show();
                lust_bar.Show();
            }
            else
            {
                metroLabel29.Hide();
                trackbar_lust.Hide();
                lust_val.Hide();
                lust_bar.Hide();
            }
            if (lustOtherAddr.ContainsKey(currentPerson))
            {
                metroLabel30.ResetText();
                metroLabel30.Text = "Lust for Lee";
                lust_to_val.Text = memLib.readInt(baseAddress + lustOtherAddr[currentPerson]).ToString();
                metroLabel30.Show();
                trackbar_lust_to.Show();
                lust_to_val.Show();
                lust_to_bar.Show();
            }
            else
            {
                metroLabel30.Hide();
                trackbar_lust_to.Hide();
                lust_to_val.Hide();
                lust_to_bar.Hide();
            }
        }

        private void btn_triss_Click(object sender, EventArgs e)
        {
            label_status.Text = "Status: ";
            currentPerson = "Triss";
            stats.Show();
            if (relationAddr.ContainsKey(currentPerson))
            {
                relation_val.Text = memLib.readInt(baseAddress + relationAddr[currentPerson]).ToString();
                metroLabel19.Show();
                trackbar_relation.Show();
                relation_val.Show();
                relation_bar.Show();
            }
            else
            {
                metroLabel19.Hide();
                trackbar_relation.Hide();
                relation_val.Hide();
                relation_bar.Hide();
            }
            if (lustAddr.ContainsKey(currentPerson))
            {
                lust_val.Text = memLib.readInt(baseAddress + lustAddr[currentPerson]).ToString();
                metroLabel29.Show();
                trackbar_lust.Show();
                lust_val.Show();
                lust_bar.Show();
            }
            else
            {
                metroLabel29.Hide();
                trackbar_lust.Hide();
                lust_val.Hide();
                lust_bar.Hide();
            }
            if (lustOtherAddr.ContainsKey(currentPerson))
            {
                metroLabel30.ResetText();
                metroLabel30.Text = "Lust for ";
                lust_to_val.Text = memLib.readInt(baseAddress + lustOtherAddr[currentPerson]).ToString();
                metroLabel30.Show();
                trackbar_lust_to.Show();
                lust_to_val.Show();
                lust_to_bar.Show();
            }
            else
            {
                metroLabel30.Hide();
                trackbar_lust_to.Hide();
                lust_to_val.Hide();
                lust_to_bar.Hide();
            }
        }

        private void btn_ako_Click(object sender, EventArgs e)
        {
            label_status.Text = "Status: ";
            currentPerson = "Ako";
            stats.Show();
            if (relationAddr.ContainsKey(currentPerson))
            {
                relation_val.Text = memLib.readInt(baseAddress + relationAddr[currentPerson]).ToString();
                metroLabel19.Show();
                trackbar_relation.Show();
                relation_val.Show();
                relation_bar.Show();
            }
            else
            {
                metroLabel19.Hide();
                trackbar_relation.Hide();
                relation_val.Hide();
                relation_bar.Hide();
            }
            if (lustAddr.ContainsKey(currentPerson))
            {
                lust_val.Text = memLib.readInt(baseAddress + lustAddr[currentPerson]).ToString();
                metroLabel29.Show();
                trackbar_lust.Show();
                lust_val.Show();
                lust_bar.Show();
            }
            else
            {
                metroLabel29.Hide();
                trackbar_lust.Hide();
                lust_val.Hide();
                lust_bar.Hide();
            }
            if (lustOtherAddr.ContainsKey(currentPerson))
            {
                metroLabel30.ResetText();
                metroLabel30.Text = "Lust for ";
                lust_to_val.Text = memLib.readInt(baseAddress + lustOtherAddr[currentPerson]).ToString();
                metroLabel30.Show();
                trackbar_lust_to.Show();
                lust_to_val.Show();
                lust_to_bar.Show();
            }
            else
            {
                metroLabel30.Hide();
                trackbar_lust_to.Hide();
                lust_to_val.Hide();
                lust_to_bar.Hide();
            }
        }

        private void btn_bill_Click(object sender, EventArgs e)
        {
            label_status.Text = "Status: ";
            currentPerson = "Bill";
            stats.Show();
            if (relationAddr.ContainsKey(currentPerson))
            {
                relation_val.Text = memLib.readInt(baseAddress + relationAddr[currentPerson]).ToString();
                metroLabel19.Show();
                trackbar_relation.Show();
                relation_val.Show();
                relation_bar.Show();
            }
            else
            {
                metroLabel19.Hide();
                trackbar_relation.Hide();
                relation_val.Hide();
                relation_bar.Hide();
            }
            if (lustAddr.ContainsKey(currentPerson))
            {
                lust_val.Text = memLib.readInt(baseAddress + lustAddr[currentPerson]).ToString();
                metroLabel29.Show();
                trackbar_lust.Show();
                lust_val.Show();
                lust_bar.Show();
            }
            else
            {
                metroLabel29.Hide();
                trackbar_lust.Hide();
                lust_val.Hide();
                lust_bar.Hide();
            }
            if (lustOtherAddr.ContainsKey(currentPerson))
            {
                metroLabel30.ResetText();
                metroLabel30.Text = "Lust for ";
                lust_to_val.Text = memLib.readInt(baseAddress + lustOtherAddr[currentPerson]).ToString();
                metroLabel30.Show();
                trackbar_lust_to.Show();
                lust_to_val.Show();
                lust_to_bar.Show();
            }
            else
            {
                metroLabel30.Hide();
                trackbar_lust_to.Hide();
                lust_to_val.Hide();
                lust_to_bar.Hide();
            }
        }

        private void btn_chanise_Click(object sender, EventArgs e)
        {
            label_status.Text = "Status: ";
            currentPerson = "Chanise";
            stats.Show();
            if (relationAddr.ContainsKey(currentPerson))
            {
                relation_val.Text = memLib.readInt(baseAddress + relationAddr[currentPerson]).ToString();
                metroLabel19.Show();
                trackbar_relation.Show();
                relation_val.Show();
                relation_bar.Show();
            }
            else
            {
                metroLabel19.Hide();
                trackbar_relation.Hide();
                relation_val.Hide();
                relation_bar.Hide();
            }
            if (lustAddr.ContainsKey(currentPerson))
            {
                lust_val.Text = memLib.readInt(baseAddress + lustAddr[currentPerson]).ToString();
                metroLabel29.Show();
                trackbar_lust.Show();
                lust_val.Show();
                lust_bar.Show();
            }
            else
            {
                metroLabel29.Hide();
                trackbar_lust.Hide();
                lust_val.Hide();
                lust_bar.Hide();
            }
            if (lustOtherAddr.ContainsKey(currentPerson))
            {
                metroLabel30.ResetText();
                metroLabel30.Text = "Lust for ";
                lust_to_val.Text = memLib.readInt(baseAddress + lustOtherAddr[currentPerson]).ToString();
                metroLabel30.Show();
                trackbar_lust_to.Show();
                lust_to_val.Show();
                lust_to_bar.Show();
            }
            else
            {
                metroLabel30.Hide();
                trackbar_lust_to.Hide();
                lust_to_val.Hide();
                lust_to_bar.Hide();
            }
        }

        private void btn_erwan_Click(object sender, EventArgs e)
        {
            label_status.Text = "Status: ";
            currentPerson = "Erwan";
            stats.Show();
            if (relationAddr.ContainsKey(currentPerson))
            {
                relation_val.Text = memLib.readInt(baseAddress + relationAddr[currentPerson]).ToString();
                metroLabel19.Show();
                trackbar_relation.Show();
                relation_val.Show();
                relation_bar.Show();
            }
            else
            {
                metroLabel19.Hide();
                trackbar_relation.Hide();
                relation_val.Hide();
                relation_bar.Hide();
            }
            if (lustAddr.ContainsKey(currentPerson))
            {
                lust_val.Text = memLib.readInt(baseAddress + lustAddr[currentPerson]).ToString();
                metroLabel29.Show();
                trackbar_lust.Show();
                lust_val.Show();
                lust_bar.Show();
            }
            else
            {
                metroLabel29.Hide();
                trackbar_lust.Hide();
                lust_val.Hide();
                lust_bar.Hide();
            }
            if (lustOtherAddr.ContainsKey(currentPerson))
            {
                metroLabel30.ResetText();
                metroLabel30.Text = "Lust for ";
                lust_to_val.Text = memLib.readInt(baseAddress + lustOtherAddr[currentPerson]).ToString();
                metroLabel30.Show();
                trackbar_lust_to.Show();
                lust_to_val.Show();
                lust_to_bar.Show();
            }
            else
            {
                metroLabel30.Hide();
                trackbar_lust_to.Hide();
                lust_to_val.Hide();
                lust_to_bar.Hide();
            }
        }

        private void btn_mathew_Click(object sender, EventArgs e)
        {
            label_status.Text = "Status: ";
            currentPerson = "Mathew";
            stats.Show();
            if (relationAddr.ContainsKey(currentPerson))
            {
                relation_val.Text = memLib.readInt(baseAddress + relationAddr[currentPerson]).ToString();
                metroLabel19.Show();
                trackbar_relation.Show();
                relation_val.Show();
                relation_bar.Show();
            }
            else
            {
                metroLabel19.Hide();
                trackbar_relation.Hide();
                relation_val.Hide();
                relation_bar.Hide();
            }
            if (lustAddr.ContainsKey(currentPerson))
            {
                lust_val.Text = memLib.readInt(baseAddress + lustAddr[currentPerson]).ToString();
                metroLabel29.Show();
                trackbar_lust.Show();
                lust_val.Show();
                lust_bar.Show();
            }
            else
            {
                metroLabel29.Hide();
                trackbar_lust.Hide();
                lust_val.Hide();
                lust_bar.Hide();
            }
            if (lustOtherAddr.ContainsKey(currentPerson))
            {
                metroLabel30.ResetText();
                metroLabel30.Text = "Lust for ";
                lust_to_val.Text = memLib.readInt(baseAddress + lustOtherAddr[currentPerson]).ToString();
                metroLabel30.Show();
                trackbar_lust_to.Show();
                lust_to_val.Show();
                lust_to_bar.Show();
            }
            else
            {
                metroLabel30.Hide();
                trackbar_lust_to.Hide();
                lust_to_val.Hide();
                lust_to_bar.Hide();
            }
        }

        private void btn_lee_Click(object sender, EventArgs e)
        {
            label_status.Text = "Status: ";
            currentPerson = "Lee";
            stats.Show();
            if (relationAddr.ContainsKey(currentPerson))
            {
                relation_val.Text = memLib.readInt(baseAddress + relationAddr[currentPerson]).ToString();
                metroLabel19.Show();
                trackbar_relation.Show();
                relation_val.Show();
                relation_bar.Show();
            }
            else
            {
                metroLabel19.Hide();
                trackbar_relation.Hide();
                relation_val.Hide();
                relation_bar.Hide();
            }
            if (lustAddr.ContainsKey(currentPerson))
            {
                lust_val.Text = memLib.readInt(baseAddress + lustAddr[currentPerson]).ToString();
                metroLabel29.Show();
                trackbar_lust.Show();
                lust_val.Show();
                lust_bar.Show();
            }
            else
            {
                metroLabel29.Hide();
                trackbar_lust.Hide();
                lust_val.Hide();
                lust_bar.Hide();
            }
            if (lustOtherAddr.ContainsKey(currentPerson))
            {
                metroLabel30.ResetText();
                metroLabel30.Text = "Lust for Sharon";
                lust_to_val.Text = memLib.readInt(baseAddress + lustOtherAddr[currentPerson]).ToString();
                metroLabel30.Show();
                trackbar_lust_to.Show();
                lust_to_val.Show();
                lust_to_bar.Show();
            }
            else
            {
                metroLabel30.Hide();
                trackbar_lust_to.Hide();
                lust_to_val.Hide();
                lust_to_bar.Hide();
            }
        }

        private void btn_dan_Click(object sender, EventArgs e)
        {
            label_status.Text = "Status: ";
            currentPerson = "Dan";
            stats.Show();
            if (relationAddr.ContainsKey(currentPerson))
            {
                relation_val.Text = memLib.readInt(baseAddress + relationAddr[currentPerson]).ToString();
                metroLabel19.Show();
                trackbar_relation.Show();
                relation_val.Show();
                relation_bar.Show();
            }
            else
            {
                metroLabel19.Hide();
                trackbar_relation.Hide();
                relation_val.Hide();
                relation_bar.Hide();
            }
            if (lustAddr.ContainsKey(currentPerson))
            {
                lust_val.Text = memLib.readInt(baseAddress + lustAddr[currentPerson]).ToString();
                metroLabel29.Show();
                trackbar_lust.Show();
                lust_val.Show();
                lust_bar.Show();
            }
            else
            {
                metroLabel29.Hide();
                trackbar_lust.Hide();
                lust_val.Hide();
                lust_bar.Hide();
            }
            if (lustOtherAddr.ContainsKey(currentPerson))
            {
                metroLabel30.ResetText();
                metroLabel30.Text = "Lust for ";
                lust_to_val.Text = memLib.readInt(baseAddress + lustOtherAddr[currentPerson]).ToString();
                metroLabel30.Show();
                trackbar_lust_to.Show();
                lust_to_val.Show();
                lust_to_bar.Show();
            }
            else
            {
                metroLabel30.Hide();
                trackbar_lust_to.Hide();
                lust_to_val.Hide();
                lust_to_bar.Hide();
            }
        }

        private void btn_bryan_Click(object sender, EventArgs e)
        {
            label_status.Text = "Status: ";
            currentPerson = "Bryan";
            stats.Show();
            if (relationAddr.ContainsKey(currentPerson))
            {
                relation_val.Text = memLib.readInt(baseAddress + relationAddr[currentPerson]).ToString();
                metroLabel19.Show();
                trackbar_relation.Show();
                relation_val.Show();
                relation_bar.Show();
            }
            else
            {
                metroLabel19.Hide();
                trackbar_relation.Hide();
                relation_val.Hide();
                relation_bar.Hide();
            }
            if (lustAddr.ContainsKey(currentPerson))
            {
                lust_val.Text = memLib.readInt(baseAddress + lustAddr[currentPerson]).ToString();
                metroLabel29.Show();
                trackbar_lust.Show();
                lust_val.Show();
                lust_bar.Show();
            }
            else
            {
                metroLabel29.Hide();
                trackbar_lust.Hide();
                lust_val.Hide();
                lust_bar.Hide();
            }
            if (lustOtherAddr.ContainsKey(currentPerson))
            {
                metroLabel30.ResetText();
                metroLabel30.Text = "Lust for ";
                lust_to_val.Text = memLib.readInt(baseAddress + lustOtherAddr[currentPerson]).ToString();
                metroLabel30.Show();
                trackbar_lust_to.Show();
                lust_to_val.Show();
                lust_to_bar.Show();
            }
            else
            {
                metroLabel30.Hide();
                trackbar_lust_to.Hide();
                lust_to_val.Hide();
                lust_to_bar.Hide();
            }
        }

        private void btn_beverly_Click(object sender, EventArgs e)
        {
            label_status.Text = "Status: ";
            currentPerson = "Beverly";
            stats.Show();
            if (relationAddr.ContainsKey(currentPerson))
            {
                relation_val.Text = memLib.readInt(baseAddress + relationAddr[currentPerson]).ToString();
                metroLabel19.Show();
                trackbar_relation.Show();
                relation_val.Show();
                relation_bar.Show();
            }
            else
            {
                metroLabel19.Hide();
                trackbar_relation.Hide();
                relation_val.Hide();
                relation_bar.Hide();
            }
            if (lustAddr.ContainsKey(currentPerson))
            {
                lust_val.Text = memLib.readInt(baseAddress + lustAddr[currentPerson]).ToString();
                metroLabel29.Show();
                trackbar_lust.Show();
                lust_val.Show();
                lust_bar.Show();
            }
            else
            {
                metroLabel29.Hide();
                trackbar_lust.Hide();
                lust_val.Hide();
                lust_bar.Hide();
            }
            if (lustOtherAddr.ContainsKey(currentPerson))
            {
                metroLabel30.ResetText();
                metroLabel30.Text = "Lust for ";
                lust_to_val.Text = memLib.readInt(baseAddress + lustOtherAddr[currentPerson]).ToString();
                metroLabel30.Show();
                trackbar_lust_to.Show();
                lust_to_val.Show();
                lust_to_bar.Show();
            }
            else
            {
                metroLabel30.Hide();
                trackbar_lust_to.Hide();
                lust_to_val.Hide();
                lust_to_bar.Hide();
            }
        }

        private void btn_iris_Click(object sender, EventArgs e)
        {
            label_status.Text = "Status: ";
            currentPerson = "Iris";
            stats.Show();
            if (relationAddr.ContainsKey(currentPerson))
            {
                relation_val.Text = memLib.readInt(baseAddress + relationAddr[currentPerson]).ToString();
                metroLabel19.Show();
                trackbar_relation.Show();
                relation_val.Show();
                relation_bar.Show();
            }
            else
            {
                metroLabel19.Hide();
                trackbar_relation.Hide();
                relation_val.Hide();
                relation_bar.Hide();
            }
            if (lustAddr.ContainsKey(currentPerson))
            {
                lust_val.Text = memLib.readInt(baseAddress + lustAddr[currentPerson]).ToString();
                metroLabel29.Show();
                trackbar_lust.Show();
                lust_val.Show();
                lust_bar.Show();
            }
            else
            {
                metroLabel29.Hide();
                trackbar_lust.Hide();
                lust_val.Hide();
                lust_bar.Hide();
            }
            if (lustOtherAddr.ContainsKey(currentPerson))
            {
                metroLabel30.ResetText();
                metroLabel30.Text = "Lust for ";
                lust_to_val.Text = memLib.readInt(baseAddress + lustOtherAddr[currentPerson]).ToString();
                metroLabel30.Show();
                trackbar_lust_to.Show();
                lust_to_val.Show();
                lust_to_bar.Show();
            }
            else
            {
                metroLabel30.Hide();
                trackbar_lust_to.Hide();
                lust_to_val.Hide();
                lust_to_bar.Hide();
            }
        }

        private void btn_mayo_Click(object sender, EventArgs e)
        {
            label_status.Text = "Status: ";
            currentPerson = "Mayo";
            stats.Show();
            if (relationAddr.ContainsKey(currentPerson))
            {
                relation_val.Text = memLib.readInt(baseAddress + relationAddr[currentPerson]).ToString();
                metroLabel19.Show();
                trackbar_relation.Show();
                relation_val.Show();
                relation_bar.Show();
            }
            else
            {
                metroLabel19.Hide();
                trackbar_relation.Hide();
                relation_val.Hide();
                relation_bar.Hide();
            }
            if (lustAddr.ContainsKey(currentPerson))
            {
                lust_val.Text = memLib.readInt(baseAddress + lustAddr[currentPerson]).ToString();
                metroLabel29.Show();
                trackbar_lust.Show();
                lust_val.Show();
                lust_bar.Show();
            }
            else
            {
                metroLabel29.Hide();
                trackbar_lust.Hide();
                lust_val.Hide();
                lust_bar.Hide();
            }
            if (lustOtherAddr.ContainsKey(currentPerson))
            {
                metroLabel30.ResetText();
                metroLabel30.Text = "Lust for ";
                lust_to_val.Text = memLib.readInt(baseAddress + lustOtherAddr[currentPerson]).ToString();
                metroLabel30.Show();
                trackbar_lust_to.Show();
                lust_to_val.Show();
                lust_to_bar.Show();
            }
            else
            {
                metroLabel30.Hide();
                trackbar_lust_to.Hide();
                lust_to_val.Hide();
                lust_to_bar.Hide();
            }
        }

        private void btn_christy_Click(object sender, EventArgs e)
        {
            label_status.Text = "Status: ";
            currentPerson = "Christy";
            stats.Show();
            if (relationAddr.ContainsKey(currentPerson))
            {
                relation_val.Text = memLib.readInt(baseAddress + relationAddr[currentPerson]).ToString();
                metroLabel19.Show();
                trackbar_relation.Show();
                relation_val.Show();
                relation_bar.Show();
            }
            else
            {
                metroLabel19.Hide();
                trackbar_relation.Hide();
                relation_val.Hide();
                relation_bar.Hide();
            }
            if (lustAddr.ContainsKey(currentPerson))
            {
                lust_val.Text = memLib.readInt(baseAddress + lustAddr[currentPerson]).ToString();
                metroLabel29.Show();
                trackbar_lust.Show();
                lust_val.Show();
                lust_bar.Show();
            }
            else
            {
                metroLabel29.Hide();
                trackbar_lust.Hide();
                lust_val.Hide();
                lust_bar.Hide();
            }
            if (lustOtherAddr.ContainsKey(currentPerson))
            {
                metroLabel30.ResetText();
                metroLabel30.Text = "Lust for ";
                lust_to_val.Text = memLib.readInt(baseAddress + lustOtherAddr[currentPerson]).ToString();
                metroLabel30.Show();
                trackbar_lust_to.Show();
                lust_to_val.Show();
                lust_to_bar.Show();
            }
            else
            {
                metroLabel30.Hide();
                trackbar_lust_to.Hide();
                lust_to_val.Hide();
                lust_to_bar.Hide();
            }
        }

        private void btn_lily_Click(object sender, EventArgs e)
        {
            label_status.Text = "Status: ";
            currentPerson = "Lily";
            stats.Show();
            if (relationAddr.ContainsKey(currentPerson))
            {
                relation_val.Text = memLib.readInt(baseAddress + relationAddr[currentPerson]).ToString();
                metroLabel19.Show();
                trackbar_relation.Show();
                relation_val.Show();
                relation_bar.Show();
            }
            else
            {
                metroLabel19.Hide();
                trackbar_relation.Hide();
                relation_val.Hide();
                relation_bar.Hide();
            }
            if (lustAddr.ContainsKey(currentPerson))
            {
                lust_val.Text = memLib.readInt(baseAddress + lustAddr[currentPerson]).ToString();
                metroLabel29.Show();
                trackbar_lust.Show();
                lust_val.Show();
                lust_bar.Show();
            }
            else
            {
                metroLabel29.Hide();
                trackbar_lust.Hide();
                lust_val.Hide();
                lust_bar.Hide();
            }
            if (lustOtherAddr.ContainsKey(currentPerson))
            {
                metroLabel30.ResetText();
                metroLabel30.Text = "Lust for ";
                lust_to_val.Text = memLib.readInt(baseAddress + lustOtherAddr[currentPerson]).ToString();
                metroLabel30.Show();
                trackbar_lust_to.Show();
                lust_to_val.Show();
                lust_to_bar.Show();
            }
            else
            {
                metroLabel30.Hide();
                trackbar_lust_to.Hide();
                lust_to_val.Hide();
                lust_to_bar.Hide();
            }
        }

        private void btn_hailey_Click(object sender, EventArgs e)
        {
            label_status.Text = "Status: ";
            currentPerson = "Hailey";
            stats.Show();
            if (relationAddr.ContainsKey(currentPerson))
            {
                relation_val.Text = memLib.readInt(baseAddress + relationAddr[currentPerson]).ToString();
                metroLabel19.Show();
                trackbar_relation.Show();
                relation_val.Show();
                relation_bar.Show();
            }
            else
            {
                metroLabel19.Hide();
                trackbar_relation.Hide();
                relation_val.Hide();
                relation_bar.Hide();
            }
            if (lustAddr.ContainsKey(currentPerson))
            {
                lust_val.Text = memLib.readInt(baseAddress + lustAddr[currentPerson]).ToString();
                metroLabel29.Show();
                trackbar_lust.Show();
                lust_val.Show();
                lust_bar.Show();
            }
            else
            {
                metroLabel29.Hide();
                trackbar_lust.Hide();
                lust_val.Hide();
                lust_bar.Hide();
            }
            if (lustOtherAddr.ContainsKey(currentPerson))
            {
                metroLabel30.ResetText();
                metroLabel30.Text = "Lust for ";
                lust_to_val.Text = memLib.readInt(baseAddress + lustOtherAddr[currentPerson]).ToString();
                metroLabel30.Show();
                trackbar_lust_to.Show();
                lust_to_val.Show();
                lust_to_bar.Show();
            }
            else
            {
                metroLabel30.Hide();
                trackbar_lust_to.Hide();
                lust_to_val.Hide();
                lust_to_bar.Hide();
            }
        }

        private void btn_margaret_Click(object sender, EventArgs e)
        {
            label_status.Text = "Status: ";
            currentPerson = "Margaret";
            stats.Show();
            if (relationAddr.ContainsKey(currentPerson))
            {
                relation_val.Text = memLib.readInt(baseAddress + relationAddr[currentPerson]).ToString();
                metroLabel19.Show();
                trackbar_relation.Show();
                relation_val.Show();
                relation_bar.Show();
            }
            else
            {
                metroLabel19.Hide();
                trackbar_relation.Hide();
                relation_val.Hide();
                relation_bar.Hide();
            }
            if (lustAddr.ContainsKey(currentPerson))
            {
                lust_val.Text = memLib.readInt(baseAddress + lustAddr[currentPerson]).ToString();
                metroLabel29.Show();
                trackbar_lust.Show();
                lust_val.Show();
                lust_bar.Show();
            }
            else
            {
                metroLabel29.Hide();
                trackbar_lust.Hide();
                lust_val.Hide();
                lust_bar.Hide();
            }
            if (lustOtherAddr.ContainsKey(currentPerson))
            {
                metroLabel30.ResetText();
                metroLabel30.Text = "Lust for ";
                lust_to_val.Text = memLib.readInt(baseAddress + lustOtherAddr[currentPerson]).ToString();
                metroLabel30.Show();
                trackbar_lust_to.Show();
                lust_to_val.Show();
                lust_to_bar.Show();
            }
            else
            {
                metroLabel30.Hide();
                trackbar_lust_to.Hide();
                lust_to_val.Hide();
                lust_to_bar.Hide();
            }
        }

        private void btn_karly_Click(object sender, EventArgs e)
        {
            label_status.Text = "Status: ";
            currentPerson = "Karly";
            stats.Show();
            if (relationAddr.ContainsKey(currentPerson))
            {
                relation_val.Text = memLib.readInt(baseAddress + relationAddr[currentPerson]).ToString();
                metroLabel19.Show();
                trackbar_relation.Show();
                relation_val.Show();
                relation_bar.Show();
            }
            else
            {
                metroLabel19.Hide();
                trackbar_relation.Hide();
                relation_val.Hide();
                relation_bar.Hide();
            }
            if (lustAddr.ContainsKey(currentPerson))
            {
                lust_val.Text = memLib.readInt(baseAddress + lustAddr[currentPerson]).ToString();
                metroLabel29.Show();
                trackbar_lust.Show();
                lust_val.Show();
                lust_bar.Show();
            }
            else
            {
                metroLabel29.Hide();
                trackbar_lust.Hide();
                lust_val.Hide();
                lust_bar.Hide();
            }
            if (lustOtherAddr.ContainsKey(currentPerson))
            {
                metroLabel30.ResetText();
                metroLabel30.Text = "Lust for ";
                lust_to_val.Text = memLib.readInt(baseAddress + lustOtherAddr[currentPerson]).ToString();
                metroLabel30.Show();
                trackbar_lust_to.Show();
                lust_to_val.Show();
                lust_to_bar.Show();
            }
            else
            {
                metroLabel30.Hide();
                trackbar_lust_to.Hide();
                lust_to_val.Hide();
                lust_to_bar.Hide();
            }
        }

        private void btn_charlotte_Click(object sender, EventArgs e)
        {
            label_status.Text = "Status: ";
            currentPerson = "Charlotte";
            stats.Show();
            if (relationAddr.ContainsKey(currentPerson))
            {
                relation_val.Text = memLib.readInt(baseAddress + relationAddr[currentPerson]).ToString();
                metroLabel19.Show();
                trackbar_relation.Show();
                relation_val.Show();
                relation_bar.Show();
            }
            else
            {
                metroLabel19.Hide();
                trackbar_relation.Hide();
                relation_val.Hide();
                relation_bar.Hide();
            }
            if (lustAddr.ContainsKey(currentPerson))
            {
                lust_val.Text = memLib.readInt(baseAddress + lustAddr[currentPerson]).ToString();
                metroLabel29.Show();
                trackbar_lust.Show();
                lust_val.Show();
                lust_bar.Show();
            }
            else
            {
                metroLabel29.Hide();
                trackbar_lust.Hide();
                lust_val.Hide();
                lust_bar.Hide();
            }
            if (lustOtherAddr.ContainsKey(currentPerson))
            {
                metroLabel30.ResetText();
                metroLabel30.Text = "Lust for ";
                lust_to_val.Text = memLib.readInt(baseAddress + lustOtherAddr[currentPerson]).ToString();
                metroLabel30.Show();
                trackbar_lust_to.Show();
                lust_to_val.Show();
                lust_to_bar.Show();
            }
            else
            {
                metroLabel30.Hide();
                trackbar_lust_to.Hide();
                lust_to_val.Hide();
                lust_to_bar.Hide();
            }
        }

        private void btn_twins_Click(object sender, EventArgs e)
        {
            label_status.Text = "Status: ";
            currentPerson = "AvaMia";
            stats.Show();
            if (relationAddr.ContainsKey(currentPerson))
            {
                relation_val.Text = memLib.readInt(baseAddress + relationAddr[currentPerson]).ToString();
                metroLabel19.Show();
                trackbar_relation.Show();
                relation_val.Show();
                relation_bar.Show();
            }
            else
            {
                metroLabel19.Hide();
                trackbar_relation.Hide();
                relation_val.Hide();
                relation_bar.Hide();
            }
            if (lustAddr.ContainsKey(currentPerson))
            {
                lust_val.Text = memLib.readInt(baseAddress + lustAddr[currentPerson]).ToString();
                metroLabel29.Show();
                trackbar_lust.Show();
                lust_val.Show();
                lust_bar.Show();
            }
            else
            {
                metroLabel29.Hide();
                trackbar_lust.Hide();
                lust_val.Hide();
                lust_bar.Hide();
            }
            if (lustOtherAddr.ContainsKey(currentPerson))
            {
                metroLabel30.ResetText();
                metroLabel30.Text = "Lust for ";
                lust_to_val.Text = memLib.readInt(baseAddress + lustOtherAddr[currentPerson]).ToString();
                metroLabel30.Show();
                trackbar_lust_to.Show();
                lust_to_val.Show();
                lust_to_bar.Show();
            }
            else
            {
                metroLabel30.Hide();
                trackbar_lust_to.Hide();
                lust_to_val.Hide();
                lust_to_bar.Hide();
            }
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {
            if (relationAddr.ContainsKey(currentPerson))
            {
                memLib.writeMemory(baseAddress+ relationAddr[currentPerson].ToString(), "int", relation_val.Text, "");
            }
            if (lustAddr.ContainsKey(currentPerson))
            {
                memLib.writeMemory(baseAddress + lustAddr[currentPerson].ToString(), "int", lust_val.Text, "");
            }
            if (lustOtherAddr.ContainsKey(currentPerson))
            {
                memLib.writeMemory(baseAddress + lustOtherAddr[currentPerson].ToString(), "int", lust_to_val.Text, "");
            }
            label_status.ResetText();
            label_status.Text = "Status: Saved!";
        }
    }
}
