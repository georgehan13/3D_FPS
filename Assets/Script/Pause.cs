using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour 
{
	bool gamePause = false;

	public void OnPauseButtonClick()
	{
		gamePause = !gamePause;

		if(gamePause)
			Time.timeScale = 0.0f;
		else
			Time.timeScale = 1.0f;
	}

	float oldRealTimeSinceStartup = 0.0f;
	float realtimeDeltaTime = 0.0f;

	void Update()
	{
		realtimeDeltaTime = Time.realtimeSinceStartup - oldRealTimeSinceStartup;

		oldRealTimeSinceStartup = Time.realtimeSinceStartup;
	}

}
