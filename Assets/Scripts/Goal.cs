using TMPro;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private TMP_Text enemyScoreText;
    private int enemyScore;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Football ball))
        {
            GameManager.instance.Goal();

            enemyScore++;
            enemyScoreText.text = enemyScore.ToString();
        }
    }
}
