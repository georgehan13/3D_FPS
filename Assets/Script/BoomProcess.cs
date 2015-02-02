using UnityEngine;
using System.Collections;

public class BoomProcess : MonoBehaviour 
{
	public GameObject particleObject;

	//homework add 0202
	public GameObject wallParticleObject; // for Link in Inspector Tab

	void OnCollisionEnter(Collision collision)
	{
		Debug.Log ("Collision Object Name:" + collision.gameObject.name);

		/* homework disable 0202
		GameObject particleObj = Instantiate (particleObject) as GameObject; //see gameobject name!!!
		
		particleObj.transform.position = transform.position;
		*/

		//homework add 0202
		if (collision.gameObject.name.Contains ("Plane")) 
		{
			GameObject particleObj = Instantiate (particleObject) as GameObject;
			particleObj.transform.position = transform.position;
		}

		else
		{
			GameObject wallParticleObj = Instantiate (wallParticleObject) as GameObject;
			
			wallParticleObj.transform.position = transform.position;
		}

		Destroy( gameObject );
	}


	/*
	void OnCollisionExit(Collision collision)
	{
		Debug.LogWarning("Exit Object Name:" + collision.gameObject.name);
	}
	*/

}
