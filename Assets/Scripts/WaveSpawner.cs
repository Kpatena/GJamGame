using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour {

	public enum SpawnState { SPAWNING, WAITING, COUNTING};

	[System.Serializable]
	public class Wave {

		public string name;
		public Transform enemy;
		public int count;
		public float rate;

	}

	public static bool complete = false;
	public static bool finalWaveComplete = false;
	public GameObject bossPosition;
	public GameObject Boss;
	public GameObject Explosion;

	public Wave[] waves;
	private int nextWave = 0;

	public Transform[] spawnPoints;

	public float timeBetweenWaves = 5f;
	private float waveCountDown;

	private float searchCountdown = 1f;

	private SpawnState state = SpawnState.COUNTING;

	void Start() 
	{
		if (spawnPoints.Length == 0) 
		{
			Debug.Log ("No Spawn points referenced");
		}

		waveCountDown = timeBetweenWaves;

	}

	void Update() 
	{

		if (state == SpawnState.WAITING) 
		{
			// Check if enemy still alive
			if (!EnemyIsALive ()) {
				// Beging new round
				//Problem is here
				WaveCompleted(); 
		
			} else 
			{
				return;
			}				
		}

		if (waveCountDown <= 0) 
		{
				
			if (state != SpawnState.SPAWNING) 
			{

				// Start Spawning
				StartCoroutine( SpawnWave( waves[nextWave]));

			}
		} else 
		{
			waveCountDown -= Time.deltaTime;
		}
	}

	void WaveCompleted() 
	{
		Debug.Log("Wave Completed");
		complete = true;
		state = SpawnState.COUNTING;
		waveCountDown = timeBetweenWaves;

		if (nextWave + 1 > waves.Length - 1) {
			finalWaveComplete = true;
			nextWave = 0;
			spawnBoss ();
			Debug.Log ("All waves complete!");
		} else {
			nextWave++;
		}
	}

	bool EnemyIsALive()
	{
		searchCountdown -= Time.deltaTime;
		if (searchCountdown <= 0f) 
		{	
			searchCountdown = 1f;
			if (GameObject.FindGameObjectWithTag ("Enemy") == null) 
			{
				return false;
			}
		}
		return true;
	}

	IEnumerator SpawnWave(Wave _wave) 
	{

		state = SpawnState.SPAWNING;
		// Spawn
		for (int i = 0; i < _wave.count; i++) {

			SpawnEnemy (_wave.enemy);
			yield return new WaitForSeconds (1f / _wave.rate);

		}

		state = SpawnState.WAITING;

		yield break;

	}

	void SpawnEnemy (Transform _enemy)
	{
		// Spawn Enemy
		if (spawnPoints.Length == 0) 
		{
			Debug.Log ("Spawning enemy: " + _enemy.name);
		}

		Transform _sp = spawnPoints [Random.Range (0, spawnPoints.Length)];
		Instantiate(_enemy, _sp.transform.position, _sp.transform.rotation);

	}

	public void setComplete(bool c)
	{
		complete = c;
	}

	public bool getComplete()
	{
		return complete;
	}

	public bool getFinalComplete() 
	{
		return finalWaveComplete;
	}

	public void setFinalComplete(bool c)
	{
		finalWaveComplete = c;
	}

	public void spawnBoss()
	{
		Instantiate(Explosion, bossPosition.transform.position, bossPosition.transform.rotation);
		Instantiate(Boss, bossPosition.transform.position, bossPosition.transform.rotation);
	}
}
