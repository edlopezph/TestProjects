using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Core;
using ToyRobot.Data;

namespace ToyRobot.Tests
{
    [TestClass]
    public class RobotTests
    {
        [TestMethod]
        public void Robot_CommandIgnored_WhenNotPlacedYet()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.Command("REPORT");
            //assert
            Assert.AreEqual(RobotData.NOT_PLACED_YET_MESSAGE, result);
        }

        [TestMethod]
        public void Robot_CommandReturnEmptyString_AfterBeingPlaced()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.Command("PLACE 0,0,NORTH");
            //assert
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void Robot_Report_AfterBeingPlaced()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.Command("PLACE 0,0,NORTH");
            result = robot.Command("REPORT");
            //assert
            Assert.AreEqual("0,0,NORTH", result);
        }

        // ************** Test cardinal directions ********************************************
        [TestMethod]
        public void Robot_Report_0_1_N_AfterPlaced_0_0_N_AndSingleMove()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.Command("PLACE 0,0,NORTH");
            result = robot.Command("MOVE");
            result = robot.Command("REPORT");
            //assert
            Assert.AreEqual("0,1,NORTH", result);
        }

        [TestMethod]
        public void Robot_Report_1_0_E_AfterPlaced_0_0_E_AndSingleMove()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.Command("PLACE 0,0,EAST");
            result = robot.Command("MOVE");
            result = robot.Command("REPORT");
            //assert
            Assert.AreEqual("1,0,EAST", result);
        }

        [TestMethod]
        public void Robot_Report_1_0_S_AfterPlaced_1_1_S_AndSingleMove()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.Command("PLACE 1,1,SOUTH");
            result = robot.Command("MOVE");
            result = robot.Command("REPORT");
            //assert
            Assert.AreEqual("1,0,SOUTH", result);
        }

        [TestMethod]
        public void Robot_Report_0_1_W_AfterPlaced_1_1_W_AndSingleMove()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.Command("PLACE 1,1,WEST");
            result = robot.Command("MOVE");
            result = robot.Command("REPORT");
            //assert
            Assert.AreEqual("0,1,WEST", result);
        }

        // ************** Test left direction ********************************************
        [TestMethod]
        public void Robot_Report_0_0_W_AfterPlaced_0_0_N_AndLeftCommand()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.Command("PLACE 0,0,NORTH");
            result = robot.Command("LEFT");
            result = robot.Command("REPORT");
            //assert
            Assert.AreEqual("0,0,WEST", result);
        }

        [TestMethod]
        public void Robot_Report_0_0_S_AfterPlaced_0_0_W_AndLeftCommand()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.Command("PLACE 0,0,WEST");
            result = robot.Command("LEFT");
            result = robot.Command("REPORT");
            //assert
            Assert.AreEqual("0,0,SOUTH", result);
        }

        [TestMethod]
        public void Robot_Report_0_0_E_AfterPlaced_0_0_S_AndLeftCommand()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.Command("PLACE 0,0,SOUTH");
            result = robot.Command("LEFT");
            result = robot.Command("REPORT");
            //assert
            Assert.AreEqual("0,0,EAST", result);
        }

        [TestMethod]
        public void Robot_Report_0_0_N_AfterPlaced_0_0_E_AndLeftCommand()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.Command("PLACE 0,0,EAST");
            result = robot.Command("LEFT");
            result = robot.Command("REPORT");
            //assert
            Assert.AreEqual("0,0,NORTH", result);
        }

        // ************** Test right direction ********************************************
        [TestMethod]
        public void Robot_Report_0_0_E_AfterPlaced_0_0_N_AndRightCommand()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.Command("PLACE 0,0,NORTH");
            result = robot.Command("RIGHT");
            result = robot.Command("REPORT");
            //assert
            Assert.AreEqual("0,0,EAST", result);
        }
        [TestMethod]
        public void Robot_Report_0_0_S_AfterPlaced_0_0_E_AndRightCommand()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.Command("PLACE 0,0,EAST");
            result = robot.Command("RIGHT");
            result = robot.Command("REPORT");
            //assert
            Assert.AreEqual("0,0,SOUTH", result);
        }
        [TestMethod]
        public void Robot_Report_0_0_W_AfterPlaced_0_0_S_AndRightCommand()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.Command("PLACE 0,0,SOUTH");
            result = robot.Command("RIGHT");
            result = robot.Command("REPORT");
            //assert
            Assert.AreEqual("0,0,WEST", result);
        }
        [TestMethod]
        public void Robot_Report_0_0_N_AfterPlaced_0_0_W_AndRightCommand()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.Command("PLACE 0,0,WEST");
            result = robot.Command("RIGHT");
            result = robot.Command("REPORT");
            //assert
            Assert.AreEqual("0,0,NORTH", result);
        }

        // ************** Test robot environment boundaries on placement ******************************
        [TestMethod]
        public void Robot_IgnoreCommand_AfterPlace_NegativeXCoordinate()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.Command("PLACE -1,0,WEST");
            //assert
            Assert.AreEqual(RobotData.OUT_OF_BOUNDS_MESSAGE, result);
        }
        [TestMethod]
        public void Robot_IgnoreCommand_AfterPlace_NegativeYCoordinate()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.Command("PLACE 0,-1,WEST");
            //assert
            Assert.AreEqual(RobotData.OUT_OF_BOUNDS_MESSAGE, result);
        }
        [TestMethod]
        public void Robot_IgnoreCommand_AfterPlace_UpperBoundX()
        {
            //arrange
            Robot robot = new Robot(5, 5);
            //act
            string result = robot.Command("PLACE 6,5,WEST");
            //assert
            Assert.AreEqual(RobotData.OUT_OF_BOUNDS_MESSAGE, result);
        }
        [TestMethod]
        public void Robot_IgnoreCommand_AfterPlace_UpperBoundY()
        {
            //arrange
            Robot robot = new Robot(5, 5);
            //act
            string result = robot.Command("PLACE 5,6,WEST");
            //assert
            Assert.AreEqual(RobotData.OUT_OF_BOUNDS_MESSAGE, result);
        }

        // ************** Test robot environment boundaries on movement ************************
        [TestMethod]
        public void Robot_IgnoreCommand_AfterMove_NegativeXCoordinate()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.Command("PLACE 0,0,WEST");
            result = robot.Command("MOVE");
            //assert
            Assert.AreEqual(RobotData.OUT_OF_BOUNDS_MESSAGE, result);
        }
        [TestMethod]
        public void Robot_IgnoreCommand_AfterMove_NegativeYCoordinate()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.Command("PLACE 0,0,SOUTH");
            result = robot.Command("MOVE");
            //assert
            Assert.AreEqual(RobotData.OUT_OF_BOUNDS_MESSAGE, result);
        }
        [TestMethod]
        public void Robot_IgnoreCommand_AfterMove_UpperBoundXCoordinate()
        {
            //arrange
            Robot robot = new Robot(1, 1);
            //act
            string result = robot.Command("PLACE 0,0,EAST");
            result = robot.Command("MOVE");
            result = robot.Command("MOVE");
            //assert
            Assert.AreEqual(RobotData.OUT_OF_BOUNDS_MESSAGE, result);
        }
        [TestMethod]
        public void Robot_IgnoreCommand_AfterMove_UpperBoundYCoordinate()
        {
            //arrange
            Robot robot = new Robot(1, 1);
            //act
            string result = robot.Command("PLACE 0,0,NORTH");
            result = robot.Command("MOVE");
            result = robot.Command("MOVE");
            //assert
            Assert.AreEqual(RobotData.OUT_OF_BOUNDS_MESSAGE, result);
        }

        // ************** Sample tests provided ************************
        [TestMethod]
        public void ProvidedTest_A()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.Command("PLACE 0,0,NORTH");
            result = robot.Command("MOVE");
            result = robot.Command("REPORT");
            //assert
            Assert.AreEqual("0,1,NORTH", result);
        }
        [TestMethod]
        public void ProvidedTest_B()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.Command("PLACE 0,0,NORTH");
            result = robot.Command("LEFT");
            result = robot.Command("REPORT");
            //assert
            Assert.AreEqual("0,0,WEST", result);
        }
        [TestMethod]
        public void ProvidedTest_C()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.Command("PLACE 1,2,EAST");
            result = robot.Command("MOVE");
            result = robot.Command("MOVE");
            result = robot.Command("LEFT");
            result = robot.Command("MOVE");
            result = robot.Command("REPORT");
            //assert
            Assert.AreEqual("3,3,NORTH", result);
        }

        // ************** Test garbage input ************************
        [TestMethod]
        public void Robot_ReturnsErrorMessage_AfterPlacement_WhenGarbageCommandSent()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.Command("PLACE 1,2,EAST");
            result = robot.Command("BANANAS");
            //assert
            Assert.AreEqual(RobotData.COMMAND_NOT_RECOGNISED_MESSAGE, result);
        }

        // ************** Test garbage input ************************
        [TestMethod]
        public void Robot_ReturnsValidCommandsMessage_WhenGarbageCommandSent()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.Command("PLACE %,2,EAST");
            //assert
            Assert.AreEqual(RobotData.VALID_COMMANDS_MESSAGE, result);
        }

    }
}
