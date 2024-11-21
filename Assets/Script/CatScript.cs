using UnityEngine;

public class CatScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float jumpStrength;
    public LogicScript logic;
    public bool catIsAlive = true;

    private Animator animator;
    private bool isGrounded = false;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && catIsAlive && isGrounded)
        {
            myRigidbody.linearVelocity = Vector2.up * jumpStrength;
            animator.SetBool("isJumping", true);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isJumping", false); // Immediately set to false when grounded
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            logic.gameOver(); // Call logic to handle game over
            catIsAlive = false;
            animator.SetBool("isJumping", false);
            FreezeGame(); // Freeze the game when the cat dies
        }
    }

    private void FreezeGame()
    {
        Time.timeScale = 0f; // Set time scale to 0 to freeze the game
    }
}
