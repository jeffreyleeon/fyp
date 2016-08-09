using UnityEngine;

namespace Leap {
	public class LeapUnityUtil {
		public static Vector3 toUnityvector3(Vector3 position){
			return new Vector3 (-position.x, position.z, position.y);
		}
	}
}
