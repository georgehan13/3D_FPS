using UnityEngine;
using System.Collections;

public class FireManager : MonoBehaviour 
{
	public Transform cameraTransform;
	public GameObject fireObject;
	public float power = 20.0f;

	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetButtonDown("Fire1"))
		{
			GameObject obj = Instantiate (fireObject) as GameObject;

			obj.transform.position = transform.position;
			obj.rigidbody.velocity = cameraTransform.forward * power;
		}
	
	}
}
