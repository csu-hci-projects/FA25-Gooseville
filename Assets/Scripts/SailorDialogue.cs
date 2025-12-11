using System.Collections;
using UnityEngine;

public class SailorDialogue : MonoBehaviour
{
    
    [SerializeField] private GameObject SailorSpeechBubble;
    [SerializeField] private DialogueManager dialogue;
    [SerializeField] private MapUI map;
    private bool playerClicked = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    if (QuestHandlerData.getActiveQuests()[0])
            {
                SailorSpeechBubble.SetActive(true);
            }
    }
    public void OnPlayerClick()
    {
        playerClicked = true;
    }
    public void OnEnable()
    {
        playerClicked = false;
    }
    public void onSpeechBubbleClick()
    {
        StartCoroutine(RunCutscene());
    }
    private IEnumerator RunCutscene()
    {
        // Dialogue
        playerClicked = false;
        dialogue.ShowDialogue("Hello traveler! Do you need directions to Ankig's Abode?", "Yes!", "");
        yield return new WaitUntil(() => playerClicked);

        playerClicked = false;
        dialogue.ShowDialogue("See that sign there along the path? Click it, and it will open up with some directions. Good luck!", "Thanks!", "");
        yield return new WaitUntil(() => playerClicked);
        dialogue.HideDialogue();

        SailorSpeechBubble.SetActive(false);

        QuestHandlerData.setQuestInactive(0); // sets "Talk to sailor" quest inactive
        QuestHandlerData.setQuestActive(1); // sets "Talk to Ankig" quest active

        map.deactivateQuest(0);
        map.activateQuest(1);
    
    }

}
