namespace ToyRobot.Data
{
    public class RobotData
    {
        public const string COMMAND_SUCCESS_MESSAGE = "Command successful";
        public const string OUT_OF_BOUNDS_MESSAGE = "Command ignored - Out of bounds";
        public const string NOT_PLACED_YET_MESSAGE = "Command ignored - Robot not placed yet";
        public const string COMMAND_NOT_RECOGNISED_MESSAGE = "Command ignored - Robot did not understand this command";
        public const string VALID_COMMANDS_MESSAGE = "Error during command handling.\nValid commands are:\nPLACE X,Y,Direction\nMOVE\nLEFT\nRIGHT\nREPORT";

        public enum Directions
        {
            NORTH,
            EAST,
            SOUTH,
            WEST
        }
    }
}