using UnityEngine;
using System.Collections;
//거미 인공지능
public class SpiderScript : MonoBehaviour 
{
	//--▼거미 체력----
	int helathPoint = 5;
	//----------------------
	float attackStateMaxTime = 2.0f;
	//-----------------------------------------
	float stateTime = 0.0f;
	public float idleStateMaxTime = 2.0f; //2초
	//------------------------------------
	Transform target;

	PlayerState playerState; //0

	public float speed = 5.0f;
	public float rotationSpeed = 10.0f;
	public float attackableRange = 2.5f;

	CharacterController characterController;

	public GameObject explosionParticle = null;
	public GameObject deadObject = null;

	public int score = 10;

	void OnEnable()
	{
		InitSpider();
	}


	void Start()
	{
		target = GameObject.Find("Player").transform;

		playerState = target.GetComponent<PlayerState>(); //0

		characterController = GetComponent<CharacterController>();
	}
	//--------------------------------------------------------
	void Awake() // Awake-오브젝트를꺼도 호출됨,게임시작시 딱 한번만 호출됨.
	{
		InitSpider();
	}

	void InitSpider()
	{
		helathPoint = 5;
		stateTime = 0.0f;
		spiderState = SPIDERSTATE.IDLE;
		animation.Play ("iddle"); //idle 애니메이션을 플레이하라
	}

 enum SPIDERSTATE
	{
		NONE = -1,
		IDLE =0,
		MOVE,
		ATTACK,
		DAMAGE,
		DEAD
	}

	SPIDERSTATE spiderState = SPIDERSTATE.IDLE;

	//--▼거미와 포탄의 피격상태 조건에 대한 코드와 충돌정보 확인----
	void OnCollisionEnter( Collision collision)
	{
		if( spiderState == SPIDERSTATE.NONE ||
		   spiderState == SPIDERSTATE.DEAD )
			return;

		//Debug.Log ( collision.gameObject.name);
		if(collision.gameObject.name.Contains("Bomb") == false)
			return;
		spiderState = SPIDERSTATE.DAMAGE;
	}
/*
-----------▼태그로 호출-------------------------------
 void OnCollisionEnter( Collision collision)
	{
	   if(collision.gameObject.tag != "Bomb")
              return;
           spiderState = SPIDERSTATE.DAMAGE;
    }
-----------▼레이어로 호출------------------------------
 void OnCollisionEnter( Collision collision)
	{
	   int layerIndex = collision.gameObject.layer;
	   if(LayerMask.LayerToName(layerIndex) != "Bomb")
           return;
           spiderState = SPIDERSTATE.DAMAGE;
    }
*/

	//--------------------------------------------------------

	IEnumerator DeadProcess()
	{
		animation["death"].speed = 0.5f;
		animation.Play ("death");

		while(animation.isPlaying)
		{
			yield return new WaitForEndOfFrame();
		}

		yield return new WaitForSeconds(1.0f);

		GameObject explosionObj = Instantiate(explosionParticle) as GameObject;
		Vector3 explosionObjPos = transform.position;
		explosionObjPos.y = 0.6f;
		explosionObj.transform.position = explosionObjPos;

		yield return new WaitForSeconds(0.5f);

		GameObject deadObj = Instantiate(deadObject) as GameObject;
		Vector3 deadObjPos = transform.position;
		deadObjPos.y = 0.6f;
		deadObj.transform.position = deadObjPos;

		float rotationY = (float)Random.Range(-180, 180);
		deadObj.transform.eulerAngles = new Vector3(0.0f, rotationY, 0.0f);


		//Destroy(gameObject);
		gameObject.SetActive(false);
	}

	
	void Update()
	{	
		switch( spiderState )
		{
		case SPIDERSTATE.IDLE:
			{
			   stateTime += Time.deltaTime;
			   if(stateTime > idleStateMaxTime) //현재시간 > idleStateMaxTime(2초라고 위에선언)
			   {
				stateTime = 0.0f; //현재시간을 초기화 선언해줘야함
				spiderState = SPIDERSTATE.MOVE; // case SPIDERSTATE.MOVE 로 이동
			   }

			} 
			break;
		case SPIDERSTATE.MOVE:
		    {
			animation.Play ("walk");

			float distance = (target.position - transform.position).magnitude;
			if (distance<attackableRange)
			{
				spiderState = SPIDERSTATE.ATTACK;

				stateTime = attackStateMaxTime; //공격시간을 풀로만들고.
			}
			else
			{
				Vector3 dir = target.position - transform.position;
				dir.y = 0.0f; // y는 높이, 높이값을 0으로 만들어줌
				dir.Normalize(); // Normalize 일정한 간격으로 속도를 만들어줌.
				characterController.SimpleMove(dir*speed);

				Quaternion to = Quaternion.LookRotation (dir);
				transform.rotation = Quaternion.Lerp(transform.rotation,to,rotationSpeed*Time.deltaTime);

			}
			}
			break;
		case SPIDERSTATE.ATTACK:
			{
			stateTime += Time.deltaTime;
			if( stateTime > attackStateMaxTime )
			{
				stateTime = 0.0f;
				animation.Play("attack_Melee");
				animation.PlayQueued("iddle",QueueMode.CompleteOthers);

				playerState.DamageByEnemy(); //playerStat 안에 DamageByEnemy 호출

			}

			//--▼거미가 공격후 플레이어를 따라가서 공격----
			float distance =(target.position - transform.position).magnitude;
			if(distance > attackableRange)
			{
				spiderState = SPIDERSTATE.IDLE; //idle로해야 2초간 텀이 생김
			}
			}
			break;
		case SPIDERSTATE.DAMAGE:
		    {
			//--▼거미 체력----
			--helathPoint;

			animation["damage"].speed=0.5f; //기본숫자 1 , 0.5는 더 느리게 움직임
			animation.Play("damage"); //스피드 설정하고 플레이해야됨.
			animation.PlayQueued("iddle", QueueMode.CompleteOthers); //Queued= damage애니끝나고 iddle애니메이션이 차례대로나옴.

			stateTime=0.0f;
			spiderState=SPIDERSTATE.IDLE;

			if(helathPoint <= 0)
			  {
				spiderState=SPIDERSTATE.DEAD;
			  }
		    }
			break;
		case SPIDERSTATE.DEAD:
		    {
				//Destroy(gameObject); //Destroy(누구를없앨건지,없어질 시간)
				StartCoroutine("DeadProcess");
				spiderState = SPIDERSTATE.NONE;

				ScoreManager.Instance().myScore += score;

		    }
			break;
		}
	}
}



//유니티 광고 - 벙글, 유니티에즈?????
// awake(딱1번만 생성되는함수)
// OnEnable(꺼질때),OnDisable(켜질때)-(오브젝트를 껐다 켤때마다 호출되는함수)
// Start(씬이바뀔때 한번만 호출)
// Update 
//magnitude;(거리계산)
//Normalize(방향만 뽑아내기,정규화)
//SimpleMove(
//Lerp(보관 부드럽게해주는) /Quaternion(사원수 - 가상으로 세축을 한번에 회전하게하는것)
//transform.rotation = Quaternion.LerP *부드럽게 움직이게함* (transform.rotation.to.rotationSpeed*Time.deltaTime)*어디서부터 어디까지 

//Queued 차례로 (애니메이션)을 호출
//completeOthers 또는 playNow
//Contains 포함되있지않으면