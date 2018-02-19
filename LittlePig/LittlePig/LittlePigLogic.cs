using System;

namespace LittlePig
{
    //public enum dieSide { side1, side2, side3, side4, side5, side6}

    class LittlePigLogic
    {
        //Fields
        private const int WINNING_SCORE = 100;
        public const int BAD_NUMBER = 6;

        private Random rand = new Random();
        private int player1Score;
        private int player2Score;
        private int turnPoints;
        private int turn; //1 for Player 1 and 2 for Player 2

        //Properties
        public string Player1Name { get; set; }
        public string Player2Name { get; set; }
        public int Player1Score { get { return player1Score; } }
        public int Player2Score { get { return player2Score; } }
        public int TurnPoints { get { return turnPoints; } }
        public int Turn { get { return turn; } }

        //Constructors
        public LittlePigLogic()
        {
            player1Score = 0;
            player2Score = 0;
            turnPoints = 0;
            turn = 1; //Player 1 goes first
        }

        // Use to instantiate an object with the state for a game in progress
        public LittlePigLogic(int p1Score, int p2Score, int tPoints, int t)
        {
            player1Score = p1Score;
            player2Score = p2Score;
            turnPoints = tPoints;
            turn = t;
        }

        //Methods
        // Start over without creating a new game object
        //public void ResetGame()
        //{           
        //    player1Score = 0;
        //    player2Score = 0;
        //    turnPoints = 0;
        //    turn = 1;
        //}

        // Roll die and update turn points field
        public int RollDie()
        {
            int roll = rand.Next(6) + 1;

            if (roll != BAD_NUMBER)
            {
                turnPoints += roll;
            }
            else
            {
                turnPoints = 0;
            }

            return roll;
        }

        // Get player based on the assumption that player 1 always goes first
        public string GetCurrentPlayer()
        {
            if (turn == 1)
                return Player1Name;
            else
                return Player2Name;
        }

        // toggles the turn number between 1 and 2
        public int ChangeTurn()
        {
            if (turn == 1)
                player1Score += turnPoints;
            else
                player2Score += turnPoints;

            turnPoints = 0;

            turn = turn % 2 + 1;
            return turn;
        }

        // rules for winning:
        // 1. Both players need to have had the same number of turns
        // 2. First player to reach WINNING_SCORE wins
        // 3. If both players have reached WINNING_SCORE 
        //    the one with the higher score wins
        public string CheckForWinner()
        {
            string name = "";

            if (player1Score >= WINNING_SCORE && player2Score >= WINNING_SCORE)
            {
                if (player1Score == player2Score)
                {
                    name = " It's a tie!";
                }
                else if (player1Score > player2Score)
                {
                    name = Player1Name + " wins!";
                }
                else
                {
                    name = Player2Name + " wins!";
                }
            }
            else if (player1Score >= WINNING_SCORE)
            {
                name = Player1Name + " wins!";
            }
            else if (player2Score >= WINNING_SCORE)
            {
                name = Player2Name + " wins!";
            }
            return name;
        }
    }
}