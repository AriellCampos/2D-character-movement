using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target; // Vari�vel para armazenar a refer�ncia ao transform do objeto a ser seguido.

    private Vector3 velocity = Vector3.zero; // Usada para suavizar o movimento da c�mera.

    private float smoothTime = 0.1f; // Tempo que a c�mera leva para se ajustar � nova posi��o.

    // Start is called before the first frame update
    private void Start()
    {
        // Encontra o GameObject com a tag "player" e obt�m seu Transform.
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Cria uma nova posi��o para a c�mera, que � a posi��o do alvo deslocada uma unidade para tr�s no eixo Z.
        Vector3 cameraPosition = target.position + new Vector3(0, 0, -1);

        // Move a c�mera suavemente para a nova posi��o calculada.
        transform.position = Vector3.SmoothDamp(transform.position, cameraPosition, ref velocity, smoothTime);
    }
}
