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
            ani.SetBool("attack01", true);
            enemy.exploding = true;
            GetComponent<SphereCollider>().enabled = false;
            Debug.Log("aaa");
            Destroy(gameObject, 2f);
        }
    }
}
