using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Vector3 startPoint;
    public Vector3 endPoint;
    public float speed;
    public float detectionRange = 5f; // ĳ������ ��������� ����

    private Transform target; // ֳ��, �� ��� �������� �����

    private void Update()
    {
        // ���� � ���� � ���� ����, �������� �� ��
        if (target != null && target.gameObject.activeInHierarchy)
        {
            MoveTowards(target.position);
        }
        else
        {
            // ������ ���� ����
            FindTarget("Unit");

            // ���� ���� ���, �������� �� ������ �����
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
        // ��������� �� ���� ������ �� ����
        GameObject[] units = GameObject.FindGameObjectsWithTag(tag);

        // ������ ����������� ����
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
