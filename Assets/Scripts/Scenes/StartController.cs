using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Player
{
    public class StartController : MonoBehaviour
    {
        private bool beginning = false;
        
        [Header("Audio")]
    
        public AudioClip pressStartLine;
        public AudioSource _audioSource;
    //Make it check for input AND also the current scene, if it is the start menu then it will go to gameplay mode
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "StartMenuScene" && Keyboard.current.anyKey.wasPressedThisFrame
            || Gamepad.current.buttonWest.wasPressedThisFrame
            || Gamepad.current.buttonEast.wasPressedThisFrame
            || Gamepad.current.buttonNorth.wasPressedThisFrame
            || Gamepad.current.buttonSouth.wasPressedThisFrame)
        {
            if (beginning == false){
                Debug.Log("Input Detected!");
                beginning = true;
                _audioSource.PlayOneShot(pressStartLine);
                StartCoroutine(VoiceLineWait());
            }
        }
    }

    private IEnumerator VoiceLineWait()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("IntroCutscene");
    }
    }
}