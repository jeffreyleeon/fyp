using UnityEngine;
using System.Collections;

public class PresentManager : MonoBehaviour {

	static public string presentsIconBasePath = "PresentsIcon/";
	public enum PresentType {
		Shield = 0,
		HalfDamage,
		AddHP,
		PresentCount,
	}
}

public interface IPresent {
	PresentManager.PresentType PresentType ();
	string GetPresentIcon ();
	void RedeemEffect (Player player);
}

public class ShieldBehv : IPresent {
	public PresentManager.PresentType PresentType () {
		return PresentManager.PresentType.Shield;
	}

	public string GetPresentIcon () {
		return "";
	}

	public void RedeemEffect (Player player) {
		Debug.Log ("======Redeem effect: Shield");
	}
}

public class HalfDamageBehv : IPresent {
	public PresentManager.PresentType PresentType () {
		return PresentManager.PresentType.HalfDamage;
	}

	public string GetPresentIcon () {
		return "";
	}

	public void RedeemEffect (Player player) {
		Debug.Log ("======Redeem effect: Half damage");
	}
}

public class AddHPBehv : IPresent {
	public PresentManager.PresentType PresentType () {
		return PresentManager.PresentType.AddHP;
	}

	public string GetPresentIcon () {
		return "";
	}

	public void RedeemEffect (Player player) {
		Debug.Log ("======Redeem effect: Add HP");
	}
}
