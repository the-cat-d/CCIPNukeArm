using HarmonyLib;
using NuclearOption.UIStyleSystem;
using System.Collections.Generic;
using UnityEngine;

namespace CCIPNukeArm.Source.Patches
{
    public class CCIPPatches
    {
        
        private static Dictionary<string,float> nukeArmDelays  = new Dictionary<string,float>(); 
        
        
        [HarmonyPatch(typeof(HUDBombingState),nameof(HUDBombingState.UpdateWeaponDisplay))]
        public static class WeaponDisplayUpdatePatch
        {
            public static void Postfix(HUDBombingState __instance, Aircraft aircraft)
            {
                if (!__instance.weaponInfo.nuclear) return;

                if (!nukeArmDelays.TryGetValue(__instance.weaponInfo.weaponName, out float armDelay))
                {
                    OpticalSeekerBomb seeker = __instance.weaponInfo.weaponPrefab.GetComponent<OpticalSeekerBomb>();
                    armDelay = seeker.armDelay; 
                }

                float fallTime = Kinematics.FallTime(aircraft.radarAlt, aircraft.rb.velocity.y);
                
                __instance.ccipFallTime.text = $"ToF {fallTime:F1}/{armDelay:F1}";

                if (fallTime < armDelay)
                {
                    __instance.ccipLine.color = Color.red;
                    __instance.ccrpCircle.color = Color.red;
                    __instance.ccrpFallTime.color = Color.red;
                    __instance.ccipFallTime.color = Color.red;
                    __instance.ccipPipper.color = Color.red;
                    __instance.alignmentBar.color = Color.red;
                    __instance.lowerMarker.color = Color.red;
                    __instance.upperMarker.color = Color.red;
                    __instance.dropCountdown.color = Color.red;
                    
                }
                else
                {
                    __instance.ccipLine.color = ThemeManager.Active.colorTheme.allClear;
                    __instance.ccipLine.color = ThemeManager.Active.colorTheme.allClear;
                    __instance.ccrpCircle.color = ThemeManager.Active.colorTheme.allClear;
                    __instance.ccipFallTime.color = ThemeManager.Active.colorTheme.allClear;
                    __instance.ccipPipper.color = ThemeManager.Active.colorTheme.allClear;
                    __instance.alignmentBar.color = ThemeManager.Active.colorTheme.allClear;
                    __instance.lowerMarker.color = ThemeManager.Active.colorTheme.allClear;
                    __instance.upperMarker.color = ThemeManager.Active.colorTheme.allClear;
                }
                
            }
        }
        
    }
}
