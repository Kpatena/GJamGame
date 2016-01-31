using UnityEngine;
using System.Collections;

public class Heart2 : MonoBehaviour {

	// Use this for initialization
	private SpriteRenderer rend;
	// Use this for initialization
	void Start () {
		rend = GetComponent<SpriteRenderer> ();
	}

	public void deleteHeart() 
	{
		rend.enabled = false;
	}
}
