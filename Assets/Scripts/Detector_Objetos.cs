using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Detector_Objetos : MonoBehaviour
{
    [SerializeField] GameObject luz;
    [SerializeField] Material luzVerde, luzRoja;
    [SerializeField] Button boton_extraccion;
    void Start()
    {
        luz.GetComponent<Renderer>().material = luzRoja;
        boton_extraccion.interactable = false;
    }

    public void ResetDetector()
    {
        luz.GetComponent<Renderer>().material = luzRoja;
        boton_extraccion.interactable = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ObjetoEnterrado")
        {
            luz.GetComponent<Renderer>().material = luzVerde;
            boton_extraccion.interactable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ObjetoEnterrado")
        {
            luz.GetComponent<Renderer>().material = luzRoja;
            boton_extraccion.interactable = false;
        }
    }
}
