using System;
namespace MarsRover
{
    public class Message
    {
        public string Name { get; set; }
        public Command[] Commands { get; set; }

        public Message(string name, Command[] commands) // Test 7
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(name, "Name not passed to constructor");
            }
            this.Name = name;
            this.Commands = commands;
        }





    }
}
