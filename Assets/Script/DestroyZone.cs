using UnityEngine;
using System.Collections;

public class DestroyZone : MonoBehaviour {
	
	void OnTriggerEnter(Collider other)
	{
		Debug.Log("EnterObject:"+other.gameObject.name);
		if(other.gameObject.name.Contains ("Player"))
		{
			other.gameObject.transform.position=
				new Vector3(0.0f,100.0f,0.0f);
		}
		else if(other.gameObject.name.Contains("BombBall"))
		{
			Destroy(other.gameObject);
		}

	}
}

//충돌함수6개 triggerEnter,Stay,Exit/colliderEnterStay,Exit/
//Contains 포함
//trigger -자동이벤트 / Collider-물리적인것이 가해졌을때
//OnCollisionEnter 들어갈때 충돌?
//OnCollisionStay 유지?
//OnCollisionExit 나갈때

//숙제 - 바닥에 이펙트는 그을음있게 구현, 벽에 폭탄이 터졌을땐 그을음이 없는걸로 구현(이펙트-ExplosionForAir)