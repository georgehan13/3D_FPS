using UnityEngine;
using System.Collections;

public class BoomProcess : MonoBehaviour 
{
	public GameObject groundExplosionObject;
	public GameObject airExplosionObject;


	void OnCollisionEnter(Collision collision)
	{
		Debug.Log ("Collision Object Name:" + collision.gameObject.name);

		int collisionLayer = collision.gameObject.layer;

		if(collisionLayer == LayerMask.NameToLayer("Ground"))
		{
			GameObject particleObj = Instantiate (groundExplosionObject) as GameObject;
			particleObj.transform.position = transform.position;
		}

		else
		{
			GameObject particleObj = Instantiate (airExplosionObject) as GameObject;
			particleObj.transform.position = transform.position;
		}
	

		Destroy( gameObject );
	}

}
