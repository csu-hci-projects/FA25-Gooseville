using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterAnkigsAbode : MonoBehaviour
{
    public void EnterAbode()
    {
        SceneHandlerData.playerSpawnPos = new Vector2(7,0);
        SceneManager.LoadScene("A1_AnkigsAbode0");

    }
}
