using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float moveSpeed = 10f;

    private float currentMoveSpeed;

    private Animator anim;

    public int questStatus;

    public bool inMotion;

    public Vector2 lastMove;

    private Rigidbody2D myRigidBody;

    private static bool playerExist;

    public string startPoint;

    public bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        //Get current animator and rigibody component attached to player
        anim = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();

        //when loaded into new area don't destroy to carry over everything
        //check for duplicates
        if (!playerExist)
        {
            playerExist = true;
            DontDestroyOnLoad(transform.gameObject);
        } else
        {
            Destroy(gameObject);
        }


    }




    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.isPaused)
        {
            return;
        }

        if (!canMove)
        {
            currentMoveSpeed = 0f;
        }
        inMotion = false;

        //this regulates movement using blend tree
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            myRigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * currentMoveSpeed, myRigidBody.velocity.y);
            inMotion = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        } 

        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, Input.GetAxisRaw("Vertical") * currentMoveSpeed);
            inMotion = true;
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }

        if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5)
        {
            myRigidBody.velocity = new Vector2(0f, myRigidBody.velocity.y);
        } 

        if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f )
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, 0f);
        }

        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
        {
            currentMoveSpeed = moveSpeed / 1.5f;
        } else
        {
            currentMoveSpeed = moveSpeed;
        }

        //This tells the animator current state of player. Motion and direction
        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("InMotion", inMotion);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);

    }









    //void Update()
    //easier way to implement player movement but more like for space invaders(too ice skatyyy-ish). not RPG
    //{ 

    //    float moveHorizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
    //    float moveVertical = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

    //    transform.Translate(new Vector3(moveHorizontal, moveVertical));
    //}
}
