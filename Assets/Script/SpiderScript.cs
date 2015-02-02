using UnityEngine;
using System.Collections;

public class SpiderScript : MonoBehaviour 
{

	enum SPIDERSTATE
	{
		IDLE = 0,
		MOVE,
		ATTACK,
		DAMAGE,
		DEAD,
	}

	SPIDERSTATE spiderState = SPIDERSTATE.IDLE;

	
	float stateTime = 0.0f;
	public float idleStateMaxTime = 2.0f;

	Transform target;

	public float speed = 5.0f;
	public float rotationSpeed = 10.0f;
	public float attackableRange = 2.5f;

	CharacterController characterController;

	float attackStateMaxTime = 2.0f;


	void InitSpider()
	{
		spiderState = SPIDERSTATE.IDLE;
		animation.Play ("iddle");
	}
	

	void Awake()
	{
		InitSpider();
	}


	void Start()
	{
		target = GameObject.Find ("Player").transform;
		characterController = GetComponent<CharacterController>();
	}



	void Update()
	{
		switch(spiderState)
		{
		case SPIDERSTATE.IDLE:
			{
				stateTime += Time.deltaTime;
				if(stateTime > idleStateMaxTime)
				{
				 	stateTime = 0.0f;
					spiderState = SPIDERSTATE.MOVE;
				}

			}
			break;

			case SPIDERSTATE.MOVE:
			{
				animation.Play ("walk");

				float distance = (target.position - transform.position).magnitude;

				if(distance<attackableRange)
				{
					spiderState = SPIDERSTATE.ATTACK;

					stateTime = attackStateMaxTime; // come close and no attack 
				}
				else
				{
					Vector3 dir = target.position - transform.position;
					dir.y = 0.0f;
					dir.Normalize();
					characterController.SimpleMove(dir*speed); // simpleMove - no Y move

					transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), rotationSpeed * Time.deltaTime);
				}

			}
			break;

		case SPIDERSTATE.ATTACK:
			{
				stateTime += Time.deltaTime;
				if (stateTime > attackStateMaxTime)
				{
					stateTime = 0.0f;
					animation.Play ("attack_Melee");
					animation.PlayQueued("iddle", QueueMode.CompleteOthers);
				}

				float distance = (target.position - transform.position).magnitude;
				if(distance > attackableRange)
				{
					spiderState = SPIDERSTATE.IDLE;
				}

			}
			break;
		case SPIDERSTATE.DAMAGE:
			{
				
			}
			break;
		case SPIDERSTATE.DEAD:
			{

			}
			break;


		}
	}


	void OnCollisionEnter(Collision collision)
	{
		Debug.Log (collision.gameObject.name);
		if(collision.gameObject.name.Contains("Bomb") == false)
			return;

		spiderState = SPIDERSTATE.DAMAGE;
	}



}
