using UnityEngine;
using System.Collections;

public class Demon : MonoBehaviour {

    public Rigidbody2D fireball;
    public float maxSpeed;
	public GameObject[] waypoints;
	public float moveSpeed = 5f;
	public float waitTime = 5f;

	//Boss Hp
	private int hp = 3;


	private bool startMove = false;
	private bool moveNormally = false;
	private int waypointIndex = 0;

	// Use this for initialization
	void Start () {
        InvokeRepeating("LaunchFireballs", 5, 1);
		waypoints[0] = GameObject.FindGameObjectWithTag("BossWaypoint1");
		waypoints[1] = GameObject.FindGameObjectWithTag("BossWaypoint2");
	}

    void LaunchFireballs()
    {
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
    }

	void Update() 
	{
		if (startMove == false)
		{
			waitTime -= Time.deltaTime;
		}

		if (waitTime < 0) 
		{
			startMove = true;
		}
		//transform.position = Vector3.MoveTowards (transform.position, waypoints [waypointIndex].transform.position, Time.deltaTime * moveSpeed);
		if (startMove) 
		{
			transform.position = Vector3.MoveTowards (transform.position, waypoints [waypointIndex].transform.position, Time.deltaTime * moveSpeed);
		}

		if (transform.position == waypoints [waypointIndex].transform.position) {
			startMove = false;
			moveNormally = true;
			waypointIndex = 1;
		}

		if (transform.position == waypoints [waypointIndex].transform.position) {
			startMove = false;
			moveNormally = true;
			waypointIndex = 0;
		}

		if (moveNormally) 
		{
			transform.position = Vector3.MoveTowards (transform.position, waypoints [waypointIndex].transform.position, Time.deltaTime * moveSpeed);
		}
	}
}
