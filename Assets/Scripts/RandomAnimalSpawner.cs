using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnimalSpawner : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public Transform[] spawnPositions;
    public AudioSource myAudio;
    public AudioClip quest, sound;


    public void Start()
    {
        if (animalPrefabs.Length < 4 || spawnPositions.Length < 4)
        {
            Debug.LogError("At least 4 animalPrefabs and 4 spawnPositions are required!");
            return;
        }

        int[] randomIndices = GenerateRandomIndices(animalPrefabs.Length);

        for (int i = 0; i < 4; i++)
        {
            int randomIndex = randomIndices[i];
            GameObject animalPrefab = animalPrefabs[randomIndex];
            Transform spawnPosition = spawnPositions[i];

            Instantiate(animalPrefab, spawnPosition.position, Quaternion.identity);
        }

        StartCoroutine(PlayAudioClips());
    }

    void Update()
    {

    }

    
    IEnumerator PlayAudioClips()
    {
        myAudio.clip = quest;
        myAudio.PlayDelayed(1.0f);

        yield return new WaitForSeconds(2.4f);

        myAudio.clip = sound;
        myAudio.volume = 0.3f;
        myAudio.Play();
    }

    int[] GenerateRandomIndices(int length)
    {
        int[] indices = new int[length];
        for (int i = 0; i < length; i++)
        {
            indices[i] = i;
        }

        for (int i = 0; i < length - 1; i++)
        {
            int randomIndex = Random.Range(i, length);
            int temp = indices[i];
            indices[i] = indices[randomIndex];
            indices[randomIndex] = temp;
        }

        return indices;
    }
}
