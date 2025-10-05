using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Objeto Transform que la cámara seguirá (tu personaje)
    public Transform target;

    // Distancia deseada entre la cámara y el objetivo
    public Vector3 offset;

    // Ajusta la suavidad del movimiento. Un valor más alto significa un seguimiento más rápido.
    public float smoothSpeed = 10f;

    // Es crucial usar LateUpdate en lugar de Update para el movimiento de la cámara.
    // LateUpdate se llama después de que se han procesado todos los cálculos de Update(), 
    // asegurando que el personaje se haya movido completamente antes de que la cámara lo siga.
    void LateUpdate()
    {
        // 1. Calcular la posición deseada de la cámara
        // La posición deseada es la posición del objetivo (target) más el desplazamiento (offset)
        Vector3 desiredPosition = target.position + offset;

        // 2. Suavizar el movimiento de la cámara
        // Usamos Vector3.Lerp para interpolar suavemente entre la posición actual y la deseada.
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // 3. Aplicar la nueva posición a la cámara
        transform.position = smoothedPosition;

        // Opcional: Para que la cámara siempre mire al personaje (útil en cámaras 3D)
        // transform.LookAt(target); 
    }
}
