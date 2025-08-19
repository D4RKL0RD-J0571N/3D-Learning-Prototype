using UnityEngine;

namespace Entities
{
    public abstract class Entity<T> : MonoBehaviour where T : EntityData, new()
    {
        protected T _data = new();

        public virtual void Initialize()
        {
            if (_data == null)
            {
                CustomUtilities.WriteLog($"[{GetType().Name}] Initialization failed: Data is null.");
                return;
            }

            if (_data.IsInitialized)
            {
                CustomUtilities.WriteLog($"[{GetType().Name}] '{typeof(T).Name}' is already initialized.");
                return;
            }

            _data.IsInitialized = true;
            CustomUtilities.WriteLog($"[{GetType().Name}] '{typeof(T).Name}' initialized.");
            
            SetInitialized(true);
        }
        
        public virtual T GetData() => _data;

        public virtual bool SetData(T data)
        {
            if (data == null) return false;
            _data = data;
            return true;
        }

        public string GetID() => _data.ID;
        public string GetName() => _data.Name;
        public string GetDescription() => _data.Description;
        public Vector3 GetPosition() => _data.Position;
        public Quaternion GetRotation() => _data.Rotation;
        public bool GetIfInitialized() => _data.IsInitialized;

        public void SetID(string id) => _data.ID = id;
        public void SetName(string name) => _data.Name = name;
        public void SetDescription(string description) => _data.Description = description;
        public void SetPosition(Vector3 position) => _data.Position = position;
        public void SetRotation(Quaternion rotation) => _data.Rotation = rotation;
        public void SetInitialized(bool initialized) => _data.IsInitialized = initialized;
    }
}