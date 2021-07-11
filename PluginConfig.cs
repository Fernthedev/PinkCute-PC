
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using IPA.Config.Stores;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace PinkCute.Configuration
{
    internal class PluginConfig
    {
        public static PluginConfig Instance { get; set; }
        public virtual bool RandomCutie { get; set; }
        public virtual string Cutie { get; set; } = "Pink";
        public virtual List<string> Cuties { get; set; } = new List<string>(){ "Pink", "Goobie", "Eris" };

    }
}
