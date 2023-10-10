using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float moveSpeed;
    public GameObject projectile;
    public float shootDelay;
    public float shootInterval;
    public GameObject spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = Random.Range(4f, 7f);
        shootDelay = Random.Range(0.5f, 1f);
        shootInterval = Random.Range(0.5f, 1.5f);
        InvokeRepeating("Shoot", shootDelay, shootInterval);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }

    private void Shoot()
    {
        Vector3 projectileSpawnPosition = new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z);
        Instantiate(projectile, projectileSpawnPosition, transform.rotation);
    }
}
