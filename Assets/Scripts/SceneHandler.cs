using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = SceneHandlerData.playerSpawnPos;
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
