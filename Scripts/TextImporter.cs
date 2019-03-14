using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextImporter : MonoBehaviour
{

    public string[] npcs;

    public int[] check;

    public int index;

    public DialogueHolder dHolder;

    public QuestManager questCompletion;



    // Start is called before the first frame update
    void Start()
    {
        //npcs = new string[]{"Mr. Smith", "Mrs. Smith", "Amelia", "Steven", };
        //check = new int[20];

    }

    // Update is called once per frame
    void Update()
    {
      
    }


    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    GameObject MrSmith = GameObject.FindWithTag("Mr. Smith");
    //    GameObject MrsSmith = GameObject.FindWithTag("Mrs. Smith");
    //    GameObject Amelia = GameObject.FindWithTag("Amelia");

    //    Debug.Log(MrSmith);
    //    Debug.Log(check);

    //    if (other.gameObject.name == "Mr. Smith")
    //    {
    //        dHolder = MrSmith.GetComponent<DialogueHolder>();
    //        if (dHolder.completed == 1)
    //        {
    //            Debug.Log(dHolder.completed);
    //            check[0] += 1;
    //            if (check[0] == 1)
    //                questCompletion.Increase1();
    //        }
    //    }
    //    else if (other.gameObject.name == "Mrs. Smith")
    //    {
    //        dHolder = MrsSmith.GetComponent<DialogueHolder>();
    //        if (dHolder.completed == 1)
    //        {
    //            check[1] += 1;
    //            if (check[1] == 1)
    //                questCompletion.Increase1();
    //        }
    //    }
    //    else if (other.gameObject.name == "Amelia")
    //    {
    //        dHolder = Amelia.GetComponent<DialogueHolder>();
    //        //check[2] += 1;
    //        if (dHolder.completed == 1)
    //        {
    //            check[2] += 1;
    //            if (check[2] == 1)
    //                questCompletion.Increase1();
    //        }

    //    }
    //}

    //public void Add(int x)
    //{
    //    if(check[x] == 0)
    //    {
    //        check[x] = 1;

    //    }
    //}
}
