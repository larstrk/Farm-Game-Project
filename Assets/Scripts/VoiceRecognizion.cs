using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech;

public class VoiceRecognizion : MonoBehaviour
{
    public GameObject[] spawnPositions;
    public RandomAnimalSpawner randomAnimalSpawner;

    [SerializeField]
    private string AnimalTag;

    public ClickHandler[] clickHandlers;

    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    private AudioClip microphoneClip;
    AudioSource myAudio2;
    
    // Start is called before the first frame update
    void Start()
    {

        actions.Add("yes", Yes);
        actions.Add("no", No);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();

        foreach (ClickHandler clickHandler in clickHandlers)
        {
            ClickHandler.clicken = 0;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void Yes()
    {
        // TO-DO: check if correct animal and give add point
        Debug.Log("YOU SAID YES !!");  // for debugging

        bool Spawned = CheckSpawned();

        if (Spawned)
        {
            Debug.Log("CORRECT!! --> Score +1");
            keywordRecognizer.Stop();
            ScoreScript.scoreValue += 1;

            // TO-DO: Führe entsprechende Aktionen aus
            myAudio2 = GetComponent<AudioSource>();
            myAudio2.Play();
            
            foreach (ClickHandler clickHandler in clickHandlers)
            {
                ClickHandler.clicken = 1;
            }

            
            
        }
        else
        {
            Debug.Log("WRONG!!");
            keywordRecognizer.Stop();

            // Scorewert in einen String umwandeln und speicher
            string scoreString = "Score: " + ScoreScript.scoreValue.ToString(); // Scorewert in einen String umwandeln und speicher
            PlayerPrefs.SetString("currentScore", scoreString);
            SceneManager.LoadScene("GameOver");

        }

        
    }

    private void No()
    {
        // TO-DO: check if correct animal and give add point
        Debug.Log("YOU SAID NO !!");  // for debugging

        bool Spawned = CheckSpawned();

        if (!Spawned)
        {
            Debug.Log("CORRECT!! --> Score +1");
            keywordRecognizer.Stop();
            ScoreScript.scoreValue += 1;
            
            //Aktion
            int index = UnityEngine.Random.Range(1, 8);
            SceneManager.LoadScene(index);
            Debug.Log("Scene " + index + " loaded.");
            
        }
        else
        {
            Debug.Log("WRONG!!");
            keywordRecognizer.Stop();

            // Scorewert in einen String umwandeln und speicher
            string scoreString = "Score: " + ScoreScript.scoreValue.ToString(); // Scorewert in einen String umwandeln und speicher
            PlayerPrefs.SetString("currentScore", scoreString);
            SceneManager.LoadScene("GameOver");

        }
 
    }

    private bool CheckSpawned()
    {
        bool Spawned = false;

        foreach (GameObject spawnPosition in spawnPositions)
        {
            Collider2D[] colliders = Physics2D.OverlapPointAll(spawnPosition.transform.position);
            Spawned = colliders.Any(collider => collider.gameObject.CompareTag(AnimalTag));

            if (Spawned)
            {
                break;
            }
        }

        return Spawned;
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }


}

