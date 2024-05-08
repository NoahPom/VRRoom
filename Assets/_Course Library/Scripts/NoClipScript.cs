using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoClipScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform teleportLocation;
    public GameObject playerObject;
    public GameObject handModel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        print("Colliding");
        if (other.gameObject == handModel)
        {
            print("Colliding Hand");
            playerObject.transform.position = teleportLocation.transform.position;
        }
    }
}
