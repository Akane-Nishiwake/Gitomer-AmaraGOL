﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gitomer_AmaraGOL
{
    public partial class Form1 : Form
    {
        int SeedofUniverse;//the current Seed of random
        public static int X = Properties.Settings.Default.WidthX;//X axis initialization
        public static int Y = Properties.Settings.Default.HeightY;//Yaxis initialization
        bool[,] universe = new bool[X, Y];//initialization of changeable universe
        // Drawing colors - storing colors
        Color gridColor = Color.DarkGray;//default grid color
        Color cellColor = Color.MediumSeaGreen;//default cell color
        // The Timer class
        Timer timer = new Timer();
        // Generation count
        int generations = 0;
        public Form1()
        {
            InitializeComponent();
            // Setup the timer
            timer.Interval = 100; // milliseconds
            timer.Tick += Timer_Tick;
            timer.Enabled = false; // start timer running having it false makes it not run when program is opened
        }
        private void NextGeneration()//this is out way that next generatio works
        {
            //https://natureofcode.com/book/chapter-7-cellular-automata/
            // Increment generation count
            generations++;
            RulesofGOL();//goes through the rules
            // Update status strip generations
            toolStripStatusLabelGenerations.Text = "Generations = " + generations.ToString();

        }
        // The event called by the timer every Interval milliseconds.
        private void Timer_Tick(object sender, EventArgs e)//the method that notifies next generation to go
        {
            NextGeneration();
        }
        private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Calculate the width and height of each cell in pixels
            // CELL WIDTH = WINDOW WIDTH / NUMBER OF CELLS IN X
            float cellWidth = (float)graphicsPanel1.ClientSize.Width / (float)universe.GetLength(0);
            // CELL HEIGHT = WINDOW HEIGHT / NUMBER OF CELLS IN Y
            float cellHeight = (float)graphicsPanel1.ClientSize.Height / (float)universe.GetLength(1);

            int _count = Cellcount();
            LivingGenerations.Text = "Living Generations = " + _count.ToString();//prints living generations on status strip

            currentTimer.Text = "Current Timer = " + timer.Interval.ToString() + " milliseconds";//prints current timer interval to status strip
            // A Pen for drawing the grid lines (color, width)
            Pen gridPen = new Pen(gridColor, 1);

            // A Brush for filling living cells interiors (color)
            Brush cellBrush = new SolidBrush(cellColor);

            //This prints the generations
            for (int y = 0; y < universe.GetLength(1); y++)// Iterate through the universe in the y, top to bottom
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    // A rectangle to represent each cell in pixels
                    RectangleF cellRect = Rectangle.Empty;
                    cellRect.X = x * cellWidth;
                    cellRect.Y = y * cellHeight;
                    cellRect.Width = cellWidth;
                    cellRect.Height = cellHeight;
                    Font font = new Font("ComicSans", 12f);
                    // Fill the cell with a brush if alive 
                    int bob = CountNeighbor(x, y);
                    if (universe[x, y] == true)//prints the generations on the cell
                    {
                        StringFormat stringFormat = new StringFormat();
                        stringFormat.Alignment = StringAlignment.Center;
                        stringFormat.LineAlignment = StringAlignment.Center;
                        e.Graphics.FillRectangle(cellBrush, cellRect);
                        e.Graphics.DrawString(bob.ToString(), font, Brushes.Black, cellRect, stringFormat);

                    }
                    else if (CountNeighbor(x, y) != 0 && !universe[x, y])//print generations outside the cell
                    {
                        StringFormat stringFormat = new StringFormat();
                        stringFormat.Alignment = StringAlignment.Center;
                        stringFormat.LineAlignment = StringAlignment.Center;
                        e.Graphics.DrawString(bob.ToString(), font, Brushes.IndianRed, cellRect, stringFormat);
                    }
                    // Outline the cell with a pen
                    e.Graphics.DrawRectangle(gridPen, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);
                }
            }

            // Cleaning up pens and brushes- helps the garbage collector
            gridPen.Dispose();
            cellBrush.Dispose();
        }
        private void graphicsPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            // If the left mouse button was clicked
            if (e.Button == MouseButtons.Left)
            {
                // Calculate the width and height of each cell in pixels
                int cellWidth = graphicsPanel1.ClientSize.Width / universe.GetLength(0);
                int cellHeight = graphicsPanel1.ClientSize.Height / universe.GetLength(1);

                // Calculate the cell that was clicked in
                // CELL X = MOUSE X / CELL WIDTH
                int x = e.X / cellWidth;
                // CELL Y = MOUSE Y / CELL HEIGHT
                int y = e.Y / cellHeight;

                // Toggle the cell's state
                universe[x, y] = !universe[x, y];

                // Tell Windows you need to repaint
                graphicsPanel1.Invalidate(); // use this when anything changes in the window - DO NOT PLACE INSIDE PAINT
            }
        }
        
        //This section is for Methods involved in Rules and Counting
        private void RulesofGOL()//rules of Game of Life that say if a cell is dead or alive
        {
            int i = universe.GetLength(0);//makes these objects
            int j = universe.GetLength(1);
            bool[,] scratchPad = new bool[i, j];
            for (int y = 0; y < j; y++)
            {
                for (int x = 0; x < i; x++)//runs through the neighbors
                {
                    if (universe[x, y])
                    {
                        if (CountNeighbor(x, y) < 2 || CountNeighbor(x, y) > 3)//rules (sees if cell dead or alive then decides if the cell should die or not)
                        {
                            scratchPad[x, y] = false;
                        }
                        else
                        {
                            scratchPad[x, y] = true;
                        }
                    }
                    else
                    {
                        if (CountNeighbor(x, y) == 3)
                        {
                            scratchPad[x, y] = true;
                        }
                    }
                }
            }
            bool[,] temp = universe;//swap
            universe = scratchPad;
            scratchPad = temp;
            graphicsPanel1.Invalidate();
        }
        private int FiniteCountNeighbor(int x, int y)//this is a finite boundry
        {
            int neighbor = 0;
            int suzy = universe.GetLength(0);//makes these objects
            int Ricky = universe.GetLength(1);
            //check x+1,y(middle right)
            if (x + 1 < suzy && universe[x + 1, y])
            {
                neighbor++;
            }
            //check rightx,y+1 (bottom right)
            if (x + 1 < suzy && y + 1 < Ricky && universe[x + 1, y + 1])
            {
                neighbor++;
            }
            //check x,y+1 (bottom middle)
            if (y + 1 < Ricky && universe[x, y + 1])
            {
                neighbor++;
            }
            //check leftx,y (middle left)
            if (x - 1 >= 0 && universe[x - 1, y])
            {
                neighbor++;
            }
            //check leftx,y-1 (top left)
            if (x - 1 >= 0 && y - 1 >= 0 && universe[x - 1, y - 1])
            {
                neighbor++;
            }
            //check x, y-1 (top middle)
            if (y - 1 >= 0 && universe[x, y - 1])
            {
                neighbor++;
            }
            //check leftx, y+1 (bottom left)
            if (x - 1 >= 0 && y + 1 < Ricky && universe[x - 1, y + 1])
            {
                neighbor++;
            }
            //check rightx, y-1 (top right)
            if (x + 1 < suzy && y - 1 >= 0 && universe[x + 1, y - 1])
            {
                neighbor++;
            }

            return neighbor;
        }
        private int CountNeighbor(int x, int y)//this is toroidal boundry
        {
            //return FiniteCountNeighbor(x, y);
            int suzy = universe.GetLength(0);//x value
            int Ricky = universe.GetLength(1);//y value
            int neighbor = 0;
            int leftx = ((x - 1) < 0) ? suzy - 1 : (x - 1); //if the fist statement is true (? = conditional) then use szy-1 (:=else) use like normal
            int rightx = ((x + 1) >= suzy) ? 0 : (x + 1);
            int topy = ((y - 1) < 0) ? Ricky - 1 : (y - 1);
            int bottomy = ((y + 1) >= Ricky) ? 0 : (y + 1);
            //check x+1,y (middle right)
            if (rightx < suzy && universe[rightx, y])
            {
                neighbor++;
            }
            //check rightx,y+1 (bottom right)
            if (rightx < suzy && bottomy < Ricky && universe[rightx, bottomy])
            {
                neighbor++;
            }
            //check x,y+1 (bottom middle)
            if (bottomy < Ricky && universe[x, bottomy])
            {
                neighbor++;
            }
            //check leftx,y (middle left)
            if (leftx >= 0 && universe[leftx, y])
            {
                neighbor++;
            }
            //check leftx,y-1 (top left)
            if (leftx >= 0 && topy >= 0 && universe[leftx, topy])
            {
                neighbor++;
            }
            //check x, y-1 (top middle)
            if (topy >= 0 && universe[x, topy])
            {
                neighbor++;
            }
            //check leftx, y+1 (bottom left)
            if (leftx >= 0 && bottomy < Ricky && universe[leftx, bottomy])
            {
                neighbor++;
            }
            //check rightx, y-1 (top right)
            if (rightx < suzy && topy >= 0 && universe[rightx, topy])
            {
                neighbor++;
            }
            return neighbor;
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)//this exits from the program
        {
            this.Close();
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)//this makes the program start anew with a new generation count
        {
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    universe[x, y] = false;
                }
            }
            generations = -1;
            NextGeneration();//resets generations
            timer.Stop();//makes sure it doesnt run
            graphicsPanel1.Invalidate();
        }
        private int Cellcount()//counts living generations
        {
            int number=0;
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    if(universe[x,y] )
                    {
                        number++;
                    }
                }
            }
            return number;
        }
       
        //This section is for menu items and tool strip items that are not inheirently customization
        private void newToolStripButton_Click(object sender, EventArgs e)//this does the same as the new too strip button
        {
            newToolStripMenuItem_Click(sender, e);
        }
        private void saveToolStripButton_Click(object sender, EventArgs e)//this saves current univerese
        {	
            //Saving the current universe to a text file. 
            //The current state and size of the universe should be able to be saved in PlainText file format. 
            //The file name should be chosen by the user with a save file dialog box.
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)//this opens a previously saved univerese
        {
            //Opening a previously saved universe. 
            //A previously saved PlainText file should be able to be read in and assigned to the current universe. 
            //Opening should also resize the current universe to match the size of the file being read.
        }
        private void openToolStripButton_Click(object sender, EventArgs e)//does the same as opening but from the tool strip button
        {
            openToolStripMenuItem_Click(sender, e);
        }
        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Reload will revert back to the last saved settings
        }
        private void resetToolStripMenuItem_Click(object sender, EventArgs e)//This resets to the previous universe/colors
        {
            //Reset will return the applications default settings for these values.
        }
        private void toolStripButton1_Click(object sender, EventArgs e)//this is the play button
        {
            timer.Start();
        }
        private void playToolStripMenuItem_Click(object sender, EventArgs e)//play menu item
        {
            toolStripButton1_Click(sender, e);
        }
        private void toolStripButton2_Click(object sender, EventArgs e)//this is the pause button
        {
            timer.Stop();
        }
        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)//pause menu item
        {
            toolStripButton2_Click(sender, e);
        }
        private void toolStripButton3_Click(object sender, EventArgs e)//this is the next button
        {
            NextGeneration();
        }
        private void nextToolStripMenuItem_Click(object sender, EventArgs e)//next menu item
        {
            toolStripButton3_Click(sender, e);
        }
       
        //This section is for Randomize
        private void Population(Random num)//method to populate universe with random
        {
            generations = 0;//set generations to zero
            for (int i = 0; i < universe.GetLength(1); i++)//y axis
            {
                for (int j = 0; j < universe.GetLength(0); j++)//x axis
                {
                    if (num.Next() % 3 == 0)//divisible by 3 live
                    {
                        universe[j, i] = true;
                    }
                    else//not dead
                    {
                        universe[j, i] = false;
                    }

                    CountNeighbor(j, i);//make the universe
                }
            }
        }
        private void bySeedToolStripMenuItem_Click(object sender, EventArgs e) //seed user can input
        {
            //uses modal dialogue box
            UserSeedBox UserBox = new UserSeedBox();
            UserBox.UserSeedInput = SeedofUniverse;
            if (DialogResult.OK == UserBox.ShowDialog())
            {
                Random userInput = new Random(SeedofUniverse);
                Population(userInput);
                graphicsPanel1.Invalidate();
            }
        }
        private void fromCurrentSeedToolStripMenuItem_Click(object sender, EventArgs e) //seed that already exist
        {
            Random rand = new Random(SeedofUniverse);//initialize random
            Population(rand);//populate
            graphicsPanel1.Invalidate();
        }
        private void byTimeToolStripMenuItem_Click(object sender, EventArgs e)//seed by current time
        {
            SeedofUniverse = (int)DateTime.Now.Ticks;//initialize to current time
            Random rand = new Random(SeedofUniverse);//makes random seed
            Population(rand);//random population
            graphicsPanel1.Invalidate();
        }
       
        //This section is for customizing
        private void moduleToolStripMenuItem_Click(object sender, EventArgs e)//this is the dialogue box for right clicking 
        {
            DialogueBoxStuff stuff = new DialogueBoxStuff();//this calls upon dialogue box
            stuff.Time = timer.Interval;//makes dialogue box time current time
            if (DialogResult.OK == stuff.ShowDialog())//initializes if they press ok
            {
                timer.Interval = stuff.Time;//makes new time current time
                universe = new bool[X, Y];//changes size
            }
            graphicsPanel1.Invalidate();//does the thing to make it work
        }
        private void colorToolStripMenuItem_Click(object sender, EventArgs e)//modal color cell change
        {
            ColorDialog color = new ColorDialog();
            color.Color = cellColor;
            if (DialogResult.OK == color.ShowDialog())
            {
                cellColor = color.Color;
                graphicsPanel1.Invalidate();
            }
        }
        private void cellColorToolStripMenuItem_Click(object sender, EventArgs e)//changes cell color
        {
            ColorDialog color = new ColorDialog();
            color.Color = cellColor;
            if (DialogResult.OK == color.ShowDialog())
            {
                cellColor = color.Color;
                graphicsPanel1.Invalidate();
            }
        }
        private void gridColorToolStripMenuItem_Click(object sender, EventArgs e)//changes grid color
        {
            ColorDialog gcolor = new ColorDialog();
            gcolor.Color = gridColor;
            if (DialogResult.OK == gcolor.ShowDialog())
            {
                gridColor = gcolor.Color;
                graphicsPanel1.Invalidate();
            }
        }
        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e) //changes background color
        {
            ColorDialog bcolor = new ColorDialog();
            bcolor.Color = graphicsPanel1.BackColor;
            if (DialogResult.OK == bcolor.ShowDialog())
            {
                graphicsPanel1.BackColor = bcolor.Color;
                graphicsPanel1.Invalidate();
            }
        }

    }
}
