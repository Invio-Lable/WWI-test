using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    public Vector2 startPoint;
    public Transform towerTransform; // Додано змінну для вежі
    public float speed;
    public float detectionRange = 5f; // Діапазон виявлення ворогів

    private Transform target; // Ціль, до якої рухається юніт

    private void Update()
    {
        // Якщо є ціль і вона жива, рухаємося до неї
        if (target != null && target.gameObject.activeInHierarchy)
        {
            MoveTowards(target.position);
        }
        else
        {
            // Шукаємо нову ціль
            FindTarget("Enemy");

            // Якщо немає цілі, рухаємося до вежі
            if (target == null)
            {
                MoveTowards(towerTransform.position);
            }
        }
    }

    private void MoveTowards(Vector3 position)
    {
        transform.position = Vector2.MoveTowards(transform.position, position, speed * Time.deltaTime);
    }

    private void FindTarget(string tag)
    {
        // Знаходимо всіх ворогів на сцені
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(tag);

        // Шукаємо найближчого ворога
        float closestDistance = detectionRange;
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                target = enemy.transform;
            }
        }
    }
}
