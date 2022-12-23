using UnityEngine;

public class hitEnemy : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            print("daño");
        }
    }
}
