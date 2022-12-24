using UnityEngine;


public class bombEnemy : MonoBehaviour
{
    public float timeChanger = 4f;
    public float timer;
    public Animator ani;
    public float speedWalk;
    public bool exploding;
    public bool isRigth;
    public GameObject range;
    public GameObject hit;

    void Start()
    {
        ani = GetComponent<Animator>();
        timer = timeChanger;
    }

    void Update()
    {
        Behaviour();
        Crono();
    }

    public void Behaviour()
    {
        if (!exploding)
        {
            if(isRigth == true)
            {
                transform.position += new Vector3(0.1f,0,0) * speedWalk * Time.deltaTime;
                transform.rotation = Quaternion.Euler(0,90,0);
                ani.SetBool("walk", true);
            }
            if(isRigth == false)
            {
                transform.position += new Vector3(-0.1f,0,0) * speedWalk * Time.deltaTime;
                transform.rotation = Quaternion.Euler(0,270,0);
                ani.SetBool("walk", true);
            }
        }
    }

    public void Crono()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timer = timeChanger;
            isRigth = !isRigth;
        }
    }
    
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("wall"))
        {
            Destroy(gameObject,0f);
        }
    }

}