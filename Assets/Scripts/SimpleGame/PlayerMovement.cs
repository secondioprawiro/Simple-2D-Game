using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Data Hero")]
    public HeroData heroData;

    private float currentMoveSpeed;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // inisialisasi hero
        if (heroData != null)
        {
            currentMoveSpeed = heroData.moveSpeed;

            HealthSystem health = GetComponent<HealthSystem>();
            if (health != null)
            {
                health.maxHealth = heroData.maxHealth;
                health.currentHealth = heroData.maxHealth;
            }

            SwordDamage sword = GetComponentInChildren<SwordDamage>();
            if (sword != null)
            {
                sword.damage = heroData.attackDamage;
            }
        }
        else
        {
            currentMoveSpeed = 5f;
            Debug.LogWarning("Hero Data belum dimasukkan di Inspector!");
        }
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * currentMoveSpeed * Time.fixedDeltaTime);
    }
}