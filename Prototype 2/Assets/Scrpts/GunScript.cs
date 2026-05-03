using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.VFX;
public class GunScript : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    public bool canShoot;
    public void Shoot(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (canShoot)
            {
                Instantiate(bulletPrefab, transform.position, transform.rotation);
            }
            else return;
        }
    }

    public void shootForCinematic()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}
