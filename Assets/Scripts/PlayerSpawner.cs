using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{

    public GameObject baldPrefab;
    public GameObject longHairPrefab;
    public GameObject shortHairPrefab;
    // public Vector3 spawnPoint;
    // private static bool spawned = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // if (!spawned)
        // {
            int playerChoice = PlayerPrefs.GetInt("SelectedCharacter", 0);

            GameObject player = null;

            if (playerChoice == 0)
            {
                player = Instantiate(baldPrefab);
            }
            else if (playerChoice == 1)
            {
                player = Instantiate(shortHairPrefab);
            }
            else if (playerChoice == 2)
            {
                player = Instantiate(longHairPrefab);
            }
            Transform spawnPoint = GameObject.Find("SpawnPoint").transform;
            player.transform.position = spawnPoint.position;
            DontDestroyOnLoad(player);
        //     spawned = true;
        // }
    }
}
