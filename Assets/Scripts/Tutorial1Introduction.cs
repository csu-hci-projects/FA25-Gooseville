using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Unity.VisualScripting;

public class Tutorial1Introduction : MonoBehaviour
{
    [SerializeField] private CourierManager courier;
    [SerializeField] private DialogueManager dialogue;
    [SerializeField] private PaperUI letterUI;
    [SerializeField] private PlayerMovement playerMovement;
    private GameObject player;
    private Transform playerTransform;
    private Rigidbody2D playerRB;
    private bool playerClicked = false;
    // [SerializeField] private CanvasGroup fadePanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        // grabbing player data
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        playerRB = player.GetComponent<Rigidbody2D>();
        playerMovement = player.GetComponent<PlayerMovement>();
        // player cannot move during cutscene
        // playerMovement.canMove = false;
        StartCoroutine(RunCutscene());
    }

    private IEnumerator RunCutscene()
    {
        // Tutorial / Information for player
        playerClicked = false;
        dialogue.ShowDialogue("Welcome to Gooseville! Use W, A, S, and D, or the arrow keys, to move around.","","");
        yield return new WaitUntil(() => playerClicked);

        playerClicked = false;
        dialogue.ShowDialogue("The Courier is about to hand you a letter. Stay in place, it'll make the delivery much easier.","","");
        yield return new WaitUntil(() => playerClicked);
        dialogue.HideDialogue();

        // Courier walks in
        courier.MoveTo(playerTransform.position + new Vector3(1.5f, 0, 0));
        yield return new WaitUntil(() => Vector3.Distance(courier.transform.position, playerTransform.position + new Vector3(1.5f, 0, 0)) < 0.1f);
        player.GetComponent<SpriteRenderer>().flipX = true;

        // Dialogue
        playerClicked = false;
        dialogue.ShowDialogue("I've been looking for you. Got something I'm supposed to deliver - your hands only.", "", "");
        yield return new WaitUntil(() => playerClicked);

        playerClicked = false;
        dialogue.ShowDialogue("Let's see here... I have a letter here for you.", "Thank you.", "Who is it from?!");
        yield return new WaitUntil(() => playerClicked);

        playerClicked = false;
        dialogue.ShowDialogue("It's from... Ankig the Prince Goose of Gooseville? You've got friends in high places.", "", "");
        yield return new WaitUntil(() => playerClicked);
        dialogue.HideDialogue();

        // Courier leaves
        courier.GetComponent<SpriteRenderer>().flipX = true;
        courier.MoveTo(new Vector3(11.5f, 0, 0)); // y = courier.transform.position.y
        yield return new WaitUntil(() => Vector3.Distance(courier.transform.position, new Vector3(11.5f, 0, 0)) < 0.1f);

        // Player thinking
        playerClicked = false;
        dialogue.ShowDialogue("", "I guess I should open this letter...", "");
        yield return new WaitUntil(() => playerClicked);
        dialogue.HideDialogue();

        // Open letter (UI handles button click)
        letterUI.OpenPaper();
        yield return new WaitUntil(() => !letterUI.getPaperCanvas().activeSelf);

        // Store player spawn position in scene handler data class
        SceneHandlerData.playerSpawnPos = new Vector2(-3,0);
        
        // Load next scene
        playerClicked = false;
        dialogue.ShowDialogue("Follow the courier, to the very center-right side of the screen. Here, you will catch a boat to Gooseville to meet with Ankig the Prince Goose.","","");
        yield return new WaitUntil(() => playerClicked);
        dialogue.HideDialogue();

        playerMovement.canMove = true;

        QuestHandlerData.setQuestActive(0); // sets "Talk to sailor" quest active
    }

    public void OnPlayerClick()
    {
        playerClicked = true;
    }
    public void OnEnable()
    {
        playerClicked = false;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
