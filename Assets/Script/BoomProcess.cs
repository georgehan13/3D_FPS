using UnityEngine;
using System.Collections;

public class BoomProcess : MonoBehaviour 
{
	public GameObject particleObject;

	void OnCollisionEnter(Collision collision)
	{
		Debug.Log ("Collision Object Name:" + collision.gameObject.name);

		GameObject particleObj = Instantiate (particleObject) as GameObject;
		
		particleObj.transform.position = transform.position;

		Destroy( gameObject );
	}


	/*
	void OnCollisionExit(Collision collision)
	{
		Debug.LogWarning("Exit Object Name:" + collision.gameObject.name);
	}
	*/

}
