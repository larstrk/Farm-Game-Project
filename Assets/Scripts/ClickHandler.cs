using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickHandler : MonoBehaviour
{
    [SerializeField]
    private string AnimalTag;

    public static int clicken = 0;


    void OnMouseDown()
    {
        if (clicken == 1 && gameObject.CompareTag(AnimalTag))
        {
            Debug.Log("Correct animal clicked --> Score + 1");
            ScoreScript.scoreValue += 1;

            int index = Random.Range(1, 8);
            SceneManager.LoadScene(index);
            Debug.Log("Scene " + index + " loaded.");
        }
        else if (clicken == 0)
        {
            Debug.Log("Click disabled for this animal");
        }
        else
        {
            Debug.Log("Wrong animal clicked");
            string scoreString = "Score: " + ScoreScript.scoreValue.ToString();
            PlayerPrefs.SetString("currentScore", scoreString);
            SceneManager.LoadScene("GameOver");
        }
    }
}
