using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using System;

public class DialogueManager : MonoBehaviour
{
    [Header("Player 1 Dialogue UI")]
    [SerializeField] private GameObject p1DialoguePanel;
    [SerializeField] private TextMeshProUGUI p1DialogueText;
    // [SerializeField] private GameObject[] p1Choices;
    // private TextMeshProUGUI[] p1ChoicesText;

    [Header("Player 2 Dialogue UI")]
    [SerializeField] private GameObject p2DialoguePanel;
    [SerializeField] private TextMeshProUGUI p2DialogueText;
    // [SerializeField] private GameObject[] p2Choices;
    // private TextMeshProUGUI[] p2ChoicesText;

    private Story currentStory1;
    private Story currentStory2;
    public bool dialogueIsPlaying1 { get; private set; }
    public bool dialogueIsPlaying2 { get; private set; }

    public static event Action standardCallback; //callbacks at end of dialogue! Functions defined in other classes can turn into actions to be called (pointers preserved from that class too)

    // MAKE SURE TO RESET CALLBACK AFTER EXITING DIALOGUE MODE
    public static event Action p1Callback = standardCallback;
    public static event Action p2Callback = standardCallback;

    private static DialogueManager instance;

    private void DoNothing() {

    }

    private void Awake()
    {   
        standardCallback = DoNothing;
        if (instance != null)
        {
            Debug.LogWarning("Found more than two Dialogue Managers in the scene");
        }
        instance = this;
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying1 = false;
        dialogueIsPlaying2 = false;
        p1DialoguePanel.SetActive(false);
        p2DialoguePanel.SetActive(false);

        // // get all of the choices text for player 1
        // // p1ChoicesText = new TextMeshProUGUI[p1Choices.Length];
        // int index = 0;
        // foreach (GameObject choice in p1Choices)
        // {
        //     p1ChoicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
        //     index++;
        // }

        // // get all of the choices text for player 2
        // p2ChoicesText = new TextMeshProUGUI[p2Choices.Length];
        // index = 0;
        // foreach (GameObject choice in p2Choices)
        // {
        //     p2ChoicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
        //     index++;
        // }
    }

    private void Update()
    {
        // return right away if dialogue isn't playing
        if (!dialogueIsPlaying1 && !dialogueIsPlaying2)
        {
            return;
        }

        // handle continuing to the next line in the dialogue when submit is pressed
        if (currentStory1 != null && dialogueIsPlaying1 && currentStory1.currentChoices.Count == 0 && InputManager.GetInstance().GetSubmitPressed())
        {
            ContinueStory(true); //player 1 True
        }
        if (currentStory2 != null && dialogueIsPlaying2 && currentStory2.currentChoices.Count == 0 && InputManager1.GetInstance().GetSubmitPressed())
        {
            ContinueStory(false); // player 1 False
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON, bool isPlayer1, Action callbackFunc = null)
    {
        Action curCallbackFunc = callbackFunc ?? standardCallback;
        if (isPlayer1)
        {
            p1Callback = curCallbackFunc; // callback when p1 done speaking.

            //freeze player
            p1move p1MoveScript = GameObject.FindGameObjectWithTag("Player1").GetComponent<p1move>();
            p1MoveScript.canMove = false;

            currentStory1 = new Story(inkJSON.text);
            dialogueIsPlaying1 = true;
            p1DialoguePanel.SetActive(true);

            ContinueStory(true); //player 1 continues
        }
        else
        {
            //freeze player
            p2Callback = curCallbackFunc; // callback when p2 done speaking

            p2move p2MoveScript = GameObject.FindGameObjectWithTag("Player2").GetComponent<p2move>();
            p2MoveScript.canMove = false;

            currentStory2 = new Story(inkJSON.text);
            dialogueIsPlaying2 = true;
            p2DialoguePanel.SetActive(true);
        }

            ContinueStory(false); // player 2 continues
    }

    private IEnumerator ExitDialogueMode(bool isPlayer1)
    {

        yield return new WaitForSeconds(0.2f);

        if (isPlayer1){

            dialogueIsPlaying1 = false;
            p1DialoguePanel.SetActive(false);
            p1DialogueText.text = "";
            p1move p1MoveScript = GameObject.FindGameObjectWithTag("Player1").GetComponent<p1move>();
            p1MoveScript.canMove = true;

            Action curCallbackFunc = p1Callback ?? standardCallback; // runs player 1 callback
            curCallbackFunc.Invoke();

            p1Callback = null; // IMPORTANT: RESETS 
            
        } else {
            dialogueIsPlaying2 = false;
            p2DialoguePanel.SetActive(false);
            p2DialogueText.text = "";
            p2move p2MoveScript = GameObject.FindGameObjectWithTag("Player2").GetComponent<p2move>();
            p2MoveScript.canMove = true;

            Action curCallbackFunc = p2Callback ?? standardCallback;
            curCallbackFunc.Invoke();

            p2Callback = null;
        }


        // Enable player movement for both players here if needed
    }

    private void ContinueStory(bool isPlayer1)
    {
        if (isPlayer1)
        {
            if (currentStory1 != null && currentStory1.canContinue)
            {
                p1DialogueText.text = currentStory1.Continue();
                // DisplayChoices(p1Choices, p1ChoicesText, true);
            }
            else
            {
                StartCoroutine(ExitDialogueMode(true)); // is player 1
            }
        }
        else
        {
            if (currentStory2 != null && currentStory2.canContinue)
            {
                p2DialogueText.text = currentStory2.Continue();
                // DisplayChoices(p2Choices, p2ChoicesText, false);
            }
            else
            {
                StartCoroutine(ExitDialogueMode(false)); // is player 2
            }
        }
    }


    // private void DisplayChoices(GameObject[] choicesArray, TextMeshProUGUI[] choicesTextArray, bool isPlayer1)
    // {
    //     List<Choice> currentChoices;
    //     if (isPlayer1){
    //         currentChoices = currentStory1.currentChoices;
    //     } else {
    //         currentChoices = currentStory2.currentChoices;
    //     }
        

    //     // defensive check to make sure our UI can support the number of choices coming in
    //     if (currentChoices.Count > choicesArray.Length)
    //     {
    //         Debug.LogError("More choices were given than the UI can support. Number of choices given: "
    //             + currentChoices.Count);
    //     }

    //     int index = 0;
    //     // enable and initialize the choices up to the amount of choices for this line of dialogue
    //     foreach (Choice choice in currentChoices)
    //     {
    //         choicesArray[index].gameObject.SetActive(true);
    //         choicesTextArray[index].text = choice.text;
    //         index++;
    //     }
    //     // go through the remaining choices the UI supports and make sure they're hidden
    //     for (int i = index; i < choicesArray.Length; i++)
    //     {
    //         choicesArray[i].gameObject.SetActive(false);
    //     }

    //     StartCoroutine(SelectFirstChoice(choicesArray));
    // }

    // private IEnumerator SelectFirstChoice(GameObject[] choicesArray)
    // {
    //     // Event System requires we clear it first, then wait
    //     // for at least one frame before we set the current selected object.
    //     EventSystem.current.SetSelectedGameObject(null);
    //     yield return new WaitForEndOfFrame();
    //     EventSystem.current.SetSelectedGameObject(choicesArray[0].gameObject);
    // }

    // public void MakeChoice(string choice)
    // {
    //     // first index is choice, and second is player
    //     if (choice[1] == '1'){
    //         Debug.Log(int.Parse(choice[0].ToString()));
    //         currentStory1.ChooseChoiceIndex(int.Parse(choice[0].ToString()));
    //         // The below two lines were added to fix a bug after the Youtube video was made
    //         InputManager.GetInstance().RegisterSubmitPressed(); // this is specific to my InputManager script
    //         ContinueStory(true);
    //     } else if (choice[1] != '1'){
    //         currentStory2.ChooseChoiceIndex(int.Parse(choice[0].ToString()));
    //         // The below two lines were added to fix a bug after the Youtube video was made
    //         InputManager1.GetInstance().RegisterSubmitPressed(); // this is specific to my InputManager script
    //         ContinueStory(false);
    //     }

    // }
}
