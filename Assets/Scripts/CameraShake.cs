using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float mag;
    GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (player != null)
        {
            StartCoroutine(Shake(mag));
        }
    }
    public IEnumerator Shake(float magnitude)
    {
        Vector3 originalPos = new Vector3(0, 0, -10);
        while (Input.GetKey(KeyCode.Space))
        {
            float xOffset = Random.Range(-0.5f, 0.5f) * magnitude;
            float yOffset = Random.Range(-0.5f, 0.5f) * magnitude;
            transform.position = new Vector3(xOffset, yOffset, originalPos.z);
            yield return null;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            transform.position = originalPos;
        }
    }
}
