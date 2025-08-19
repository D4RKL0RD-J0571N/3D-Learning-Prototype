using System.IO;
using Entities;

namespace Serialization
{
    public static class SaveSystem
    {
        private static string path; // We want to save probably in MyGames if in Windows, if there is a build for linux or other systems, it can change.

        public static void Save(EntityData data) // We want to be able to save from actor data to attribute data etc.
        {
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            
            
            
        }
    }
}