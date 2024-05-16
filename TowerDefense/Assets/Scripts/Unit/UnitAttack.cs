using UnityEngine;

public class UnitAttack : MonoBehaviour
{
    public UnitData unitData; // Додано змінну для даних юніта
    private float attackTimer;
    private Animator animator;
    private Collider2D target;
    private Tower tower; // Додано змінну для вежі

    private void Start()
    {
        animator = GetComponent<Animator>();
        tower = FindObjectOfType<Tower>(); // Знаходимо вежу на сцені
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
        else if (target == null && tower != null && Vector2.Distance(transform.position, tower.transform.position) < 1.0f && attackTimer >= unitData.attackSpeed)
        {
            animator.SetTrigger("attack");
            attackTimer = 0f;
            tower.TakeDamage(unitData.damage);
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
