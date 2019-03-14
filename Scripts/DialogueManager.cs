using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class DialogueManager : MonoBehaviour
{
    public GameObject dBox;

    public Text dText;

    public bool dialogueActive;

    public TextAsset textFile;

    public string[] textLines;

    public int currentLine;

    public int endAtLine;
     
    private PlayerController thePlayer;

    private bool isTyping = false;

    private bool cancelTyping = false;

    private float typeSpeed = 0.02f;

    private SFXManager continueSound;

    



    // Start is called before the first frame update
    void Start()
    {
        //get access to PlayerController script
        thePlayer = FindObjectOfType<PlayerController>();
        continueSound = FindObjectOfType<SFXManager>();

        //display text line by from text sheet
        if (textFile != null)
        {
            textLines = textFile.text.Split('\n');
        }

        //get the last line of text. Each /new line in text is an index
        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }

        //simply activate or deactive dialogue box when need
        if (dialogueActive)
        {
            EnableDialogueBox();
        }
        else
        {
            DisableDialogueBox();
        }

    }

    // Update is called once per frame
    void Update()
    {
        //no need to update here if there is no dialogue box
        if (!dialogueActive)
        {
            return;
        }

        if(PauseMenu.isPaused)
        {
            return;
        }

        //if box is active display 1 index of text at a time
        //dText.text = textLines[currentLine];

        //everytime player hits space print next line
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(!isTyping)
            {

                currentLine += 1;

                //once you reach the last index disable dialogue box
                if (currentLine > endAtLine)
                {
                    DisableDialogueBox();
                } else
                {

                    StartCoroutine(TextScroll(textLines[currentLine]));
                }

            } else if (isTyping && !cancelTyping)
            {
                continueSound.spaceContinue.Play();
                cancelTyping = true;
            }
            continueSound.spaceContinue.Play();

        }


     


    }

    //a Coroutine happens at the same time as next set of code from when it was called
    private IEnumerator TextScroll(string lineOfText)
    {

        int letter = 0;
        dText.text = "";
        isTyping = true;
        cancelTyping = false;
        while (isTyping && !cancelTyping && (letter < lineOfText.Length-1))
        {
            dText.text += lineOfText[letter];
            letter += 1;
            yield return new WaitForSeconds(typeSpeed);

        }

        //if while text is typing and cancel typing is true break out of the coroutine
        dText.text = lineOfText;
        isTyping = false;
        cancelTyping = false;
    }

    //enables box and stop player from moving while reading text
    public void EnableDialogueBox()
    {
        dialogueActive = true;
        dBox.SetActive(true);
        thePlayer.canMove = false;

        StartCoroutine(TextScroll(textLines[currentLine]));

    }

    //disables box and allows player to move again
    public void DisableDialogueBox()
    {
        dialogueActive = false;
        dBox.SetActive(false);
        thePlayer.canMove = true;
    }


    //reload different text script as needed
    public void ReloadScript(TextAsset newText)
    {
        //makes sure we don't get empty textfile
        if(newText != null)
        {
            //empty old array and fill indices with new textfile and display it
            textLines = new string[1];
            textLines = newText.text.Split('\n');

            if (currentLine > endAtLine)
            {
                DisableDialogueBox();
            }
        } 

    }


}
