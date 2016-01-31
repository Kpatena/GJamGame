using UnityEngine;
using System.Collections;

public class Punch : MonoBehaviour {

    public GameObject enemy;
    public GameObject bloodParticle;
	private AudioSource threatSound;
	private AudioSource splatSound;
	public static int killed = 0;

    public void die()
    {
		killed++;
        Instantiate(bloodParticle, enemy.transform.position, enemy.transform.rotation);
        Destroy(enemy);
		Debug.Log ("Killed: " + killed);
    }

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player" && Input.GetKey(KeyCode.Space))
		{
			splatSound = GameObject.FindGameObjectWithTag ("SplatSound").GetComponentInParent<AudioSource>();
			splatSound.Play ();
			Debug.Log("punchable");

			if (this.gameObject.tag == "Boss") {
				threatSound = GameObject.FindGameObjectWithTag ("ThreatSound").GetComponentInParent<AudioSource>();
				threatSound.Play ();
			}
			die();
		}
	}
}
