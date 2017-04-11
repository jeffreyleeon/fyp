using UnityEngine;
using System.Collections;

public class RayCast : MonoBehaviour {

	[Tooltip("Count down of disabling the button again")]
	private static int disableCount;

	void Start () {
		RestartDisableCount ();
	}

	// Update is called once per frame
	void Update () {
        RaycastHit hit;

        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);

		if (Physics.Raycast (transform.position, forward, out hit)) {
			RestartDisableCount ();
//			print ("=================hitting " + hit.collider.gameObject.name);
//			print ("LINE BREAK\n" + Time.time);

			if (hit.collider.gameObject.name == ObjectStore.GetStartButtonName ()) {
				StartSceneManager.EnableLoading ();
				StartSceneManager.SetTargetScene (StartSceneManager.TUTORIAL_SCENE);
				StartSceneManager.SetTutorNext (StartSceneManager.BRIGHT_SCENE);
				StartSceneManager.AddCount ();
			} else if (hit.collider.gameObject.name == ObjectStore.GetMapButtonName ()) {
				StartSceneManager.EnableLoading ();
				StartSceneManager.SetTargetScene (StartSceneManager.MAP_SCENE);
				StartSceneManager.AddCount ();
				//print ("=================MAP " + hit.collider.gameObject.name);
			} else if (hit.collider.gameObject.name == ObjectStore.GetMenuButtonName ()) {
				StartSceneManager.EnableLoading ();
				StartSceneManager.SetTargetScene (StartSceneManager.MENU_SCENE);
				StartSceneManager.AddCount ();
			} else if (hit.collider.gameObject.name == ObjectStore.GetNextButtonName ()) {
				StartSceneManager.EnableLoading ();
				StartSceneManager.SetTargetScene (StartSceneManager.GetNextLevel(CurrentLevel.currentLevel));
				StartSceneManager.AddCount ();
			} else if (hit.collider.gameObject.name == ObjectStore.GetForestButtonName ()) {
				StartSceneManager.EnableLoading ();
				StartSceneManager.SetTargetScene (StartSceneManager.TUTORIAL_SCENE);
				StartSceneManager.SetTutorNext (StartSceneManager.BRIGHT_SCENE);
				StartSceneManager.AddCount ();
			} else if (hit.collider.gameObject.name == ObjectStore.GetChristmasButtonName ()) {
				StartSceneManager.EnableLoading ();
				StartSceneManager.SetTargetScene (StartSceneManager.TUTORIAL_SCENE);
				StartSceneManager.SetTutorNext (StartSceneManager.CHRISTMAS_SCENE);
				StartSceneManager.AddCount ();
			} else if (hit.collider.gameObject.name == ObjectStore.GetSpaceButtonName ()) {
				StartSceneManager.EnableLoading ();
				StartSceneManager.SetTargetScene (StartSceneManager.TUTORIAL_SCENE);
				StartSceneManager.SetTutorNext (StartSceneManager.SPACE_SCENE);
				StartSceneManager.AddCount ();
			} else if (hit.collider.gameObject.name == ObjectStore.GetHorrorButtonName ()) {
				StartSceneManager.EnableLoading ();
				StartSceneManager.SetTargetScene (StartSceneManager.TUTORIAL_SCENE);
				StartSceneManager.SetTutorNext (StartSceneManager.HORROR_SCENE);
				StartSceneManager.AddCount ();
			}else{
				StartSceneManager.DisableLoading ();
			}
		} else {
			DisableLoading ();
		}
	}

	void RestartDisableCount () {
		disableCount = 120;
	}

	void DisableLoading () {
		if (disableCount >= 0) {
//			print (disableCount);
			disableCount = disableCount - 1;
			return;
		}
		// print (disableCount);
		StartSceneManager.DisableLoading ();
	}
}
