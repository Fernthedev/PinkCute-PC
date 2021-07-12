using System;
using System.Reflection;
using IPA.Utilities;
using JetBrains.Annotations;
using PinkCute.Configuration;
using TMPro;

namespace PinkCute.HarmonyPatches
{
    using HarmonyLib;

    [HarmonyPatch(typeof(TextMeshPro))]
    [HarmonyPatch("GenerateTextMesh")]
    internal static class TextMeshPro_GenerateTextMesh
    {
        private static readonly MethodInfo ParseInputText = typeof(TextMeshPro).GetMethod("ParseInputText",
             BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
            Type.DefaultBinder, new Type[] { }, null);

        private static void Prefix(TextMeshPro __instance)
        {
            if (__instance == null || ParseInputText == null) throw new NullReferenceException("NOOO!");

            __instance.text = $"{PluginConfig.Instance.GetRandomCutie()} Cute";
            ParseInputText.Invoke(__instance, new object[] {});
        }
    }


}