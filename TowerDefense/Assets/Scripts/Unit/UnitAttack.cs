using UnityEngine;

public class UnitAttack : MonoBehaviour
{
    public UnitData unitData;
    private float attackTimer;
    private Animator animator;
    private Collider2D target;
    private EnemyTower enemyTower;

    private void Start()
    {
        animator = GetComponent<Animator>();
        enemyTower = FindObjectOfType<EnemyTower>();
    }

    private void Update()
    {
        attackTimer += Time.deltaTime;

        if (target != null && attackTimer >= unitData.attackSpeed)
        {
            animator.SetTrigger("attack");
            attackTimer = 0f;

            EnemyHealth enemyHealth = target.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(unitData.damage);
            }
        }
        else if (target == null && enemyTower != null && Vector2.Distance(transform.position, enemyTower.transform.position) < 1.0f && attackTimer >= unitData.attackSpeed)
        {
            animator.SetTrigger("attack");
            attackTimer = 0f;
            enemyTower.TakeDamage(unitData.damage);
        }
        else
        {
            animator.SetTrigger("walk");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            target = collision;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            target = null;
            animator.SetTrigger("walk");
        }
    }
}
