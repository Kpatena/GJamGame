using UnityEngine;
using System.Collections;

public class Punch : MonoBehaviour {

    public GameObject enemy;
    public GameObject bloodParticle;

    public void die()
    {
        Instantiate(bloodParticle, enemy.transform.position, enemy.transform.rotation);
        Destroy(enemy);
    }
}
