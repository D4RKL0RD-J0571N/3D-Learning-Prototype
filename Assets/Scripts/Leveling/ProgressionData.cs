using System;
using UnityEngine;

namespace Leveling
{
    [Serializable]
    public class ProgressionData
    {
        private int _level;
        private float _experience;
        private int _perkPoints;
    
        public int Level
        {
            get => _level;
            set => _level = Mathf.Max(value, 0);
        }
    
        public float Experience
        {
            get => _experience;
            set => _experience = Mathf.Max(value, 0);
        }
    
        public int PerkPoints
        {
            get => _perkPoints;
            set => _perkPoints = Mathf.Max(value, 0);
        }
    }
}