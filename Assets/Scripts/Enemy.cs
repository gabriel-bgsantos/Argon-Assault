using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;

    ScoreBoard scoreBoard;
    [SerializeField] int scorePerHit = 0;
    float nextShot;
    float timeCooldown = 0.2f;

    private void Start() 
    {
        scoreBoard = FindObjectOfType<ScoreBoard>(); 
    }

    private void OnParticleCollision(GameObject other) {
        ProcessHit();
        KillEnemy();
    }

    private void ProcessHit()
    {
        if(Time.time > nextShot) { //this if for cooldown is to prevent the bug of increasing the score 2 times for the same enemy (2 lasers hitting almost at the same time)
            scoreBoard.ScoreManager(scorePerHit);
            nextShot = Time.time + timeCooldown;
        }
    }

    private void KillEnemy()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity, transform.parent = parent);
        //vfx.transform.parent = parent;
        Destroy(gameObject);
    }
}
