using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target; // Variável para armazenar a referência ao transform do objeto a ser seguido.

    private Vector3 velocity = Vector3.zero; // Usada para suavizar o movimento da câmera.

    private float smoothTime = 0.1f; // Tempo que a câmera leva para se ajustar à nova posição.

    // Start is called before the first frame update
    private void Start()
    {
        // Encontra o GameObject com a tag "player" e obtém seu Transform.
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Cria uma nova posição para a câmera, que é a posição do alvo deslocada uma unidade para trás no eixo Z.
        Vector3 cameraPosition = target.position + new Vector3(0, 0, -1);

        // Move a câmera suavemente para a nova posição calculada.
        transform.position = Vector3.SmoothDamp(transform.position, cameraPosition, ref velocity, smoothTime);
    }
}
