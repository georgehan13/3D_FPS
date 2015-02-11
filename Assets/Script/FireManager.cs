using UnityEngine;
using System.Collections;

using UnityEngine.EventSystems;

public class FireManager : MonoBehaviour {

	public Transform cameraTransform;
	public GameObject fireObject;

	public Transform firePosition;

	public float power = 20.0f;

	PlayerState playerState = null; //02선언

	void Start()
	{
		playerState  = GetComponent<PlayerState>(); //02 부모(PlayerState)에 접근 /null;(없다)
		//foreach(Transform child in transform) -자식을 조사할때
		//Get Component InParent - 부모 오브젝트를 꺼내올수있다 
	}
	
	void Update ()
	{
		if(EventSystem.current.IsPointerOverGameObject()==true)
		{
			return;
		}


		if(playerState.isDead)
			return; //02

		if(Input.GetButtonDown("Fire1")) //fire1 마우스 왼쪽버튼 누른다
		{
			GameObject obj = Instantiate(fireObject)as GameObject; //fireObject 복사

			obj.transform.position = firePosition.position; //위치
			obj.rigidbody.velocity = cameraTransform.forward*power; //속도 카메라앞방향으로 rigidbody(방향도포함)
			obj.rigidbody.angularVelocity = new Vector3 (Random.Range(-180.0f, 180.0f),Random.Range(-180.0f, 180.0f),Random.Range(-180.0f, 180.0f)); //회전


			//obj.transform.rotation = Random.rotation; //회전된 상태에서 던져짐
			//Vector 의미 - 방향과 크기를가지고 움직임 (위치값(0.0.0)멈춤 /) 
			//rigidbody - 강체(움직임을 가지고있음)속도?
			//무작위함수로 힘을가해 던지기 Random.Range(0.0f,7.0f)
		}
	
	}
}


///null;(없다)