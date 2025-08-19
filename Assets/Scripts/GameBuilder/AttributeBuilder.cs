using Attributes;
using UnityEngine;

namespace GameBuilder
{
    public class AttributeBuilder : EntityBuilder
    {
        public Attribute BuildAttribute(Attribute attribute, AttributeData attributeData)
        {
            if (!attribute)
            {
                CustomUtilities.WriteLog($"[{GetType().Name}] Attribute reference is null. Cannot build attribute.");
                return null;
            }

            var newAttribute = BuildEntity(attribute, attributeData);

            newAttribute.SetInitialValue(attributeData.InitialValue);
            newAttribute.SetRegenerationRate(attributeData.RegenerationRate);
            newAttribute.SetRegenerationMultiplier(attributeData.RegenerationMultiplier);
            newAttribute.SetCombatRegenerationRate(attributeData.CombatRegenerationRate);
            newAttribute.SetInCombat(attributeData.IsInCombat);
            newAttribute.SetCanRegenerate(attributeData.CanRegenerate);
    
            newAttribute.Initialize();

            AttributeManager.Instance.Register(newAttribute);
            CustomUtilities.WriteLog($"[{GetType().Name}] Attribute with ID: '{newAttribute.GetID()}' has been created with initial value of {newAttribute.GetCurrentValue()} / {newAttribute.GetMaxValue()}.");
    
            return newAttribute;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <param name="initialValue"></param>
        /// <param name="regenerationRate"></param>
        /// <param name="regenerationMultiplier"></param>
        /// <param name="combatRegenerationRate"></param>
        /// <param name="isInCombat"></param>
        /// <param name="canRegenerate"></param>
        /// <returns></returns>
        public AttributeData CreateAttributeData(
            string id,
            string name,
            string description,
            UnityEngine.Vector3 position,
            UnityEngine.Quaternion rotation,
            float initialValue,
            float regenerationRate,
            float regenerationMultiplier,
            float combatRegenerationRate,
            bool isInCombat,
            bool canRegenerate 
        )
        {
            var attributeData = CreateEntityData<AttributeData>(id, name, description, position, rotation);
            attributeData.InitialValue = initialValue;
            attributeData.RegenerationRate = regenerationRate;
            attributeData.RegenerationMultiplier = regenerationMultiplier;
            attributeData.CombatRegenerationRate = combatRegenerationRate;
            attributeData.IsInCombat = isInCombat;
            attributeData.CanRegenerate = canRegenerate;
            
            return attributeData;
        }
    }
}