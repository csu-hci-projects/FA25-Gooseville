using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitHandler : MonoBehaviour
{

    [SerializeField] string[] scenesNESW;
    [SerializeField] string currentSceneName;
    GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = player.transform.position;
        if ((pos.x >= 9f) || (pos.x <= -9f) || (pos.y >= 9f) || (pos.y <= -9f))
        {
            calculateSpawnPoint(pos);
        }
    }

    private void calculateSpawnPoint(Vector2 exitPos)
    {
        // INTRO SCENE (special case)
        if (currentSceneName == "S1_Intro")
        {
            SceneHandlerData.playerSpawnPos = new Vector2(-3,0);
            Debug.Log("scene: " + currentSceneName + "\nexit pos: " + exitPos + "\nspawn pos: " + SceneHandlerData.playerSpawnPos);
            SceneManager.LoadScene(scenesNESW[1]);
        }
        // NORTH
        else if ((exitPos.y >= 9f) && (scenesNESW[0] != ""))
        {
            SceneHandlerData.playerSpawnPos = new Vector2(exitPos.x,exitPos.y*(-1)+2);
            Debug.Log("scene: " + currentSceneName + "\nexit pos: " + exitPos + "\nspawn pos: " + SceneHandlerData.playerSpawnPos);
            SceneManager.LoadScene(scenesNESW[0]);
        } 
        // EAST
        else if ((exitPos.x >= 9f) && (scenesNESW[1] != ""))
        {
            SceneHandlerData.playerSpawnPos = new Vector2(exitPos.x*(-1)+2,exitPos.y);
            Debug.Log("scene: " + currentSceneName + "\nexit pos: " + exitPos + "\nspawn pos: " + SceneHandlerData.playerSpawnPos);
            SceneManager.LoadScene(scenesNESW[1]);
        }
        // SOUTH
        else if ((exitPos.y <= -9f) && (scenesNESW[2] != ""))
        {
            SceneHandlerData.playerSpawnPos = new Vector2(exitPos.x,exitPos.y*(-1)-2);
            Debug.Log("scene: " + currentSceneName + "\nexit pos: " + exitPos + "\nspawn pos: " + SceneHandlerData.playerSpawnPos);
            SceneManager.LoadScene(scenesNESW[2]);
        }
        // WEST
        else if ((exitPos.x <= -9f) && (scenesNESW[3] != ""))
        {
            SceneHandlerData.playerSpawnPos = new Vector2(exitPos.x*(-1)-2,exitPos.y);
            Debug.Log("scene: " + currentSceneName + "\nexit pos: " + exitPos + "\nspawn pos: " + SceneHandlerData.playerSpawnPos);
            SceneManager.LoadScene(scenesNESW[3]);
        }

    }
}
