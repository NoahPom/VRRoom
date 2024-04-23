using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotGem : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotX;
    public float rotY;
    public float rotZ;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotX, rotY, rotZ);
    }
}
