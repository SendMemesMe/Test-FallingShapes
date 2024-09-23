using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour
{
    public int score = 0;
    public int hcore = 0;
    public Text scoreText;
    public Text hscoreText;

    private void OnEnable()
    {
        score = 0;
        UpdateScore();
    }

    public void AddScore(int value) 
    {
        score += value;
        if (score >= hcore)
        {
            hcore = score;
        }
        UpdateScore();
    }

    public void SubtractScore(int value) 
    {
        if (score < value)
        {
            score = 0;
        }
        else 
        {
            score -= value;
        }
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = $"Score: {score}";
        hscoreText.text = $"High Score: {score}";
    }
}
