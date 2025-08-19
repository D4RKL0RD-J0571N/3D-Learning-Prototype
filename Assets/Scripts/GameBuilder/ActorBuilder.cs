using System.Collections.Generic;
using Actors;
using Attributes;
using Leveling;
using UnityEngine;

namespace GameBuilder
{
    public class ActorBuilder : EntityBuilder
    {
        public Actor BuildActor(Actor actor, ActorData data, ProgressionData progressionData, List<AttributeData> attributesData)
        {
            if (actor == null)
            {
                CustomUtilities.WriteLog($"[{GetType().Name}] Provided actor reference is null. Cannot build actor.");
                return null;
            }

            var newActor = BuildEntity(actor, data);

            newActor.SetLevel(progressionData.Level);
            newActor.SetExperience(progressionData.Experience);
            newActor.SetPerkPoints(progressionData.PerkPoints);
            newActor.SetLifeState(data.LifeState);

            if (attributesData != null)
            {
                foreach (var attrData in attributesData)
                {
                    AddAttributeToActor(newActor, attrData);
                }
            }

            newActor.Initialize();
            ActorManager.Instance.Register(newActor);

            CustomUtilities.WriteLog($"[{GetType().Name}] Actor with ID: '{newActor.GetID()}' has been created.");
            return newActor;
        }

        private void AddAttributeToActor(Actor actor, AttributeData attributeData)
        {
            if (attributeData == null)
            {
                CustomUtilities.WriteLog($"[{GetType().Name}] Null AttributeData passed. Skipping.");
                return;
            }

            var attribute = actor.gameObject.AddComponent<Attribute>();
            attribute.SetData(attributeData);
            attribute.Initialize();

            if (actor.AddAttribute(attribute))
            {
                CustomUtilities.WriteLog($"[{GetType().Name}] Added attribute '{attribute.GetID()}' to actor '{actor.GetID()}'.");
            }
            else
            {
                CustomUtilities.WriteLog($"[{GetType().Name}] Failed to add attribute '{attribute.GetID()}' to actor '{actor.GetID()}'.");
            }
        }

        public ActorData CreateActorData(
            string id,
            string name,
            string description,
            Vector3 position,
            Quaternion rotation,
            LifeState lifeState)
        {
            var actorData = CreateEntityData<ActorData>(id, name, description, position, rotation);
            actorData.LifeState = lifeState;

            return actorData;
        }

        public ProgressionData CreateActorProgressionData(int level, float experience, int perkPoints)
        {
            return new ProgressionData
            {
                Level = level,
                Experience = experience,
                PerkPoints = perkPoints,
            };
        }
    }
}
