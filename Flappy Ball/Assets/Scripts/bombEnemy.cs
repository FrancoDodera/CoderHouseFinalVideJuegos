using UnityEngine;

public class bombEnemy : MonoBehaviour
{
    public int rutine;
    public float timer;
    public Animator ani;
    public int direction;
    public float speedWalk;
    public float speedRun;
    public Transform target;
    public bool exploding;

    public float visionRange;
    public float explosionRange;
    public GameObject range;
    public GameObject hit;

    void Start()
    {
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        Behaviour();
    }

    public void Behaviour()
    {
        if (Mathf.Abs(transform.position.x - target.transform.position.x) > visionRange && !exploding)
        {
            ani.SetBool("run", false);
            timer += 1 * Time.deltaTime;
            if (timer >= 3)
            {
                rutine = Random.Range(0, 2);
                timer = 0;
            }

            switch (rutine)
            {
                case 0:
                    ani.SetBool("walk", false);
                    break;

                case 1:
                    direction = Random.Range(0, 2);
                    rutine++;
                    break;

                case 2:
                    switch (direction)
                    {
                        case 0:
                            transform.rotation = Quaternion.Euler(0,270,0);
                            transform.Translate(Vector3.forward * speedWalk * Time.deltaTime);
                            break;

                        case 1:
                            transform.rotation = Quaternion.Euler(0,90,0);
                            transform.Translate(Vector3.forward * speedWalk * Time.deltaTime);
                            break;
                    }
                ani.SetBool("walk", true);
                break;
            }
        }
        // else
        // {
        //     if (Mathf.Abs(transform.position.x - target.transform.position.x) > explosionRange && !exploding)
        //     {
        //         if (transform.position.x < target.transform.position.x)
        //         {
        //             ani.SetBool("walk", false);
        //             ani.SetBool("run", true);
        //             transform.Translate(Vector3.forward * speedRun * Time.deltaTime);
        //             transform.rotation = Quaternion.Euler(0,270,0);
        //             ani.SetBool("attack01", false);
        //         }
        //         else
        //         {
        //             ani.SetBool("walk", false);
        //             ani.SetBool("run", true);
        //             transform.Translate(Vector3.forward * speedRun * Time.deltaTime);
        //             transform.rotation = Quaternion.Euler(0,90,0);
        //             ani.SetBool("attack01", false);
        //         }
        //     }
        //     else
        //     {
        //         if (!exploding)
        //         {
        //             if (transform.position.x < target.transform.position.x)
        //             {
        //                 transform.rotation = Quaternion.Euler(0,270,0);
        //             }
        //             else
        //             {
        //                 transform.rotation = Quaternion.Euler(0,90,0);
        //             }
        //             ani.SetBool("walk", false);
        //             ani.SetBool("run", false);
        //         }
        //     }
        // }
    }

    public void FinalAnimation()
    {
        ani.SetBool("attack01", false);
        exploding = false;
        range.GetComponent<SphereCollider>().enabled = true;
    }

    public void ColliderAttackTrue()
    {
        hit.GetComponent<SphereCollider>().enabled = true;
    }

    public void ColliderAttackFalse()
    {
        hit.GetComponent<SphereCollider>().enabled = true;
    }
}