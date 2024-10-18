using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARFoundation.Samples;
using UnityEngine.XR.ARSubsystems;

public class Spawn_Vainas : ObjectSpawner
{
    [SerializeField] private IndicatorSelector indicator;
    [SerializeField] private SelectorVaina vainaSelector;
    public void SpawnearVaina()
    {
        if (m_RaycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), s_Hits, TrackableType.Planes))
        {
            var hit = s_Hits[0];

            var anchor = CreateAnchor(hit, placementIndicator);

            if (anchor)
            {
                m_Anchors.Add(anchor);

                Controller_Menu_MinigameDesenterrar.instance.AddVaina(anchor.gameObject);
                indicator.UnSelectIndicator();
                vainaSelector.DesactiveButton();
            }

            else
            {
                Debug.Log("Problema al crear anchor");
            }
        }
    }

    public void ResetearVaina()
    {
        objectToSpawn = null;
        spawnButton.interactable = false;
    }
}
