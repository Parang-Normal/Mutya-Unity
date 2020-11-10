using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainInstructions : MonoBehaviour
{
    [SerializeField] GameObject NextInstructions;
    private void OnTriggerExit()
    {
        Destroy(this.gameObject);
        this.NextInstructions.SetActive(true);
    }

}
