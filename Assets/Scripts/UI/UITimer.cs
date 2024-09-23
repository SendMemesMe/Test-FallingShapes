using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour
{
    public Text timerText;
    public GameObject popup;
    public int timeRemaining = 60;
    private bool timerRunning = false;

    private void OnEnable()
    {
        timeRemaining = 60;
        timerRunning = false;
        StartTimer();
    }

    public void StartTimer()
    {
        if (!timerRunning)
        {
            timerRunning = true;
            StartCoroutine(TimerCoroutine());
            
        }
    }

    private IEnumerator TimerCoroutine()
    {
        while (timeRemaining > 0)
        {
            timerText.text = $"Time: {timeRemaining}";
            yield return new WaitForSeconds(1f);
            timeRemaining--;
        }
        TimerFinished();
    }

    private void TimerFinished()
    {
        timerRunning = false;
        popup.SetActive(true);

    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
