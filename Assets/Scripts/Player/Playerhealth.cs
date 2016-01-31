using UnityEngine;
using System.Collections;

public class Playerhealth : MonoBehaviour {

	public bool hittable = true;
	public Heart1 heart1;
	public Heart2 heart2;
	public Heart3 heart3;

	public float currentInvincibilityTime;
	public float maxInvincibilityTime = 3f;

	public int maxHealth = 3;
	public int currentHealth;

	// Use this for initialization
	void Start () 
	{
		currentHealth = maxHealth;
		currentInvincibilityTime = maxInvincibilityTime;
	}

	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.tag == "Enemy") 
		{
			if (currentHealth > 0 && hittable) 
			{
				hittable = false;
				currentHealth--;
				deleteHeart (currentHealth);
				Debug.Log ("Hit! HP is " + currentHealth + " Hittable: " + hittable);
			}
		}
	}

	public void addHeart()
	{
	}

	public void deleteHeart(int hp)
	{
		switch (hp) 
		{
		case 2:
			heart3.deleteHeart ();
			break;

		case 1:
			heart2.deleteHeart ();
			break;
		
		case 0:
			heart1.deleteHeart ();
			break;
		}
	}
		

	void Update() 
	{
		if (!hittable) 
		{
			currentInvincibilityTime -= Time.deltaTime;
			Debug.Log ("Hittable: " + hittable);
		}

		if (currentInvincibilityTime <= 0)
		{
			hittable = true;
			currentInvincibilityTime = maxInvincibilityTime;
		}
	}
}
