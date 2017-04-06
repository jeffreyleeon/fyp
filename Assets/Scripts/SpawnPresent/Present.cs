using UnityEngine;
using System.Collections;

public class Present : HittableObject {

	[Tooltip("Audio of present being hit")]
	public AudioClip hitAudio;

	protected PresentManager.PresentType presentType;
	protected IPresent presentBehv;

	virtual public void Start () {
		SetHitBehv (HitType.Normal);
		SetPresentBehv (PresentManager.PresentType.Shield);
	}

	public void SetPresentBehv (PresentManager.PresentType newPresentType){
		if (newPresentType == null) {
			return;
		}
		presentType = newPresentType;

		switch (presentType) {
		case PresentManager.PresentType.Shield:
			presentBehv = (IPresent)new ShieldBehv ();
			break;
		case PresentManager.PresentType.HalfDamage:
			presentBehv = (IPresent)new HalfDamageBehv ();
			break;
		case PresentManager.PresentType.AddHP:
			presentBehv = (IPresent)new AddHPBehv ();
			break;
		}
	}

	void OnCollisionEnter (Collision collision){
		if (collision.gameObject.tag == ObjectStore.GetBulletTag ()) {
			PlayHitSound ();
			Bullet b = collision.gameObject.GetComponent<Bullet> ();
			hitBehv.HitBy (b.Attack);
			if (this.IsDead()) {
				if (b.IsOwnBy(PhotonNetwork.player.name) && presentBehv != null) {
					// Only perform effect on target player
					Player player = ObjectStore.FindMyPlayer ();
					presentBehv.RedeemEffect (player);
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
