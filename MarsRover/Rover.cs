using System;
namespace MarsRover
{
    public class Rover
    {
        public string Mode { get; set; }
        public int Position { get; set; }
        public int GeneratorWatts { get; set; }

        public Rover(int position) 
        {
            Position = position;
            Mode = "NORMAL";
            GeneratorWatts = 110;
        }

        public override string ToString()
        {
            return "Position: " + Position + " - Mode: " + Mode + " - GeneratorWatts: " + GeneratorWatts; 
        }

        public void RecieveMessage(Message message)
        {
           foreach(var command in message.Commands)
            {
                if (command.CommandType == "MODE_CHANGE")
                {
                    Mode = command.NewMode;
                }
                else if (command.CommandType == "MOVE" && Mode != "LOW_POWER")
                {
                    Position = command.NewPostion;
                }
            }
        }
    }
}
