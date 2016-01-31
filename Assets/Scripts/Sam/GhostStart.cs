using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GhostStart : MonoBehaviour
{

    public GameObject enemy;
    public GameObject bloodParticle;
    public static int killed = 0;

    public void die()
    {
        killed++;
        Instantiate(bloodParticle, enemy.transform.position, enemy.transform.rotation);
        enemy.GetComponent<Renderer>().enabled = false;
        Debug.Log("Killed: " + killed);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKey(KeyCode.Space))
        {
            Debug.Log("punchable");
            Invoke("LaunchLevel", 0.5f);
            die();
        }
    }

    void LaunchLevel()
    {
        SceneManager.LoadScene("Put Scene Here");
    }
}
