using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Audio;
using HarmonyLib;
using UnityEngine;

namespace Harmony
{
    public class ZombieZen : IModApi
    {
        public void InitMod(Mod _modInstance)
        {
            Log.Out(" Loading Patch: " + GetType());

            var harmony = new HarmonyLib.Harmony(GetType().ToString());
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }

    [HarmonyPatch(typeof(EntityZombie))]
    [HarmonyPatch("StartRage")]
    public class NoZombieRage
    {
        private static bool Prefix()
        {
            return false;
        }
    }
}