using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMove : MonoBehaviour
{
    public float moveSpeed;

    void Update()
    {
        transform.Translate(new Vector3(moveSpeed * -Time.deltaTime, 0, 0));

        if (transform.position.x < -700)
        {
            transform.position = new Vector3(transform.position.x + 240, transform.position.y, transform.position.z);
        }
    }
}
