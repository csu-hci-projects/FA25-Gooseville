using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private Button dialogueOption0;
    [SerializeField] private Button dialogueOption1;
    [SerializeField] private Button dialogueNext;

    // Show the dialogue box with: NPC Dialogue, Player Dialogue Options 0 and/or 1, OR Next button if no dialogue options
    public void ShowDialogue(string NPCText, string option0, string option1)
    {
        dialoguePanel.SetActive(true);
        dialogueNext.gameObject.SetActive(false);
        dialogueText.text = NPCText;

        // If a first option is given
        if (option0 != "")
        {
            dialogueOption0.gameObject.SetActive(true);
            dialogueOption0.GetComponentInChildren<TMP_Text>().text = option0;
        }
        // If a second option is given
        if (option1 != "")
        {
            dialogueOption1.gameObject.SetActive(true);
            dialogueOption1.GetComponentInChildren<TMP_Text>().text = option1;
        }
        // If no dialogue options are given
        if ((option0 == "") && (option1 == ""))
        {
            dialogueOption0.gameObject.SetActive(false);
            dialogueOption1.gameObject.SetActive(false);
            dialogueNext.gameObject.SetActive(true);
        }

    }

    public void HideDialogue()
    {
        dialoguePanel.SetActive(false);
    }
    
}
