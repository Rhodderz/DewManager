namespace DewManager.Configs
{
    public class DewritoConfigLine
    {
        public string Key;
        public string[] Values;

        public DewritoConfigLine(string key, string[] values)
        {
            this.Key = key;
            this.Values = values;
        }
    }
}