using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour 
{
	public Transform cameraTransform;

	public float moveSpeed = 10.0f;
	public float jumpSpeed = 10.0f;
	public float gravity = -20.0f;

	PlayerState playerState = null; //1 

	CharacterController characterController = null;
	float yVelocity = 0.0f;

	void Start ()
	{
		characterController = GetComponent<CharacterController>();

		playerState = GetComponent <PlayerState>(); //1
	
	}

	void Update ()
	{
		if(playerState.isDead)
			return; //1 죽을때 움직이지 않게.

		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		Vector3 moveDirection = new Vector3(x,0,z);
		moveDirection = cameraTransform.TransformDirection( moveDirection );
		moveDirection *= moveSpeed;

		if( Input.GetButtonDown("Jump"))
		{
			yVelocity = jumpSpeed;
		}

		yVelocity +=( gravity * Time.deltaTime);
		moveDirection.y = yVelocity;

		characterController.Move ( moveDirection * Time.deltaTime );
		if( characterController.collisionFlags == CollisionFlags.Below)
		{
			yVelocity = 0.0f;
		}
	} //End of Update
}
	