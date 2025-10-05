using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MostrarMensajeInteraccion : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textoInteraccion;

    void Start()
    {
        if (textoInteraccion != null)
            textoInteraccion.gameObject.SetActive(false); // Ocultamos al inicio
    }

    public void MostrarMensaje(string mensaje)
    {
        if (textoInteraccion != null)
        {
            textoInteraccion.text = mensaje;
            textoInteraccion.gameObject.SetActive(true);
        }
    }

    public void OcultarMensaje()
    {
        if (textoInteraccion != null)
            textoInteraccion.gameObject.SetActive(false);
    }
}
