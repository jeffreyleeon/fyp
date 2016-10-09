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
	/// </summary>
	/// <param name="damage">Damage.</param>
	/// <returns>remain health</returns>
	public virtual void HitBy(int damage){
		if (damage < 0) {
			Debug.LogError ("Cannot have negative damage.");
		}
		currentHealth -= damage;
		if (currentHealth < 0) {
			currentHealth = 0;
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
