using UnityEngine;
using System.Collections;

public class TutorManager : MonoBehaviour {

	enum TutorState {
		SHOW_HAND_STATE,
		DISMISS_HAND_STATE,
		SHOOT_BULLET_STATE,
		END_STATE,
	};
	TutorState currentState;

	private HandStore handStore;

	// Use this for initialization
	void Start () {
		handStore = HandStore.GetInstance ();
		InitialState ();
	}
	
	// Update is called once per frame
	void Update () {
		switch (currentState) {
		case TutorState.SHOW_HAND_STATE:
			{
				if (handStore.handNum >= 2) {
					ProceedState ();
				}
				break;
			}
		case TutorState.DISMISS_HAND_STATE:
			{
				if (handStore.handNum <= 0) {
					ProceedState ();
				}
				break;
			}
		case TutorState.SHOOT_BULLET_STATE:
			{
				break;
			}
		case TutorState.END_STATE:
			{	
				break;
			}
		default:
			{
				print ("FYP/TutorManager/Update: Invalid tutorial state");
				break;
			}
		}
	}

	void InitialState () {
		currentState = TutorState.SHOW_HAND_STATE;
		OnUpdateState ();
	}

	void ProceedState () {
		currentState++;
		OnUpdateState ();
	}

	void OnUpdateState () {
		switch (currentState) {
		case TutorState.SHOW_HAND_STATE:
			{
				MsgSystem.ShowMsg (MsgStore.GetShowHandTutorMsg (), 30);
				break;
			}
		case TutorState.DISMISS_HAND_STATE:
			{
				MsgSystem.ShowMsg (MsgStore.GetDismissHandTutorMsg (), 30);
				break;
			}
		case TutorState.SHOOT_BULLET_STATE:
			{
				MsgSystem.ShowMsg (MsgStore.GetShootingTutorMsg (), 30);
				break;
			}
		case TutorState.END_STATE:
			{
				break;
			}
		default:
			{
				print ("FYP/TutorManager/OnUpdateState: Invalid tutorial state");
				break;
			}
		}
	}

}
