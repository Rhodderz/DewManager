using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DewManager
{
    public class Voting
    {
        public ObservableCollection<Map> Maps { get; set; }
        public ObservableCollection<GameType> Types { get; set; }
    }
}