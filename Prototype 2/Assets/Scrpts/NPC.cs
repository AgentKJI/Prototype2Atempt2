using System.Collections;
using TMPro;
using UnityEngine;


public class NPC : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private CassandraScript script;
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private bool isInConversation = false;
    [SerializeField] private int currentLine = 0;
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject target2;
    [SerializeField] private ParticleSystem deathEffect1;
    [SerializeField] private ParticleSystem deathEffect2;
    [SerializeField] private GameObject otherNPC;
    [SerializeField] private GunScript gunScript;
    public bool chosenPerson = false;
    private bool isDead = false;
    [SerializeField] private GameObject cutsceneForCassandra;
    [SerializeField] private CinematicScript cinematicScript;
    [SerializeField] private DemetriaCinematicScript demetriaCinematicScript;
    [SerializeField] private GameObject cutsceneForDemetria;
    private bool hasRun = false;
    
    private int lastLine = 0;


    private void Update()
    {
        if (isDead)
        {
            return;
        }

        if (gameObject.CompareTag("NPC1") && chosenPerson && !hasRun)  //&& dialogueBox != null
        {
            hasRun = true;
            //dialogueText.text = script.dialogue[currentLine];
            //dialogueBox.SetActive(true);


            gunScript.canShoot = false;
            cutsceneForCassandra.SetActive(true);

            cinematicScript.StartCinematic();

        }
        else if (gameObject.CompareTag("NPC2") && chosenPerson && !hasRun)
        {             
            hasRun = true;
            gunScript.canShoot = false;
            cutsceneForDemetria.SetActive(true);

            demetriaCinematicScript.StartCinematic();
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueBox.SetActive(true);
            dialogueText.text = script.dialogue[currentLine];
            playerController.canInteract = true;
            isInConversation = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueBox.SetActive(false);
            currentLine = 0; // reset to the first line when player leaves
            playerController.canInteract = false;
            isInConversation = false;
        }
    }



    public void conversation()
    {
        if (isInConversation)
        {
            Debug.Log("Player is in conversation with NPC");

            currentLine++;

            if (currentLine >= script.dialogue.Length)
            {
                currentLine = 0;
            }

            dialogueText.text = script.dialogue[currentLine];
        }

    }

    public void Death(bool isNPC1)
    {
        //gunScript.canShoot = false;

        isDead = true;
        if (isNPC1)
        {
            deathEffect1.Play();
            target.SetActive(false);
            Destroy(dialogueBox,0.99f);
            chosenPerson = true;
            Destroy(gameObject, 1);
            otherNPC.GetComponent<NPC>().chosenPerson = true;




        }
        if (!isNPC1)
        {
            deathEffect2.Play();
            target2.SetActive(false);
            Destroy(dialogueBox,0.99f);
            chosenPerson = true;
            Destroy(gameObject, 1);
            otherNPC.GetComponent<NPC>().chosenPerson = true;


        }
    }
}
