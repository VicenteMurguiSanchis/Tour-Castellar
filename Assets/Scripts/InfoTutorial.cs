using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoTutorial : MonoBehaviour
{
    [SerializeField] private string[] Titulos;
    [SerializeField] private TextMeshProUGUI tituloText, instruccionesText;
    [SerializeField] private Button buttonRight, buttonLeft, buttonComenzar;
    [SerializeField] private string[] instrucciones;
    [SerializeField] private int paginaActual;

    void Start()
    {
        paginaActual = 0;
        ActualizarPagina(paginaActual);
    }

    private void OnEnable()
    {
        paginaActual = 0;
        ActualizarPagina(paginaActual);
    }

    public void ActualizarPagina(int paginaActual)
    {
        if(paginaActual == 0)
        {
            buttonLeft.gameObject.SetActive(false);
            buttonComenzar.gameObject.SetActive(false);
        }
        else
        {
            buttonLeft.gameObject.SetActive(true);
            buttonComenzar.gameObject.SetActive(false);
        }

        if (paginaActual == (instrucciones.Length - 1)) 
        {
            buttonRight.gameObject.SetActive(false);
            buttonComenzar.gameObject.SetActive(true);
        }
        else
        {
            buttonRight.gameObject.SetActive(true);
            buttonComenzar.gameObject.SetActive(false);
        }

        instruccionesText.text = instrucciones[paginaActual];
        tituloText.text = Titulos[paginaActual];
    }

    public void SiguientePag()
    {
        paginaActual++;
        ActualizarPagina(paginaActual);
    }

    public void AnteriorPag()
    {
        paginaActual--;
        ActualizarPagina(paginaActual);
    }
}
