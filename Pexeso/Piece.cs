using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pexeso
{
    internal class Piece
    {
        private static int globalId = 0;
        private PictureBox picBox;
        private string imageUrl;
        private int id;
        private Point loc;
        public Piece(string imageUrl, Point point)
        {
            this.picBox = new PictureBox();
            this.picBox.Size = new Size(100, 100);
            this.picBox.SizeMode = PictureBoxSizeMode.StretchImage;
            this.picBox.Click += Panel_Click;
            this.picBox.BackColor = Color.Black;
            this.imageUrl = imageUrl;
            this.id = globalId;
            this.loc = point;

        }

        public int Id { get => id; }
        public Point Loc { get => loc; set => loc = value; }

        private void Panel_Click(object? sender, EventArgs e)
        {
            if (GameManager.Instance.SelectedPieces.Count == 2)
            {
                return;
            }
            this.picBox.Load(imageUrl);
            GameManager.Instance.AddToSelected(this);
        }

        public void AddPiece()
        {
            this.picBox.Location = loc;
            GameForm.Instance.Controls.Add(this.picBox);
            
            Console.WriteLine(this.id);
        }
        public static void IncreaseID()
        {
            globalId++;
        }
        public void RemovePiece()
        {
            GameForm.Instance.Controls.Remove(this.picBox);
        }

        public void hide()
        {
            this.picBox.Image = null;
        }      

    }
}
