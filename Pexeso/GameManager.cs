namespace Pexeso
{
    internal class GameManager
    {

        private static GameManager _instance = new GameManager();

        internal static GameManager Instance { get => _instance; }
        internal Settings Settings { get => settings; }
        internal List<Piece> SelectedPieces { get => selectedPieces; }

        List<Piece> pieces = new();
        List<Piece> selectedPieces = new List<Piece>();
        Random rd = new();

        private string actualCat;
        List<Cat> cats;

        List<Player> players;
        private Player actualPlayer;

        Settings settings = new();
        private GameManager()
        {
        }



        public void Generate()
        {
            players = new List<Player>();
            settings.Players.ForEach(p =>
            {
                players.Add(p.clone());
            });

            actualPlayer = players[rd.Next(players.Count)];

            cats = RequestManager.Instance.GetCats(settings.Pieces * 2);
            ChangeCat();

            int x = 0;
            for (int i = 0; i < Math.Ceiling(Math.Sqrt(settings.Pieces * 2)); i++)
            {
                for (int j = 0; j < Math.Ceiling(Math.Sqrt(settings.Pieces * 2)); j++)
                {
                    if (pieces.Count == settings.Pieces * 2)
                    {
                        break;
                    }
                    if (x % 2 == 0)
                    {
                        Piece.IncreaseID();
                        ChangeCat();
                    }
                    pieces.Add(new Piece(actualCat, new Point((j * 102) + 165, (i * 102) + 50)));
                    x++;
                }
            }
            Shuffle();
            AddPiecesToForm();
        }
        private void Shuffle()
        {
            for (int i = 0; i < pieces.Count; i++)
            {
                Swap(pieces[i], pieces[rd.Next(pieces.Count)]);
            }
        }
        private void Swap(Piece piece1, Piece piece2)
        {
            Piece temp = piece1;
            piece1 = piece2;
            piece2 = temp;

            Point locTemp = piece1.Loc;
            piece1.Loc = piece2.Loc;
            piece2.Loc = locTemp;
        }
        private void AddPiecesToForm()
        {

            foreach (var piece in pieces)
            {
                piece.AddPiece();
            }
        }

        public void AddToSelected(Piece piece)
        {
            if (!IsSelected(piece))
            {
                selectedPieces.Add(piece);
            }
            if (selectedPieces.Count == 2)
            {
                if (selectedPieces[0].Id != selectedPieces[1].Id)
                {
                    Task.Delay(new TimeSpan(0, 0, 1)).ContinueWith(o =>
                    {
                        foreach (var item in selectedPieces)
                        {
                            item.hide();
                        }
                        selectedPieces.Clear();

                    });
                    ChangeActualPlayer();
                    ReloadPlayers();
                }
                else
                {
                    foreach (var item in selectedPieces)
                    {
                        item.RemovePiece();
                        pieces.Remove(item);

                    }
                    selectedPieces.Clear();
                    GetActualPlayer().Score += 1;
                    ReloadPlayers();

                    if (pieces.Count == 0)
                    {

                        Win();
                    }

                }

            }
        }



        private void ChangeCat()
        {
            Cat cat = cats[0];
            actualCat = cat.url;
            cats.Remove(cat);
        }

        public bool IsSelected(Piece piece)
        {
            return selectedPieces.Contains(piece);
        }

        public void LoadPlayers()
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i] == actualPlayer)
                {
                    GameForm.Instance.listBox1.Items.Add("Aktuálně hraje: " + players[i].Name + " Score: " + players[i].Score);
                    continue;
                }
                GameForm.Instance.listBox1.Items.Add(players[i].Name + " Score: " + players[i].Score);
            }


        }
        public void ReloadPlayers()
        {
            GameForm.Instance.listBox1.Items.Clear();
            LoadPlayers();
        }

        private Player GetActualPlayer()
        {
            foreach (var player in players)
            {
                if (player == actualPlayer)
                {
                    return player;
                }
            }
            return actualPlayer;
        }

        private void ChangeActualPlayer()
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i] == actualPlayer)
                {
                    if (i == players.Count - 1)
                    {
                        actualPlayer = players[0];
                        return;
                    }
                    actualPlayer = players[i + 1];
                    return;
                }
            }
        }

        private void Win()
        {
            GameForm gameForm = GameForm.Instance;
            List<Player> winners = GetWinners();
            string winMessage = "Vyhrál/a ";
            for (int i = 0; i < winners.Count; i++)
            {
                winMessage += winners[i].Name + " ";
            }
            MessageBox.Show(winMessage);
            gameForm.button1.Visible = true;
            gameForm.button3.Visible = true;
        }

        private List<Player> GetWinners()
        {
            players = players.OrderBy(p => p.Score).ToList();
            List<Player> winners = new List<Player>();
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].Score == players[players.Count - 1].Score)
                {
                    winners.Add(players[i]);
                }
            }

            return winners;
        }
    }

}
