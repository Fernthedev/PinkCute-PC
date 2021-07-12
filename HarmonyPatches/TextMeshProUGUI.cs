using System;
using System.Reflection;
using IPA.Utilities;
using PinkCute.Configuration;
using TMPro;

namespace PinkCute.HarmonyPatches
{
    using HarmonyLib;

    [HarmonyPatch(typeof(TextMeshProUGUI))]
    [HarmonyPatch("GenerateTextMesh")]
    internal class TextMeshProUGUI_GenerateTextMesh
    {
        private static readonly MethodInfo ParseInputText = typeof(TextMeshPro).GetMethod("ParseInputText",
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
            Type.DefaultBinder, new Type[] { }, null);
        // public delegate void ParseInputText(TextMeshProUGUI instance);
        // private static readonly ParseInputText ParseInputTextAccessor = MethodAccessor<TextMeshProUGUI, ParseInputText>.GetDelegate("ParseInputText");

        private static void Prefix(TextMeshProUGUI __instance)
        {
            __instance.text = $"{PluginConfig.Instance.GetRandomCutie()} Cute";
            ParseInputText.Invoke(__instance, new object[] {});
        }
    }


}