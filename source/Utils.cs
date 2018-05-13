using System;
using BattleTech;

namespace StatsFixMod
{
    internal static class Utils
    {
        internal static void PerformOperation(this StatCollection collection, Statistic statistic, StatisticEffectData data)
        {
            var type = Type.GetType(data.modType);
            var variant = new Variant(type);
            variant.SetValue(data.modValue);
            variant.statName = data.statName;
            collection.PerformOperation(statistic, data.operation, variant);
        }
    }
}
