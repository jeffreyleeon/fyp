using UnityEngine;
using UnityEngine.UI;

using System.Collections;


public abstract class MsgObserver : MonoBehaviour {

	public abstract void ShowMessage (string msg);
}

public class MsgText : MsgObserver {

	public Text txt;

	void Start(){
		MsgSystem.AddObserver (this);
	}

	void OnDestroy () {
		MsgSystem.RemoveObserver (this);
	}

	public override void ShowMessage (string msg){
		txt.text = msg;
	}

}
