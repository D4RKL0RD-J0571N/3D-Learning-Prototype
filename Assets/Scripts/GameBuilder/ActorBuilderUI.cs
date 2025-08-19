using System.Collections.Generic;
using Actors;
using Attributes;

namespace GameBuilder
{
    public class ActorBuilderUI : BaseBuilderUI
    {
        public int actorLevel;
        public float actorXp;
        public int actorPerkPoints;
        public LifeState actorLifeState;
        public List<AttributeData> actorAttributes;

        private ActorBuilder _actorBuilder = new();

        private void Start()
        {
            var actorPrefab = SharedPrefabs.ActorPrefab;

            if (!actorPrefab)
            {
                CustomUtilities.WriteLog($"[{GetType().Name}]: Actor Prefab is null.");
                return;
            }

            // Spawn the prefab instance (not yet initialized)
            var actorInstance = SpawnManager.Instance.SpawnActor(actorPrefab);

            if (!actorInstance)
            {
                CustomUtilities.WriteLog($"[{GetType().Name}]: Failed to spawn actor instance.");
                return;
            }

            // Create ActorData and ProgressionData using builder utilities
            var actorData = _actorBuilder.CreateActorData(
                entityID,
                entityName,
                entityDescription,
                entityPosition,
                entityRotation,
                actorLifeState
            );

            var progressionData = _actorBuilder.CreateActorProgressionData(
                actorLevel,
                actorXp,
                actorPerkPoints
            );

            // Build and register the actor
            var builtActor = _actorBuilder.BuildActor(actorInstance, actorData, progressionData, actorAttributes);

            if (builtActor != null)
            {
                CustomUtilities.WriteLog($"[{GetType().Name}]: Finished: Spawned Actor: {builtActor.GetName()}.");
            }
            else
            {
                CustomUtilities.WriteLog($"[{GetType().Name}]: Failed to build actor.");
            }
        }
    }
}
