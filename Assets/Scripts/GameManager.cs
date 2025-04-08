using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private Player playerLeft;
    [SerializeField] private Player playerRight;
    [SerializeField] private GameObject goalBanner;
    [SerializeField] private TMP_Text timerText;
    private int timer = 60;

    public void Goal()
    {
        goalBanner.SetActive(true);
        Invoke(nameof(Reset), 1);
    }

    private void CountDown()
    {
        timer--;
        timerText.text = Helpers.FormatTimer(timer);
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
