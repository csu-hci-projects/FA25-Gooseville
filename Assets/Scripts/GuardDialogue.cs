using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GuardDialogue : MonoBehaviour
{
    [SerializeField] private GameObject GuardSpeechBubble;
    [SerializeField] private DialogueManager dialogue;
    [SerializeField] private ExitHandler exitHandle;
    private bool playerClicked = false;
    
    void Start()
    {
        if (QuestHandlerData.getActiveQuests()[1])
        {
            GuardSpeechBubble.SetActive(true);
        }
        // probably not best practice
        if (!GuardSpeechBubble.activeSelf)
        {
            exitHandle.setExit("A1_AnkigsAbode1", 3);
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
        dialogue.ShowDialogue("Halt! Who goes there?", "Ankig the Prince Goose has sent me a letter requesting my aid.", "");
        yield return new WaitUntil(() => playerClicked);

        playerClicked = false;
        dialogue.ShowDialogue("My apologies. You may proceed.", "", "");
        yield return new WaitUntil(() => playerClicked);

        dialogue.HideDialogue();

        GuardSpeechBubble.SetActive(false);
        exitHandle.setExit("A1_AnkigsAbode1", 3);
        
    }
}
