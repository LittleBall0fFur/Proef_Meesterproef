using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour {
    private int health;
    private int currentHealth;
	// Use this for initialization
	void Start () {
        health = 3;
        currentHealth = health;
	}
	
	// Update is called once per frame
	void Update () {
        checkDeath();
	}

    public void loseHealth()
    {
        if(currentHealth > 0)currentHealth--;
    }

    private void checkDeath()
    {
        if(currentHealth <= 0)
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public int getHealth()
    {
        return currentHealth;
    }
}
