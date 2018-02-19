using Android.App;
using Android.Widget;
using Android.OS;

namespace LittlePig
{
    [Activity(Label = "LittlePig", MainLauncher = true, Icon = "@mipmap/icon", Theme = "@android:style/Theme.NoTitleBar")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var game = new LittlePigLogic();
            var roll = 0;

            var dieImageView = FindViewById<ImageView>(Resource.Id.dieImageView);

            var p1NameEditText = FindViewById<EditText>(Resource.Id.p1NameEditText);
            var p2NameEditText = FindViewById<EditText>(Resource.Id.p2NameEditText);

            var p1ScoreTextView = FindViewById<TextView>(Resource.Id.p1ScoreTextView);
            var p2ScoreTextView = FindViewById<TextView>(Resource.Id.p2ScoreTextView);
            var turnTextView = FindViewById<TextView>(Resource.Id.turnTextView);
            var pointsTextView = FindViewById<TextView>(Resource.Id.pointsTextView);
            var winnerTextView = FindViewById<TextView>(Resource.Id.winnerTextView);

            var rollButton = FindViewById<Button>(Resource.Id.rollButton);
            var endTurnButton = FindViewById<Button>(Resource.Id.endTurnButton);
            var newGameButton = FindViewById<Button>(Resource.Id.newGameButton);

            rollButton.Click += delegate
            {
                
                displayDie(dieImageView);
                game.Player2Name = p2NameEditText.Text;
                game.Player1Name = p1NameEditText.Text;
                turnTextView.Text = game.GetCurrentPlayer() + " 's turn";
                displayTurnPoints(pointsTextView);
                if (roll == LittlePigLogic.BAD_NUMBER)
                {
                    //game.ChangeTurn();
                    rollButton.Enabled = false;
                }
            };

            endTurnButton.Click += delegate
            {
                if (rollButton.Enabled == false)
                {
                    rollButton.Enabled = true;
                    game.ChangeTurn();
                    turnTextView.Text = game.GetCurrentPlayer() + " 's turn";
                    displayScores(p1ScoreTextView, p2ScoreTextView);
                    winnerTextView.Text = game.CheckForWinner();
                }
                else
                {
                    game.ChangeTurn();
                    turnTextView.Text = game.GetCurrentPlayer() + " 's turn";
                    displayScores(p1ScoreTextView, p2ScoreTextView);
                    winnerTextView.Text = game.CheckForWinner();
                }
            };

            newGameButton.Click += delegate
            {
                game.ResetGame();
                p1NameEditText.Text = "";
                p2NameEditText.Text = "";
                turnTextView.Text = "";
                pointsTextView.Text = "";
                winnerTextView.Text = "";
                p1ScoreTextView.Text = "0";
                p2ScoreTextView.Text = "0";
            };

            void displayTurnPoints(TextView points)
            {
                pointsTextView.Text = string.Format("{0}", game.TurnPoints);
            }

            void displayScores(TextView p1Score, TextView p2Score)
            {
                p1ScoreTextView.Text = string.Format("{0}", game.Player1Score);
                p2ScoreTextView.Text = string.Format("{0}", game.Player2Score);
            }

            void displayDie(ImageView die)
            {
                roll = game.RollDie();
                switch (roll)
                {
                    case 1:
                        dieImageView.SetImageResource(Resource.Drawable.Die1);
                        break;
                    case 2:
                        dieImageView.SetImageResource(Resource.Drawable.Die2);
                        break;
                    case 3:
                        dieImageView.SetImageResource(Resource.Drawable.Die3);
                        break;
                    case 4:
                        dieImageView.SetImageResource(Resource.Drawable.Die4);
                        break;
                    case 5:
                        dieImageView.SetImageResource(Resource.Drawable.Die5);
                        break;
                    case 6:
                        dieImageView.SetImageResource(Resource.Drawable.Die6);
                        break;
                    
                }
            }
        }
    }
}



