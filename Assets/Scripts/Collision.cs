using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;
    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Tag: Friendly");
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    void StartSuccessSequence()
    {
        // TODO add SFX on crash
        // TODO add particle effects on crash
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    void StartCrashSequence()
    {
        // TODO add SFX on crash
        // TODO add particle effects on crash
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
