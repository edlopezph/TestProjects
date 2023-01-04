using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Data;

namespace ToyRobot.Core
{
    public class Robot
    {

        private const int xLowerBoundary = 0;
        private const int yLowerBoundary = 0;

        public int xUpperBoundary = -1;
        public int yUpperBoundary = -1;
        private int xPosition = -1;
        private int yPosition = -1;
        private bool isPlaced = false;

        private int direction = 0;

        int[,] moves = { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };

        // Default table size 5,5 if not
        // 
        public Robot()
        {
            xUpperBoundary = 5;
            yUpperBoundary = 5;
        }

        // Custom table size if supplied
        public Robot(int tableSizeX, int tableSizeY)
        {
            xUpperBoundary = tableSizeX;
            yUpperBoundary = tableSizeY;
        }

        public bool ValidatePosition()
        {
            if ((xPosition < xLowerBoundary) || (yPosition < yLowerBoundary))
                return false;
            else if ((xPosition > xUpperBoundary) || (yPosition > yUpperBoundary))
                return false;
            else
                return true;
        }

        public string Place(string command)
        {
            string result = string.Empty;
            char[] delimiterChars = { ',', ' ' };
            string[] wordsInCommand = command.Split(delimiterChars);

            xPosition = Int32.Parse(wordsInCommand[1]);
            yPosition = Int32.Parse(wordsInCommand[2]);

            direction = (int)(RobotData.Directions)Enum.Parse(typeof(RobotData.Directions), wordsInCommand[3]);

            if (!ValidatePosition())
                result = RobotData.OUT_OF_BOUNDS_MESSAGE;
            else
                isPlaced = true;

            return result;
        }

        public string Report()
        {
            return xPosition + "," + yPosition + "," + (RobotData.Directions)direction;
        }

        public string Move()
        {
            string result = string.Empty;
            int originalX = this.xPosition;
            int originalY = this.yPosition;

            xPosition += moves[direction,0];
            yPosition += moves[direction,1];

            if (!ValidatePosition())
            {
                xPosition = originalX;
                yPosition = originalY;
                result = RobotData.OUT_OF_BOUNDS_MESSAGE;
            }
            return result;
        }

        public void Left()
        {
            if (direction == (int)RobotData.Directions.NORTH)
                direction = (int)RobotData.Directions.WEST;
            else
                direction--;
        }

        public void Right()
        {          
            if(direction == (int)RobotData.Directions.WEST)
                direction = (int)RobotData.Directions.NORTH;
            else
                direction++;
        }

        public string Command(string input)
        {
            string command = input.ToUpper().Trim();
            string result = string.Empty;

            try
            {
                if (command.Contains("PLACE"))
                    result = Place(command);

                else if (!isPlaced)
                    result = RobotData.NOT_PLACED_YET_MESSAGE;

                else if (command == "REPORT")
                    result = Report();

                else if (command == "MOVE")
                    result = Move();

                else if (command =="LEFT")
                    Left();

                else if (command == "RIGHT")
                    Right();

                else
                    result = RobotData.COMMAND_NOT_RECOGNISED_MESSAGE;
            }
            catch (Exception e)
            {
                result = RobotData.VALID_COMMANDS_MESSAGE;
            }

            return result;
        }
    }
}
