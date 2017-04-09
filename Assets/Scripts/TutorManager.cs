using UnityEngine;
using System.Collections;

public class TutorManager : MonoBehaviour {

	[Tooltip("Number of seconds that checkings are inactive to prevent falling to the next tutorial before user realize")]
	public int inactiveSeconds;

	enum TutorState {
		INTRO_STATE,
		SHOW_HAND_STATE,
		DISMISS_HAND_STATE,
		SHOOT_BULLET_STATE,
		CHANGE_BULLET_STATE,
		SHOOT_ENEMIES_STATE,
		END_STATE,
	};
	TutorState currentState;

	private HandStore handStore;
	private GameObject shootingManager;
	private TutorialShootingController shootingController;
	GameObject[] enemies;
	private int inactiveCount;
	private static int nextScene = ChangeScene.BRIGHT_SCENE;
	private bool msgLock;

	public static void SetNextScene (int sceneIndex) {
		nextScene = sceneIndex;
	}

	// Use this for initialization
	void Start () {
		handStore = HandStore.GetInstance ();

		shootingManager = ObjectStore.FindShootingManager ();
		shootingManager.SetActive (false);

		shootingController = shootingManager.GetComponent<TutorialShootingController> ();

		enemies = ObjectStore.FindEnemies ();
		ShowEnemies (false);

		msgLock = false;
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
		case TutorState.INTRO_STATE:
			{
				//do nothing, proceed in ShowIntro()
				break;
			}
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
		case TutorState.CHANGE_BULLET_STATE:
			{
				if (shootingController.HasChangedWeapon ()) {
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
		currentState = TutorState.INTRO_STATE;
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
		case TutorState.INTRO_STATE:
			{
				StartCoroutine (ShowMsgwithDelay(MsgStore.GetExtendHandMsg(), 4, false));
				StartCoroutine (ShowMsgwithDelay(MsgStore.GetFlipHandMsg(), 4, true));
				break;
			}
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
		case TutorState.CHANGE_BULLET_STATE:
			{
				MsgSystem.ShowMsg (MsgStore.GetChangeWeaponTutorMsg (), 30);
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
				StartCoroutine (ShowCountDownMsg ());
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

	IEnumerator ShowCountDownMsg () {
		MsgSystem.ActivateFade (false);
		for (int i = 10; i > 0; --i) {
			string msg = MsgStore.GetTutorialEndMsgPartOne () + i.ToString () + MsgStore.GetTutorialEndMsgPartTwo ();
			MsgSystem.ShowMsg (msg, 30);
			yield return new WaitForSeconds (1);
		}
		MsgSystem.ActivateFade (true);
	}

	IEnumerator LeaveTutorialScene () {
		shootingManager.SetActive (false);
		HandStore.GetInstance ().resetHands ();
		GameObject leap = ObjectStore.FindLeapMotionController ();
		leap.SetActive (false);
		yield return new WaitForSeconds (10);
		leap.SetActive (true);
		ChangeScene.ChangeToScene (nextScene);
	}

	IEnumerator ShowMsgwithDelay(string message, float delay, bool proceed){
		if (msgLock) {
			yield return new WaitForSeconds (1);
			StartCoroutine (ShowMsgwithDelay (message, delay, proceed));
		} else {
			msgLock = true;
			MsgSystem.ShowMsg (message, delay);
			yield return new WaitForSeconds (delay);
			msgLock = false;
			if (proceed) {
				ProceedState ();
			}
		}
	}
}