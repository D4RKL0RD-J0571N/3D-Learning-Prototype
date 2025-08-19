using Entities;
using UnityEngine;

namespace GameBuilder
{
    public class EntityBuilder
    {
        public T BuildEntity<T, TData>(T entity, TData data)
            where T : Entity<TData>
            where TData : EntityData, new()
        {
            if (!entity)
            {
                CustomUtilities.WriteLog($"[{GetType().Name}] Entity {data.ID} is invalid");
                return null;
            }

            entity.SetID(data.ID);
            entity.SetName(data.Name);
            entity.SetDescription(data.Description);
            entity.SetPosition(data.Position);
            entity.SetRotation(data.Rotation);

            CustomUtilities.WriteLog($"[{GetType().Name}] Entity has been created, it remains deactivated.");
            return entity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <typeparam name="TData"></typeparam>
        /// <returns></returns>
        public TData CreateEntityData<TData>(string id, string name, string description, Vector3 position, Quaternion rotation)
            where TData : EntityData, new()
        {
            var newData = new TData
            {
                ID = id,
                Name = name,
                Description = description,
                Position = position,
                Rotation = rotation,
            };
            return newData;
        }
    }
}