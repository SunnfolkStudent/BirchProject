using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
    //Make it check for input AND also the current scene, if it is the start menu then it will go to gameplay mode
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "StartMenuScene" && Keyboard.current.anyKey.wasPressedThisFrame)
        {
            Debug.Log("Input Detected!");
            SceneManager.LoadScene("MagTestScene");
        }
    }
}
