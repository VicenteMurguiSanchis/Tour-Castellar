using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation.Samples;

public class Indicator_Section : MonoBehaviour
{
    [SerializeField] GameObject[] sections;
    [SerializeField] ObjectSpawner objectSpawner;
    [SerializeField] GameObject PlaceIndicator, ButtonSpawn, PanelInfoPlace, ButtonVolver, SelectionPanel;

    public void SelectSection(int section)
    {
        objectSpawner.ChangeObjectToSpawn(sections[section]);
        SelectionPanel.SetActive(false);
        ButtonSpawn.SetActive(true);
        PanelInfoPlace.SetActive(true);
        ButtonVolver.SetActive(true);
        PlaceIndicator.SetActive(true);
    }
}
