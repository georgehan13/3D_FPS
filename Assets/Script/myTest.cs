using UnityEngine;
using System.Collections;

public class myTest : MonoBehaviour 
{

	void OnCollisionStay(Collision collision) 
	{
		if (collision.rigidbody)
			collision.rigidbody.AddForce(Vector3.up * 15);
		
	}
}