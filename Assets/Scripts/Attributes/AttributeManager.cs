using System.Collections.Generic;
using Entities;
using UnityEngine;

namespace Attributes
{
    /// <summary>
    /// Manages global registration of attributes.
    /// Attributes require a unique ID, Name, Description, and InitialValue.
    /// </summary>
    public class AttributeManager : BaseEntityManager<AttributeData, Attribute>
    {
        public static AttributeManager Instance { get; private set; }
        
        [SerializeField] private GameObject attributePrefab;


        private void Awake()
        {
            if (Instance && Instance != this)
            {
                Destroy(this);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(this);
            
            SharedPrefabs.AttributePrefab = attributePrefab;
        }

        // Optionally: Custom accessors
        public Attribute GetAttribute(string id) => GetById(id);

        public List<Attribute> GetAllAttributes() => GetAll();
    }
}