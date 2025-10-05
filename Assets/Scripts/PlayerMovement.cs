using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerTopDownRotationZ : MonoBehaviour
{
    public float moveSpeed = 5f;      // Velocidad de avance/retroceso (W/S)
    public float rotationSpeed = 150f; // Velocidad de giro (A/D)

    void Update()
    {
        // --- 1. Entrada (Input) ---
        float horizontalInput = Input.GetAxis("Horizontal"); // A/D o Flechas Izq/Der
        float verticalInput = Input.GetAxis("Vertical");   // W/S o Flechas Arr/Abajo

        // --- 2. GESTIÓN DEL GIRO (A y D) ---

        // Aplica la rotación alrededor del Eje Z.
        // Vector3.forward es un atajo para new Vector3(0, 0, 1).

        // Multiplicamos por la velocidad y Time.deltaTime.
        // Nota: Agregamos -1f para invertir el input y que 'A' gire a la izquierda y 'D' a la derecha.
        transform.Rotate(Vector3.forward * horizontalInput * rotationSpeed * -1f * Time.deltaTime);

        // --- 3. GESTIÓN DEL MOVIMIENTO (W y S) ---

        // Creamos un vector de movimiento ADELANTE/ATRÁS usando el input vertical.
        // El movimiento en el plano XZ (piso) se controla con el eje Z (adelante/atrás).
        Vector3 localMovement = Vector3.up * verticalInput;

        // Movemos el objeto en su espacio LOCAL.
        // Esto hace que el personaje avance en la dirección a la que está mirando actualmente.
        transform.Translate(localMovement * moveSpeed * Time.deltaTime);
    }
}
