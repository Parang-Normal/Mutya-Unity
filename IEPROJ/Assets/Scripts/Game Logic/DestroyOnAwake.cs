using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnAwake : MonoBehaviour
{
    [SerializeField] GameObject TargetToDestroy;

    private void Awake()
    {
        Destroy(this.TargetToDestroy);
    }
}
