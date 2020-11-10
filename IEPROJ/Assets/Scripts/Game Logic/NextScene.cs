using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    [SerializeField] string TargetScene;
    [SerializeField] bool onAwake = false;

    private void OnEnable()
    {
        if (this.onAwake)
        {
            StartCoroutine(this.wait());
        }
    }

    public void next()
    {
        StartCoroutine(this.wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(this.TargetScene);
    }
}
