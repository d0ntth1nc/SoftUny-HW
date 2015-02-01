
namespace MineSweeper
{
    public class Rating
    {
        public Rating() { }

        public Rating(string playerName, int score)
        {
            this.PlayerName = playerName;
            this.Score = score;
        }

        public string PlayerName { get; set; }
        public int Score { get; set; }
    }
}
