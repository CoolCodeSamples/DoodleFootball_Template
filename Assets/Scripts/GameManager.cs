using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private GameObject startMenu;
    [SerializeField] private PlayerController leftPlayer;
    [SerializeField] private PlayerController rightPlayer;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private int timer = 120;
    [SerializeField] private GameObject timesUpUI;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private AudioSource whistleSound;

    public void Set1Player()
    {
        rightPlayer.GetComponent<AiControler>().enabled = true;
        StartGame();
    }

    public void Set2Player()
    {
        rightPlayer.GetComponent<PlayerController>().enabled = true;
        StartGame();
    }

    public void ResetPositions()
    {
        whistleSound.Play();
        Ball.Reset();
        foreach (FootballPlayer player in FindObjectsOfType<FootballPlayer>())
        {
            player.Reset();
        }
    }

    private void StartGame()
    {
        leftPlayer.GetComponent<PlayerController>().enabled = true;
        startMenu.SetActive(false);
        gameUI.SetActive(true);
        Time.timeScale = 1;
        whistleSound.Play();
    }

    private void UpdateTimer()
    {
        int minutes = timer / 60;
        int seconds = timer - minutes * 60;

        timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }

    private void CountDown()
    {
       
        if (timer<=0)
        {
            timesUpUI.SetActive(true);
            Invoke(nameof(Restart),3);
        }
        else
        {
            timer--;
            UpdateTimer();
        }
    }

    private void Restart()
    {
        Ball.Instance = null;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Awake()
    {
        Instance = this;
        Time.timeScale = 0;
        UpdateTimer();
        InvokeRepeating(nameof(CountDown), 1, 1);
        startMenu.SetActive(true);
    }
}
