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

		Debug.Log ("X :" + mouseMoveValueX);

		rotationY += mouseMoveValueX * sensitivity * Time.deltaTime;
		rotationX += mouseMoveValueY * sensitivity * Time.deltaTime;

		//Debug.Log ("X :" + rotationX);
		//Debug.Log ("Y :" + rotationY);
        
        rotationY %= 360;
		rotationX %= 360;


		transform.eulerAngles = new Vector3(-rotationX, rotationY, 0.0f);
	}

}
