using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopScript : MonoBehaviour
{
    // Start is called before the first frame update
    private float height;
    public Transform PlayerTrans;
    public float activeDistance;
    public float activeHeight;
    public float inactiveHeight;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = new Vector3(transform.position.x, height, transform.position.z);
        if (Vector3.Distance(transform.position, PlayerTrans.transform.position) < activeDistance)
        {
            print("YEEES");
            height = activeHeight;
        }
        else
        {
            height = inactiveHeight;
        }
        Vector3 _currentVelocity = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition , ref _currentVelocity, 0.25f);
    }
}
