using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PhotonView))]
public abstract class HittableObject : Photon.MonoBehaviour {

	public int maxHealth = 100;
	public enum HitType{
		normal,
		invulnerable,
		absorb
	}

	private int currentHealth;
	protected IHitBehv hitBehv;

	public void SetHitBehv (HitType newHitBehv){
		if (hitBehv != null) {
			Destroy (gameObject.GetComponent(hitBehv.GetType()));
		}

		switch (newHitBehv) {
			case HitType.normal:
				hitBehv = (IHitBehv) gameObject.AddComponent<NormalHitBehv>();
				break;
			case HitType.invulnerable:
				hitBehv = (IHitBehv) gameObject.AddComponent<InvulnerableHitBehv>();
				break;
			case HitType.absorb:
				hitBehv = (IHitBehv) gameObject.AddComponent<AbsorbHitBehv>();
				break;
		}

	}



	// Use this for initialization
	void OnEnable () {
		currentHealth = maxHealth;
	}

	#region public method
	/// <summary>
	/// Gets the current health.
	/// </summary>
	/// <returns>The current health.</returns>
	public int GetCurrentHealth(){
		return currentHealth;
	}


	public void AddHealth(int num){
		if (num < 0) {
			print ("HittableObject.cs: Add negative health");

		}
		currentHealth += num;
		if (currentHealth > maxHealth) {
			currentHealth = maxHealth;
		}
	}

	public void DeductHealth(int num){
		if (num < 0) {
			print ("HittableObject.cs: Deduct negative health");
		}
		currentHealth -= num;
		if (currentHealth <= 0) {
			currentHealth = 0;
		}
	}

	/// <summary>
	/// Kill this object.
	/// </summary>
	public virtual void Kill(){
		if (NetworkManager.IsServerConnected) {
			NetworkManager.DestroyNetworkObject(this.gameObject);
		} else {
			Destroy (this.gameObject);
		}
        
	}

	public bool IsAlive(){
		return currentHealth >= 0;
	}

	#endregion

}
