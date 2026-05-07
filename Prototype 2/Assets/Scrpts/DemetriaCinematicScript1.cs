using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DemetriaCinematicScript : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private string[] dialogueLines;
    [SerializeField] private float timeBetweenLines = 2f;
    [SerializeField] GameObject demetriaNPC;
    
        private int currentLineIndex = 0;

    private void Awake()
    {
        
    }
    public void StartCinematic()
    {


        StartCoroutine(PlayCinematic());

    }
    
        private IEnumerator PlayCinematic()
        {
        Debug.Log("Coroutine started");
        player.GetComponent<PlayerController>().enabled = false;
    
            yield return new WaitForSeconds(3.5f);

        Debug.Log("Wait finished, lines to show: " + dialogueLines.Length);
        while (currentLineIndex < dialogueLines.Length)
                {
                    Debug.Log("Showing line: " + dialogueLines[currentLineIndex]);
                    dialogueText.text = dialogueLines[currentLineIndex];
                    currentLineIndex++;
                    yield return new WaitForSeconds(timeBetweenLines);
                }
        SceneManager.LoadScene("Challenge3");

        player.GetComponent<PlayerController>().enabled = true;
        }

}

