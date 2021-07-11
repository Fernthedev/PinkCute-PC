using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using IPA;
using IPA.Config;
using IPA.Config.Stores;
using PinkCute.Configuration;
using UnityEngine.SceneManagement;
using UnityEngine;
using IPALogger = IPA.Logging.Logger;

namespace PinkCute
{

    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        internal const string HARMONYID = "com.github.Fernthedev.PinkCute";

        internal static Plugin Instance { get; private set; }
        internal static IPALogger Log { get; private set; }
        internal static readonly Harmony _harmonyInstance = new Harmony(HARMONYID);

        [Init]
        /// <summary>
        /// Called when the plugin is first loaded by IPA (either when the game starts or when the plugin is enabled if it starts disabled).
        /// [Init] methods that use a Constructor or called before regular methods like InitWithConfig.
        /// Only use [Init] with one Constructor.
        /// </summary>
        public void Init(IPALogger logger)
        {
            Instance = this;
            Log = logger;
            Log.Info("PinkCute initialized.");
            if (PluginConfig.Instance.Cuties == null)
                PluginConfig.Instance.Cuties = new List<string>() { "Pink", "Goobie", "Eris" };
        }
		/// <summary>
        /// Picks a cutie
        /// </summary>
        public string RandomCutie()
        {
            UnityEngine.Random.InitState(DateTime.UtcNow.Second);
            if (PluginConfig.Instance.RandomCutie)
                return PluginConfig.Instance.Cuties[
                    UnityEngine.Random.Range(0, PluginConfig.Instance.Cuties.Count)];
            else
                return PluginConfig.Instance.Cutie;
        }
        
        
        
        [OnEnable]
        public void OnEnable()
        {
            _harmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
        }

        [OnDisable]
        public void OnDisable()
        {
            _harmonyInstance.UnpatchAll(HARMONYID);
        }

        #region BSIPA Config
        [Init]
        public void InitWithConfig(Config conf)
        {
            Configuration.PluginConfig.Instance = conf.Generated<Configuration.PluginConfig>();
            Log.Debug("Config loaded");
        }
        #endregion
    }
}
