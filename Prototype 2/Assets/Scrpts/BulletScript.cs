using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float bulletSpeed = 20f;



    void Update()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC1"))
        {
            other.GetComponent<NPC>().Death(true);

            Destroy(gameObject);

        }
        if (other.CompareTag("NPC2"))
        {
            other.GetComponent<NPC>().Death(false);

            Destroy(gameObject);

        }
    }

    public void destroyBullet()
    {
        Destroy(gameObject);
    }
}


