using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Unity.VisualScripting;

public class Tutorial2Dialogue : MonoBehaviour
{
    [SerializeField] private DialogueManager dialogue;
    private bool playerClicked = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        if (SceneHandlerData.tutorial)
        {
            StartCoroutine(RunCutscene());
        }  
    }

    private IEnumerator RunCutscene()
    {
        // Tutorial / Information for player
        playerClicked = false;
        dialogue.ShowDialogue("You've landed on the island of Tornviken.","","");
        yield return new WaitUntil(() => playerClicked);

        playerClicked = false;
        dialogue.ShowDialogue("Press M to see a map and your objectives. Press the quest marker to read more information about the objective","","");
        yield return new WaitUntil(() => playerClicked);

        playerClicked = false;
        dialogue.ShowDialogue("Your next objective is to speak to the sailor. Press the speech bubble by him to speak to him.", "","");
        yield return new WaitUntil(() => playerClicked);
        dialogue.HideDialogue();
        SceneHandlerData.tutorial = false;
    }

    public void OnPlayerClick()
    {
        playerClicked = true;
    }
    public void OnEnable()
    {
        playerClicked = false;
    }


}
