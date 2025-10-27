using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("Play button pressed");
        SceneManager.LoadScene("CharacterSelection");
    }
    
    public void ExitGame()
    {
        Debug.Log("Exit button pressed");
        Application.Quit();
    }
}
