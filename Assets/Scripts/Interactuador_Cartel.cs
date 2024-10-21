using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactuador_Cartel : Interactuador
{
    [SerializeField] private Spawn_Carteles spawn_carteles;

    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distancia_interactuador))
        {
            if (hit.collider.tag == tag_object && spawn_carteles.objectToSpawn != null)
            {
                if(hit.collider.gameObject.GetComponent<Vaina>().CartelColocado)
                {
                    boton_accion.interactable = false;
                }
                else
                {
                    boton_accion.interactable = true;
                }
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
