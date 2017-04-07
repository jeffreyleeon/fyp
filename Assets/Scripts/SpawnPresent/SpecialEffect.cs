using UnityEngine;
using System.Collections;

public sealed class SpecialEffect {

	public static void Shield () {

	}

	public static void ReduceDamage (Player player, float amount) {
		if (player == null) {
			return;
		}
	}

	public static void AddHP (Player player, int amount) {
		if (player == null) {
			return;
		}
		try {
			player.AddHealth (amount);
		} catch {
			Debug.Log ("FYP/SpecialEffect/AddHP: Error caught");
		}
	}
}
