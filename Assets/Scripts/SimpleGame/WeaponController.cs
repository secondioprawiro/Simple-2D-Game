using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Transform weaponTransform;
    public Animator weaponAnimator; //animation for sword

    void Update()
    {
        RotateWeapon();
        Attack();
    }

    void RotateWeapon()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = mousePos - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        weaponTransform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Menyerang!");

            // weaponAnimator.SetTrigger("Attack");
        }
    }
}