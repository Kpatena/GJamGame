using UnityEngine;
using System.Collections;

public class Punch : MonoBehaviour {

    public GameObject enemy;
    public GameObject bloodParticle;
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
			Debug.Log("punchable");
			die();
		}
	}
}
