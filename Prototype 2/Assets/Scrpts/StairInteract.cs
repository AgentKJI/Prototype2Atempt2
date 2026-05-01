using TMPro;
using UnityEngine;

public class StairInteract : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject Stairs;
    [SerializeField] private bool isActive = false;
    [SerializeField] private GameObject Text;
    [SerializeField] private bool isTextDestroyed = false;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerController.canInteract = true;
            Debug.Log("Player can interact with stairs");
            
            if (!isTextDestroyed)
            {
                Text.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerController.canInteract = false;
            if (!isTextDestroyed)
            {
                Text.SetActive(false);
            }
        }
    }

    public void Interaction()
    {
        if (!isActive)
        {
            Stairs.SetActive(true);

            DestroyObject(Text);
            isTextDestroyed = true;
            
        }
    }
}
