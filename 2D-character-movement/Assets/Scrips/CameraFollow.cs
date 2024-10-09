using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // O objeto que a câmera deve seguir
    public float smoothSpeed = 0.125f; // A velocidade de suavização
    public Vector3 offset; // Offset da câmera em relação ao alvo

    void LateUpdate()
    {
        if (target != null) // Verifica se o target está definido
        {
            // Define a posição desejada da câmera
            Vector3 desiredPosition = target.position + offset;
            desiredPosition.z = transform.position.z; // Mantém a posição Z da câmera fixa
            // Suaviza a movimentação da câmera
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            // Atualiza a posição da câmera
            transform.position = smoothedPosition;
        }
    }
}
