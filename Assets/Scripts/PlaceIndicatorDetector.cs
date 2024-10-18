using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
public class PlaceIndicatorDetector : PlaceIndicator
{
    public float distancia_interactuador = 200f;

    void FixedUpdate()
    {
        Debug.Log("Uso del fixed Hijo");
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distancia_interactuador))
        {
            if (hit.collider.tag == "GroundMinigame")
            {
                Debug.Log("Colisiona con la vaina");
                pose_indicator.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);


                transform.position = pose_indicator.position;

                Vector3 camara_pos = Camera.main.transform.position;

                var rotacion = transform.position - camara_pos;

                rotacion.y = 0;

                var rotacion_Quaternion = Quaternion.LookRotation(rotacion);

                transform.rotation = rotacion_Quaternion;

                Controller_Menu_MinigameDesenterrar.instance.SetVainaActual(hit.collider.gameObject.GetComponent<Vaina>());

                if(!Controller_Menu_MinigameDesenterrar.instance.GetEstadoVainaExtraccion())
                {
                    if (!indicator.activeInHierarchy)
                    {
                        indicator.SetActive(true);
                    }
                }
                else 
                {
                    Debug.Log("Vaina con objeto desenterrado");
                    indicator.SetActive(false);
                }
            }
        }
    }
}
