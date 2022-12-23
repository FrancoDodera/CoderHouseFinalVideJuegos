using UnityEngine;

public class enemyRange : MonoBehaviour
{
    public Animator ani;
    public bombEnemy enemy;

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            ani.SetBool("walk", false);
            ani.SetBool("run", false);
            ani.SetBool("attack01", false);
            enemy.exploding = true;
            GetComponent<SphereCollider>().enabled = false;
        }
    }
}
