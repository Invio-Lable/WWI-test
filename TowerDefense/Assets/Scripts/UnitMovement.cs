using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    public Vector3 startPoint;
    public Vector3 endPoint;
    public float speed;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPoint, speed * Time.deltaTime);

        if (transform.position == endPoint)
        {
            Destroy(gameObject);
        }
    }
}
