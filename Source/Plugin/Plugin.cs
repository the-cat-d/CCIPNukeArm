using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace CCIPNukeArm;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VER)]
public class Plugin : BaseUnityPlugin
{
    internal static new ManualLogSource logger;

    private static Harmony harmony;
    
    private void Awake()
    {
        // Log
        
        logger = base.Logger;
        logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loading...");
        
        // Config
        
        PluginConfig.BindConfig(Config);
        
        // Harmony
        
        harmony = new Harmony(PluginInfo.PLUGIN_GUID);
        harmony.PatchAll();
        
        
        
        
        
    }
}
