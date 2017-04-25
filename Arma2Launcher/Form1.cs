using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arma2Launcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string param = "";

            if(comboBox1.Text != "")
            {
                param += " -cpuCount="+comboBox1.Text;
            }
            if(comboBox2.Text != "")
            {
                param += " -maxMem="+comboBox2.Text;
            }
            if(comboBox3.Text != "")
            {
                param += " -ExThreads="+comboBox3.Text;
            }
            if (nopause.Checked == true)
            {
                param += " -noPause";
            }
            if (winxp.Checked == true)
            {
                param += " -winxp";
            }
            if (vsync.Checked == true)
            {
                param += " -Vsync";
            }
            if (nocb.Checked == true)
            {
                param += " -noCB";
            }
            if (nosplash.Checked == true)
            {
                param += " -nosplash";
            }
            if (world.Checked == true)
            {
                param += " -world=empty";
            }
            if (textBox1.Text != "")
            {
                param += " -connect=" + textBox1.Text;
            }
            if (textBox3.Text != "")
            {
                param += " -port=" + textBox3.Text;
            }
            if (textBox4.Text != "")
            {
                param += " -password=" + textBox4.Text;
            }
            if (checkedListBox1.CheckedItems.Count > 0) {
                param += " -mod=";
                for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                {
                        param+=checkedListBox1.CheckedItems[i].ToString()+";";
                }
            }
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            ProcessStartInfo mcStartInfo = new ProcessStartInfo(textBox2.Text + "\\ArmA2OA", param);
            Process.Start(mcStartInfo);
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            using (StreamReader reader = File.OpenText("config.txt"))
            {
                int cou = 0;
                string line = null;
                do
                {
                    cou++;
                    line = reader.ReadLine();
                    switch (cou) { 
                        case 1:
                            textBox2.Text = line; break;
                        case 2:
                            if(line == "True"){nopause.Checked = true;}else{nopause.Checked = false;}break;
                        case 3:
                            if(line == "True"){winxp.Checked = true;}else{winxp.Checked = false;}break;
                        case 4:
                            if(line == "True"){vsync.Checked = true;}else{vsync.Checked = false;}break;
                        case 5:
                            if(line == "True"){nocb.Checked = true;}else{nocb.Checked = false;}break;
                        case 6:
                            if(line == "True"){nosplash.Checked = true;}else{nosplash.Checked = false;}break;
                        case 7:
                            if(line == "True"){world.Checked = true;}else{world.Checked = false;}break;
                        case 8:
                            comboBox1.Text = line; break;
                        case 9:
                            comboBox2.Text = line; break;
                        case 10:
                            comboBox3.Text = line; break;
                        case 11:
                            textBox1.Text = line; break;
                        case 12:
                            textBox3.Text = line; break;
                        case 13:
                            textBox4.Text = line; break;
                    }
                    

                } while (line != null);
            }

            using (StreamReader reader = File.OpenText("config.txt"))
            {
                string line = null;
                line = reader.ReadLine();
            }
            try
            {
                DirectoryInfo dir = new DirectoryInfo(textBox2.Text);
                foreach (var item in dir.GetDirectories())
                {
                    string s = Convert.ToString(item);
                    if (s[0] == '@')
                    {
                        checkedListBox1.Items.Add(item);
                    }
                }
            }
            catch{
                try
                {
                    textBox2.Text = @"C:\Program Files (x86)\Steam\steamapps\common\Arma 2 Operation Arrowhead";
                    DirectoryInfo dir = new DirectoryInfo(textBox2.Text);
                    foreach (var item in dir.GetDirectories())
                    {
                        string s = Convert.ToString(item);
                        if (s[0] == '@')
                        {
                            checkedListBox1.Items.Add(item);
                        }
                    }
                }
                catch 
                {
                    MessageBox.Show("Не удалось определить папку с ArmA2,укажите её вручную.");
                }
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = File.CreateText("config.txt"))
            {
                writer.WriteLine(textBox2.Text);
                writer.WriteLine(nopause.Checked);
                writer.WriteLine(winxp.Checked);
                writer.WriteLine(vsync.Checked);
                writer.WriteLine(nocb.Checked);
                writer.WriteLine(nosplash.Checked);
                writer.WriteLine(world.Checked);
                writer.WriteLine(comboBox1.Text);
                writer.WriteLine(comboBox2.Text);
                writer.WriteLine(comboBox3.Text);
                writer.WriteLine(textBox1.Text);
                writer.WriteLine(textBox3.Text);
                writer.WriteLine(textBox4.Text);
            }
            MessageBox.Show("Сохраненно");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
