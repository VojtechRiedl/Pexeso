namespace Pexeso
{
    public partial class Form1 : Form
    {
        private static Form1 _instance;
        public Form1()
        {
            InitializeComponent();
            _instance = this;
        }

        public static Form1 Instance { get => _instance; }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            SettingsForm.Instance.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (GameManager.Instance.Settings.Players.Count < 2)
            {
                MessageBox.Show("Musíš pøidat alespoò dva hráèe!");
                return;
            }

            this.Hide();
            new GameForm().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ovládání je øešeno klikáním myší. Pokud hráè zvolí nesprávnou dvojici, hraje další hráè. Pokud zvolí správnou dvojici, pokraèuje stejný hráè.");
        }
    }
}