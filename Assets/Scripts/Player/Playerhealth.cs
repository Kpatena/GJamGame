using UnityEngine;
using System.Collections;

public class Playerhealth : MonoBehaviour {

	public GameObject bloodParticle;
	public GameObject player;
	public GameObject camera;
	public GameObject gameOver;

	public AudioSource hurtSound;
	public AudioSource fallSound;

	private bool flash = false;
	private bool flashOn = false;

	public bool hittable = true;
	public Heart1 heart1;
	public Heart2 heart2;
	public Heart3 heart3;

	public float currentInvincibilityTime;
	public float maxInvincibilityTime = 3f;

	public int maxHealth = 3;
	public int currentHealth;

	private SpriteRenderer rend;
	// Use this for initialization
	void Start () 
	{
		currentHealth = maxHealth;
		currentInvincibilityTime = maxInvincibilityTime;
		rend = GetComponent<SpriteRenderer> ();
		Time.timeScale = 1;
	}
	 
	//Collision with an enemy causes player to take damage and flash
	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "Fireball" || coll.gameObject.tag == "Boss") 
		{

			if (coll.gameObject.tag == "Fireball") {
				Destroy (coll.gameObject);
			}

			if (currentHealth > 0 && hittable) 
			{
				hurtSound.Play();
				hittable = false;
				currentHealth--;
				deleteHeart (currentHealth);
				flash = true;
				Debug.Log ("Hit! HP is " + currentHealth + " Hittable: " + hittable);
			} 
				
		}



	}
		
	//Health system add a heart back if you pick up health
	public void addHeart()
	{
	}


	//Destroy a heart when hit 
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
		

	//Times the invincibility times when hit and checks if hp is less than 0
	void Update() 
	{
		if (!hittable) 
		{
			currentInvincibilityTime -= Time.deltaTime;
			if (flash) 
			{
				if (flashOn) {
					Color tmp = rend.color;
					tmp.a = 0.5f;
					rend.color = tmp;
					flashOn = false;
				} else {
					Color tmp = rend.color;
					tmp.a = 1f;
					rend.color = tmp;
					flashOn = true;
				}
			}
		}

		if (currentInvincibilityTime <= 0)
		{
			hittable = true;
			flash = false;
			Color tmp = rend.color;
			tmp.a = 1f;
			rend.color = tmp;
			currentInvincibilityTime = maxInvincibilityTime;
		}

		if (currentHealth <= 0) 
		{
			Instantiate(bloodParticle, this.transform.position, this.transform.rotation);
			Instantiate(camera, new Vector3(this.transform.position.x, this.transform.position.y, -10), this.transform.rotation);
			Destroy (player);
			gameOver.SetActive (true);
			Time.timeScale = Time.timeScale == 0 ? 1 : 0;
		}
	}

	//when falling and hits the trigger kill player
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Fall")
		{
			fallSound.Play ();
			Instantiate(bloodParticle, this.transform.position, this.transform.rotation);
			Instantiate(camera, new Vector3(this.transform.position.x, this.transform.position.y, -10), this.transform.rotation);
			Destroy (player);
			gameOver.SetActive (true);
			Time.timeScale = Time.timeScale == 0 ? 1 : 0;
		}
			
	}
}
