using UnityEngine;
using UnityEngine.UI;

using System.Collections;


public abstract class MsgObserver : MonoBehaviour {

	public abstract void ShowMessage (string msg, float duration);
	public abstract void StopMessage ();

}

public class MsgText : MsgObserver {

	public Text txt;
	public float fadeTime = 1.0f;

	private Color txtColor;
	private float timer = 0.0f;
	private float showDuration = 0.0f;
	private bool timerOn = false;

	void Start(){
		MsgSystem.AddObserver (this);
		txtColor = txt.color;
		txtColor.a = 0.0f;					//set color alpha to zero
		txt.color = txtColor;
		txt.alignment = TextAnchor.MiddleCenter;
	}

	void Update(){
		//Time.time
		if (timerOn) {
			timer += Time.deltaTime;
			if (timer <= fadeTime) {
				txtColor.a = Mathf.Lerp (0, 1, timer / fadeTime);
				txt.color = txtColor;
			} else if (timer >= fadeTime + showDuration) {
				txtColor.a = Mathf.Lerp (1, 0, (timer - fadeTime - showDuration) / fadeTime);
				txt.color = txtColor;
				if (txtColor.a <= 0.0f) {
					timer = 0.0f;
					timerOn = false;
				}
			}
		}
	}

	void OnDestroy () {
		MsgSystem.RemoveObserver (this);
	}

	public override void ShowMessage (string msg, float duration){
		txt.text = msg;
		showDuration = duration;
		timerOn = true;
	}

	public override void StopMessage (){
		timerOn = false;
		timer = 0.0f;
		txtColor.a = 0.0f;
		txt.color = txtColor;
	}
}
