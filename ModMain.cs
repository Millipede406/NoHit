using System;
using MelonLoader;
using HarmonyLib;
using PatchQuest;
using UnityEngine;

namespace MillimediaGames.NoHit
{
    public class ModMain : MelonMod
    {
        public override void OnUpdate()
        {
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 0)
                return;

            if(Game.State == GameState.QUESTING)
            {
                // Forcing health values to be 1
                Player.P1.Status.health = 1;
                Player.P2.Status.health = 1;
            }
        }
    }

    [HarmonyPatch(typeof(PlayerStatus))]
    [HarmonyPatch(nameof(PlayerStatus.MaxHealth))]
    [HarmonyPatch(MethodType.Getter)]
    public class MaxHealthPatch
    {
        public static void Postfix(ref int __result)
        {
            __result = 1;
        }
    }

    [HarmonyPatch(typeof(PlayerStatus))]
    [HarmonyPatch(nameof(PlayerStatus.CurrentHealth))]
    [HarmonyPatch(MethodType.Getter)]
    public class HealthPatch
    {
        public static void Postfix(ref int __result)
        {
            __result = 1;
        }
    }
}
