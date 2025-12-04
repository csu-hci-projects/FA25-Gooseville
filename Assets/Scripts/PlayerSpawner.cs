using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{

    public GameObject playerPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
            // PlayerPrefs.SetInt("SelectedCharacter", 0); // here until players have choice of character
            // int playerChoice = PlayerPrefs.GetInt("SelectedCharacter", 0);
            Instantiate(playerPrefab, new Vector2(0,0), Quaternion.identity);
    }
}
