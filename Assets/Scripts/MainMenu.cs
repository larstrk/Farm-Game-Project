using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // public float time;
    private string input;
    float timeValue = 60; // Standardwert

    public void PlayGame()
    {
        int index = Random.Range(1, 8);
        SceneManager.LoadScene(index);
        Debug.Log("Scene " + index + " loaded.");
        ScoreScript.scoreValue = 0;
        if (!string.IsNullOrEmpty(input))
        {
            if (float.TryParse(input, out float inputTime))
            {
                float inputUser = float.Parse(input);
                // Wenn der Benutzer eine gültige Eingabe gemacht hat
                Timer.currentTime = inputUser;
                Debug.Log("User input: " + inputUser);
            }
            else
            {
                Debug.Log("Invalid input");
            }
        }
        else
        {
            Timer.currentTime = timeValue;
            Debug.Log("No input, using default value: " + timeValue);
        }
        //Timer.currentTime = timeValue;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Info()
    {
        SceneManager.LoadScene(10);
    }

    public void ReadStringInput(string s)
    {
        input = s;
        Debug.Log(input);
    }
}
