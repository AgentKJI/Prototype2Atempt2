using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] private string levelName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            Application.LoadLevel(levelName);
        }
    }
}
