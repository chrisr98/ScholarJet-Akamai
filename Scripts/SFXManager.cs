using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource spaceContinue;
    public AudioSource chrisVocal;

    private static bool sfxManExists;
    // Start is called before the first frame update
    void Start()
    {
        if (!sfxManExists)
        {
            sfxManExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.isPaused)
        {
            spaceContinue.pitch = 0f;
            chrisVocal.pitch = 0f;
        }
    }
}
