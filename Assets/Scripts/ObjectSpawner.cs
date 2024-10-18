using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARSubsystems;

namespace UnityEngine.XR.ARFoundation.Samples
{
    public class ObjectSpawner : MonoBehaviour
    {
        public GameObject objectToSpawn;
        public Button spawnButton;
        public PlaceIndicator placementIndicator;
        protected static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();
        protected List<ARAnchor> m_Anchors = new List<ARAnchor>();
        protected ARRaycastManager m_RaycastManager;
        protected ARAnchorManager m_AnchorManager;

        void Awake()
        {
            //placementIndicator = FindObjectOfType<PlaceInidcator>();
            m_RaycastManager = FindObjectOfType<ARRaycastManager>();
            m_AnchorManager = FindObjectOfType<ARAnchorManager>();
        }

        private void OnEnable()
        {
            spawnButton.interactable = false;
        }

        public void SpawnObject()
        {
            
            if(m_RaycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2),s_Hits,TrackableType.Planes))
            {
                var hit = s_Hits[0];

                var anchor = CreateAnchor(hit, placementIndicator);

                if(anchor)
                {                        
                    m_Anchors.Add(anchor);
                }

                else{
                    Debug.Log("Problema al crear anchor");
                }
            }
        }

        protected ARAnchor CreateAnchor(in ARRaycastHit hit, PlaceIndicator placementIndicator)
        {
            ARAnchor anchor = null;

            if(hit.trackable is ARPlane plane){
                var planeManager = FindObjectOfType<ARPlaneManager>();
                if (planeManager)
                {
                    var oldPrefab = m_AnchorManager.anchorPrefab;
                    m_AnchorManager.anchorPrefab = objectToSpawn;
                    anchor = m_AnchorManager.AttachAnchor(plane, placementIndicator.pose_indicator);
                    m_AnchorManager.anchorPrefab = oldPrefab;
                    return anchor;
                }
            }

            var gameObject = Instantiate(objectToSpawn, placementIndicator.pose_indicator.position, placementIndicator.pose_indicator.rotation);

            anchor = gameObject.GetComponent<ARAnchor>();

            if (anchor == null)
            {
                anchor = gameObject.AddComponent<ARAnchor>();
            }
            return anchor;
        }


        public void ChangeObjectToSpawn(GameObject spawn)
        {
            objectToSpawn = spawn;
            spawnButton.interactable = true;
        }
    }
}
