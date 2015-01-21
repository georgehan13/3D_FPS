using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour 
{
	public float sensitivity = 700.0f;
	float rotationX;
	float rotationY;

	void Update()
	{
		float mouseMoveValueX = Input.GetAxis ("Mouse X");
		float mouseMoveValueY = Input.GetAxis ("Mouse Y");

		//Debug.Log ("X :" + mouseMoveValueX);

		rotationY += mouseMoveValueX * sensitivity * Time.deltaTime;
		rotationX += mouseMoveValueY * sensitivity * Time.deltaTime;

		//Debug.Log ("dTime :" + Time.deltaTime);
		//Debug.Log ("X :" + rotationX);
		//Debug.Log ("Y :" + rotationY);
        
        rotationY %= 360;
		rotationX %= 360;

		//Debug.Log ("Rotation X : "+ rotationX);                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              

		/*
		if( rotationX > 40.0f)
			rotationX = 40.0f;

		if( rotationX < -40.0f)
			rotationX = -40.0f;
		*/

		rotationX = Mathf.Clamp(rotationX, -40.0f, 40.0f); // !!! same as if

		transform.eulerAngles = new Vector3(-rotationX, rotationY, 0.0f);


	}

}
