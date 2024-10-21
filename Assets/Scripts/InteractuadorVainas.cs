using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractuadorVainas : Interactuador
{

    [SerializeField] private ObjetosDesenterradosSO objDesenterrado;
    public void MostrarMenuObjetoExtraido()
    { 
        if (objDesenterrado != null)
        {
            Controller_Menu_MinigameDesenterrar.instance.ShowMenuObject(objDesenterrado);
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
                objDesenterrado = hit.collider.gameObject.GetComponent<Almacenaje>().getObjetoAlmacenado();
            }

            else
            {
                boton_accion.interactable = false;
                objDesenterrado = null;
            }
        }

        else
        {
            boton_accion.interactable = false;
            objDesenterrado = null;
        }
    }
}
