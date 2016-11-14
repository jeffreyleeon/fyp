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
		SetTextAlpha (0.0f);
		txt.alignment = TextAnchor.MiddleCenter;
	}

	void Update(){
		//Time.time
		if (timerOn) {
			timer += Time.deltaTime;
			if (IsEntering ()) {
				SetTextAlpha (Mathf.Lerp (0, 1, timer / fadeTime));
			} else if (IsLeaving ()) {
				SetTextAlpha (Mathf.Lerp (1, 0, (timer - fadeTime - showDuration) / fadeTime));
				if (IsInvisible ()) {
					TurnOffTimer ();
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
		TurnOffTimer ();
		SetTextAlpha (0.0f);
		txtColor.a = 0.0f;
		txt.color = txtColor;
	}

	private bool IsEntering () {
		return timer <= fadeTime;
	}

	private bool IsLeaving () {
		return timer >= fadeTime + showDuration;
	}

	private bool IsInvisible () {
		return txtColor.a <= 0.0f;
	}

	private void TurnOffTimer () {
		timer = 0.0f;
		timerOn = false;
	}

	private void SetTextAlpha (float alpha) {
		txtColor.a = alpha;
		txt.color = txtColor;
	}
}
