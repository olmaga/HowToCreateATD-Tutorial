using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float spawnDistance = 0.4f;
    public Text waveCountdownText;
    public float timeBetweenWaves = 5f;

    private float countdown = 2f;
    private int wave = 1;

    void Update () {
        if (countdown <= 0f) {
            StartCoroutine(SpawnWave ());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;

        waveCountdownText.text = "Next Wave in " + Mathf.Ceil(countdown).ToString() + " seconds";
    }

    IEnumerator SpawnWave () {
        Debug.Log ("Wave incoming");
        for (int i = 0; i < wave; i++) {
            SpawnEnemy ();
            yield return new WaitForSeconds(spawnDistance);
        }
        wave++;
    }

    void SpawnEnemy () {
        Instantiate (enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}