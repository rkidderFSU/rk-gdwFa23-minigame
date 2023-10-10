using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private float verticalInput;
    private float horizontalInput;
    private float xRange = 8f;
    private float yRange = 4f;
    public GameObject projectile;
    public GameObject spawnPoint;
    public GameObject laser;
    private bool toggleLaser;
    // public float turnSmoothTime = 0.1f;
    // private float turnSmoothVelocity;

    // Start is called before the first frame update
    void Start()
    {
        toggleLaser = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (toggleLaser == false)
        {
            Move();
            Shoot();
        }
        LookAtMouse();
        KeepInBounds();
        FireLaser();
    }

    private void Move()
    {
        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0).normalized;
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);

        // Rotate to face direction the player is moving in ((OLD CODE))
        /* if (direction.magnitude >= 0.1f)
         {
             float targetAngle = Mathf.Atan2(-direction.x, direction.y) * Mathf.Rad2Deg;
             float angle = Mathf.SmoothDampAngle(transform.eulerAngles.z, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
             transform.rotation = Quaternion.Euler(0f, 0f, angle);
             transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
         } */
    }

    private void LookAtMouse()
    {
        var direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }


    private void KeepInBounds()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector2(-xRange, transform.position.y);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector2(xRange, transform.position.y);
        }
        if (transform.position.y < -yRange)
        {
            transform.position = new Vector2(transform.position.x, -yRange);
        }
        if (transform.position.y > yRange)
        {
            transform.position = new Vector2(transform.position.x, yRange);
        }
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(projectile, spawnPoint.transform.position, transform.rotation);
        }
    }

    private void FireLaser()
    {
        if (toggleLaser == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                toggleLaser = true;
                Instantiate(laser, spawnPoint.transform.position, transform.rotation);
            }
        }
        else if (toggleLaser == true)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                toggleLaser = false;
            }
        }
    }
}
