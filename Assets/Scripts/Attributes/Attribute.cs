using System;
using Entities;
using UnityEngine;

namespace Attributes
{
    public class Attribute : Entity<AttributeData>
    {
        public float GetCurrentValue() => _data.CurrentValue;
        public float GetMaxValue() => _data.MaxValue;
        public float GetRegenerationRate() => _data.RegenerationRate;
        public float GetRegenerationMultiplier() => _data.RegenerationMultiplier;
        public float GetCombatRegenerationRate() => _data.CombatRegenerationRate;
        public bool GetIsInCombat() => _data.IsInCombat;
        
        public bool GetCanRegenerate() => _data.CanRegenerate;

        public void SetInitialValue(float value)
        {
            _data.InitialValue = value;
            SetValue(value);
        }

        public void SetValue(float value) => _data.MaxValue = _data.CurrentValue = value;
        public void SetCurrentValue(float value) => _data.CurrentValue = value;
        public void SetMaxValue(float value) => _data.MaxValue = value;
        public void SetRegenerationRate(float value) => _data.RegenerationRate = value;
        public void SetRegenerationMultiplier(float value) => _data.RegenerationMultiplier = value;
        public void SetCombatRegenerationRate(float value) => _data.CombatRegenerationRate = value;
        public void SetInCombat(bool value) => _data.IsInCombat = value;

        public void SetCanRegenerate(bool value) => _data.CanRegenerate = value;
        
        private void AddToCurrentValue(float value) => _data.CurrentValue += value;
        private void AddToMaxValue(float value) => _data.MaxValue += value;

        public override void Initialize()
        {
            base.Initialize();
            SetInCombat(false);
        }

        private float CalculateRegenerationRate()
        {
            float baseRate = GetIsInCombat() ? GetCombatRegenerationRate() : GetRegenerationRate();
            return GetMaxValue() * baseRate * GetRegenerationMultiplier();
        }

        public void Regenerate(float deltaTime)
        {
            if (!GetCanRegenerate()) return;
            float restoreAmount = CalculateRegenerationRate() * deltaTime;
            AddToCurrentValue(restoreAmount);
        }

        public bool IsDepleted => GetCurrentValue() <= 0f;
        public bool IsFull => Mathf.Approximately(GetCurrentValue(), GetMaxValue());
    }
}
