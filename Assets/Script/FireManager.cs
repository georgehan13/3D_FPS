using UnityEngine;
using System.Collections;

public class FireManager : MonoBehaviour 
{
	public Transform cameraTransform;
	public GameObject fireObject;
	public Transform firePosition;
	public float power = 20.0f;



	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetButtonDown("Fire1"))
		{
			GameObject obj = Instantiate (fireObject) as GameObject;

			obj.transform.position = firePosition.position;
			obj.rigidbody.velocity = cameraTransform.forward * power;
			obj.rigidbody.angularVelocity = new Vector3 (Random.Range(-180.0f, 180.0f),Random.Range(-180.0f, 180.0f),Random.Range(-180.0f, 180.0f));

			//obj.rigidbody.AddTorque(Random.Range(-180.0f, 180.0f),Random.Range(-180.0f, 180.0f),Random.Range(-180.0f, 180.0f));
		
		}
	
	}
}
