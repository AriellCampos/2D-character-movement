using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    #region Variáveis de Movimento
    public float moveSpeed = 5f; // Velocidade de movimento
    private Rigidbody2D rigidBody; // Referência ao Rigidbody2D
    #endregion

    #region Variáveis de Pulo
    public float jumpForce = 5f; // Força do pulo
    private bool isGrounded; // Verifica se o personagem está no chão
    private int jumpCount; // Contador de pulos
    #endregion

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>(); // Obtém o Rigidbody2D
        jumpCount = 0; // Inicializa o contador de pulos
    }

    void Update()
    {
        // Verifica se o jogador pressionou a tecla de pulo
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        // Captura a entrada horizontal como uma variável local
        float moveInput = Input.GetAxis("Horizontal");

        // Move o personagem
        rigidBody.velocity = new Vector2(moveInput * moveSpeed, rigidBody.velocity.y);
    }

    void Jump()
    {
        if (isGrounded) // Se está no chão, permite o pulo simples
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce); // Aplica a força do pulo
            jumpCount = 1; // Incrementa o contador de pulos
        }
        else if (jumpCount < 2) // Permite o pulo duplo
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce); // Aplica a força do pulo
            jumpCount++; // Incrementa o contador de pulos
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Verifica se colidiu com o chão
        {
            isGrounded = true; // Define que o personagem está no chão
            jumpCount = 0; // Reseta o contador de pulos
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Verifica se saiu do chão
        {
            isGrounded = false; // Define que o personagem não está mais no chão
        }
    }
}
