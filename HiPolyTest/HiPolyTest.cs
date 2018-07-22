using BepInEx;
using Harmony;
using System.Reflection;
using System;
using UnityEngine;

public class HiPolyTest : BaseUnityPlugin
{
	[HarmonyPrefix, HarmonyPatch(typeof(ChaControl), "InitBaseCustomTextureBody")]
	public static bool SetHiPolyFlag(ChaControl __instance)
	{
		typeof(ChaControl).GetProperty("hiPoly", BindingFlags.Instance|BindingFlags.NonPublic| BindingFlags.Public| BindingFlags.FlattenHierarchy).SetValue(__instance, true, null);
		return true;
	}

	public void Awake() => HarmonyInstance.Create("HiPolyTest").PatchAll(typeof(HiPolyTest));
}
