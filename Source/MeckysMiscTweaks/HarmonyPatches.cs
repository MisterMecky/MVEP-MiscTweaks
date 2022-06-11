using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;
using HarmonyLib;
using VanillaTraitsExpanded;

namespace MeckysMiscTweaks.VETraits
{
    [StaticConstructorOnStartup]
    internal class HarmonyPatches
    {
        static HarmonyPatches()
        {
            new Harmony("MisterMecky.MiscTweaks").PatchAll();
            
        }

        [HarmonyPatch(typeof(JobGiver_GetRest))]
        [HarmonyPatch("TryGiveJob")]
        public static class TryGiveJob_Patch
        {
            public static bool Prefix(Pawn pawn)
            {
                if (pawn.HasTrait(VTEDefOf.VTE_Insomniac) && pawn.needs.rest.CurLevel > 0.40f)
                {
                    return false;
                }
                return true;
            }
        }

    }
}
