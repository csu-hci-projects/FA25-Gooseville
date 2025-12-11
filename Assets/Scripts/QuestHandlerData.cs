using UnityEngine;

public class QuestHandlerData : MonoBehaviour
{
    private static bool[] questActive = new bool[3];

    public static void setQuestActive(int quest)
    {
        questActive[quest] = true;

    }

    public static void setQuestInactive(int quest)
    {
        questActive[quest] = false;
    }

    public static bool[] getActiveQuests()
    {
        return questActive;
    }
    
    public void updateMap()
    {
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
