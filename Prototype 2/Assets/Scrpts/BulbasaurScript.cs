using UnityEngine;

public class BulbasaurScript : MonoBehaviour
{
    [SerializeField] private GameObject FinalCutscene;
    [SerializeField] private GameObject button;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {

            other.gameObject.GetComponent<BulletScript>().destroyBullet();
            button.SetActive(false);
            FinalCutscene.SetActive(true);

            Destroy(gameObject);

        }
    }
}
