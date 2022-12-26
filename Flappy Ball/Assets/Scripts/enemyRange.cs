using UnityEngine;

public class enemyRange : MonoBehaviour
{
    public Animator ani;
    public bombEnemy enemy;
    public GameObject explosion;

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            ani.SetBool("walk", false);
            ani.SetBool("run", false);
            ani.SetBool("attack01", true);
            Instantiate(explosion);
            enemy.exploding = true;
            GetComponent<SphereCollider>().enabled = false;
            Destroy(gameObject, 2f);
            
        }
    }
}
