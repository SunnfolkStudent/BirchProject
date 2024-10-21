using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryBox : MonoBehaviour
{
    void OnCollisionEnter2D  (Collision2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("EndCutscene");
        }
    }
}
