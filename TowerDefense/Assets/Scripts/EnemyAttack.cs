using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public EnemyData enemyData;
    private float attackTimer;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        attackTimer += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Unit") && attackTimer >= enemyData.attackSpeed)
        {
            animator.SetTrigger("attack");
            attackTimer = 0f;

            UnitHealth playerUnitHealth = collision.gameObject.GetComponent<UnitHealth>();
            if (playerUnitHealth != null)
            {
                playerUnitHealth.TakeDamage(enemyData.damage);
            }
        }
    }
}