using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARFoundation.Samples;
using UnityEngine.XR.ARSubsystems;

public class SpawnSecciones : ObjectSpawner
{
    [SerializeField] GameObject indicator, menuSpawnerSection, SelectionPanel, ButtonSpawn;
    public void EmplazarSeccion()
    {

        if (m_RaycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), s_Hits, TrackableType.Planes))
        {
            var hit = s_Hits[0];

            var anchor = CreateAnchor(hit, placementIndicator);

            if (anchor)
            {
                m_Anchors.Add(anchor);
                activateSection();
                indicator.SetActive(false);
                SelectionPanel.SetActive(true);
                ButtonSpawn.SetActive(false);
                menuSpawnerSection.SetActive(false);
            }

            else
            {
                Debug.Log("Problema al crear anchor");
            }
        }
    }

    public void activateSection()
    {
        GameManager.instance.openSection();
    }
}
