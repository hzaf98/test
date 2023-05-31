using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroMovement : MonoBehaviour
{
    bool alive = true;

    public float speed = 5;
    [SerializeField] Rigidbody rb;

    float horizontalInput;
    [SerializeField] float horizontalMultiplier = 0.5f;

    public float speedIncreasedPerPoint= 0.1f;

    [SerializeField] float jumpForce = 400f;
    [SerializeField] LayerMask groundMask;
    private void FixedUpdate()
    {
        //if not alive stop running this function which wont allow player to move
        if (!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        horizontalInput = Input.GetAxis("Horizontal"); 
        if(transform.position.y < -5)
        {
            Die();
        }//if hero's vertical position is less than -5 then he will die
    }

    public void Die()
    {
        alive = false;
        //Restart Game
        Invoke("Restart", 2); //loads scene currently in or restart
    
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Jump()
    {
        //Check whether we are currently grounded
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) * 0.1f, groundMask);//raycasts slightly down to check if player collider hits ground.
        //If we are, jump

        rb.AddForce(Vector3.up * jumpForce);
    }

}
