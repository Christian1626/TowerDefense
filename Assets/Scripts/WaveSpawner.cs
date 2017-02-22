using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public static int EnemiesAlive;
    public Wave[] waves;

    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    //public float timeBetweenEnemies= 0.5f;
    private float countDown = 2f;
    private int waveIndex = 0;

    public Text waveCountdownText;
	
	// Update is called once per frame
	void Update () {
        //si des ennemies sont tjr present
        if (EnemiesAlive > 0)
            return;

        //nouvelle wave
		if(countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
            return;
        }
        countDown -= Time.deltaTime;
        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}",countDown);

    }

    IEnumerator SpawnWave()
    {
        
        PlayerStats.Waves = waveIndex;

        Wave wave = waves[waveIndex];
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f/wave.rate);
        }

        waveIndex++;
        Debug.Log("Wave Level:"+waveIndex);

        if(waveIndex == waves.Length)
        {
            Debug.Log("WON");
            this.enabled = false;
        }
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position,spawnPoint.rotation);
        EnemiesAlive++;
    }
}
