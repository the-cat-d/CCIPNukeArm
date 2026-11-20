using BepInEx.Configuration;
using UnityEngine;

namespace CCIPNukeArm
{
    public static class PluginConfig
    {
        public static ConfigEntry<bool> showArmDelay;
        public static ConfigEntry<bool> colorInvalidDrop;
        public static ConfigEntry<Color> invalidDropColor;
        

        
        public static void BindConfig(ConfigFile config)
        {
            showArmDelay = config.Bind("Main", "Show arming delay next to ToF in CCIP", true);
            colorInvalidDrop = config.Bind("Main", "Color invalid drops in CCIP", true);
            invalidDropColor = config.Bind("Main","Invalid drop color", Color.red);
            

        }
        
    }
}
