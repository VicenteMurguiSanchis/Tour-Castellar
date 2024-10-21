using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation.Samples;

public class IndicatorSelector : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject[] indicators;
    [SerializeField] GameObject[] objects;
    [SerializeField] ObjectSpawner objectSpawner;
    public void SelectNewIndicator(int indicatorIndex)
    {
        for(var i = this.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(this.transform.GetChild(i).gameObject);
        }

        GameObject indicator = Instantiate(indicators[indicatorIndex], this.transform);
        indicator.transform.localPosition = Vector3.zero;
        indicator.transform.localRotation = Quaternion.identity;

        objectSpawner.ChangeObjectToSpawn(objects[indicatorIndex]);

    }

    public void UnSelectIndicator()
    {
        for (var i = this.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(this.transform.GetChild(i).gameObject);
        }
    }
}
