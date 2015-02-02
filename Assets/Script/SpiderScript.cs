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

	void Update()
	{
		switch(spiderState)
		{
		case SPIDERSTATE.IDLE:
			{

			}
			break;
		case SPIDERSTATE.MOVE:
			{

			}
			break;
		case SPIDERSTATE.ATTACK:
			{

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
}
