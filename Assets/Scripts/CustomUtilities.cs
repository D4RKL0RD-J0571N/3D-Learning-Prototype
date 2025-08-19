using UnityEngine;

public static class CustomUtilities
{
    private static bool _showLogs = false;

    public static void WriteLog(string log)
    {
        Debug.Log("[CustomUtilities] " + log);
    }

    public static void ShowLog(bool show)
    {
        _showLogs = show;
    }
        
}