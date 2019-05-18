using System;
using System.Collections;

namespace mazeGeneration
{
    internal class Maze
    {
        private int width;
        private int height;
        private string[,] grid;
        private int startPointWidth;
        private int startPointHeight;
        private int currentpointWidth;
        private int currentpointHeight;
        private bool right;
        private bool left;
        private bool up;
        private bool down;
        private int check;
        private Stack sW = new Stack();
        private Stack sH = new Stack();
        private bool finished = false;
        Random random = new Random();
        private int randomEntrance;
        private int loadingProgress;
        private int loadingMax;

        //func to get and set width and height
        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        public int Height
        {
            get { return height; }
            set { height = value; }
        }
        //func to print the maze on screen
        public void Print()
        {
            for (int col = 0; col < width; col++)
            {
                System.Console.WriteLine();
                for (int row = 0; row < height; row++)
                {
                    System.Console.Write(grid[col, row]);
                }
            }
            System.Console.WriteLine();
        }
        //func to reset the maze (in first use SET the maze)
        public void Reset()
        {
            //making the values odd so that a maze can be generated
            if (height % 2 == 0)
            {
                height--;
            }
            if (width % 2 == 0)
            {
                width--;
            }

            //making the grid array that can be used like terrain
            grid = new string[width, height];

            //resetting the grid
            for (int col = 0; col < width; col++)
            {
                for (int row = 0; row < height; row++)
                {
                    if (col % 2 == 0)
                    {
                        grid[col, row] = "██";
                    }
                    else if (row % 2 == 0)
                    {
                        grid[col, row] = "██";
                    }
                    else
                    {
                        grid[col, row] = "░░";
                    }
                }
            }
            currentpointWidth = startPointWidth;
            currentpointHeight = startPointHeight;
        }
        //func to choose a starting point
        public int StartPointWidth
        {
            get { return startPointWidth; }
            set
            {
                if (value == width)
                {
                    value -= 1;
                }
                if (value % 2 == 0)
                {
                    value--;
                }
                if (value <= 1)
                {
                    value = 1;
                }
                startPointWidth = value;
            }
        }
        public int StartPointHeight
        {
            get { return startPointHeight; }
            set
            {
                if (value == height)
                {
                    value -= 1;
                }
                if (value % 2 == 0)
                {
                    value--;
                }
                if (value <= 1)
                {
                    value = 1;
                }
                startPointHeight = value;
            }
        }
        //func to check sides
        public void CheckSides()
        {
            //normalizing the booleans so that they show correct states
            right = false;
            left = false;
            up = false;
            down = false;
            try
            {
                if (grid[currentpointWidth - 2, currentpointHeight] == "░░")
                {
                    //UP
                    up = true;
                }
            }
            catch (Exception) { }
            try
            {
                if (grid[currentpointWidth + 2, currentpointHeight] == "░░")
                {
                    //DOWN
                    down = true;
                }
            }
            catch (Exception) { }
            try
            {
                if (grid[currentpointWidth, currentpointHeight - 2] == "░░")
                {
                    //LEFT
                    left = true;
                }
            }
            catch (Exception) { }
            try
            {
                if (grid[currentpointWidth, currentpointHeight + 2] == "░░")
                {
                    //RIGHT
                    right = true;
                }
            }
            catch (Exception) { }
        }
        //cheking where to move and how to move
        public void Move()
        {
            //random
            Random rnd = new Random();
            CheckSides();


            //all sides
            if (right == true && left == true && up == true && down == true)
            {
                check = rnd.Next(1, 5);
                //UP
                if (check == 1)
                {
                    MoveUp();
                }
                //DOWN
                else if (check == 2)
                {
                    MoveDown();
                }
                //LEFT
                else if (check == 3)
                {
                    MoveLeft();
                }
                //RIGHT
                else if (check == 4)
                {
                    MoveRight();
                }
            }

            //3 sides
            else if (right == false && left == true && up == true && down == true)
            {
                check = rnd.Next(1, 4);
                //UP
                if (check == 1)
                {
                    MoveUp();
                }
                //LEFT
                else if (check == 2)
                {
                    MoveLeft();
                }
                //DOWN
                else if (check == 3)
                {
                    MoveDown();
                }

            }
            else if (right == true && left == false && up == true && down == true)
            {
                check = rnd.Next(1, 4);
                //UP
                if (check == 1)
                {
                    MoveUp();
                }
                //LEFT
                else if (check == 2)
                {
                    MoveLeft();
                }
                //DOWN
                else if (check == 3)
                {
                    MoveDown();
                }
            }
            else if (right == true && left == true && up == false && down == true)
            {
                check = rnd.Next(1, 4);
                //DOWN
                if (check == 1)
                {
                    MoveDown();
                }
                //LEFT
                else if (check == 2)
                {
                    MoveLeft();
                }
                //RIGHT
                else if (check == 3)
                {
                    MoveRight();
                }
            }
            else if (right == true && left == true && up == true && down == false)
            {
                check = rnd.Next(1, 4);
                //UP
                if (check == 1)
                {
                    MoveUp();
                }
                //LEFT
                else if (check == 2)
                {
                    MoveLeft();
                }
                //RIGHT
                else if (check == 3)
                {
                    MoveRight();
                }
            }

            //2 sides
            else if (right == false && left == false && up == true && down == true)
            {
                check = rnd.Next(1, 3);
                //UP
                if (check == 1)
                {
                    MoveUp();
                }
                //DOWN
                else if (check == 2)
                {
                    MoveDown();
                }
            }
            else if (right == true && left == true && up == false && down == false)
            {
                check = rnd.Next(1, 3);
                //LEFT
                if (check == 1)
                {
                    MoveLeft();
                }
                //RIGHT
                else if (check == 2)
                {
                    MoveRight();
                }
            }
            else if (right == true && left == false && up == true && down == false)
            {
                check = rnd.Next(1, 3);
                //UP
                if (check == 1)
                {
                    MoveUp();
                }
                //RIGHT
                else if (check == 2)
                {
                    MoveRight();
                }
            }
            else if (right == true && left == false && up == false && down == true)
            {
                check = rnd.Next(1, 3);
                //DOWN
                if (check == 1)
                {
                    MoveDown();
                }
                //RIGHT
                else if (check == 2)
                {
                    MoveRight();
                }
            }
            else if (right == false && left == true && up == true && down == false)
            {
                check = rnd.Next(1, 3);
                //UP
                if (check == 1)
                {
                    MoveUp();
                }
                //LEFT
                else if (check == 2)
                {
                    MoveLeft();
                }
            }
            else if (right == false && left == true && up == false && down == true)
            {
                check = rnd.Next(1, 3);
                //DOWN
                if (check == 2)
                {
                    MoveDown();
                }
                //LEFT
                else if (check == 3)
                {
                    MoveLeft();
                }
            }

            //1 side
            else if (right == false && left == false && up == false && down == true)
            {
                MoveDown();
            }
            else if (right == false && left == false && up == true && down == false)
            {
                MoveUp();
            }
            else if (right == false && left == true && up == false && down == false)
            {
                MoveLeft();
            }
            else if (right == true && left == false && up == false && down == false)
            {
                MoveRight();
            }

            //if theres no space, start popping until finishing or finding a new space
            else
            {
                try{
                    currentpointWidth = (int)sW.Pop();
                    currentpointHeight = (int)sH.Pop();
                    Move();
                }
                catch(Exception)
                {
                    finished = true;
                }
            }
        }

        private void MoveRight()
        {
            grid[currentpointWidth, currentpointHeight + 1] = "  ";
            grid[currentpointWidth, currentpointHeight + 2] = "  ";
            sW.Push(currentpointWidth);
            sH.Push(currentpointHeight);
            currentpointHeight = currentpointHeight + 2;
            loadingProgress++;
        }
        private void MoveLeft()
        {
            grid[currentpointWidth, currentpointHeight - 1] = "  ";
            grid[currentpointWidth, currentpointHeight - 2] = "  ";
            sW.Push(currentpointWidth);
            sH.Push(currentpointHeight);
            currentpointHeight = currentpointHeight - 2;
            loadingProgress++;
        }
        private void MoveDown()
        {
            grid[currentpointWidth + 1, currentpointHeight] = "  ";
            grid[currentpointWidth + 2, currentpointHeight] = "  ";
            sW.Push(currentpointWidth);
            sH.Push(currentpointHeight);
            currentpointWidth = currentpointWidth + 2;
            loadingProgress++;
        }
        private void MoveUp()
        {
            grid[currentpointWidth - 1, currentpointHeight] = "  ";
            grid[currentpointWidth - 2, currentpointHeight] = "  ";
            sW.Push(currentpointWidth);
            sH.Push(currentpointHeight);
            currentpointWidth = currentpointWidth - 2;
            loadingProgress++;
        }

        //making a whole generation or (move untill) func
        public void Generate()
        {
            loadingProgress = 0;
            if(width % 2 == 0 && height % 2 == 0)
            {
                loadingMax = (width / 2) * (height / 2);
            }
            else if(width %2 == 1 && height %2 == 0)
            {
                loadingMax = ((width - 1) / 2) * (height / 2);
            }
            else if(width % 2 == 0 && height % 2 == 1)
            {
                loadingMax = (width / 2) * ((height - 1) / 2);
            }
            else
            {
                loadingMax = ((width - 1) / 2) * ((height - 1) / 2);
            }
            while (finished != true)
            {
                Move();
                Console.WriteLine($"Loading... {loadingProgress} / {loadingMax}");
                System.Threading.Thread.Sleep(10);
            }
            randomEntrance = random.Next(0, width - 1);
            if (randomEntrance % 2 == 0)
            {
                randomEntrance--;
            }
            if (randomEntrance <= 0)
            {
                randomEntrance = 1;
            }
            grid[randomEntrance, height - 1] = "  ";

            randomEntrance = random.Next(0, width - 1);
            if (randomEntrance % 2 == 0)
            {
                randomEntrance--;
            }
            if (randomEntrance <= 0)
            {
                randomEntrance = 1;
            }
            grid[randomEntrance, 0] = "  ";
        }
        public void GenerateWhole()
        {
            Reset();
            Generate();
            Print();
        }
    }
}