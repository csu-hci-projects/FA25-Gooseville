using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectorManager : MonoBehaviour
{
    public void SelectCharacter(int index)
    {
        PlayerPrefs.SetInt("SelectedCharacter", index);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Introduction");
    }

}
