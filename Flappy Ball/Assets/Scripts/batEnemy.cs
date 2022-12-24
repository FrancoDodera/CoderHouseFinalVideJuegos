using System.Collections.Generic;
using UnityEngine;

public class batEnemy : MonoBehaviour
{   
    [SerializeField] List<Transform> waypoints;
    public float speed;
    public float changeDistance = 0.2f;
    public byte nextPosition;
    void Start()
    {
        
    }

    void Update()
    {
        EnemyMovement();
    }

    void EnemyMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[nextPosition]. transform.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, waypoints[nextPosition]. transform.position) < changeDistance)
        {
            nextPosition++;
            if (nextPosition >= waypoints.Count)
            {
                nextPosition = 0;
            }
        }
    }
}
