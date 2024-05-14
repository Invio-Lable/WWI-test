using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Vector3 startPoint;
    public Vector3 endPoint;
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
        // Знаходимо всі юніти гравця на сцені
        GameObject[] units = GameObject.FindGameObjectsWithTag(tag);

        // Шукаємо найближчого юніта
        float closestDistance = detectionRange;
        foreach (GameObject unit in units)
        {
            float distance = Vector3.Distance(transform.position, unit.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                target = unit.transform;
            }
        }
    }
}
