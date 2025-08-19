using System;
using UnityEngine;

namespace Serialization
{
    [Serializable]
    public class SaveData
    {
        public string id;
        public string name;
        public string description;
        public Vector3 position;
        public Quaternion rotation;
        public bool isInitialized;
    }
}