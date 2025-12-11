using System.Collections;
using UnityEngine;

public class PumgooseDialogue : MonoBehaviour
{
    
    [SerializeField] private GameObject PumgooseSpeechBubble;
    [SerializeField] private DialogueManager dialogue;
    [SerializeField] private MapUI map;
    private bool playerClicked = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (QuestHandlerData.getActiveQuests()[2])
        {
            PumgooseSpeechBubble.SetActive(true);
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
        dialogue.ShowDialogue("Hello there, who are you?", "I was sent by Ankig, our prince.", "");
        yield return new WaitUntil(() => playerClicked);

        playerClicked = false;
        dialogue.ShowDialogue("What does he request of us?", "He wants you to finish your vacation early.", "");
        yield return new WaitUntil(() => playerClicked);

        playerClicked = false;
        dialogue.ShowDialogue("Very well then. We shall meet him at his abode shortly.", "Take care", "");
        yield return new WaitUntil(() => playerClicked);

        dialogue.HideDialogue();

        PumgooseSpeechBubble.SetActive(false);

        QuestHandlerData.setQuestInactive(2); // sets "Talk to pumgoose" quest inactive

        map.deactivateQuest(2);

        //cooldown before system sends player dialogue
        yield return new WaitForSeconds(3);

        playerClicked = false;
        dialogue.ShowDialogue("You completed the very simple quest! Congrats.", "", "");
        yield return new WaitUntil(() => playerClicked);

        playerClicked = false;
        dialogue.ShowDialogue("Feel free to explore the map to your heart's content. Thanks for playing!","","");
        yield return new WaitUntil(()=> playerClicked);

        dialogue.HideDialogue();
    }

}
