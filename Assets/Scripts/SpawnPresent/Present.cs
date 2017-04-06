using UnityEngine;
using System.Collections;

public class Present : HittableObject {

	[Tooltip("Audio of present being hit")]
	public AudioClip hitAudio;

	virtual public void Start () {
		SetHitBehv (HitType.Normal);
	}

	void OnCollisionEnter (Collision collision){
		if (collision.gameObject.tag == ObjectStore.GetBulletTag ()) {
			PlayHitSound ();
			Bullet b = collision.gameObject.GetComponent<Bullet> ();
			hitBehv.HitBy (b.Attack);
			if (this.IsDead()) {
				if (b.IsOwnBy(PhotonNetwork.player.name)) {
					// Only perform effect on target player
				}
				this.Kill ();
			}
		}
	}

	void PlayHitSound () {
		if (hitAudio != null) {
			AudioSource audio = GetComponent<AudioSource>();
			audio.PlayOneShot(hitAudio);
		}
	}

	bool IsDead () {
		return (this.GetCurrentHealth () <= 0);
	}

	public virtual void Kill () {
		base.Kill ();
	}
}
