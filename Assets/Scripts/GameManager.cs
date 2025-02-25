using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private Player playerLeft;
    [SerializeField] private Player playerRight;
    [SerializeField] private GameObject goalBanner;

    public void Goal()
    {
        goalBanner.SetActive(true);
        Invoke(nameof(Reset), 1);
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
    }
}
