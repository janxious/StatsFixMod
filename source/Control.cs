
using HBS.Logging;
using Harmony;
using System.Reflection;
using DynModLib;

namespace StatsFixMod
{
    public static class Control
    {
        public static Mod mod;

        public static ModSettings settings = new ModSettings();

        public static void OnInit(string modDirectory)
        {
            mod = new Mod(modDirectory);
            Logger.SetLoggerLevel(mod.Logger.Name, LogLevel.Log);

            mod.LoadSettings(settings);
			
			var harmony = HarmonyInstance.Create(mod.Name);
            harmony.PatchAll(Assembly.GetExecutingAssembly());

            // logging output can be found under BATTLETECH\BattleTech_Data\output_log.txt
            // or also under yourmod/log.txt
            mod.Logger.Log("Loaded " + mod.Name);
        }
    }
}
