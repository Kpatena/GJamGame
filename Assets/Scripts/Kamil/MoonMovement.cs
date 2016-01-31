using UnityEngine;
using System.Collections;

public class MoonMovement : MonoBehaviour {

	public WaveSpawner wave;
	private int ghostsKilled;
	public GameObject[] waypoints;
	public GameObject moon;
	public float moveSpeed = 3f;
	private Vector3 targetLocation;
	private int waypointIndex = 0;

	
	// Update is called once per frame
	void Update () {
		if (wave.getComplete() && waypointIndex < 4) {
			moon.transform.position = Vector3.MoveTowards (moon.transform.position, waypoints [waypointIndex].transform.position, Time.deltaTime * moveSpeed);
			if (moon.transform.position == waypoints [waypointIndex].transform.position) {
				waypointIndex++;
				wave.setComplete (false);
			}
		}
	}
}
