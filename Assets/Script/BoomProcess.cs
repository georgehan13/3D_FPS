using UnityEngine;
using System.Collections;

public class BoomProcess : MonoBehaviour 
{
	void OnCollisionEnter(Collision collision)
	{
		Debug.Log ("Collision Object Name:" + collision.gameObject.name);
	}

}
