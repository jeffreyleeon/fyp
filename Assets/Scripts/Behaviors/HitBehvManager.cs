using UnityEngine;
using System.Collections;

public class HitBehvManager : MonoBehaviour {

}

public interface IHitBehv {
	void HitBy (int damage);
}

public class NormalHitBehv: MonoBehaviour, IHitBehv{
	public void HitBy (int damage){
		this.GetComponent<HittableObject> ().DeductHealth (damage);
	}
}

public class InvulnerableHitBehv: MonoBehaviour, IHitBehv{
	public void HitBy (int damage){
		return;
	}
}

public class AbsorbHitBehv: MonoBehaviour, IHitBehv{
	public void HitBy (int damage){
		this.GetComponent<HittableObject> ().AddHealth (damage);
	}
}
