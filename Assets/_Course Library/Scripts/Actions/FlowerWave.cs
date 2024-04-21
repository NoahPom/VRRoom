using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerWave : MonoBehaviour
{
    private float waveTimer;
    private float edit1;
    private float edit2;
    private float edit3;
    private float edit4;
    private float edit5;
    private float edit6;
    public float intensity;
    public float speed;

    void Start()
    {
        waveTimer = Random.Range(0, 40);

        edit1 = Random.Range(1 * intensity, 5 * intensity);
        edit2 = Random.Range(3 * intensity, 15 * intensity);
        edit3 = Random.Range(0.5f * intensity, 2.5f * intensity);
        edit4 = Random.Range(1.5f * intensity, 7.5f * intensity);
        edit1 = Random.Range(1 * intensity, 5 * intensity);
        edit6 = Random.Range(3 * intensity, 15 * intensity);
    }

    void Update()
    {
        waveTimer += 0.3f * speed * Time.deltaTime;

        transform.eulerAngles = new Vector3(Mathf.Sin(waveTimer * edit1) * edit2, Mathf.Sin(waveTimer * edit3) * edit4, Mathf.Sin(waveTimer * edit5) * edit6);
    }
}
