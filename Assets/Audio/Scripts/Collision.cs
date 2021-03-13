using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Tag: Friendly");
                break;
            case "Finish":
                Debug.Log("Tag: Finish");
                break;
            case "Fuel":
                Debug.Log("Tag: Fuel");
                break;
            default:
                ReloadLevel();
                break;
        }
    }
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
