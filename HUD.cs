using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour {
    private GameObject health;
    private int currentHealth;
    private int score;
    private float timer;
    // Use this for initialization
    void Start () {
        health = GameObject.Find("Health");
        score = 0;
        timer = 0f;
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        healthGui();
    }

    private void healthGui()
    {
        currentHealth = GameObject.Find("Player").GetComponent<HealthSystem>().getHealth();
        if(health != null)health.GetComponent<Text>().text = "Levens: " + currentHealth + "       Punten: " + score /**+ "       Time: " + timer*/;
    }

    public void addScore(int i)
    {
        score = score + i;
    }

    public int getScore()
    {
        return score;
    }
}
