using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MapUI : MonoBehaviour
{
    [SerializeField] private InputAction mapKey;
    [SerializeField] private GameObject mapCanvas;
    [SerializeField] private GameObject[] questMarkers;
    [SerializeField] private GameObject[] questBubbles;


    void OnEnable()
    {
        mapKey.Enable();
    }

    public void activateQuest(int i)
    {
        questMarkers[i].SetActive(true);
    }

    public void deactivateQuest(int i)
    {
        questMarkers[i].SetActive(false);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bool[] questActive = QuestHandlerData.getActiveQuests();
        // Makes quest markers active or not based on global active quests boolean array
        for (int i = 0; i < questMarkers.Length; i++)
        {
            if (questActive[i]){
                questMarkers[i].SetActive(true);
            }
            else
            {
                questMarkers[i].SetActive(false);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (mapKey.triggered) 
        {
            mapCanvas.SetActive(!mapCanvas.activeSelf);
        }
    }

    public void CloseMap()
    {
        mapCanvas.SetActive(false);
    }

    public void ToggleQuestInfo(int i)
    {
        questBubbles[i].SetActive(!questBubbles[i].activeSelf);
    }
}
