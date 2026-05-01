using UnityEngine;

public class SoulScript : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private Material doorMaterial;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has collected the soul");
           
            door.GetComponent<MeshRenderer>().material = doorMaterial;
            door.GetComponent<BoxCollider>().isTrigger = true;
            Destroy(gameObject);
        }
    }
}
