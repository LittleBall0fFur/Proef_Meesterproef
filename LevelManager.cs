using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour{
    private float timer;
    private int level = 1;
    private HUD hud;
    private GameObject screen1;
    private GameObject screen2;
    private bool added;
    private bool scoreAdded;

	void Start () {
        //Find GameObjects scripts
        hud = GameObject.Find("Canvas").GetComponent<HUD>();
        //Find GameObjects in scene
        screen1 = GameObject.Find("ScoreScreen1");
        screen2 = GameObject.Find("ScoreScreen2");
    }
	
	void Update () {
        progressScreen();
        nextLevel();
        showScreen();
        if (SceneManager.GetActiveScene().name == "Level2" && !added)
        {
            hud.addScore(200);
            added = true;
        }
    }
    /**
        Start the timer when Score screen is visible
        After 5 seconds load the next scene
        Reset timer
    */
    private void progressScreen()
    {
        if (SceneManager.GetActiveScene().name == "ScoreScreen" || SceneManager.GetActiveScene().name == "ScoreScreen2") timer += Time.deltaTime;//If the score screen is visible start timer
        if (SceneManager.GetActiveScene().name == "ScoreScreen" && timer >= 7 || SceneManager.GetActiveScene().name == "ScoreScreen2" && timer >= 7)//load after 5 seconds level 2
        {
            if(level == 1)SceneManager.LoadScene("Level2");
            if (SceneManager.GetActiveScene().name == "ScoreScreen2") SceneManager.LoadScene("Menu");
        }
    }
    /**
        Check if the level is completed by score
        Check if the loaded level is correct
        Load the score screen
    */
    private void nextLevel()
    {
        if (hud.getScore() >= 200 && SceneManager.GetActiveScene().name == "Daan")
        {
            level = 2;
            if (SceneManager.GetActiveScene().name != "ScoreScreen") SceneManager.LoadScene("ScoreScreen");
        }
        if(hud.getScore() >= 400 && SceneManager.GetActiveScene().name == "Level2" || hud.getScore() >= 400 && SceneManager.GetActiveScene().name == "ScoreScreen2")
        {
            if (SceneManager.GetActiveScene().name != "ScoreScreen2") SceneManager.LoadScene("ScoreScreen2");
            level = 2;
        }
    }

    /**
      Show the correct screen on level 
    */
    private void showScreen()
    {
        if (level == 1 && SceneManager.GetActiveScene().name == "ScoreScreen")
        {
            if(screen2 != null)Destroy(screen2);
        }
        if (level == 2 && SceneManager.GetActiveScene().name == "ScoreScreen")
        {
            if (!scoreAdded) {
                hud.addScore(400);
                scoreAdded = true;
            }
           if(screen1 != null) Destroy(screen1);
        }
    }
}
