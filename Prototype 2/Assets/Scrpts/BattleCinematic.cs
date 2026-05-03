using System.Collections;
using UnityEditor.Rendering;
using UnityEngine;

public class BattleCinematic : MonoBehaviour
{
    [SerializeField] private GameObject UI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        StartCoroutine(PlayBattleScene());

        

    }

    private IEnumerator PlayBattleScene()
    {
        yield return new WaitForSeconds(21f);
        Cursor.visible = true;  
        Cursor.lockState = CursorLockMode.Confined;

        UI.SetActive(true);
        gameObject.SetActive(false);
    }
}