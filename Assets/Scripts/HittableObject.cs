using UnityEngine;
using System.Collections;

public abstract class HittableObject : Photon.MonoBehaviour {

	public int maxHealth = 100;

	private int currentHealth;



	// Use this for initialization
	void Start () {
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
	/// <returns><c>true</c>, if object still alive, <c>false</c> otherwise.</returns>
	/// <param name="damage">Damage.</param>
	public virtual void HitBy(int damage){
		if (currentHealth < 0) {
			Debug.LogError ("Object has negative health already");
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
		PhotonNetwork.Destroy (this.gameObject);
	}

	public bool Alive(){
		return currentHealth == 0;
	}

	#endregion

}
