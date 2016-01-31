using UnityEngine;
using System.Collections;

public class Demon : MonoBehaviour {

    public Rigidbody2D fireball;
    public GameObject player;
    public float maxSpeed;

	// Use this for initialization
	void Start () {
        InvokeRepeating("LaunchFireballs", 1, 1);
	}

    void LaunchFireballs()
    {
        //Rigidbody2D instance1 = Instantiate(fireball, new Vector3(transform.position.x, transform.position.y, 10), Quaternion.LookRotation(player.transform.position - transform.position, Vector3.up) * Quaternion.Euler(0f, 0f, -10f)) as Rigidbody2D;
        //Rigidbody2D instance2 = Instantiate(fireball, transform.position, Quaternion.LookRotation(player.transform.position - transform.position, Vector3.up) * Quaternion.Euler(0f, 0f, 0f)) as Rigidbody2D;
        //Rigidbody2D instance3 = Instantiate(fireball, transform.position, Quaternion.LookRotation(player.transform.position - transform.position, Vector3.up) * Quaternion.Euler(0f, 0f, 10f)) as Rigidbody2D;
        //instance1.velocity = new Vector3(maxSpeed, -10, 0);
        //instance2.velocity = new Vector3(maxSpeed, -10, 0);
        //instance3.velocity = new Vector3(maxSpeed, -10, 0);
        Rigidbody2D instance1 = Instantiate(fireball, new Vector3(transform.position.x, transform.position.y, 10), Quaternion.Euler(0f, 0f, 0f)) as Rigidbody2D;
        instance1.velocity = new Vector3(0, maxSpeed, 0);
        Rigidbody2D instance2 = Instantiate(fireball, new Vector3(transform.position.x, transform.position.y, 10), Quaternion.Euler(0f, 0f, 0f)) as Rigidbody2D;
        instance2.velocity = new Vector3(3, maxSpeed, 0);
        Rigidbody2D instance3 = Instantiate(fireball, new Vector3(transform.position.x, transform.position.y, 10), Quaternion.Euler(0f, 0f, 0f)) as Rigidbody2D;
        instance3.velocity = new Vector3(-3, maxSpeed, 0);
        Rigidbody2D instance4 = Instantiate(fireball, new Vector3(transform.position.x, transform.position.y, 10), Quaternion.Euler(0f, 0f, 0f)) as Rigidbody2D;
        instance4.velocity = new Vector3(5, maxSpeed, 0);
        Rigidbody2D instance5 = Instantiate(fireball, new Vector3(transform.position.x, transform.position.y, 10), Quaternion.Euler(0f, 0f, 0f)) as Rigidbody2D;
        instance5.velocity = new Vector3(-5, maxSpeed, 0);
        //Rigidbody2D instance1 = Instantiate(fireball, new Vector3(transform.position.x, transform.position.y, 10), new Quaternion(0, 0, 1, 0)) as Rigidbody2D;
        //instance1.velocity = new Vector3(maxSpeed, -10, 0);
        //Physics2D.IgnoreCollision(instance.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        //Rigidbody2D instance = Instantiate(fireball);
        //GameObject instance = Instantiate(fireball, new Vector2(demon.transform.position.x, demon.transform.position.y), transform.rotation) as GameObject;
        //instance.GetComponent<Rigidbody2D>().velocity = new Vector3(5, 5, 5);
    }
}
