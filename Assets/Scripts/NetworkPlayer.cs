using UnityEngine;
using System.Collections;

public class NetworkPlayer : MonoBehaviour {
	Player player;


	// Use this for initialization
	void Start () {
		player = this.GetComponent<Player> ();
		if (player == null) {
			Debug.LogError ("NetworkPlayer.cs: No Player Script");
		}
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting) {
			// We own this player: send the others our data
			stream.SendNext (player.GetCurrentHealth());
		} else {
			// Network player, receive data
			if (player != null) {
				player.SetHealth ((int)stream.ReceiveNext ());
			}
		}
	}
	

}
