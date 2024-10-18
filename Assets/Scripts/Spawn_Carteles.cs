using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARFoundation.Samples;
using UnityEngine.XR.ARSubsystems;

public class Spawn_Carteles : ObjectSpawner
{
   public void SpawnearCartel()
    {
        if(!Controller_Menu_MinigameDesenterrar.instance.GetEstadoVainaCartelColocado() && Controller_Menu_MinigameDesenterrar.instance.GetVainaActual() != null)
        {
            ARAnchor anchor = null;

            GameObject newCartel = Instantiate(objectToSpawn, placementIndicator.pose_indicator.position, placementIndicator.pose_indicator.rotation);

            anchor = newCartel.GetComponent<ARAnchor>();

            if (anchor == null)
            {
                anchor = newCartel.AddComponent<ARAnchor>();
            }

            if (anchor != null)
            {
                m_Anchors.Add(anchor);
            }

            newCartel.transform.parent = Controller_Menu_MinigameDesenterrar.instance.GetVainaActual().transform.parent;

        }
    }
}
