using System;
using Attributes;
using UnityEngine;

namespace Entities
{
    [Serializable]
    public class EntityData
    {   
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Vector3 Position { get; set; }
        public Quaternion Rotation { get; set; }
        public bool IsInitialized { get; set; }



        public virtual EntityData Clone()
        {
            return new EntityData
            {
                ID = ID,
                Name = Name,
                Description = Description,
                Position = Position,
                Rotation = Rotation,
                IsInitialized = IsInitialized,
            };
        }
    
    }
}