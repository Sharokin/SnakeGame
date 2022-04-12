using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class Snake_ : Form
    {
        private Food ValuableFood = new ValuableFood();
        private Food NormalFood = new NormalFood();
        private Food DietFood = new DietFood();
        private Food RandomIntervalsFood = new IntervalFood();

        private Snake Snake1 = new Snake("up");
        private Snake Snake2 = new Snake("up");
        private Snake Snake3 = new Snake("down"); // EXTENSION

        private int maxWidth;
        private int maxHeight;

        private int AmountOfPlayers;

        private bool RedrawIntervalFood = false;  // EXTENSION

        Random rand = new Random();
        public Snake_()
        {
            new Settings();
            InitializeComponent();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.A && Snake1.Direction != "right")
            {
                Snake1.ChangeDirection("left", true);
            }
            if (e.KeyCode == Keys.D && Snake1.Direction != "left")
            {
                Snake1.ChangeDirection("right", true);
            }
            if (e.KeyCode == Keys.W && Snake1.Direction != "down")
            {
                Snake1.ChangeDirection("up", true);
            }
            if (e.KeyCode == Keys.S && Snake1.Direction != "up")
            {
                Snake1.ChangeDirection("down", true);
            }
            
            if (e.KeyCode == Keys.J && Snake2.Direction != "right")
            {
                Snake2.ChangeDirection("left", true);
            }
            if (e.KeyCode == Keys.L && Snake2.Direction != "left")
            {
                Snake2.ChangeDirection("right", true);
            }
            if (e.KeyCode == Keys.I && Snake2.Direction != "down")
            {
                Snake2.ChangeDirection("up", true);
            }
            if (e.KeyCode == Keys.K && Snake2.Direction != "up")
            {
                Snake2.ChangeDirection("down", true);
            }

            if (e.KeyCode == Keys.F && Snake3.Direction != "right") // EXTENSION
            {
                Snake3.ChangeDirection("left", true);
            }
            if (e.KeyCode == Keys.H && Snake3.Direction != "left")
            {
                Snake3.ChangeDirection("right", true);
            }
            if (e.KeyCode == Keys.T && Snake3.Direction != "down")
            {
                Snake3.ChangeDirection("up", true);
            }
            if (e.KeyCode == Keys.G && Snake3.Direction != "up")
            {
                Snake3.ChangeDirection("down", true);
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                Snake1.ChangeDirection("left", false);
            }
            if (e.KeyCode == Keys.D)
            {
                Snake1.ChangeDirection("right", false);
            }
            if (e.KeyCode == Keys.W)
            {
                Snake1.ChangeDirection("up", false);
            }
            if (e.KeyCode == Keys.S)
            {
                Snake1.ChangeDirection("down", false);
            }

            if (e.KeyCode == Keys.J)
            {
                Snake2.ChangeDirection("left", false);
            }
            if (e.KeyCode == Keys.L)
            {
                Snake2.ChangeDirection("right", false);
            }
            if (e.KeyCode == Keys.I)
            {
                Snake2.ChangeDirection("up", false);
            }
            if (e.KeyCode == Keys.K)
            {
                Snake2.ChangeDirection("down", false);
            }

            if (e.KeyCode == Keys.F) // EXTENSION
            {
                Snake3.ChangeDirection("left", false);
            }
            if (e.KeyCode == Keys.H)
            {
                Snake3.ChangeDirection("right", false);
            }
            if (e.KeyCode == Keys.T)
            {
                Snake3.ChangeDirection("up", false);
            }
            if (e.KeyCode == Keys.G)
            {
                Snake3.ChangeDirection("down", false);
            }
        }
        private void OnePlayer(object sender, EventArgs e)
        {
            button1player.Enabled = false;
            button2player.Enabled = false;
            button3player.Enabled = false;
            PrepareGame(1);
        }
        private void TwoPlayers(object sender, EventArgs e)
        {
            button1player.Enabled = false;
            button2player.Enabled = false;
            button3player.Enabled = false;
            PrepareGame(2);
        }
        private void ThreePlayers(object sender, EventArgs e) // EXTENSION
        {
            button1player.Enabled = false;
            button2player.Enabled = false;
            button3player.Enabled = false;
            PrepareGame(3);
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            Snake1.SnakeDirection();
            Snake2.SnakeDirection();
            Snake3.SnakeDirection(); // EXTENSION

            for (int i = Snake1.SnakeBody.Count - 1; i >= 0; i--) //Snake1
            {
                if (i == 0) // Snakes Head
                {                   
                    Snake1.MoveHead();

                    Snake1.ThroughWalls(maxWidth, maxHeight);

                    if (ValuableFood.Eaten(Snake1)) // Eats ValuableFood
                        ValuableFood = new ValuableFood { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };

                    if (NormalFood.Eaten(Snake1)) // Eats NormalFood
                        NormalFood = new NormalFood { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };                 

                    if (RandomIntervalsFood.Eaten(Snake1)) // Eats IntervalFood EXTENSION
                    {
                        RandomIntervalsFood.X = -1;
                        RandomIntervalsFood.Y = -1;
                    }

                    if (DietFood.Eaten(Snake1)) // Eats DietFood
                        DietFood = new DietFood { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };

                    if (AmountOfPlayers == 3)
                    {
                        Snake1.Collision(Snake2);
                        Snake1.Collision(Snake3);
                    }
                    
                    if (AmountOfPlayers == 2)
                        Snake1.Collision(Snake2);
                    
                    Snake1.Collision();

                    if (Snake1.IntervalActive) // EXTENSION
                    {
                        RedrawIntervalFood = Snake1.RandomMoves(rand.Next(1, 30));

                        if (RedrawIntervalFood)
                        {
                            RandomIntervalsFood = new IntervalFood { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };
                            RedrawIntervalFood = false;
                        }
                    }
                }
                else 
                {
                    Snake1.MoveAlong(i);
                }
            }

            for (int i = Snake2.SnakeBody.Count - 1; i >= 0; i--) //Snake2 -||-  
            {
                if (i == 0) 
                {              
                    Snake2.MoveHead();

                    Snake2.ThroughWalls(maxWidth, maxHeight);

                    if (ValuableFood.Eaten(Snake2))
                        ValuableFood = new ValuableFood { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };

                    if (NormalFood.Eaten(Snake2)) 
                        NormalFood = new NormalFood { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };

                    if (RandomIntervalsFood.Eaten(Snake2))  // EXTENSION
                    {
                        RandomIntervalsFood.X = -1;
                        RandomIntervalsFood.Y = -1;
                    }

                    if (DietFood.Eaten(Snake2)) 
                        DietFood = new DietFood { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };

                    if (AmountOfPlayers == 3)
                    {
                        Snake2.Collision(Snake1);
                        Snake2.Collision(Snake3);
                    }

                    if (AmountOfPlayers == 2)
                        Snake2.Collision(Snake1);

                    Snake2.Collision();
                    
                    if (Snake2.IntervalActive) // EXTENSION
                    {
                        RedrawIntervalFood = Snake2.RandomMoves(rand.Next(1, 30));

                        if (RedrawIntervalFood)
                        {
                            RandomIntervalsFood = new IntervalFood { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };
                            RedrawIntervalFood = false;
                        }
                    }
                }
                else 
                {
                    Snake2.MoveAlong(i);
                }
            }

            for (int i = Snake3.SnakeBody.Count - 1; i >= 0; i--) //Snake3 -||-  EXTENSION
            {
                if (i == 0)
                {  
                    Snake3.MoveHead();

                    Snake3.ThroughWalls(maxWidth, maxHeight);

                    if (ValuableFood.Eaten(Snake3))
                        ValuableFood = new ValuableFood { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };

                    if (NormalFood.Eaten(Snake3))
                        NormalFood = new NormalFood { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };

                    if (RandomIntervalsFood.Eaten(Snake3)) // EXTENSION
                    {
                        RandomIntervalsFood.X = -1;
                        RandomIntervalsFood.Y = -1;
                    }

                    if (DietFood.Eaten(Snake3))
                        DietFood = new DietFood { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };               

                    Snake3.Collision(Snake1);
                    Snake3.Collision(Snake2);
                    Snake3.Collision();

                    if (Snake3.IntervalActive) // EXTENSION
                    {
                        RedrawIntervalFood = Snake3.RandomMoves(rand.Next(1, 30));

                        if (RedrawIntervalFood)
                        {
                            RandomIntervalsFood = new IntervalFood { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };
                            RedrawIntervalFood = false;
                        }
                    }
                }
                else
                {
                    Snake3.MoveAlong(i);
                }
            }

            if (Snake1.SnakeBody.Count == 0 && Snake2.SnakeBody.Count == 0 && Snake3.SnakeBody.Count == 0) //EXTENSION
                GameOver();

            PicCanvas.Invalidate();
        }

        private void UpdateGrapichs(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            Brush Snake1Color = Brushes.Green;
            Brush Snake2Color = Brushes.Yellow;
            Brush Snake3Color = Brushes.DarkOrange; // EXTENSON

            for (int i = 0; i < Snake1.SnakeBody.Count; i++)
                Snake1.Draw(canvas, i, Snake1Color);
           
            for (int i = 0; i < Snake2.SnakeBody.Count; i++)
                Snake2.Draw(canvas, i, Snake2Color);
            
            for (int i = 0; i < Snake3.SnakeBody.Count; i++) // EXTENSION
                Snake3.Draw(canvas, i, Snake3Color);

            NormalFood.Draw(e.Graphics); 
            ValuableFood.Draw(e.Graphics);
            DietFood.Draw(e.Graphics);
            RandomIntervalsFood.Draw(e.Graphics); // EXTENSION

            S1Score.Text = "Score: " + Snake1.SnakeScore;
            if(AmountOfPlayers >= 2)
                S2Score.Text = "Score: " + Snake2.SnakeScore;
            if (AmountOfPlayers == 3) // EXTENSION
                S3Score.Text = "Score: " + Snake3.SnakeScore;
            
            if (Snake1.IntervalActive)
                S1Score.Text = $"{S1Score.Text} {Snake1.ThirtySeconds.ToString("n2")}"; // EXTENSION
            if (Snake2.IntervalActive)
                S2Score.Text = $"{S2Score.Text} {Snake2.ThirtySeconds.ToString("n2")}"; // EXTENSION
            if (Snake3.IntervalActive)
                S3Score.Text = $"{S3Score.Text} {Snake3.ThirtySeconds.ToString("n2")}"; // EXTENSION
        }

        private void PrepareGame(int amountOfPlayers)
        {
            AmountOfPlayers = amountOfPlayers;
            maxWidth = PicCanvas.Width / Settings.Width - 1;
            maxHeight = PicCanvas.Height / Settings.Height - 1;

            Snake1.SnakeBody.Clear();
            Snake2.SnakeBody.Clear();
            Snake3.SnakeBody.Clear();  // EXTENSION

            Snake1.SnakeScore = 0;
            Snake2.SnakeScore = 0;
            Snake3.SnakeScore = 0;  // EXTENSION

            Snake1.Direction = "up";
            Snake2.Direction = "up";
            Snake3.Direction = "down";  // EXTENSION

            Snake1.ThirtySeconds = 0; // EXTENSION
            Snake2.ThirtySeconds = 0; // EXTENSION
            Snake3.ThirtySeconds = 0; // EXTENSION

            Snake1.IntervalActive = false; // EXTENSION 
            Snake2.IntervalActive = false; // EXTENSION
            Snake3.IntervalActive = false; // EXTENSION

            if (amountOfPlayers == 1)
            {
                S1Score.Text = "Score: " + Snake1.SnakeScore;
                S2Score.Text = "";
                S3Score.Text = "";
            }
            if (amountOfPlayers == 2)
            {
                S1Score.Text = "Score: " + Snake1.SnakeScore;
                S2Score.Text = "Score:" + Snake2.SnakeScore;
                S3Score.Text = "";
            }
            if (amountOfPlayers == 3) // EXTENSION
            {
                S1Score.Text = "Score: " + Snake1.SnakeScore;
                S2Score.Text = "Score: " + Snake2.SnakeScore;
                S3Score.Text = "Score: " + Snake3.SnakeScore;
            }

            Circle head1 = new Circle { X = 5, Y = 20 };
            Circle head2 = new Circle { X = 30, Y = 20 };
            Circle head3 = new Circle { X = 15, Y = 20 };  // EXTENSION

            Snake1.SnakeBody.Add(head1);
            if(amountOfPlayers > 1)
                Snake2.SnakeBody.Add(head2);
            if (amountOfPlayers > 2)  // EXTENSION
                Snake3.SnakeBody.Add(head3);

            for (int i = 0; i < 9; i++)
            {
                Circle body1 = new Circle();
                Circle body2 = new Circle();
                Circle body3 = new Circle();  // EXTENSION

                Snake1.SnakeBody.Add(body1);
                if(amountOfPlayers > 1)
                    Snake2.SnakeBody.Add(body2);
                if (amountOfPlayers > 2)  // EXTENSION
                    Snake3.SnakeBody.Add(body3);
            }

            NormalFood = new NormalFood() { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };
            ValuableFood = new ValuableFood() { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };
            DietFood = new DietFood() { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };
            RandomIntervalsFood = new IntervalFood { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) }; // EXTENSION

            GameTimer.Start();
        }
        private void GameOver()
        {
            GameTimer.Stop();
            button1player.Enabled = true;
            button2player.Enabled = true;
            button3player.Enabled = true; // EXTENSION
        }
    }
}
