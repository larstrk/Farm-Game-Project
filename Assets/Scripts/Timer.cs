using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    public static float currentTime;
    public bool countDown;

    public bool hasLimit;
    public static float timerLimit = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;

        if(hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit)))
        {
            currentTime = timerLimit;
            SetTimerText();
            timerText.color = Color.red;
            enabled = false;
            // Scorewert in einen String umwandeln und speicher
            string scoreString = "Score: " + ScoreScript.scoreValue.ToString(); // Scorewert in einen String umwandeln und speicher
            PlayerPrefs.SetString("currentScore", scoreString);
            SceneManager.LoadScene(11);
        }

        SetTimerText();
    }

    private void SetTimerText()
    {
        timerText.text = "Timer: " + currentTime.ToString("0");
    }
}
