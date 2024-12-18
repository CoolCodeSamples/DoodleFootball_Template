using TMPro;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private TMP_Text goalText;
    [SerializeField] private GameObject goalImage;
    private int goals;
    private static bool canScore = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Ball ballScript) && canScore)
        {
            canScore = false;
            goals++;
            goalText.text = goals.ToString();
            goalImage.SetActive(true);

            Invoke(nameof(Reset),1);
        }           
    }

    private void Reset()
    {
        GameManager.Instance.ResetPositions();
        canScore = true;
        goalImage.SetActive(false);
        GetComponentInChildren<PowerUpSpawner>().Spawn();
    }
}
