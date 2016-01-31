using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour {

	public GameObject camera;
	public WaveSpawner wave;
	public float screenShakeTime = 10f;
	bool right = true;

	private Vector3 originalPos;

	void Start()
	{
		originalPos = camera.transform.localPosition;
	}

	// Update is called once per frame
	void FixedUpdate () {

		if (wave.getFinalComplete ()) {
			screenShakeTime -= Time.deltaTime;
			if (right) {

				Vector3 tmp = new Vector3(0.5f, camera.transform.localPosition.y, camera.transform.localPosition.z);
				tmp.x = 0.5f;
				camera.transform.position = tmp;
				right = false;
			} else {
				camera.transform.position = originalPos;
				right = true;
			}
		}

		if (screenShakeTime < 0 && wave.getFinalComplete ()) 
		{
			camera.transform.position = originalPos;
			wave.setFinalComplete (false);
		}

//		if (camera.transform.position.x != 0) {
//			Vector3 tmp = new Vector3(0, camera.transform.position.y, camera.transform.position.z);
//			camera.transform.position = tmp;
//		}
	}
}
