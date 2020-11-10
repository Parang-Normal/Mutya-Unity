using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_WASDMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float jumpHeight = 5.0f;

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

    // Start is called before the first frame update
    void Start()
    {
        
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
            this.currentDir = Direction.FORWARD;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            this.currentDir = Direction.BACKWARD;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            this.currentDir = Direction.LEFT;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            this.currentDir = Direction.RIGHT;
        }
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D)) //|| Input.GetKeyUp(KeyCode.Space))
        {
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

        if (this.currentDir == Direction.FORWARD)
        {
            this.gameObject.transform.Translate(Vector3.forward * Time.deltaTime * this.speed);
        }
        else if (this.currentDir == Direction.BACKWARD)
        {
            this.gameObject.transform.Translate(Vector3.back * Time.deltaTime * this.speed);
        }
        else if (this.currentDir == Direction.RIGHT)
        {
            this.gameObject.transform.Translate(Vector3.right * Time.deltaTime * this.speed);
        }
        else if (this.currentDir == Direction.LEFT)
        {
            this.gameObject.transform.Translate(Vector3.left * Time.deltaTime * this.speed);
        }
        if (this.jump == true)
        {
            this.gameObject.transform.Translate(Vector3.up * Time.deltaTime * this.jumpHeight);
        }
    }
}
