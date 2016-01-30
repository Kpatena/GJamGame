using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public float moveSpeed = 0.1f;

	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);

	}
}
