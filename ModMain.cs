using System;
using MelonLoader;
using HarmonyLib;
using PatchQuest;

namespace MillimediaGames.NoHit
{
    public class ModMain : MelonMod
    {
        
    }

    [HarmonyPatch(typeof(Scaling))]
    [HarmonyPatch(nameof(Scaling.HealthCurve))]
    [HarmonyPatch(MethodType.Getter)]
    public class HealthCurvePatch
    {
        public static void Postfix(ref float __result)
        {
            MelonLogger.Msg("HealthCurve get patched");
            __result = 1f;
        }
    }
}
