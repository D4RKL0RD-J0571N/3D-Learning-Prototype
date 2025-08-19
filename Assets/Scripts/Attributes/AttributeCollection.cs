using System;
using System.Collections.Generic;
using UnityEngine;

namespace Attributes
{
    public class AttributeCollection
    {
        private Dictionary<string, Attribute> _attributes = new();

        public void RegenerateAttributes() // We can call this on the actor update
        {
            if (_attributes == null) return;
            foreach (var attribute in _attributes)
            {
                attribute.Value.Regenerate(Time.deltaTime);
            }
        }
        
        /// <summary>
        /// Adds a new attribute to the collection if the ID is unique.
        /// </summary>    
        public bool AddAttribute(Attribute newAttribute)
        {
            if (_attributes.TryAdd(newAttribute.GetID(), newAttribute)) return true;
            CustomUtilities.WriteLog($"Attribute '{newAttribute.GetID()}' already exists.");
            return false;

        }

        /// <summary>
        /// Removes the attribute by ID if it exists.
        /// </summary>
        public bool RemoveAttribute(string id)
        {
            if (_attributes.ContainsKey(id)) return _attributes.Remove(id);
            CustomUtilities.WriteLog($"Cannot remove attribute. ID '{id}' not found.");
            return false;

        }

        /// <summary>
        /// Gets an attribute by ID. Throws if not found to enforce strict access.
        /// </summary>
        public Attribute Get(string id)
        {
            if (_attributes.TryGetValue(id, out var attribute))
                return attribute;

            CustomUtilities.WriteLog($"Attribute with the ID : '{id}' is not found in collection.");
            return null;
        }

        /// <summary>
        /// Checks if an attribute exists by ID.
        /// </summary>
        public bool Has(string id) => _attributes.ContainsKey(id);

        /// <summary>
        /// Enumerates all attributes in the collection.
        /// </summary>
        public IEnumerable<KeyValuePair<string, Attribute>> GetAll() => _attributes;

        // Indexer shortcut
        // public Attribute this[string id] => Get(id);
    }
}
