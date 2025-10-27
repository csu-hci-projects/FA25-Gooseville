using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{

    public GameObject[] playerPrefabs;
    public Transform spawnPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
            int playerChoice = PlayerPrefs.GetInt("SelectedCharacter", 0);
            Instantiate(playerPrefabs[playerChoice], spawnPoint.position, Quaternion.identity);
    }
}
