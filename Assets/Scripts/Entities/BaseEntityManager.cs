using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    public abstract class BaseEntityManager<TData, TEntity> : MonoBehaviour
        where TData : EntityData, new()
        where TEntity : Entity<TData>
    {
        protected readonly Dictionary<string, TEntity> Registry = new();

        public virtual void Register(TEntity entity)
        {
            if (entity == null)
            {
                CustomUtilities.WriteLog($"[{GetType().Name}] Cannot register null {typeof(TEntity).Name}.");
                return;
            }

            var id = entity.GetID();

            if (string.IsNullOrWhiteSpace(id))
            {
                CustomUtilities.WriteLog($"[{GetType().Name}] Cannot register {typeof(TEntity).Name} with null or empty ID.");
                return;
            }

            if (!entity.GetIfInitialized())
            {
                CustomUtilities.WriteLog($"[{GetType().Name}] Cannot register. ID '{id}' is not initialized.");
                return;
            }

            if (!Registry.TryAdd(id, entity))
            {
                CustomUtilities.WriteLog($"[{GetType().Name}] Failed to register. ID '{id}' is already in use.");
            }
        }

        public virtual void Unregister(TEntity entity)
        {
            if (entity == null)
            {
                CustomUtilities.WriteLog($"[{GetType().Name}] Cannot unregister null {typeof(TEntity).Name}.");
                return;
            }

            var id = entity.GetID();
            if (!Registry.Remove(id))
            {
                CustomUtilities.WriteLog($"[{GetType().Name}] Failed to unregister. ID '{id}' not found.");
            }
        }

        public virtual bool Has(string id) => Registry.ContainsKey(id);

        public virtual TEntity GetById(string id)
        {
            Registry.TryGetValue(id, out var entity);
            return entity;
        }

        public virtual List<TEntity> GetAll() => new(Registry.Values);
    }
}