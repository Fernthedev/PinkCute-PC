
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using IPA.Config.Stores;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace PinkCute.Configuration
{
    internal class PluginConfig
    {
        public static PluginConfig Instance { get; set; }
        public virtual bool RandomCutie { get; set; } = false;
        public virtual string Cutie { get; set; } = "Pink";

        public static readonly List<string> Cuties = new List<string> { "Pink", "Goobie", "Eris" };

        /// <summary>
        /// Picks a cutie
        /// </summary>
        public string GetRandomCutie()
        {
            if (RandomCutie)
                return Cuties[
                    UnityEngine.Random.Range(0, Cuties.Count)];
            else
                return Instance.Cutie;
        }
    }
}
