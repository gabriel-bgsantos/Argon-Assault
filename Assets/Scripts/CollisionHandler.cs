using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        //collision affect one object physics, making it react phisically to the collision
        Debug.Log(this.name + "--Collided with--" + other.gameObject.name); // don't need the 'this' right here, but it's better to understando what's going on
    }

    private void OnTriggerEnter(Collider other) {
        //trigger doens't affect one object physics, but trigger something after colliding with other object
        Debug.Log($"{this.name} **Triggered by** {other.gameObject.name}"); // strings interpolation just to remember
    }
}

// you can't use both, or you collide using Rigidbody and its options (Is Kinematic or not)
// or you trigger using the static collider (Is Trigger or not)
