using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ProjectileSpawner : MonoBehaviour
{
    private GameObject projectile;
    private GameObject[] projectiles;
    private GameObject core;
    private GameObject leftPos;
    private GameObject rightPos;
    private List<GameObject> spawnLocations = new List<GameObject>();
    [SerializeField]
    private Sprite sprite;
    private int index;
    private float timer;
    private float thrust;
    private float velocity;
    private float distance;
    private Vector3 spawnPosition;
    [SerializeField]
    private Vector3 outOfScreen;
    private bool hasVelocity;
    private bool hitcollision;
    private HealthSystem healthSystem;
    // Use this for initialization
    void Start()
    {
        core = GameObject.Find("Core");
        leftPos = GameObject.Find("LT");
        rightPos = GameObject.Find("RT");
        healthSystem = GameObject.Find("Player").GetComponent<HealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        spawnProjectiles();
        projectiles = GameObject.FindGameObjectsWithTag("Projectile");
        movement();
    }

    private void spawnProjectiles()
    {
        if (timer > 3f)
        {
            projectile = new GameObject();
            projectile.AddComponent<SpriteRenderer>();
            projectile.AddComponent<BoxCollider2D>();
            projectile.GetComponent<BoxCollider2D>().size = new Vector2(0.4f, 0.4f);
            projectile.AddComponent<Rigidbody2D>();
            projectile.GetComponent<Rigidbody2D>().gravityScale = -2.3f;
            projectile.name = "Projectile";
            projectile.tag = "Projectile";
            projectile.transform.position = selectSpawnPoint();
            projectile.GetComponent<SpriteRenderer>().sprite = sprite;
            timer = 0;
            hasVelocity = false;
        }
    }
    private void movement()
    {
        foreach(GameObject projectile in projectiles)
        {
            //set rotation
            projectile.GetComponent<Rigidbody2D>().AddForce(projectile.transform.forward * -0.03f);
            projectile.GetComponent<Rigidbody2D>().gravityScale += 0.06f;
            getRandomVelocity();
            hasVelocity = true;
            if (spawnPosition == leftPos.transform.position) projectile.GetComponent<Rigidbody2D>().AddForce(projectile.transform.right / velocity);
            if (spawnPosition == rightPos.transform.position) projectile.GetComponent<Rigidbody2D>().AddForce(projectile.transform.right / -velocity);
            collision();
        }
    }

    private Vector2 selectSpawnPoint()
    {
        spawnLocations.Add(leftPos);
        spawnLocations.Add(rightPos);
        index = UnityEngine.Random.Range(0, spawnLocations.Count);
        spawnPosition = spawnLocations[index].transform.position;
        return spawnPosition;
    }

    private float getRandomVelocity()
    {
        if (!hasVelocity)
        {
            velocity = UnityEngine.Random.Range(0.14f, 0.19f);
        }
        return velocity;
    }

    private void collision()
    {
        foreach(GameObject projectile in projectiles)
        {
            distance = Vector2.Distance(core.transform.position, projectile.transform.position);
            if (distance <= 1)
            {
                Destroy(projectile);
                if (SceneManager.GetActiveScene().name == "Daan") healthSystem.loseHealth();
            }
            if(projectile.transform.position.y <  outOfScreen.y)
            {
                if (SceneManager.GetActiveScene().name == "Level2") healthSystem.loseHealth();
                Destroy(projectile);
            }
        }
    }
}
