using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AdvancedEnemyScript : MonoBehaviour
{

    public float moveSpeed = 6f;
    public GameObject projectile;
    public GameObject player;
    public float shootDelay = 1f;
    private float shootInterval;
    public GameObject spawnPoint;
    private Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        shootInterval = Random.Range(1, 2);
        InvokeRepeating("Shoot", shootDelay, shootInterval);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        LookAtPlayer();
    }

    private void Move()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }

    private void LookAtPlayer()
    {
        transform.LookAt(player.transform.position);
    }

    private void Shoot()
    {
        spawnPosition = new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z);
        Instantiate(projectile, spawnPosition, spawnPoint.transform.rotation);
    }
}
