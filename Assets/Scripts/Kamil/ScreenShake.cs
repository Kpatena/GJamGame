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
		originalPos = camera.transform.position;
	}

	// Update is called once per frame
	void FixedUpdate () {

		if (wave.getFinalComplete ()) {
			screenShakeTime -= Time.deltaTime;
			if (right) {
				Vector3 tmp = new Vector3(camera.transform.position.x, camera.transform.position.y, camera.transform.position.z);
				tmp.x = 0.5f;
				camera.transform.position = tmp;
				right = false;
			} else {
				Vector3 tmp = new Vector3(camera.transform.position.x, camera.transform.position.y, camera.transform.position.z);
				tmp.x = 0;
				camera.transform.position = tmp;
				right = true;
			}
		}

		if (screenShakeTime < 0 && wave.getFinalComplete ()) 
		{
			Vector3 tmp = new Vector3(camera.transform.position.x, camera.transform.position.y, camera.transform.position.z);
			tmp.x = 0;
			camera.transform.position = tmp;
			wave.setFinalComplete (false);
		}
	}
}
