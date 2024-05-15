using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMove : MonoBehaviour
{
    public float moveSpeed;
    public float xReset;

    void Update()
    {
        transform.Translate(new Vector3(moveSpeed * -Time.deltaTime, 0, 0));

        if (transform.position.x < xReset)
        {
            transform.position = new Vector3(transform.position.x + 240, transform.position.y, transform.position.z);
        }
    }
}
