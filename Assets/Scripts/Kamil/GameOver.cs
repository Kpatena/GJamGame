using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	public string scene;

	public void ReloadScene() {
		Application.LoadLevel(scene);
	}
}
