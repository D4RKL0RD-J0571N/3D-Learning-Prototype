using System;
using System.Collections.Generic;
using Actors;
using Attributes;

namespace Serialization
{
    [Serializable]
    public class ActorSaveData : SaveData
    {
        public int level;
        public float xp;
        public int perkPoints;
        public LifeState lifeState;
        public List<AttributeData> attributes;
    }
}