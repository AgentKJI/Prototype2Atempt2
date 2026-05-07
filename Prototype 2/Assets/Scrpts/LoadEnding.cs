using System.Collections;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadEnding : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(LoadEndingIEnumerator());       
    }

    private IEnumerator LoadEndingIEnumerator()
    {
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene("Ending");

    }
    
}
