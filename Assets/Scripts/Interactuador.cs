using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Interactuador : MonoBehaviour
{
    protected float distancia_interactuador = 40;
    public Button boton_accion;
    public string tag_object;

    // Update is called once per frame
    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distancia_interactuador))
        {
            if(hit.collider.tag == tag_object)
            {
                boton_accion.interactable = true;
            }

            else
            {
                boton_accion.interactable = false;
            }
        }

        else
        {
            boton_accion.interactable = false;
        }
    }
}
