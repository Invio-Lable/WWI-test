using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Vector2 startPoint;
    public Transform towerTransform; // Додано змінну для трансформу вежі
    public float speed;
    public float detectionRange = 5f; // Діапазон виявлення юнітів

    private Transform target; // Ціль, до якої рухається ворог

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
            FindTarget("Unit");

            // Якщо немає цілі, рухаємося до вежі
            if (target == null && towerTransform != null)
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
        // Знаходимо всі юніти гравця на сцені
        GameObject[] units = GameObject.FindGameObjectsWithTag(tag);

        // Шукаємо найближчого юніта
        float closestDistance = detectionRange;
        foreach (GameObject unit in units)
        {
            float distance = Vector2.Distance(transform.position, unit.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                target = unit.transform;
            }
        }
    }
}
