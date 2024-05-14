using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    public Vector3 startPoint;
    public Vector3 endPoint;
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

            // Якщо немає цілі, рухаємося до кінцевої точки
            if (target == null)
            {
                MoveTowards(endPoint);
            }
        }
    }

    private void MoveTowards(Vector3 position)
    {
        transform.position = Vector3.MoveTowards(transform.position, position, speed * Time.deltaTime);
    }

    private void FindTarget(string tag)
    {
        // Знаходимо всіх ворогів на сцені
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(tag);

        // Шукаємо найближчого ворога
        float closestDistance = detectionRange;
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                target = enemy.transform;
            }
        }
    }
}
