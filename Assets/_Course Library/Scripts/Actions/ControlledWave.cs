using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlledWave : MonoBehaviour
{
    private float waveTimer;
    public float xOffset;
    public float yOffset;
    public float zOffset;
    public float xIntensity;
    public float yIntensity;
    public float zIntensity;
    public float xSpeed;
    public float ySpeed;
    public float zSpeed;

    void Start()
    {
        waveTimer = Random.Range(0, 40);
    }

    void Update()
    {
        waveTimer += Time.deltaTime;

        transform.eulerAngles = new Vector3((Mathf.Sin(waveTimer * xSpeed) * xIntensity) + xOffset, (Mathf.Sin(waveTimer * ySpeed) * yIntensity) + yOffset, (Mathf.Sin(waveTimer * zSpeed) * zIntensity) + zOffset);
    }
}
