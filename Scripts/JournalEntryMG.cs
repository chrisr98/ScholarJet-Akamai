using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalEntryMG : MonoBehaviour
{
    public GameObject education;

    public GameObject coding;

    public GameObject lang;

    public GameObject volunteer;

    public GameObject skills;

    public GameObject project;

    public GameObject work;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Display(int x)
    {
        if (x == 0)
        {
            return;
        } else if (x == 1)
        {
            education.SetActive(true);
        }
        else if (x == 2)
        {
            coding.SetActive(true);
        }
        else if (x == 3)
        {
            lang.SetActive(true);
        }
        else if (x == 4)
        {
            volunteer.SetActive(true);
        }
        else if (x == 5)
        {
            skills.SetActive(true);
        }
        else if (x == 6)
        {
            project.SetActive(true);
        }
        else if (x == 7)
        {
            work.SetActive(true);
        }
    }

}
