using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("Play button pressed");
        // SceneManager.LoadScene("CharacterSelection"); // omitting character selection
        SceneManager.LoadScene("S1_Intro");
    }
    
    public void ExitGame()
    {
        Debug.Log("Exit button pressed");
        Application.Quit();
    }
}
