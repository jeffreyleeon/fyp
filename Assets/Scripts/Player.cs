using UnityEngine;
using System.Collections;

public class Player : HittableObject {
	
	#region public param
	public int ID;
	#endregion 


	#region private param
	private string userName;
	private int score;
	#endregion

	void Start(){
		setUserName ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		MovementControll ();

	}


	#region public method
	public int getScore(){
		return score;
	}

	public void addScore(int mark){
		score += mark;
	}

	public string getUserName(){
		return userName;
	}
	#endregion


	#region private method
	private void setUserName(){
		// get username from UI
		userName = "Default" + Random.Range(1,100);
	}

	/// <summary>
	/// Move Player position, just for testing
	/// </summary>
	private void MovementControll(){
		//control movement
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);
		Rigidbody rigidbody = gameObject.GetComponent<Rigidbody> ();
		rigidbody.velocity = movement * 10.0f;

		if (Input.GetKey(KeyCode.Space)){
			Debug.Log ("Input Key: Space Down");
			rigidbody.velocity = rigidbody.velocity + (Vector3.up * 50 * Time.fixedDeltaTime);
		}
	}

	#endregion
}
