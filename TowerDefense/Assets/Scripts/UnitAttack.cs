using UnityEngine;

public class UnitAttack : MonoBehaviour
{
    public UnitData unitData;
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= unitData.attackSpeed)
            {
                animator.SetTrigger("attack");
                attackTimer = 0f;

                EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(unitData.damage);
                }
            }
        }
    }
}