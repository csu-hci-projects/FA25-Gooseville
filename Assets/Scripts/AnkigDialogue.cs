using System.Collections;
using UnityEngine;

public class AnkigDialogue : MonoBehaviour
{
    [SerializeField] private GameObject AnkigSpeechBubble;
    [SerializeField] private DialogueManager dialogue;
    [SerializeField] private MapUI map;
    private bool playerClicked = false;
    

    void Start()
    {
        if (QuestHandlerData.getActiveQuests()[1])
        {
            AnkigSpeechBubble.SetActive(true);
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
        dialogue.ShowDialogue("Are you the traveler I have been awaiting?", "Yes, I am.", "");
        yield return new WaitUntil(() => playerClicked);

        playerClicked = false;
        dialogue.ShowDialogue("Good. The pumgeese are on vacation. I request that their vacation end a week early.", "Really?", "");
        yield return new WaitUntil(() => playerClicked);

        playerClicked = false;
        dialogue.ShowDialogue("Yes. You will find them east of the pumpkin patch, at their sacred maze. Please let them know.", "Alright. I will.", "");
        yield return new WaitUntil(() => playerClicked);

        dialogue.HideDialogue();

        AnkigSpeechBubble.SetActive(false);

        QuestHandlerData.setQuestInactive(1); // sets "Talk to ankig" quest inactive
        QuestHandlerData.setQuestActive(2); // sets "Talk to pumgoose" quest active

        map.deactivateQuest(1);
        map.activateQuest(2);

    }
}
