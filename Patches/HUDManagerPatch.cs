using HarmonyLib;

namespace NoPenaltyOnGordion.Patches;

[HarmonyPatch(typeof(HUDManager))]
public class HUDManagerPatch
{
    [HarmonyPatch(nameof(HUDManager.ApplyPenalty))]
    [HarmonyPrefix]
    private static bool ApplyPenaltyPrefix(HUDManager __instance, int playersDead, int bodiesInsured)
    {
        
        if (RoundManager.Instance.currentLevel.levelID == 3) // 71-Gordion
        {
            __instance.statsUIElements.penaltyAddition.text = Plugin.PenaltyText.Value;
            __instance.statsUIElements.penaltyTotal.text = "DUE: $0";
            return false;
        }
        
        return true;
    }
}