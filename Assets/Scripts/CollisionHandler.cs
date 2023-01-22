using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delayTime = 1f;
    //[SerializeField] ParticleSystem crashVFX;
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;
    
    
    private void OnTriggerEnter(Collider other) {
        //trigger doens't affect one object physics, but trigger something after colliding with other object
        Debug.Log($"{this.name} **Triggered by** {other.gameObject.name}"); // strings interpolation just to remember
        CrashSequence(); // do not need 'isTransitioning' because will destroy gameObject after collision
    }

    private void CrashSequence()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity, transform.parent = parent);
        //dont use the code below because the player ship does not have a meshRenderer
            //crashVFX.Play();
            //GetComponent<PlayerControls>().enabled = false;
            //GetComponent<MeshRenderer>().enabled = false;
            //GetComponent<BoxCollider>().enabled = false;
        Destroy(gameObject);
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
