using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceIndicatorCarteles : PlaceIndicator
{
    public float distancia_interactuador = 40f;

    void FixedUpdate()
    {
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

                rotacion.y = 0f;

                var rotacion_Quaternion = Quaternion.LookRotation(rotacion.normalized);

                transform.rotation = rotacion_Quaternion;

                Controller_Menu_MinigameDesenterrar.instance.SetVainaActual(hit.collider.gameObject.GetComponent<Vaina>());

                if (!indicator.activeInHierarchy)
                {
                    indicator.SetActive(true);
                }
            }
        }
    }
}
