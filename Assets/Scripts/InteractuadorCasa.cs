using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractuadorCasa : Interactuador
{

    [SerializeField] private GameObject objEmplazado;

    public void MostrarMenuObjetoCasa()
    {
        if (objEmplazado != null)
        {
            Controller_Menu_House.instance.OpenMenuObjeto(objEmplazado.GetComponent<AlmacenajeCasa>().ObjetosColocadoCasaSO());
        }

    }

    public void EliminarObjetoEmplazado()
    {
        if(objEmplazado != null)
        {
            Destroy(objEmplazado);
            objEmplazado = null;
        }
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distancia_interactuador))
        {
            if (hit.collider.tag == tag_object)
            {
                boton_accion.interactable = true;
                objEmplazado = hit.collider.gameObject;
            }

            else
            {
                boton_accion.interactable = false;
                objEmplazado = null;
            }
        }

        else
        {
            boton_accion.interactable = false;
            objEmplazado = null;
        }
    }
}
