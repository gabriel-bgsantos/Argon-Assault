using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] int health = 0;
    [SerializeField] int scorePerHit = 0;

    ScoreBoard scoreBoard;
    GameObject parentGameObject;
    
    float nextScore;
    float timeCooldown = 0.2f;

    private void Start() 
    {
        scoreBoard = FindObjectOfType<ScoreBoard>(); // using this cause it searches all the project, while GetComponent only searches in the gameObject it is called
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
    }

    private void Update() {
        GetComponent<MeshRenderer>().material.color = Color.white;
    }

    private void OnParticleCollision(GameObject other) {
        //ProcessHit(); let it here and remove from KillEnemy() if you want to score by hit, not by kill
        GetComponent<MeshRenderer>().material.color = Color.red;
        KillEnemy();
    }

    private void KillEnemy()
    {
        health--;
        if(health < 1){
            GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity, transform.parent = parentGameObject.transform);
            //fx.transform.parent = parent;
            Destroy(gameObject);
            ProcessHit();
        }
    }

    private void ProcessHit()
    {
        if(Time.time > nextScore) { //this if for cooldown is to prevent the bug of increasing the score 2 times for the same enemy (2 lasers hitting almost at the same time) - in case of score by hit
            scoreBoard.ScoreManager(scorePerHit);
            nextScore = Time.time + timeCooldown;
        }
    }
}
