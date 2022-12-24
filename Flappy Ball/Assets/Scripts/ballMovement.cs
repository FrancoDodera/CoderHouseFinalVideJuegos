using UnityEngine;

public class ballMovement : MonoBehaviour
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

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        m_isGrounded = true;
    }
    private void Update()
    {
        Jump();
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
    
        if(other.transform.gameObject.tag == "Coin")
        {
            coinsColected++;
            Destroy(other.transform.gameObject);
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
        }
        if(lives == 0f)
        {
            Respawn();
            Debug.Log("¡¡¡YOU LOST!!!");
        }

    }
}
