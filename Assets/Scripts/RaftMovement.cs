using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftMovement : MonoBehaviour
{
    private float waveTimer;
    public float yOffset;
    public float yIntensity;
    public float ySpeed;

    void Start()
    {
        waveTimer = Random.Range(0, 40);
    }

    void Update()
    {
        waveTimer += Time.deltaTime;

        transform.position = new Vector3(transform.position.x, (Mathf.Sin(waveTimer * ySpeed) * yIntensity) + yOffset, transform.position.z);
    }
}
