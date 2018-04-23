using DewManager.Configs;

namespace DewManager
{
    public class ConfigBundle
    {
        public int Index { get; set; }
        public DewritoConfig DewritoConfig{ get; set; }
        public Voting VotingConfig { get; set; }

        public ConfigBundle(int index, DewritoConfig dewritoConfig, Voting votingConfig)
        {
            this.DewritoConfig = dewritoConfig;
            this.VotingConfig = votingConfig;
            this.Index = index;
        }
    }
}