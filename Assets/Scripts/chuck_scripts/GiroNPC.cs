using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCGiroSoloY : MonoBehaviour
{
    private bool jugadorEnRango = false;
    private Transform jugador;

    void Update()
    {
        if (jugadorEnRango && Input.GetKeyDown(KeyCode.Return))
        {
            Vector3 direccion = jugador.position - transform.position;

            // Ignorar componente vertical para rotar en plano X-Z
            direccion.y = 0;

            // Si la dirección es válida
            if (direccion.sqrMagnitude > 0.001f)
            {
                // Calcular ángulo en el plano X-Z
                float anguloY = Mathf.Atan2(direccion.x, direccion.z) * Mathf.Rad2Deg;

                // Aplicar rotación solo en Y y mantener el x en 90°
                transform.rotation = Quaternion.Euler(90f, anguloY, 0);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorEnRango = true;
            jugador = other.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorEnRango = false;
        }
    }
}