using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuScript : MonoBehaviour
{

    public GameObject quitMenu;
    public Button startText;
    public Button exitText;
    public Button creditsText;
    public GameObject creditsMenu;
    public GameObject tutorialScreen;
    public GameObject loadingScreen;

    public Button yes;
    public Button no;
    public Button back;
    public Button back2;

    private float timer;
    private bool loading;

    void Start()
    {
        quitMenu = GameObject.Find("ExitScreen");
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        quitMenu.SetActive(false);
        creditsMenu.SetActive(false);
        tutorialScreen.SetActive(false);
        yes.enabled = false;
        no.enabled = false;
        back.enabled = false;
        back2.enabled = false;
        loadingScreen.SetActive(false);
    }

    void Update()
    {
        
        if(loading) timer += Time.deltaTime;
        if (timer >= 3)
        {
            SceneManager.LoadScene("Daan");
        }
    }

    public void ExitPress()
    {
        quitMenu.SetActive(true);
        yes.enabled = true;
        no.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;
    }

    public void CreditsPress()
    {
        quitMenu.SetActive(false);
        startText.enabled = false;
        exitText.enabled = false;
        creditsMenu.SetActive(true);
        back.enabled = true;
    }

    public void NoPress()
    {
        quitMenu.SetActive(false);
        startText.enabled = true;
        exitText.enabled = true;
        creditsMenu.SetActive(false);
        tutorialScreen.SetActive(false);
        yes.enabled = false;
        no.enabled = false;
        back.enabled = false;
        back2.enabled = false;
    }

    public void tutorialPress()
    {
        tutorialScreen.SetActive(true);
        quitMenu.SetActive(false);
        startText.enabled = false;
        exitText.enabled = false;
        creditsMenu.SetActive(false);
        back2.enabled = true;
    }

    public void StartLvl()
    {
        loadingScreen.SetActive(true);
        loading = true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
