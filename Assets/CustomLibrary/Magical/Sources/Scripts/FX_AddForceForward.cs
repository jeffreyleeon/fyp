using UnityEngine;
using System.Collections;

namespace MagicalFX
{
	[RequireComponent (typeof(Rigidbody))]

public class FX_AddForceForward : MonoBehaviour
	{
	
		public float Force = 300;

		void Start ()
		{
			Rigidbody rb = GetComponent<Rigidbody> ();
			if (rb) {
				rb.AddForce (this.transform.forward * Force);
			}
		}

		void Update ()
		{
		
		}
	}
}
