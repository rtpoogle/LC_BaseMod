using BepInEx;
using HarmonyLib;
using BepInEx.Logging;

namespace BaseMod
{
    [BepInPlugin(GUID, NAME, VER)]
    //[BepInDependency(modGUID)]
    public class BaseModPlugin : BaseUnityPlugin
    {
        public const string GUID = "xyz.poogle.lc_basemod";
        public const string NAME = "Base Mod";
        public const string VER = "1.0.0";
        public readonly Harmony harmony = new Harmony(GUID);

        public ManualLogSource LogSrc;

        public static BaseModPlugin Instance;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            LogSrc = BepInEx.Logging.Logger.CreateLogSource(GUID);

            Patches.InitPatches();

            LogSrc.LogInfo("Initialized!");

        }
    }

    internal class Patches
    {
        internal static void InitPatches()
        {
            BaseModPlugin.Instance.harmony.PatchAll();
        }
    }
}
