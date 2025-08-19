using Attributes;
using UnityEngine;

namespace GameBuilder
{
    public class AttributeBuilderUI : BaseBuilderUI
    {
        [SerializeField] private float initialValue;
        [SerializeField] private bool canRegenerate;
        [SerializeField] private bool remainActiveAfterSpawn;
        [SerializeField] private Vector3 targetPosition;
        [SerializeField] private Quaternion targetRotation;
        
        [SerializeField] private float attributeRegenerationRate;
        [SerializeField] private float attributeRegenerationMultiplier;
        [SerializeField] private float attributeCombatRegenerationRate;
        

        private AttributeBuilder _attributeBuilder = new();

        private void Start()
        {
            var attributePrefab = SharedPrefabs.AttributePrefab;

            if (!attributePrefab)
            {
                CustomUtilities.WriteLog($"[{GetType().Name}]: Attribute Prefab is null");
                return;
            }

            var attributeInstance = SpawnManager.Instance.SpawnAttribute(attributePrefab, remainActiveAfterSpawn);
            if (!attributeInstance)
            {
                CustomUtilities.WriteLog($"[{GetType().Name}]: Failed to spawn attribute instance.");
                return;
            }
            var attributeData = _attributeBuilder.CreateAttributeData(
                entityID, entityName, entityDescription, targetPosition, targetRotation, initialValue, 
                attributeRegenerationRate, attributeRegenerationMultiplier, attributeCombatRegenerationRate, false, canRegenerate);
            

            if (_attributeBuilder.BuildAttribute(attributeInstance, attributeData))
            {
                CustomUtilities.WriteLog($"[{GetType().Name}]: Finish: Spawned Attribute: {attributeInstance.GetName()}.");
            }
        }
    }
}