using UnityEditor.ShaderGraph;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    #region Vari�veis de Movimento
    public float moveSpeed = 5f; //Vari�vel p�blica que define a velocidade de movimento do personagem.
    private Rigidbody2D rigidBody; // Declara uma vari�vel privada do tipo RigidBody2D, que controla a f�sica do personagem.
    #endregion

    #region Vari�veis de Pulo
    public float jumpForce = 5f; // For�a do pulo
    private bool isGrounded; // Verifica se o personagem est� no ch�o
    private int jumpCount; // Contador de pulos
    #endregion

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>(); // Obt�m o Rigidbody2D
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
        // Captura a entrada horizontal como uma vari�vel local
        float moveInput = Input.GetAxis("Horizontal");

        // Move o personagem
        rigidBody.velocity = new Vector2(moveInput * moveSpeed, rigidBody.velocity.y);
    }

    void Jump()
    {
        if (isGrounded) // Se est� no ch�o, permite o pulo simples
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce); // Aplica a for�a do pulo
            jumpCount = 1; // Incrementa o contador de pulos
        }
        else if (jumpCount < 2) // Permite o pulo duplo
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce); // Aplica a for�a do pulo
            jumpCount++; // Incrementa o contador de pulos
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Verifica se colidiu com o ch�o
        {
            isGrounded = true; // Define que o personagem est� no ch�o
            jumpCount = 0; // Reseta o contador de pulos
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Verifica se saiu do ch�o
        {
            isGrounded = false; // Define que o personagem n�o est� mais no ch�o
        }
    }
}
