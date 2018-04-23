using System.Diagnostics;

namespace DewManager
{
    public class Command
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public Command(string cmd)
        {
            Debug.WriteLine("CMD IS:::: " + cmd);
            
            Name = cmd.Split(' ')[0];
            Value = cmd.Split(' ')[1];
        }
    }
}