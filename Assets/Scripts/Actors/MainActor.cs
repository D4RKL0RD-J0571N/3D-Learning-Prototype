using Attributes;

namespace Actors
{
    public class MainActor : Actor
    {
        private void Start()
        {
            
        }

        private void Update()
        {
            
            RegenerateAttributes();
            if (GetIfInitialized())
            {
                DebugAttributeValues();    
            }
        }

        private void DebugAttributeValues()
        {
            CustomUtilities.WriteLog($"[Player Info]");
            CustomUtilities.WriteLog($"ID: {GetID()}, Name: {GetName()}, Description: {GetDescription()}");
            CustomUtilities.WriteLog($"LifeState: {GetLifeState().ToString()}, Level: {GetLevel().ToString()}, XP: {GetExperience().ToString()}, Perk Points: {GetPerkPoints().ToString()}");
            
            CustomUtilities.WriteLog($"[Attributes]");

            
            void LogAttribute(string name, Attribute attr)
            {
                CustomUtilities.WriteLog(
                    $"{name} -> Current: {attr.GetCurrentValue()}, Max: {attr.GetMaxValue()}, " +
                    $"RegenRate: {attr.GetRegenerationRate()}, RegenMult: {attr.GetRegenerationMultiplier()}, " +
                    $"CombatRegenRate: {attr.GetCombatRegenerationRate()}, InCombat: {attr.GetIsInCombat()}, " +
                    $"IsFull: {attr.IsFull}, IsDepleted: {attr.IsDepleted}"
                );
            }

            // LogAttribute("Health", GetAttribute("health"));
            // LogAttribute("Stamina", GetAttribute("stamina"));
            // LogAttribute("Mana", GetAttribute("mana")); 
        }

    }
}