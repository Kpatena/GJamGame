using UnityEngine;
using System.Collections;

public class Heart1 : MonoBehaviour {

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
