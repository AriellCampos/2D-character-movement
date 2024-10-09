using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // O objeto que a c�mera deve seguir
    public float smoothSpeed = 0.125f; // A velocidade de suaviza��o
    public Vector3 offset; // Offset da c�mera em rela��o ao alvo

    void LateUpdate()
    {
        if (target != null) // Verifica se o target est� definido
        {
            // Define a posi��o desejada da c�mera
            Vector3 desiredPosition = target.position + offset;
            desiredPosition.z = transform.position.z; // Mant�m a posi��o Z da c�mera fixa
            // Suaviza a movimenta��o da c�mera
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            // Atualiza a posi��o da c�mera
            transform.position = smoothedPosition;
        }
    }
}
