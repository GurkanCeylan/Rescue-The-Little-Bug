using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{   
    public GameObject fadeInImage;
    public GameObject levelsPanel;
    public GameObject closeTab;
    public GameObject splashImage;
    public AudioSource menuSound;
    public bool firstEnter = true;
    public GameObject toggleCredits;
    public bool toggleButton = true;

    private void Awake() 
    {

        if (!PlayerPrefs.HasKey("FirstTime"))
        {
            splashImage.SetActive(true);
            PlayerPrefs.SetInt("FirstTime", 1);
        }
    }

    public void GoToNextScene()
    {
        fadeInImage.SetActive(true);
        menuSound.mute = true;
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("FirstGameScene");
    }

    public void GoLevelTwo()
    {
        fadeInImage.SetActive(true);
        menuSound.mute = true;
        StartCoroutine(FadeInLevelTwo());
    }

    IEnumerator FadeInLevelTwo()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("SecondGameScene");
    }

    public void GoLevelThree()
    {
        fadeInImage.SetActive(true);
        menuSound.mute = true;
        StartCoroutine(FadeInLevelThree());
    }

    IEnumerator FadeInLevelThree()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("ThirdGameScene");
    }

    public void GameQuit()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }

    public void SelectLevel()
    {
        levelsPanel.SetActive(true);
    }

    public void CloseTab()
    {
        levelsPanel.SetActive(false);
    }

    public void ToggleCredits()
    {
        if (toggleButton)
        {
            toggleCredits.SetActive(false);
            toggleButton = false;
        }else if (!toggleButton)
        {
            toggleCredits.SetActive(true);
            toggleButton = true;
        }
    }
    
}
