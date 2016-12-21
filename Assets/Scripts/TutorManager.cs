using UnityEngine;
using System.Collections;

public class TutorManager : MonoBehaviour {

	[Tooltip("Number of seconds that checkings are inactive to prevent falling to the next tutorial before user realize")]
	public int inactiveSeconds;

	enum TutorState {
		SHOW_HAND_STATE,
		DISMISS_HAND_STATE,
		SHOOT_BULLET_STATE,
		SHOOT_ENEMIES_STATE,
		END_STATE,
	};
	TutorState currentState;

	private HandStore handStore;
	private GameObject shootingManager;
	GameObject[] enemies;
	private int inactiveCount;

	// Use this for initialization
	void Start () {
		handStore = HandStore.GetInstance ();

		shootingManager = ObjectStore.FindShootingManager ();
		shootingManager.SetActive (false);

		enemies = ObjectStore.FindEnemies ();
		ShowEnemies (false);

		InitialState ();
	}
	
	// Update is called once per frame
	void Update () {
		if (inactiveCount > 0) {
			inactiveCount--;
			return;
		}
		// Debug usage
		ListenKeyboard ();
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
				print ("FYP/TutorManager/Update/DISMISS_HAND_STATE: handNum = " + handStore.handNum);
				if (handStore.handNum <= 0) {
					ProceedState ();
				}
				break;
			}
		case TutorState.SHOOT_BULLET_STATE:
			{
				if (ObjectStore.FindBullets ().Length > 0) {
					ProceedState ();
				}
				break;
			}
		case TutorState.SHOOT_ENEMIES_STATE:
			{
				if (ObjectStore.FindEnemies ().Length <= 0) {
					ProceedState ();
				}
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

	void ListenKeyboard () {
		if (Input.GetKey (KeyCode.Space)) {
			ProceedState ();
		}
	}

	void InitialState () {
		currentState = TutorState.SHOW_HAND_STATE;
		OnUpdateState ();
	}

	void ProceedState () {
		currentState++;
		ResetInactiveCount ();
		OnUpdateState ();
	}

	void ResetInactiveCount () {
		inactiveCount = 60 * inactiveSeconds;
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
				shootingManager.SetActive (true);
				MsgSystem.ShowMsg (MsgStore.GetShootingTutorMsg (), 30);
				break;
			}
		case TutorState.SHOOT_ENEMIES_STATE:
			{
				ShowEnemies (true);
				MsgSystem.ShowMsg (MsgStore.GetShootingEnemiesTutorMsg (), 30);
				break;
			}
		case TutorState.END_STATE:
			{
				StartCoroutine (LeaveTutorialScene());
				MsgSystem.ShowMsg (MsgStore.GetTutorialEndMsg (), 30);
				break;
			}
		default:
			{
				print ("FYP/TutorManager/OnUpdateState: Invalid tutorial state");
				break;
			}
		}
	}

	void ShowEnemies (bool show) {
		foreach (GameObject enemy in enemies) {
			enemy.SetActive (show);
		}
	}

	IEnumerator LeaveTutorialScene () {
		yield return new WaitForSeconds (10);
		ChangeScene.ChangeToScene (ChangeScene.BRIGHT_SCENE);
	}

}
