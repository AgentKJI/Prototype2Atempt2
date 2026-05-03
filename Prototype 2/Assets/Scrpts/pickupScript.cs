using UnityEngine;

public class pickupScript : MonoBehaviour
{
    [SerializeField] private GameObject script;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            script.SetActive(true);            
            Destroy(gameObject);
        }
    }

}
