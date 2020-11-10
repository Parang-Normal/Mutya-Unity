using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    [SerializeField] float offset = 0.1f;
    [SerializeField] float gravity = 0.5f;

    private float currentY;
    private float upperLimit;
    private float lowerLimit;

    private bool up = true;
    private bool down = false;

    // Start is called before the first frame update
    void Start()
    {
        this.currentY = this.gameObject.GetComponent<Transform>().position.y;
        this.upperLimit = this.currentY + this.offset;
        this.lowerLimit = this.currentY - this.offset;
    }

    // Update is called once per frame
    void Update()
    {
        this.currentY = this.gameObject.GetComponent<Transform>().position.y;

        if (this.currentY >= this.upperLimit)
        {
            this.up = false;
            this.down = true;
        }
        else if (this.currentY <= this.lowerLimit)
        {
            this.down = false;
            this.up = true;
        }

        this.move();
    }

    private void move()
    {
        if(this.up == true)
        {
            this.gameObject.transform.Translate(Vector3.up * Time.deltaTime * this.gravity);
        }
        else if(this.down == true)
        {
            this.gameObject.transform.Translate(Vector3.down * Time.deltaTime * this.gravity);
        }
    }
}
