using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalThrow = Input.GetAxis("Horizontal"); //remember to store it on a variable if the string is used many times (prevent from typing error)
        Debug.Log(horizontalThrow);

        float verticalThrow = Input.GetAxis("Vertical");
        Debug.Log(verticalThrow);
    }
}
