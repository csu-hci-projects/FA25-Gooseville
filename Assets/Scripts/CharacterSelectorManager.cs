using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectorManager : MonoBehaviour
{

    public GameObject baldPrefab;
    public GameObject shortHairPrefab;
    public GameObject longHairPrefab;

    public void SelectCharacter(int index)
    {
        PlayerPrefs.SetInt("SelectedCharacter", index);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Introduction");
    }

}
