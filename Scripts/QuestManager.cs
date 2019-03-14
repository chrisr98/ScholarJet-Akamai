using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{

    public Slider questBar;

    public int[] check;

    private static bool questExsit;

    // Start is called before the first frame update
    void Start()
    {
        check = new int[8];
        if (!questExsit)
        {
            questExsit = true;
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

    }


    public void Increase(int x)
    {

        if (x == 0 && check[0] < 0)
        {
            check[0] += 1;
            questBar.value += 1;
            Debug.Log(check);
        } 
        else if (x == 1 && check[1] < 1)
        {
            check[1] += 1;
            questBar.value += 1;
            Debug.Log(check);
        }
        else if (x == 2 && check[2] < 2)
        {
            check[2] += 1;
            questBar.value += 1;
            Debug.Log(check);
        }
        else if (x == 3 && check[3] < 2)
        {
            check[3] += 1;
            questBar.value += 1;
            Debug.Log(check);
        }
        else if (x == 4 && check[4] < 3)
        {
            check[4] += 1;
            questBar.value += 1;
            Debug.Log(check);
        }
        else if (x == 5 && check[5] < 2)
        {
            check[5] += 1;
            questBar.value += 1;
            Debug.Log(check);
        }
        else if (x == 6 && check[6] < 1)
        {
            check[6] += 1;
            questBar.value += 1;
            Debug.Log(check);
        }
        else if (x == 7 && check[7] < 2)
        {
            check[7] += 1;
            questBar.value += 1;
            Debug.Log(check);
        }

    }
}
