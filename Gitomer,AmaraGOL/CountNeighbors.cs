using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gitomer_AmaraGOL
{
    class CountNeighbors
    {
        public CountNeighbors()
        {
            //int FiniteCountNeighbor(int x, int y)//this is a finite boundry
            //{
            //    int neighbor = 0;
            //    int suzy = universe.GetLength(0);//makes these objects
            //    int Ricky = universe.GetLength(1);
            //    //check x+1,y(middle right)
            //    if (x + 1 < suzy && universe[x + 1, y])
            //    {
            //        neighbor++;
            //    }
            //    //check rightx,y+1 (bottom right)
            //    if (x + 1 < suzy && y + 1 < Ricky && universe[x + 1, y + 1])
            //    {
            //        neighbor++;
            //    }
            //    //check x,y+1 (bottom middle)
            //    if (y + 1 < Ricky && universe[x, y + 1])
            //    {
            //        neighbor++;
            //    }
            //    //check leftx,y (middle left)
            //    if (x - 1 >= 0 && universe[x - 1, y])
            //    {
            //        neighbor++;
            //    }
            //    //check leftx,y-1 (top left)
            //    if (x - 1 >= 0 && y - 1 >= 0 && universe[x - 1, y - 1])
            //    {
            //        neighbor++;
            //    }
            //    //check x, y-1 (top middle)
            //    if (y - 1 >= 0 && universe[x, y - 1])
            //    {
            //        neighbor++;
            //    }
            //    //check leftx, y+1 (bottom left)
            //    if (x - 1 >= 0 && y + 1 < Ricky && universe[x - 1, y + 1])
            //    {
            //        neighbor++;
            //    }
            //    //check rightx, y-1 (top right)
            //    if (x + 1 < suzy && y - 1 >= 0 && universe[x + 1, y - 1])
            //    {
            //        neighbor++;
            //    }

            //    return neighbor;
            //}
            //int CountNeighbor(int x, int y)//this is toroidal boundry
            //{
            //    int suzy = universe.GetLength(0);//x value
            //    int Ricky = universe.GetLength(1);//y value
            //    int neighbor = 0;
            //    int leftx = ((x - 1) < 0) ? suzy - 1 : (x - 1); //if the fist statement is true (? = conditional) then use szy-1 (:=else) use like normal
            //    int rightx = ((x + 1) >= suzy) ? 0 : (x + 1);
            //    int topy = ((y - 1) < 0) ? Ricky - 1 : (y - 1);
            //    int bottomy = ((y + 1) >= Ricky) ? 0 : (y + 1);
            //    //check x+1,y (middle right)
            //    if (rightx < suzy && universe[rightx, y])
            //    {
            //        neighbor++;
            //    }
            //    //check rightx,y+1 (bottom right)
            //    if (rightx < suzy && bottomy < Ricky && universe[rightx, bottomy])
            //    {
            //        neighbor++;
            //    }
            //    //check x,y+1 (bottom middle)
            //    if (bottomy < Ricky && universe[x, bottomy])
            //    {
            //        neighbor++;
            //    }
            //    //check leftx,y (middle left)
            //    if (leftx >= 0 && universe[leftx, y])
            //    {
            //        neighbor++;
            //    }
            //    //check leftx,y-1 (top left)
            //    if (leftx >= 0 && topy >= 0 && universe[leftx, topy])
            //    {
            //        neighbor++;
            //    }
            //    //check x, y-1 (top middle)
            //    if (topy >= 0 && universe[x, topy])
            //    {
            //        neighbor++;
            //    }
            //    //check leftx, y+1 (bottom left)
            //    if (leftx >= 0 && bottomy < Ricky && universe[leftx, bottomy])
            //    {
            //        neighbor++;
            //    }
            //    //check rightx, y-1 (top right)
            //    if (rightx < suzy && topy >= 0 && universe[rightx, topy])
            //    {
            //        neighbor++;
            //    }
            //    return neighbor;
            //}
        }
    }
}
