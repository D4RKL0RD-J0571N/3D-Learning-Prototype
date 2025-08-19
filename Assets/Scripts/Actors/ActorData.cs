using System;
using Entities;

namespace Actors
{
    [Serializable]
    public class ActorData : EntityData
    {
        public LifeState LifeState { get; set; }


        public override EntityData Clone()
        {
            return new ActorData
            {
                ID = ID,
                Name = Name,
                Description = Description,
                Position = Position,
                Rotation = Rotation,
                IsInitialized = IsInitialized,
                LifeState = LifeState,
            };
        }
    }

    public enum LifeState
    {
        Alive,
        Dead,
        Respawning,
        Disabled 
    }
}