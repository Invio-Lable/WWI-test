using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    public Vector2 startPoint;
    public Transform towerTransform;
    public float speed;
    public float detectionRange = 5f;

    private Transform target;

    private void Update()
    {
        if (target != null && target.gameObject.activeInHierarchy)
        {
            MoveTowards(target.position);
        }
        else
        {
            FindTarget("Enemy");

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
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(tag);

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
