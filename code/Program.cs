using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mazeGeneration
{
    class Program
    {
        static void Main(string[] args)
        {
            bool finished = false;
            while (finished == false)
            {
                try
                {
                    Random rnd = new Random();
                    Maze maze = new Maze();
                    maze.Height = 84;
                    maze.Width = 42;
                    maze.StartPointWidth = rnd.Next(0, maze.Width);
                    maze.StartPointHeight = rnd.Next(0, maze.Height);
                    maze.GenerateWhole();
                    finished = true;
                }
                catch
                {
                    finished = false;
                }
            }
        }
    }
}