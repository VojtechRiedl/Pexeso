using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pexeso
{
    public partial class SettingsForm : Form
    {
        private static SettingsForm _instance = new();
        public static SettingsForm Instance { get => _instance; }
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            if (name == "")
            {
                name = GameManager.Instance.Settings.GenerateName();
            }

            listBox1.Items.Add(name);
            GameManager.Instance.Settings.AddPlayer(name);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            GameManager.Instance.Settings.Pieces = ((int)numericUpDown1.Value);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1.Instance.Show();
            this.Hide();
        }


        private void SettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
