using UnityEngine;
using System.Collections;

public class KeepRotation : MonoBehaviour {

	Vector2 originalPos;
	void Awake()
	{
		originalPos = transform.position;
	}
	void FixedUpdate()
	{
		transform.position = originalPos;
	}
}
