using Attributes;
using Entities;
using Leveling;
using UnityEngine;
using Attribute = Attributes.Attribute;

namespace Actors
{
    public class Actor : Entity<ActorData>
    {
        private Progression _progression = new();
        private AttributeCollection _attributes = new();
        private void Update()
        {
             // Update passive effects, regen, etc.
        }
        public Attribute GetAttribute(string id) => _attributes.Get(id);
        public bool AddAttribute(Attribute attribute) => _attributes.AddAttribute(attribute);
        
        public void RegenerateAttributes() => _attributes.RegenerateAttributes();
        public int GetLevel() => _progression.GetLevel();
        public float GetExperience() => _progression.GetExperience();
        public int GetPerkPoints() => _progression.GetPerkPoints();
        public void SetLevel(int level) => _progression.SetLevel(level);
        public void SetExperience(float experience) => _progression.SetExperience(experience);
        public void SetPerkPoints(int points) => _progression.SetPerkPoints(points);
        public LifeState GetLifeState() => _data.LifeState;
        public void SetLifeState(LifeState state) => _data.LifeState = state;
    }
}
