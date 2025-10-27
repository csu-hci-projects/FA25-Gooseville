using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Unity.VisualScripting;

public class IntroductionSceneManager : MonoBehaviour
{
    [SerializeField] private CourierManager courier;
    [SerializeField] private DialogueManager dialogue;
    [SerializeField] private LetterUI letterUI;
    [SerializeField] private PlayerMovement playerMovement;
    private GameObject player;
    private Transform playerTransform;
    private Rigidbody2D playerRB;
    private bool playerClicked = false;
    // [SerializeField] private CanvasGroup fadePanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        playerRB = player.GetComponent<Rigidbody2D>();
        playerMovement = player.GetComponent<PlayerMovement>();
        playerMovement.canMove = false;
        StartCoroutine(RunCutscene());
    }

    private IEnumerator RunCutscene()
    {
        // 1. Courier walks in
        courier.MoveTo(playerTransform.position + new Vector3(1.5f, 0, 0));
        yield return new WaitUntil(() => Vector3.Distance(courier.transform.position, playerTransform.position + new Vector3(1.5f, 0, 0)) < 0.1f);
        player.GetComponent<SpriteRenderer>().flipX = true;

        // 2. Dialogue
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

        // 3. Courier leaves
        courier.GetComponent<SpriteRenderer>().flipX = true;
        courier.MoveTo(new Vector3(11.5f, courier.transform.position.y, 0));
        yield return new WaitUntil(() => Vector3.Distance(courier.transform.position, new Vector3(11.5f, courier.transform.position.y, 0)) < 0.1f);

        // 4. Player thinking
        playerClicked = false;
        dialogue.ShowDialogue("", "I guess I should open this letter...", "");
        yield return new WaitUntil(() => playerClicked);
        dialogue.HideDialogue();

        // 5. Open letter (UI handles button click)
        letterUI.OpenLetter();
        yield return new WaitUntil(() => !letterUI.gameObject.activeSelf);

        // 6. Player moves right (simulate walk)
        Debug.Log("Player entering movement state");
        Vector3 exitPos = new Vector3(11.5f, playerTransform.position.y, 0);
        while (Vector3.Distance(playerTransform.position, exitPos) > 0.1f)
        {
            Debug.Log("Player moving");
            // player.position = Vector3.MoveTowards(player.position, exitPos, 2f * Time.deltaTime);
            playerRB.MovePosition(Vector2.MoveTowards(playerRB.position, exitPos, 2f * Time.deltaTime));
            yield return null;
        }
        Debug.Log("Player done moving");

        // 7. Fade to black
        StartCoroutine(FadeController.Instance.FadeOut(1f));
        // fadePanel.gameObject.SetActive(true);
        // for (float t = 0; t < 1; t += Time.deltaTime)
        // {
        //     fadePanel.alpha = t;
        //     yield return null;
        // }

        // 8. Load next scene
        playerMovement.canMove = true;
        SceneManager.LoadScene("Overworld_Port");
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
