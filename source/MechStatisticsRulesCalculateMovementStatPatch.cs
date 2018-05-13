using System;
using BattleTech;
using Harmony;
using UnityEngine;

namespace StatsFixMod
{

    [HarmonyPatch(typeof(MechStatisticsRules), "CalculateMovementStat")]
    public static class MechStatisticsRulesCalculateMovementStatPatch
    {
        public static bool Prefix(MechDef mechDef, ref float currentValue, ref float maxValue)
        {
            try
            {
                var maxSprintDistance = mechDef.Chassis.MovementCapDef.MaxSprintDistance;
                {
                    var stats = new StatCollection();
                    var runSpeedStatistic = stats.AddStatistic("RunSpeed", maxSprintDistance);

                    foreach (var mechComponentRef in mechDef.Inventory)
                    {
                        if (mechComponentRef.Def == null || mechComponentRef.Def.statusEffects == null)
                        {
                            continue;
                        }

                        var statusEffects = mechComponentRef.Def.statusEffects;
                        foreach (var effect in statusEffects)
                        {
                            switch (effect.statisticData.statName)
                            {
                                case "RunSpeed":
                                    stats.PerformOperation(runSpeedStatistic, effect.statisticData);
                                    break;
                            }
                        }
                    }

                    maxSprintDistance = runSpeedStatistic.CurrentValue.Value<float>();
                }

                currentValue = Mathf.Floor(
                    (maxSprintDistance - UnityGameInstance.BattleTechGame.MechStatisticsConstants.MinSprintFactor)
                    / (UnityGameInstance.BattleTechGame.MechStatisticsConstants.MaxSprintFactor - UnityGameInstance.BattleTechGame.MechStatisticsConstants.MinSprintFactor)
                    * 10f
                );
                currentValue = Mathf.Max(currentValue, 1f);
                maxValue = 10f;
                return false;
            }
            catch (Exception e)
            {
                Control.mod.Logger.LogError(e);
                return true;
            }
        }
    }
}