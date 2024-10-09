using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacterTopDown : MonoBehaviour
{
    
    public float speed; // Declara uma vari�vel p�blica chamada speed que define a velocidade do personagem.

    void Update()
    {
        // Cria um vetor 3D chamado moveInput baseado nas entradas do usu�rio (teclas de movimento).
        // Input.GetAxis("Horizontal") captura a entrada horizontal (A/D ou setas esquerda/direita).
        // Input.GetAxis("Vertical") captura a entrada vertical (W/S ou setas cima/baixo).
        // O valor Z � definido como 0 para movimento em 2D.
        Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);

        // Atualiza a posi��o do objeto (personagem) multiplicando a entrada de movimento pela velocidade e pelo tempo desde o �ltimo frame.
        // Isso garante um movimento suave e consistente, independentemente da taxa de quadros.
        transform.position = transform.position + speed * moveInput * Time.deltaTime;
    }
}

