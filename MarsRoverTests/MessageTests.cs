﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover;

namespace MarsRoverTests
{
    [TestClass]
    public class MessageTests
    {
        Command[] commands = { new Command("foo", 0), new Command("bar", 20) };

        [TestMethod] // Test 5
        public void ArgumentNullExceptionThrownIfNameNotPassedToConstructorTestFive()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Message(default, default));           
        }

        [TestMethod] // Test 6
        public void ConstructorSetsNameTestSix()
        {
            string name = "Name";
            Message newMessage = new Message(name, default);
            Assert.AreEqual(newMessage.Name, name);
        }

        [TestMethod] // Test 7
        public void ConstructorSetsCommandsFieldTestSeven()
        {           
            Command[] commands = {};
            Message newMessage = new Message("foo", commands);
            Assert.AreEqual(newMessage.Commands, commands);
        }
    }
}
