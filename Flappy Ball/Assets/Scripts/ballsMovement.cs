using UnityEngine;

public class ballsMovement : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    public float doubleJumpSpeed;
    public Rigidbody rb;
    private bool m_isGrounded;
    private bool canDoubleJump;
    public float coinsColected;
    public float lives = 3f;
    public Vector3 respawnPoint;
    public float timer;
    float damage = 2f;
    public GameObject hit;
    public GameObject vida3;
    public GameObject vida2;
    public GameObject vida1;
    public GameObject corazonVacio3;
    public GameObject corazonVacio2;
    public GameObject corazonVacio1;
    public GameObject textDetected;
    public GameObject SonidoSalto;
    public GameObject coincollect;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        m_isGrounded = true;
        textDetected.SetActive(false);
    }
    private void Update()
    {
        Jump();
        if(lives == 0f)
        {
            Respawn();
            Debug.Log("¡¡¡YOU LOST!!!");
        }
    }
    void FixedUpdate()
    {
        CharacterMovement();
    }
    void CharacterMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 vector = new Vector3(horizontal,0,0);
        rb.AddForce(vector * speed * Time.deltaTime);
        
    }
    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(m_isGrounded == true)
            {
                rb.AddForce(0, jumpSpeed, 0, ForceMode.Impulse);
                canDoubleJump = true;
                Instantiate(SonidoSalto);
            }
            else
            {
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    if(canDoubleJump)
                    {
                        rb.AddForce(0, doubleJumpSpeed, 0, ForceMode.Impulse);
                        canDoubleJump = false;
                    }
                }
            }
            m_isGrounded = false;
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("floor"))
        {
            m_isGrounded = true;
        }
    
        
    }
    
    void Respawn()
    {
        transform.position = respawnPoint;
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.transform.gameObject.tag == "batEnemy")
        {
            lives--;
            Debug.Log("-1 vida");
            vida3.SetActive(false);
            corazonVacio3.SetActive(true);
            if(lives == 1)
            {
                vida2.SetActive(false);
                corazonVacio2.SetActive(true);
            }
            if(lives == 0)
            {
                vida1.SetActive(false);
                corazonVacio1.SetActive(true);
            }
        }

        if(col.transform.gameObject.tag == "Coin")
        {
            coinsColected++;
            Destroy(col.gameObject);
            Instantiate(coincollect);
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("hit"))
        {
            timer += Time.deltaTime;
            if(timer >= damage)
            {
                Debug.Log("ahora si?");
                Destroy(hit);
                lives--;
                timer = 0;
                vida3.SetActive(false);
                corazonVacio3.SetActive(true);
                if(lives == 1)
                {
                    vida2.SetActive(false);
                    corazonVacio2.SetActive(true);
                }
                if(lives == 0)
                {
                    vida1.SetActive(false);
                    corazonVacio1.SetActive(true);
                }

                
            }
        }

        if (col.CompareTag("door"))
        {
            textDetected.SetActive(true);
        }
    }
}

