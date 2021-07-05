using System;
using System.Collections.Generic;
using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverTests
{
    [TestClass]
    public class RoverTests
    {
        [TestMethod] // Test 8
        public void ConstructorSetsDefaultPosition()
        {
            int position = 98382;
            Rover newRoverPosition = new Rover(position);
            Assert.AreEqual(newRoverPosition.Position, position);
        }

        [TestMethod] // Test 9
        public void ConstructorSetsDefaultMode()
        {
            string mode = "NORMAL";
            Rover newRoverMode = new Rover(default);
            Assert.AreEqual(newRoverMode.Mode, mode);
        }

        [TestMethod] // Test 10
        public void ConstructorSetsDefaultGeneratorWatts()
        {
            double generatorWatts = 110;
            Rover newRoverWatts = new Rover(default);
            Assert.AreEqual(newRoverWatts.GeneratorWatts, generatorWatts);
        }

        [TestMethod] // Test 11 
        public void RespondsCorrectlyToModeChangeCommand()
        {
            // arrange 
            Rover rover = new Rover(default);
            Command[] commands = new Command[]
            {
                new Command("MODE_CHANGE", "LOW_POWER")
            };
            Message message = new Message("Name", commands);

            // act
            rover.RecieveMessage(message);

            // assert
            Assert.AreEqual(rover.Mode, "LOW_POWER");
        }

        [TestMethod] // Test 12
        public void DoesNotMoveInLowPower()
        {
            // arrange 
            Rover rover = new Rover(default)
            {
                Mode = "LOW_POWER"
            };
            Command[] commands = new Command[]
            {
                new Command("MOVE", 1000)
            };
            Message message = new Message("Name", commands);

            // act
            rover.RecieveMessage(message);

            // assert
            Assert.AreEqual(rover.Position, default);
        }

        [TestMethod] // Test 13 
        public void PositionChangesFromMoveCommand()
        {
            // arrange 
            Rover rover = new Rover(default);
            Command[] commands = new Command[]
            {
                new Command("MOVE", 1000)
            };
            Message message = new Message("Name", commands);

            // act
            rover.RecieveMessage(message);

            // assert
            Assert.AreEqual(rover.Position, 1000);
        }

       /* [TestMethod] // Test 14
        public void RoverReturnsAMessageForAnUnknownCommand()
        {

        }*/
    }
}
