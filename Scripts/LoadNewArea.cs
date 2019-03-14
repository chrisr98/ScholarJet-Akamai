using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour
{
    public string levelName;

    public string exitPoint;

    private PlayerController thePlayer;


    // Start is called before the first frame update
    void Start()
    {
        //get access to PlayerController
        thePlayer = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ony triggers when it comes in contact with something
    void OnTriggerEnter2D(Collider2D other)
    {
        //if it is an entry point load next level by name
        if (other.gameObject.name == "Player")
        {
            SceneManager.LoadScene(levelName);
            //remebers entry point so it can be used as the same exit
            thePlayer.startPoint = exitPoint;
        }

//#pragma warning disable CS0618 // Type or member is obsolete
//        Application.LoadLevel(levelName);
//#pragma warning restore CS0618 // Type or member is obsolete
    }
}
