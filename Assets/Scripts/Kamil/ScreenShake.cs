using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour {

	public GameObject camera;
	public GameObject playerPosition;
	public GameObject bossPosition;
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

				Vector3 tmp = new Vector3(bossPosition.transform.position.x, bossPosition.transform.position.y, -10);
				tmp.x = bossPosition.transform.position.x + 0.15f;
				camera.transform.position = tmp;
				right = false;
			} else {
				Vector3 tmp = new Vector3(bossPosition.transform.position.x, bossPosition.transform.position.y, -10);
				tmp.x = bossPosition.transform.position.x - 0.15f;
				camera.transform.position = tmp;
				right = true;
			}
		}

		if (screenShakeTime < 0 && wave.getFinalComplete ()) 
		{
			Vector3 tmp = new Vector3(playerPosition.transform.position.x, playerPosition.transform.position.y, -10);
			camera.transform.position = tmp;
			wave.setFinalComplete (false);
		}

//		if (camera.transform.position.x != 0) {
//			Vector3 tmp = new Vector3(0, camera.transform.position.y, camera.transform.position.z);
//			camera.transform.position = tmp;
//		}
	}
}
