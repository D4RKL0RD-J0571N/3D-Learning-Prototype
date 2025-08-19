using System;
using Entities;
using UnityEngine;

namespace Attributes
{
    
    [Serializable]
    public class AttributeData : EntityData
    {
        private float _initialValue;
        private float _currentValue;
        private float _maxValue;
        private float _regenerationRate; //0.7f; HealthPerSecond = MaximumHealth * HealRate% * HealRateMult% * (IsInCombat ? CombatHealthRegenMult : 1.0)
        private float _regenerationMultiplier; // 1f; In theory, out of combat will regenerate 0.7 health per second
        private float _combatRegenerationRate; //0.7f; // In combat 0.49 health per second this accounting having a 100 
        private bool _isInCombat;
        private bool _canRegenerate = true;

        public float InitialValue
        {
            get => _initialValue;
            set => _initialValue = Mathf.Clamp(value, 1f, 10000000f);
        }
        
        public float CurrentValue
        {
            get => _currentValue;
            set => _currentValue = Mathf.Clamp(value, 0, MaxValue);
        }

        public float MaxValue
        {
            get => _maxValue;
            set
            {
                _maxValue = Mathf.Max(0, value);
                if (_currentValue > _maxValue)
                    _currentValue = _maxValue;
            }
        }

        public float RegenerationRate
        {
            get => _regenerationRate;
            set => _regenerationRate = Mathf.Max(value, 0);
        }

        public float RegenerationMultiplier
        {
            get => _regenerationMultiplier;
            set => _regenerationMultiplier = Mathf.Max(value, 0);
        }

        public float CombatRegenerationRate
        {
            get => _combatRegenerationRate;
            set => _combatRegenerationRate = Mathf.Max(value, 0);
        }

        public bool IsInCombat
        {
            get => _isInCombat;
            set => _isInCombat = value;
        }

        public bool CanRegenerate
        {
            get => _canRegenerate;
            set => _canRegenerate = value;
        }
        
    }
}