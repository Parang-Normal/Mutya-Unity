using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WASD_movement : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float jumpHeight = 5.0f;

    [SerializeField] private GameObject MainSprite = null;

    [SerializeField] private Sprite Forward = null;
    [SerializeField] private Sprite Backward = null;
    [SerializeField] private Sprite Left = null;
    [SerializeField] private Sprite Right = null;

    private Animator anim;

    private enum Direction
    {
        FORWARD,
        BACKWARD,
        LEFT,
        RIGHT,
        JUMP,
        NONE
    }

    private Direction currentDir = Direction.NONE;
    private bool jump = false;
    private SpriteRenderer spriteR;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        this.InputListen();
        this.Move();
    }

    private void InputListen()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            this.anim.SetInteger("Direction", 3);
            this.anim.SetBool("Forward_Walk", true);
            this.currentDir = Direction.FORWARD;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            this.anim.SetInteger("Direction", 2);
            this.anim.SetBool("Backward_Walk", true);
            this.currentDir = Direction.BACKWARD;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            this.anim.SetInteger("Direction", 1);
            this.anim.SetBool("Left_Walk", true);
            this.currentDir = Direction.LEFT;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            this.anim.SetInteger("Direction", 0);
            this.anim.SetBool("Right_Walk", true);
            this.currentDir = Direction.RIGHT;
        }
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D)) //|| Input.GetKeyUp(KeyCode.Space))
        {
            this.anim.SetBool("Left_Walk", false);
            this.anim.SetBool("Right_Walk", false);
            this.anim.SetBool("Backward_Walk", false);
            this.anim.SetBool("Forward_Walk", false);
            this.currentDir = Direction.NONE;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //this.currentDir = Direction.JUMP;
            this.jump = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            this.jump = false;
        }
    }

    private void Move()
    {
        this.spriteR = this.MainSprite.GetComponent<SpriteRenderer>();


        if (this.currentDir == Direction.FORWARD)
        {
            this.spriteR.sprite = this.Forward;
            this.gameObject.transform.Translate(Vector3.forward * Time.deltaTime * this.speed);
        }
        else if (this.currentDir == Direction.BACKWARD)
        {
            this.spriteR.sprite = this.Backward;
            this.gameObject.transform.Translate(Vector3.back * Time.deltaTime * this.speed);
        }
        else if (this.currentDir == Direction.RIGHT)
        {
            this.spriteR.sprite = this.Right;
            this.gameObject.transform.Translate(Vector3.right * Time.deltaTime * this.speed);
        }
        else if (this.currentDir == Direction.LEFT)
        {
            this.spriteR.sprite = this.Left;
            this.gameObject.transform.Translate(Vector3.left * Time.deltaTime * this.speed);
        }
        if (this.jump == true)
        {
            this.gameObject.transform.Translate(Vector3.up * Time.deltaTime * this.jumpHeight);
        }
    }
}
