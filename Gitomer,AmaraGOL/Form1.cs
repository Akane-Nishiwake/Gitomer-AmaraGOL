using System;
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
        // The universe array - 2d array
        //Made initial array larger
        bool[,] universe = new bool[10, 10];

        // Drawing colors - storing colors
        Color gridColor = Color.Black;//Changed color from Black
        Color cellColor = Color.AliceBlue;

        // The Timer class
        Timer timer = new Timer();

        // Generation count
        int generations = 0;

        public Form1()
        {
            InitializeComponent();

            // Setup the timer
            timer.Interval = 500; // milliseconds
            timer.Tick += Timer_Tick;
            timer.Enabled = false; // start timer running having it false makes it not run when program is opened
        }

        // Calculate the next generation of cells
        private void NextGeneration()
        {
            //https://natureofcode.com/book/chapter-7-cellular-automata/

            // Increment generation count
            generations++;
            RulesofGOL();//goes through the rules
            // Update status strip generations
            toolStripStatusLabelGenerations.Text = "Generations = " + generations.ToString();
        }

        // The event called by the timer every Interval milliseconds.
        private void Timer_Tick(object sender, EventArgs e)
        {
            NextGeneration();
        }

        private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
        {
            //float change
            // Calculate the width and height of each cell in pixels
            // CELL WIDTH = WINDOW WIDTH / NUMBER OF CELLS IN X
            float cellWidth = (float)graphicsPanel1.ClientSize.Width / (float)universe.GetLength(0);
            // CELL HEIGHT = WINDOW HEIGHT / NUMBER OF CELLS IN Y
            float cellHeight = (float)graphicsPanel1.ClientSize.Height / (float)universe.GetLength(1);

            // A Pen for drawing the grid lines (color, width)
            Pen gridPen = new Pen(gridColor, 1);

            // A Brush for filling living cells interiors (color)
            Brush cellBrush = new SolidBrush(cellColor);

            // Iterate through the universe in the y, top to bottom
            for (int y = 0; y < universe.GetLength(1); y++)
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
                    Font font = new Font("Calibri", 14f);
                    // Fill the cell with a brush if alive 
                    int bob = CountNeighbor(x, y);
                    if (universe[x, y] == true)//prints the generations on the cell
                    {
                        StringFormat stringFormat = new StringFormat();
                        stringFormat.Alignment = StringAlignment.Center;
                        stringFormat.LineAlignment = StringAlignment.Center;

                        //Rectangle rect = new Rectangle(0, 0, 100, 100);
                        //int neighbors = 8;

                        e.Graphics.FillRectangle(cellBrush, cellRect);
                        e.Graphics.DrawString(bob.ToString(), font, Brushes.DarkGray, cellRect, stringFormat);

                    }
                    else if (CountNeighbor(x, y) != 0 && !universe[x, y])
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
        public void RulesofGOL()
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
        public int FiniteCountNeighbor(int x, int y)//this is a finite boundry
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
            if (x-1 >= 0 && universe[x-1, y])
            {
                neighbor++;
            }
            //check leftx,y-1 (top left)
            if (x-1 >= 0 && y-1>= 0 && universe[x-1, y-1])
            {
                neighbor++;
            }
            //check x, y-1 (top middle)
            if (y-1 >= 0 && universe[x, y-1])
            {
                neighbor++;
            }
            //check leftx, y+1 (bottom left)
            if (x-1 >= 0 && y+1 < Ricky && universe[x-1, y+1])
            {
                neighbor++;
            }
            //check rightx, y-1 (top right)
            if (x+1 < suzy && y-1 >= 0 && universe[x+1, y-1])
            {
                neighbor++;
            }

            return neighbor;
        }
        public int CountNeighbor(int x, int y)//this is toroidal boundry
        {
            return FiniteCountNeighbor(x, y);
            int suzy = universe.GetLength(0);//x value
            int Ricky = universe.GetLength(1);//y value
            int neighbor = 0;
            int leftx = ((x - 1) < 0) ? suzy-1 : (x - 1); //if the fist statement is true (? = conditional) then use szy-1 (:=else) use like normal
            int rightx = ((x + 1) >= suzy) ? 0 : (x + 1);
            int topy = ((y - 1) < 0) ? Ricky-1 : (y - 1); 
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
        private void newToolStripButton_Click(object sender, EventArgs e)//this does the same as the new too strip button
        {
            newToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)//this is the play button
        {
            timer.Start();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)//this is the pause button
        {
            timer.Stop();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)//this is the next button
        {
            NextGeneration();
        }
        //make a button for a randomize generation - One requirement of the assignment will be to generate a random universe of cells. 
        //Start this by iterating through the universe array using two nested for loops. As we visit each cell generate a random number between 0 and 2 inclusive. 
        //If the random number's value is 0 then make that cell alive, otherwise make it dead. 
        //After this is completed the initial universe should be composed of roughly 1/3 living cells and 2/3 dead cells. 
        //Later on you can play around with the actual percentage of living to dead cells and see how that affects the game.

        private void bySeedToolStripMenuItem_Click(object sender, EventArgs e) //seed user can input
        {
            //uses modal dialogue box
        }

        private void fromCurrentSeedToolStripMenuItem_Click(object sender, EventArgs e) //seed that already exist
        {
           
        }

        private void byTimeToolStripMenuItem_Click(object sender, EventArgs e)//seed by current time
        {
            
        }
    }
}
