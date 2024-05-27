using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{

    public Transform platform;
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 1.5f;

    int direction = 1;

    private void Update()
    {
        Vector2 target = currentMovementTarget();

        platform.position = Vector2.MoveTowards(platform.position, target, speed * Time.deltaTime);

        float distance = Vector2.Distance(platform.position, target);

        if (distance <= 0.1f)
        {
            SwitchDirection();
        }
    }

    void SwitchDirection()
    {
        direction *= -1;
    }

    Vector2 currentMovementTarget()
    {
        if (direction == 1)
        {
            return endPoint.position;
        }
        else
        {
            return startPoint.position;
        }
    }

    private void OnDrawGizmos()
    {
        // Debug Line
        Gizmos.DrawLine(platform.transform.position, startPoint.position);
        Gizmos.DrawLine(platform.transform.position, endPoint.position);
    }
}
