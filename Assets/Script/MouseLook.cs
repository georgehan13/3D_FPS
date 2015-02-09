using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour
{ 
	public float sensitivity = 700.0f; //public-변수에서 퍼블릭을사용하면 조절가능
	float rotationX;
	float rotationY;

	PlayerState playerState = null; //02선언

	void Start()
	{
		playerState  = transform.parent.GetComponent<PlayerState>(); //02 부모(PlayerState)에 접근 /null;(없다)
		//foreach(Transform child in transform) -자식을 조사할때
		//Get Component InParent - 부모 오브젝트를 꺼내올수있다 
	}


	void Update()
	{ 
		if(playerState.isDead)
			return; //02

		float mouseMoveValueX = Input.GetAxis ("Mouse X"); //GetAxis(축)-마우스 세로x, 가로y 움직임 구현
		float mouseMoveValueY = Input.GetAxis ("Mouse Y");

		rotationY += mouseMoveValueX * sensitivity * Time.deltaTime; //sensitivity:마우스감도, delta:무언가변화할때
		rotationX += mouseMoveValueY * sensitivity * Time.deltaTime;

		rotationY %=360; //회전각도
		rotationX %=360;

	// Debug.Log("Rotation X :" +rotationX);

		/*
		if(rotationX > 90.0f) //최대 각도값
			rotationX = 90.0f;

		if(rotationX > -90.0f)
			rotationX = -90.0f;
		*/

		rotationX = Mathf.Clamp (rotationX, -45.0f, 45.0f); //Clamp-가둔다

		transform.eulerAngles= new Vector3( -rotationX, rotationY, 0.0f); //백터3 앞엔 거의 new가붙음. 아닐땐 Vector3.

	}

}
