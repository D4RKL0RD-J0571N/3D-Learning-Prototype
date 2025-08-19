namespace Leveling
{
    public class Progression
    {
        // Stats Data
        private readonly ProgressionData _data = new ProgressionData();
        
        // XP progression config
        private const float BaseXpToLevelUp = 75f;
        private const float XpMultiplierPerLevel = 25f;
        private const float XpPerSkillLevel = 1f;

        // Read-only computed values
        public float ExperienceToLevelUp => BaseXpToLevelUp + _data.Level * XpMultiplierPerLevel;
        public bool CanLevelUp => _data.Experience >= ExperienceToLevelUp;
        
        public void Initialize()
        {
            SetLevel(1);
            SetExperience(0f);
            SetPerkPoints(0);
        }

        public void GainExperience(float amount)
        {
            _data.Experience += amount * XpPerSkillLevel;
        }

        public bool TryLevelUp()
        {
            if (!CanLevelUp)
                return false;

            PerformLevelUp();
            return true;
        }

        private void PerformLevelUp()
        {
            _data.Experience -= ExperienceToLevelUp;
            _data.Level++;
            _data.PerkPoints++;
        }

        public void SetLevel(int level)
        {
            _data.Level = level;
        }
        
        public void SetExperience(float experience)
        {
            _data.Experience = experience;
        }

        public void SetPerkPoints(int perkPoints)
        {
            _data.PerkPoints = perkPoints;
        }

        // Accessors for external systems
        public int GetLevel() => _data.Level;
        public float GetExperience() => _data.Experience;
        public int GetPerkPoints() => _data.PerkPoints;
    }
}