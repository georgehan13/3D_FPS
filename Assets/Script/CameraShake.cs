using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
	Vector3 myLocalPosition = Vector3.zero;


	void Start ()
	{
		myLocalPosition = transform.localPosition;
	}

	public void PlayCameraShake()
	{
		StopAllCoroutines();
		StartCoroutine(CameraShakeProcess(1.0f, 0.2f));
	}

	IEnumerator CameraShakeProcess(float shakeTime, float shakeSense)
	{
		yield return null;
		float deltaTime = 0.0f;

		while( deltaTime < shakeTime)
		{
			deltaTime += Time.deltaTime;

			transform.localPosition = myLocalPosition;
			Vector3 pos = Vector3.zero;
			pos.x = Random.Range (-shakeSense, shakeSense);
			pos.y = Random.Range (-shakeSense, shakeSense);
			pos.z = Random.Range (-shakeSense, shakeSense);
			transform.localPosition += pos;

			yield return new WaitForEndOfFrame();
		}

		transform.localPosition = myLocalPosition;
	}
}


//코루틴은 꼭 스타트로 호출해야함,
//코루틴 반환형태
//yield return null; - 다음 프레임까지 대기
//yield return new WaitForEndOfFrame(); - 모든 그리기 연산 이후의 프레임 대기
//yield return new WaitForFixedUpdate(); - 다음 물리 프레임까지 대기


//코루틴(Coroutine) - 함수.주 스크립트 흐름 , 한번실행되고 사라짐. / 카메라 흔들기에 사용 
//	코루틴 반환값(IEnumerator) 한오브젝트당 코루틴은 한개씩 쓰는게 좋다.		
//		로컬포지션(LocalPosition) - 상대좌표
