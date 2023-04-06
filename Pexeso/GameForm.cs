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
    public partial class GameForm : Form
    {
        private static GameForm _instance;

        public static GameForm Instance { get => _instance; }
        public GameForm()
        {
            InitializeComponent();
            _instance = this;
            listBox1.Items.Clear();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            GameManager.Instance.Generate();
            GameManager.Instance.LoadPlayers();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.Instance.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            new GameForm().Show();
        }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }
    }
}
