using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.UI;

public class collisionController : MonoBehaviour
{
    [SerializeField] private GameObject object_1 = null;
    [SerializeField] private GameObject object_2 = null;
    [SerializeField] private GameObject button = null;

    private GameObject newObject = null;
    private BoxCollider box_1 = null;
    private BoxCollider box_2 = null;
    private Image buttonImage = null;

    // Start is called before the first frame update
    void Start()
    {
        this.box_1 = this.object_1.GetComponent<BoxCollider>();
        this.box_2 = this.object_2.GetComponent<BoxCollider>();
        this.buttonImage = this.button.GetComponent<Image>();
        this.newObject = Instantiate(this.button);
        this.newObject.transform.SetParent(this.button.transform);
       // this.newObject.AddComponent<RectTransform>();
        this.newObject.GetComponent<RectTransform>().position = this.button.GetComponent<RectTransform>().position;
        this.newObject.GetComponent<RectTransform>().rotation = this.button.GetComponent<RectTransform>().rotation;
        this.newObject.GetComponent<RectTransform>().localScale = this.button.GetComponent<RectTransform>().localScale;
        //this.newObject.transform.position = this.button.GetComponent<Transform>().position;
        this.newObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.box_1.bounds.Intersects(this.box_2.bounds))
        {
           // this.newObject.AddComponent<Image>();
            this.newObject.GetComponent<Image>().sprite = this.object_2.GetComponentInChildren<SpriteRenderer>().sprite;
            this.object_2.SetActive(false);
            this.newObject.SetActive(true);
        }
    }
}
