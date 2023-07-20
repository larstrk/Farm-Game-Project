using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreHandler : MonoBehaviour
{

    public GameObject currentScore;
    private TextMeshProUGUI currentScoreText;

    // Start is called before the first frame update
    void Start()
    {
        currentScoreText = currentScore.GetComponent<TextMeshProUGUI>();

        currentScoreText.text = PlayerPrefs.GetString("currentScore");
    }
}
