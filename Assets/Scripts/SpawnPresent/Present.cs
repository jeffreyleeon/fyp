using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Present : HittableObject {

	[Tooltip("Plane object of the present icon")]
	public GameObject presentIcon;

	protected PresentManager.PresentType presentType;
	protected IPresent presentBehv;
	private AudioSource presentSound;

	virtual public void Start () {
		SetHitBehv (HitType.Normal);

		PresentManager.PresentType type = (PresentManager.PresentType)Random.Range ((int)0, (int)PresentManager.PresentType.PresentCount);
		SetPresentBehv (type);

		// Disable gravity if it is SpaceScene
		Scene scene = SceneManager.GetActiveScene ();
		if (scene.buildIndex == ChangeScene.SPACE_SCENE) {
			Rigidbody rb = GetComponent<Rigidbody> ();
			rb.useGravity = false;
		}
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
		SetPresentSound ();
	}

	public void SetPresentSound () {
		presentSound = GetComponent<AudioSource> ();
		if (presentBehv == null || presentSound == null) {
			return;
		}
		presentSound.clip = Resources.Load<AudioClip>(presentBehv.GetPresentAudioPath ());
	}

	void OnCollisionEnter (Collision collision){
		if (collision.gameObject.tag == ObjectStore.GetBulletTag ()) {
			PlayHitSound ();
			Bullet b = collision.gameObject.GetComponent<Bullet> ();
			hitBehv.HitBy (b.Attack);
			if (this.IsDead()) {
				DisplayPresentIcon ();
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
		if (presentSound != null) {
			AudioSource audio = GetComponent<AudioSource>();
			audio.PlayOneShot(presentSound.clip);
		}
	}

	void DisplayPresentIcon () {
		if (presentIcon == null) {
			return;
		}
		Quaternion rotation = new Quaternion ();
		GameObject iconObject = Instantiate(presentIcon, transform.position, rotation) as GameObject;
		PresentIcon iconScript = iconObject.GetComponent<PresentIcon> ();
		iconScript.SetIcon (presentBehv.GetPresentIcon());
	}

	bool IsDead () {
		return (this.GetCurrentHealth () <= 0);
	}

	public virtual void Kill () {
		StartCoroutine (BaseClassKill ());
		DisableMovementsAndCollisions ();
	}
	IEnumerator BaseClassKill () {
		yield return new WaitForSeconds (2);
		base.Kill ();
	}

	private void DisableMovementsAndCollisions () {
		transform.position = new Vector3 (1000, 1000, 1000);
		Rigidbody rb = GetComponent<Rigidbody>();
		rb.isKinematic = true;
		rb.detectCollisions = false;
	}
}
