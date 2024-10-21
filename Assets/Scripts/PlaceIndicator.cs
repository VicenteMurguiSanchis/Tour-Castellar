using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceIndicator : MonoBehaviour
{
    protected ARRaycastManager raycastManager;
    protected GameObject indicator;
    protected List<ARRaycastHit> hits = new List<ARRaycastHit>();
    public Pose pose_indicator;
         
    // Start is called before the first frame update
    void Start()
    {
        raycastManager = FindObjectOfType<ARRaycastManager>();
        indicator = transform.GetChild(0).gameObject;
        indicator.SetActive(false);
        pose_indicator = Pose.identity;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var ray = new Vector3(Screen.width / 2, Screen.height / 2);

        if(raycastManager.Raycast(ray, hits, TrackableType.PlaneWithinPolygon))
        {
            pose_indicator.position = hits[0].pose.position;

            transform.position = pose_indicator.position;

            if (!indicator.activeInHierarchy)
            {
                indicator.SetActive(true);
            }
        }
    }

    public void ResetRotation()
    {
        indicator.transform.rotation = Quaternion.identity;
        pose_indicator.rotation = indicator.transform.rotation;
    }

    public void Rotation_Left()
    {
        if (indicator.activeInHierarchy)
        {
            indicator.transform.Rotate(0, -10, 0);
            pose_indicator.rotation = indicator.transform.rotation;
        }
    }

    public void Rotation_Right()
    {
        if (indicator.activeInHierarchy)
        {
            indicator.transform.Rotate(0, 10, 0);
            pose_indicator.rotation = indicator.transform.rotation;
        }
    }
}
