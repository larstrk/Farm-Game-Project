using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public static int scoreValue;
    public TextMeshProUGUI myScoreText;

    // Update is called once per frame
    void Update()
    {
        myScoreText.text = "Score: " + scoreValue;
    }
}
