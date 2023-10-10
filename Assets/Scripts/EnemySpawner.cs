using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy;
    private float xRange;
    private float yRange;

    private float spawnDelayTop = 1f;
    private float spawnDelayBottom = 1f;
    private float spawnDelayLeft = 1f;
    private float spawnDelayRight = 1f;

    private float spawnIntervalTop;
    private float spawnIntervalBottom;
    private float spawnIntervalLeft;
    private float spawnIntervalRight;

    // Start is called before the first frame update
    void Start()
    {
        spawnIntervalTop = Random.Range(2f, 3f);
        spawnIntervalBottom = Random.Range(2f, 3f);
        spawnIntervalLeft = Random.Range(2f, 3f);
        spawnIntervalRight = Random.Range(2f, 3f);
        InvokeRepeating("SpawnEnemyTop", spawnDelayTop, spawnIntervalTop);
        InvokeRepeating("SpawnEnemyBottom", spawnDelayBottom, spawnIntervalBottom);
        InvokeRepeating("SpawnEnemyLeft", spawnDelayLeft, spawnIntervalLeft);
        InvokeRepeating("SpawnEnemyRight", spawnDelayRight, spawnIntervalRight);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnEnemyTop()
    {
        xRange = Random.Range(-8f, 8f);
        Quaternion topEnemyRotation = Quaternion.Euler(0, 0, Random.Range(150f, 210f));
        Instantiate(enemy, new Vector3(xRange, 6, 0), topEnemyRotation);
    }

    private void SpawnEnemyBottom()
    {
        xRange = Random.Range(-8f, 8f);
        Quaternion bottomEnemyRotation = Quaternion.Euler(0, 0, Random.Range(-30f, 30f));
        Instantiate(enemy, new Vector3(xRange, -6, 0), bottomEnemyRotation);
    }

    private void SpawnEnemyLeft()
    {
        yRange = Random.Range(-4f, 4f);
        Quaternion leftEnemyRotation = Quaternion.Euler(0, 0, Random.Range(-60f, -120f));
        Instantiate(enemy, new Vector3(-10, yRange, 0), leftEnemyRotation);
    }

    private void SpawnEnemyRight()
    {
        yRange = Random.Range(-4f, 4f);
        Quaternion rightEnemyRotation = Quaternion.Euler(0, 0, Random.Range(60f, 120f));
        Instantiate(enemy, new Vector3(10, yRange, 0), rightEnemyRotation);
    }
}
