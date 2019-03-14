using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueHolder : MonoBehaviour
{

    private DialogueManager dManager;

    public TextAsset theText;

    public int startLine;

    public int endLine;

    public bool destroyIfActivated;

    public bool requireButtonPress;

    private bool waitForPress;

    private SFXManager speechSFX;

    public QuestManager questCompletion;

    public int houseNumber;

    public int personNUM;

    public JournalEntryMG jUI;

    // Start is called before the first frame update
    void Start()
    {
        //get access to DialogueManager
        dManager = FindObjectOfType<DialogueManager>();
        speechSFX = FindObjectOfType<SFXManager>();
        questCompletion = FindObjectOfType<QuestManager>();
        jUI = FindObjectOfType<JournalEntryMG>();



    }

    // Update is called once per frame
    void Update()
    {
    
        if (waitForPress && Input.GetKeyDown(KeyCode.X))
        {
            speechSFX.chrisVocal.Play();
            questCompletion.Increase(houseNumber);
            jUI.Display(personNUM);
            //load up display text at given lines
            dManager.ReloadScript(theText);
            dManager.currentLine = startLine;
            dManager.endAtLine = endLine;
            dManager.EnableDialogueBox();


            //if dialogue not needed destroy activation zon
            if (destroyIfActivated)
            {
                Destroy(gameObject);
            }


        }
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        //if player is in activation zone to talk to NPC
        if (other.gameObject.name == "Player")
        {
            //if player needs to iniate converstation
            if(requireButtonPress)
            {
                waitForPress = true;
                return;
            }
            //load up display text at given lines
            dManager.ReloadScript(theText);
            dManager.currentLine = startLine;
            dManager.endAtLine = endLine;
            dManager.EnableDialogueBox();

            //if dialogue not needed destroy activation zon
            if (destroyIfActivated)
            {
                Destroy(gameObject);
            }


        }

    }

   

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            waitForPress = false;
        }
        //dManager.DisableDialogueBox();

    }
}

