using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Player player;
    public Spawner spawner;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public GameObject getReady;
    public GameObject textSave;
    public GameObject textTry;
    public GameObject dialogPanel;
    public GameObject exitPanel;
    public GameObject revivePanel;
    public Text reviveText;
    public Button reviveButton;
    public GameObject menuButton;
    public GameObject soundPanel;
    public GameObject thanksPanel;
    public GameObject retryButton;
    public GameObject exitButton;
    public GameObject fadeInImage;

    [Header("----Dead Count----")]
    public int deadCounter;
    private bool escPressed;
    private int score;
    private int dialogArray = 4;
    private Vector3 playerStartPosition;
    AudioManager audioManager;
    public bool canDie;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        } 
        else if(Instance != this)
        {
            Destroy(this.gameObject);
        }    

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        deadCounter = 0;

        scoreText.text = "";
        Application.targetFrameRate = 60;
        Pause();

        playerStartPosition = player.transform.position;
        canDie = true;
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);
        getReady.SetActive(false);
        textSave.SetActive(false);
        textTry.SetActive(false);
        soundPanel.SetActive(false);
        revivePanel.SetActive(false);
        menuButton.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }

        if (ADManager.Instance.isRewarded)
        {
            ADManager.Instance.isRewarded = false;
            ReviveNotUsed();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void GameOver()
    {
        if (canDie)
        {
            audioManager.PlaySFX(audioManager.death);
            deadCounter++;
            gameOver.SetActive(true);
            playButton.SetActive(true);
            textTry.SetActive(true);
            soundPanel.SetActive(true);
            revivePanel.SetActive(true);
            menuButton.SetActive(true);
            DialogChanger();
            Pause();   
        }
    }

    public void RevivePlayer()
    {
        playButton.SetActive(false);
        gameOver.SetActive(false);
        getReady.SetActive(false);
        textSave.SetActive(false);
        textTry.SetActive(false);
        soundPanel.SetActive(false);
        revivePanel.SetActive(false);
        canDie = false;

        player.transform.position = playerStartPosition; 
        Player.Instance.InvincibleOn();
        StartCoroutine(Revive());     
    }

    IEnumerator Revive()
    {
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 1f;
        player.enabled = true;
        yield return new WaitForSeconds(1.5f);
        Player.Instance.InvincibleOff();
        canDie = true;
    }

    public void ReviveUsed()
    {
        reviveText.text = "X0 REVIVE";
        reviveButton.interactable = false; 
    }

    public void ReviveNotUsed()
    {
        reviveText.text = "X1 REVIVE";
        reviveButton.interactable = true; 
    }
    
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();

         if (score == 100)//100
        {
            FinishTheGame();
        }
    }

    public void DialogChanger()
    {
        dialogArray = Random.Range(1, 7);

        if (deadCounter < 20)//20
        {
            switch (dialogArray)
            {
                case 1: textTry.GetComponent<Text>().text = "You can do better";
                    break;
                case 2: textTry.GetComponent<Text>().text = "Help the little one";
                    break;
                case 3: textTry.GetComponent<Text>().text = "Don't give up";
                    break;
                case 4: textTry.GetComponent<Text>().text = "You can't give up now";
                    break;
                case 5: textTry.GetComponent<Text>().text = "Try Harder";
                    break;
                case 6: textTry.GetComponent<Text>().text = "Everything depends up to you";
                    break;
                default: textTry.GetComponent<Text>().text = "Try Harder";
                    break;
            }
        }else if (deadCounter >= 20 && deadCounter < 40)//20 40
        {
            switch (dialogArray)
            {
                case 1: textTry.GetComponent<Text>().text = "Are You Even Trying?";
                    break;
                case 2: textTry.GetComponent<Text>().text = "The Little One Won't get away because of you!";
                    break;
                case 3: textTry.GetComponent<Text>().text = "I guess you've already given up...";
                    break;
                case 4: textTry.GetComponent<Text>().text = "if you're patient, the little bug will be free";
                    break;
                case 5: textTry.GetComponent<Text>().text = "resist, don't give up";
                    break;
                case 6: textTry.GetComponent<Text>().text = "hopes are gone";
                    break;
                default: textTry.GetComponent<Text>().text = "Try Harder";
                    break;
            }
        }
        else if (deadCounter >= 40 && deadCounter < 60)//40 60
        {
            switch (dialogArray)
            {
                case 1: textTry.GetComponent<Text>().text = "Maybe you should give up";
                    break;
                case 2: textTry.GetComponent<Text>().text = "there is no hope";
                    break;
                case 3: textTry.GetComponent<Text>().text = "hope is useless";
                    break;
                case 4: textTry.GetComponent<Text>().text = "the little one can't escape";
                    break;
                case 5: textTry.GetComponent<Text>().text = "don't resist anymore";
                    break;
                case 6: textTry.GetComponent<Text>().text = "accept his destiny";
                    break;
                default: textTry.GetComponent<Text>().text = "you don't need to try";
                    break;
            }
        }
        else if (deadCounter >= 60)//60
        {
            switch (dialogArray)
            {
                case 1: textTry.GetComponent<Text>().text = "no chance to win";
                    break;
                case 2: textTry.GetComponent<Text>().text = "you must stop now";
                    break;
                case 3: textTry.GetComponent<Text>().text = "it just hurts more";
                    break;
                case 4: textTry.GetComponent<Text>().text = "no exit from there";
                    break;
                case 5: textTry.GetComponent<Text>().text = "stop trying";
                    break;
                case 6: textTry.GetComponent<Text>().text = "this is his destiny";
                    break;
                default: textTry.GetComponent<Text>().text = "leave him to his fate";
                    break;
            }
        }
        
    }

    public void FinishTheGame()
    {
        audioManager.StopMusic();
        audioManager.PlaySFX(audioManager.victory);
        dialogPanel.SetActive(true);
        player.enabled = false;
        scoreText.text = "";

        spawner = FindObjectOfType<Spawner>();
        Destroy(spawner);

        Destroy(player.gameObject.GetComponent<Collider2D>());

        StartCoroutine(GameEnding());
    }
    IEnumerator GameEnding()
    {
        yield return new WaitForSeconds(6f);
        retryButton.SetActive(true);
        exitButton.SetActive(true);
        thanksPanel.SetActive(true);
    }

    public void GameQuit()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }

    public void ResetGame()
    {
        fadeInImage.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MenuButtonClicked()
    {
        exitPanel.SetActive(true); 
    }

    public void NoButtonClicked()
    {
        exitPanel.SetActive(false); 
    }

    public void ReturnToMenu()
    {
        fadeInImage.SetActive(true); 
        MenuReturn();
        Time.timeScale = 1f;

        StartCoroutine(MenuReturn());
    }

    IEnumerator MenuReturn()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("StartScene");
    }

    public int GetDeadCounter()
    {
        return deadCounter;
    }
}
