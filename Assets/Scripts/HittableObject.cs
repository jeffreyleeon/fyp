using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PhotonView))]
public abstract class HittableObject : Photon.MonoBehaviour {

	public int maxHealth = 100;

	private int currentHealth;



	// Use this for initialization
	void OnEnable () {
		currentHealth = maxHealth;
	}

	#region public method
	/// <summary>
	/// Gets the current health.
	/// </summary>
	/// <returns>The current health.</returns>
	public  int GetCurrentHealth(){
		return currentHealth;
	}


	/// <summary>
	/// Object get hit by damage.
	/// Autocatically call <c>Kill()</c> when Health less than or equal zero
	/// </summary>
	/// <param name="damage">Damage.</param>
	public virtual void HitBy(int damage){
		if (damage < 0) {
			Debug.LogError ("Cannot have negative damage.");
		}
		currentHealth -= damage;
		if (currentHealth < 0) {
			currentHealth = 0;
			Kill ();
		}
	}

	/// <summary>
	/// Kill this object.
	/// </summary>
	public virtual void Kill(){
        NetworkManager.DestroyNetworkObject(this.gameObject);
	}

	public bool IsAlive(){
		return currentHealth >= 0;
	}

	#endregion

}
