using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;

    private void OnParticleCollision(GameObject other) {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity, transform.parent = parent);
        //vfx.transform.parent = parent;
        Destroy(gameObject);
    }
}
