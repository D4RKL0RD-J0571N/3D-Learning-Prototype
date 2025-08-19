using System;
using System.Collections.Generic;
using Entities;
using UnityEngine;

namespace Actors
{
    public class ActorManager : BaseEntityManager<ActorData, Actor>
    {
        public static ActorManager Instance { get; private set; }
        
        [SerializeField] private GameObject actorPrefab;

        private void Awake()
        {
            if (Instance&& Instance != this)
            {
                Destroy(this);
                return;
            }
        
            Instance = this;
            DontDestroyOnLoad(this);
            
            SharedPrefabs.ActorPrefab = actorPrefab;
        }

        private void Start()
        {
        }

        /// <summary>
        /// Checks if an actor with the given ID exists.
        /// </summary>
        public bool HasActor(string id) => Registry.ContainsKey(id);

        /// <summary>
        /// Returns the actor with the specified ID, or null if not found.
        /// </summary>
        public Actor Get(string id)
        {
            Registry.TryGetValue(id, out var actor);
            return actor;
        }

        /// <summary>
        /// Returns a list of all registered actors.
        /// </summary>
        public List<Actor> GetAllActors() => new(Registry.Values);
    }
}
