using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalManager : MonoBehaviour
{
    public PauseMenu pausedMG;

    public GameObject journalUI;

    private static bool journalExist;

    // Start is called before the first frame update
    void Start()
    {
        if (!journalExist)
        {
            journalExist = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        pausedMG = FindObjectOfType<PauseMenu>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void Journal()
    {
        journalUI.SetActive(true);
    }

    public void Back()
    {
        journalUI.SetActive(false);
    }
}
