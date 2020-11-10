using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingSystem : MonoBehaviour
{
    [SerializeField] GameObject Text;
    [SerializeField] GameObject LoadingObject;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.Text.SetActive(false);
            this.LoadingObject.SetActive(true);
            for(int i = 0; i < this.LoadingObject.transform.childCount; i++)
            {
                this.LoadingObject.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
}
