using UnityEngine;
using System.Collections;

public class PresentManager : MonoBehaviour {

	static public string presentsIconBasePath = "PresentsIcon/";
	public enum PresentType {
		Shield,
		HalfDamage,
		AddHP,
	}
}

public interface IPresent {
	PresentManager.PresentType PresentType ();
	string GetPresentIcon ();
	void RedeemEffect ();
}

public class ShieldBehv : MonoBehaviour, IPresent {
	public PresentManager.PresentType PresentType () {
		return PresentManager.PresentType.Shield;
	}

	public string GetPresentIcon () {
		return "";
	}

	public void RedeemEffect (){
		Debug.Log ("======Redeem effect: Shield");
	}
}

public class HalfDamageBehv : MonoBehaviour, IPresent {
	public PresentManager.PresentType PresentType () {
		return PresentManager.PresentType.HalfDamage;
	}

	public string GetPresentIcon () {
		return "";
	}

	public void RedeemEffect (){
		Debug.Log ("======Redeem effect: Half damage");
	}
}

public class AddHPBehv : MonoBehaviour, IPresent {
	public PresentManager.PresentType PresentType () {
		return PresentManager.PresentType.AddHP;
	}

	public string GetPresentIcon () {
		return "";
	}

	public void RedeemEffect (){
		Debug.Log ("======Redeem effect: Add HP");
	}
}
