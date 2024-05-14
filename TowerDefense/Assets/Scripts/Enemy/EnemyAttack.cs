using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public EnemyData enemyData;
    private float attackTimer;
    private Animator animator;
    private Collider2D target;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        attackTimer += Time.deltaTime;

        if (target != null && attackTimer >= enemyData.attackSpeed)
        {
            animator.SetTrigger("attack");
            attackTimer = 0f;

            UnitHealth unitHealth = target.GetComponent<UnitHealth>();
            if (unitHealth != null)
            {
                unitHealth.TakeDamage(enemyData.damage);
            }
        }
        else
        {
            animator.SetTrigger("walk");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Unit"))
        {
            target = collision;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Unit"))
        {
            target = null;
            animator.SetTrigger("walk");
        }
    }
}
