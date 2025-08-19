using System;
using System.Collections.Generic;

namespace Serialization
{
    [Serializable]
    public class SaveGame
    {
        public string saveName;
        public string timestamp;
        public List<ActorSaveData> actors;
        
    }
}