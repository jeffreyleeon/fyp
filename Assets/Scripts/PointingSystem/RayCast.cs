using UnityEngine;
using System.Collections;

public class RayCast : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        RaycastHit hit;

        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);

		if (Physics.Raycast (transform.position, forward, out hit)) {
			print ("=================hitting " + hit.collider.gameObject.name);
			print ("LINE BREAK\n" + Time.time);

			if (hit.collider.gameObject.name == ObjectStore.GetStartButtonName ()) {
				StartSceneManager.EnableLoading ();
				StartSceneManager.SetTargetScene (StartSceneManager.BRIGHT_SCENE);
				StartSceneManager.AddCount ();
			} else {
				StartSceneManager.DisableLoading ();
			}
		}
	}
}
