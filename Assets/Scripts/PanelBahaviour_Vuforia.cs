using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelBahaviour_Vuforia : MonoBehaviour
{
    [SerializeField]
    private TMP_Text texto;
    [SerializeField]
    private Seccion seccion;
    [SerializeField]
    private GameObject panelMenu;

    public void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 50))
        {
            if (hit.collider.tag == "Evento")
            {
                seccion = hit.collider.gameObject.transform.parent.GetComponent<Seccion>();
                UpdatePanelContent(seccion.getSectionName());
            }
        }

    }

    private void UpdatePanelContent(string apartado)
    {
        texto.text = "¿Comenzar la sección " + apartado + " del Tour?";
    }

    public void Confirm()
    {
        seccion.IniciarSeccion();
        panelMenu.SetActive(false);
    }

    public void Negate()
    {
        seccion = null;
        panelMenu.SetActive(false);
    }

    public void CloseSection()
    {
        if(seccion != null)
        {
            seccion.GetComponent<Seccion>().FinalizarSeccionVuforia();
            seccion = null;
        }
    }
}
