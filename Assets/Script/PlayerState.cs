using UnityEngine;
using System.Collections;
using UnityEngine.UI; //<--추가

public class PlayerState : MonoBehaviour 
{
	public int healthPoint = 5;
	public Text textUi; //<--using UnityEngine.UI; 위에 추가해서 짧게 쓸수있음

	public Text scoreUi;

	public bool isDead = false; //죽었는지 판단

	CameraShake cameraShake = null; //03

	void Start()
	{
		cameraShake = GetComponentInChildren<CameraShake>(); //03
	}

	void Update()
	{
		if(isDead == false)
			textUi.text = "My Health : " +healthPoint;
		else
			textUi.text = "Game Over";

		int myScore = ScoreManager.Instance().myScore;
		int bestScore = ScoreManager.Instance().bestScore;
		scoreUi.text = "Best Score :"+ bestScore + "\n" + "Score :" + myScore;

	}
	//--▼데미지 받으면 체력이 1씩깎임--------------
	public void DamageByEnemy()
	{
		if(isDead)
			return;

		--healthPoint;
		//--▼죽었는지 판단--------------

		cameraShake.PlayCameraShake(); //03

		if( healthPoint <= 0)
			isDead = true;  
	}

}
