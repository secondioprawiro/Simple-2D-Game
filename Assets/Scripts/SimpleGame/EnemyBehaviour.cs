using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public EnemyData data;

    private float waitTime;
    private Vector2 startPosition;
    private Vector2 targetPosition;
    private Rigidbody2D rb;

    private float moveTimeOut = 3f;
    private float currentMoveTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;

        if (data != null)
        {
            waitTime = 2f;
        }

        SetRandomDestination();

        //var health = GetComponent<HealthSystem>();
        //if (health != null)
        //{
        //    health.maxHealth = data.maxHealth;
        //    health.currentHealth = data.maxHealth;
        //}
    }

    void FixedUpdate()
    {
        if (data != null)
        {
            Vector2 newPos = Vector2.MoveTowards(rb.position, targetPosition, data.speed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
        }

        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            if (waitTime > 0)
            {
                waitTime -= Time.fixedDeltaTime;
            }
            else
            {
                SetRandomDestination();
                waitTime = 2f;
            }
        }
        else
        {
            if (currentMoveTime <= 0)
            {
                SetRandomDestination();
            }
        }
    }

    void SetRandomDestination()
    {
        currentMoveTime = moveTimeOut;

        Vector2 randomPoint = Random.insideUnitCircle * data.patrolRange;
        targetPosition = startPosition + randomPoint;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HealthSystem playerHealth = collision.gameObject.GetComponent<HealthSystem>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(data != null ? data.damage : 1);
            }
        }
        else if (!collision.gameObject.CompareTag("Enemy"))
        {
            SetRandomDestination();
        }
    }
}
