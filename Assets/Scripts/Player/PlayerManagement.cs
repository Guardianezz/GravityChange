using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerManagement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private string currentSceneName;

    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float DeadZoneYUp = 20f;
    public float DeadZoneYDown = -10f;
    
    [Header("Gravity Flip Settings")]
    public bool isGrounded = false;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    private bool gravityFlipped = false;

    void Awake()
    {
        
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        MovePlayer();
        CheckGround();
        GravityFlip();
        CheckPlayerDeath();
    }

    private void MovePlayer()
    {
        float moveInput = Input.GetAxis("Horizontal"); // A/D 
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Retourne le sprite selon la direction
        if (moveInput > 0)
            sr.flipX = false;
        else if (moveInput < 0)
            sr.flipX = true;
    }

    private void CheckGround()
    {
        // Vérifie si le joueur touche le sol avec un petit cercle invisible
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void GravityFlip()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.G))
        {
            gravityFlipped = !gravityFlipped;

            // Inverse la gravité
            Physics2D.gravity = new Vector2(0, Physics2D.gravity.y * -1);

            // Retourne le joueur verticalement
            transform.Rotate(180f, 0f, 0f);
        }
    }

    
    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }

    private void CheckPlayerDeath()
    {
        if (transform.position.y > DeadZoneYUp || transform.position.y < DeadZoneYDown)
        {
            Destroy(gameObject);
            currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadSceneAsync(currentSceneName);
            Physics2D.gravity = new Vector2(0, -9.81f);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadSceneAsync(currentSceneName);
            Physics2D.gravity = new Vector2(0, -9.81f);
        }
    }
    
}
