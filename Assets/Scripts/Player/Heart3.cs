using UnityEngine;
using System.Collections;

public class Heart3 : MonoBehaviour {

//	public bool hp = true;
//	public float hpnum = 1f;


	private SpriteRenderer rend;
	// Use this for initialization
	void Start () {
		rend = GetComponent<SpriteRenderer> ();
//		if (hp) {
//			rend.enabled = true;
//		} else {
//			rend.enabled = false;
//		}
	}

	public void deleteHeart() 
	{
		rend.enabled = false;
	}
}
