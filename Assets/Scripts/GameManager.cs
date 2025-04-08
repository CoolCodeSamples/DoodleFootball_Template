using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private Player playerLeft;
    [SerializeField] private Player playerRight;
    [SerializeField] private GameObject goalBanner;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private GameObject timeUpText;
    private int timer = 60;

    public void Goal()
    {
        goalBanner.SetActive(true);
        Invoke(nameof(Reset), 1);
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void CountDown()
    {
        if (timer > 0)
        {
            timer--;
            timerText.text = Helpers.FormatTimer(timer);
        }
        else
        {
            CancelInvoke(nameof(CountDown));
            timeUpText.SetActive(true);
            Invoke(nameof(Restart), 2);
        }
    }

    private void Reset()
    {
        playerLeft.Reset();
        playerRight.Reset();
        Football.instance.Reset();
        goalBanner.SetActive(false);
    }

    private void Start()
    {
        instance = this;
        timerText.text = Helpers.FormatTimer(timer);
        InvokeRepeating(nameof(CountDown), 1, 1);
    }
}
