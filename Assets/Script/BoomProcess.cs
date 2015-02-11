
using UnityEngine;
using System.Collections;

public class BoomProcess : MonoBehaviour 
{
	public GameObject groundExplosionObject;
	public GameObject airExplisionObject;
	public AudioClip clip;
	
	void OnCollisionEnter(Collision collision) // 충돌할때
	{
		AudioManager.Instance ().PlaySfx(clip); //싱글턴? 폭탄 사운드 재생

		Debug.Log ("Collision Object Name:" + collision.gameObject.name);  //충돌할때 체크

		int collisionLayer = collision.gameObject.layer; //레이어에 접근됨
		if(collisionLayer == LayerMask.NameToLayer("Ground")) 
		{
			GameObject particleObj = Instantiate (groundExplosionObject) as GameObject;
			particleObj.transform.position = transform.position;
			Destroy (gameObject);
		}
		else
		{
			GameObject particleObj = Instantiate (airExplisionObject) as GameObject;
			particleObj.transform.position = transform.position;
		}

		Destroy(gameObject);
	}
}



//if()

//int collisionLayer = collision.gameObhect.layer;(레이어에 접근)
//









/*
using UnityEngine;
using System.Collections;

public class BoomProcess : MonoBehaviour 
{
	public GameObject particleObject;
	public GameObject particleObject2;
	
	void OnCollisionEnter(Collision collision) // 충돌할때
	{
		//Debug.Log ("Collision Object Name:" + collision.gameObject.name);  //충돌할때 체크

		if(collision.gameObject.name == "Plane") 
		{
			GameObject particleObj = Instantiate (particleObject) as GameObject;
			particleObj.transform.position = transform.position;
			Destroy (gameObject);
		}
		else
		{
			GameObject particleObj = Instantiate (particleObject2) as GameObject;
			particleObj.transform.position = transform.position;
			Destroy (gameObject);
		}

	}
}





*/
//-----------------------------------------------------------------------------------

/*		else if(Collision.gameObject.name = "Wall")
		{
			GameObject particleObj = Instantiate(particleObject) as GameObject; //파티클 복제
			particleObj.transform.position = transform.position; //파티클 위치
			
			Destroy ( gameObject );

		}
*/


//------------------------------------------------------------------------------------


/*

	void OnCollisionEnter(Collision collision) // 충돌할때
	{
		//Debug.Log ("Collision Object Name:" + collision.gameObject.name);  //충돌할때 체크

		if (Collision.gameObject.name == "Plane") 
		{
			GameObject particleObj = Instantiate (particleObject) as GameObject;
			particleObj.transform.position = transform.position;
			Destroy (gameObject);
		}
		else
		{
			GameObject particleObj = Instantiate (particleObject2) as GameObject;
			particleObj.transform.position = transform.position;
			Destroy (gameObject);
		}

	}
}

 */






//On 이벤트일때
//OnCollisionEnter 들어갈때 충돌?
//OnCollisionStay 유지?
//OnCollisionExit 나갈때
//this 컴퍼넌트만 



/*
using UnityEngine;
using System.Collections;

public class BoomProcess : MonoBehaviour 
{
	public GameObject particleObject;

	void OnCollisionEnter(Collision collision) // 충돌할때
	{
		Debug.Log ("Collision Object Name:" + collision.gameObject.name);  //충돌할때 체크

		GameObject particleObj = Instantiate(particleObject) as GameObject; //파티클 복제
		particleObj.transform.position = transform.position; //파티클 위치

		Destroy ( gameObject ); // 자기자신을 없앰. 
	}


}
 */