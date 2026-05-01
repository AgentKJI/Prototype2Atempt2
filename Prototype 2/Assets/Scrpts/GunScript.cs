using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.VFX;
public class GunScript : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    public bool canShoot = true;
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
}
