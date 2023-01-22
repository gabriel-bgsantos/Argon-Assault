using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delayTime = 1f;
    [SerializeField] ParticleSystem crashVFX;
    
    bool isTransitioning = false;

    private void OnTriggerEnter(Collider other) {
        //trigger doens't affect one object physics, but trigger something after colliding with other object
        Debug.Log($"{this.name} **Triggered by** {other.gameObject.name}"); // strings interpolation just to remember
        if (isTransitioning) {
            return;
        }
        else {
            CrashSequence();
        }
    }

    private void CrashSequence()
    {
        isTransitioning = true;
        crashVFX.Play();
        GetComponent<PlayerControls>().enabled = false;
        //GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        Invoke("ReloadScene", delayTime);

    }

    private void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; //getting scene index number
        SceneManager.LoadScene(currentSceneIndex);
    }

}

// below, tips about the object that WILL COLLIDE with the 'MAIN object' that will definitelly have a Rigidbody:
// you can't use both, or you collide using Rigidbody and its options (Is Kinematic or not)
// or you trigger using the static collider (Is Trigger or not)
