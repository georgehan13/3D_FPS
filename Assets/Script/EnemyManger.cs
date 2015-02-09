﻿using UnityEngine;
using System.Collections;

public class EnemyManger : MonoBehaviour
{
//--▼거미 클론생성---------------------------------
	public GameObject enemy;
	public float spawnTime = 2.0f;

	float deltaSpawnTime = 0.0f;
//--▼거미 클론갯수---------------------------------------
	int spawnCnt = 0;
	public int maxSpawnCnt = 10;


	void Update () 
	{
		if(spawnCnt >= maxSpawnCnt )
			return;

		deltaSpawnTime += Time.deltaTime;

		if(deltaSpawnTime > spawnTime)
		{
			deltaSpawnTime = 0.0f;

			GameObject enemyObj =  Instantiate(enemy) as GameObject;
			float x = Random.Range(-20.0f, 20.0f);
			enemyObj.transform.position = new Vector3(x, 0.1f, 20.0f);

			enemyObj.name = "Enemy_" + spawnCnt;
			++spawnCnt;
		}
	}
}
