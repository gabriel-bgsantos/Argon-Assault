using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    //Study the docs about Collision and Triggers
    //After that, rewatch lesson 88

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log("Collision Enter!");
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Trigger Enter!");
    }
}
