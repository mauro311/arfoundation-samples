using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class DogInstance : MonoBehaviour
{
    [SerializeField] GameObject modelPrefab;
    private GameObject modelPlaced;
    [SerializeField] private ARPlaneManager aRPlaneManager;
    [SerializeField] List<ARPlane> plane = new List<ARPlane>();


    private void OnEnable()
    {
       
        aRPlaneManager.planesChanged += PlanesFound;
    }
    private void OnDisable()
    {
        aRPlaneManager.planesChanged -= PlanesFound;
    }
    private void PlanesFound(ARPlanesChangedEventArgs planeData)
    {
        if (planeData.added != null && planeData.added.Count > 0)
        {
            plane.AddRange(planeData.added);
        }

        foreach (var planes in plane)
        {
            if (planes.extents.x * planes.extents.y >= 0.1 && modelPlaced == null)
            {
                modelPlaced = Instantiate(modelPrefab);
                float offset = modelPlaced.transform.localScale.y / 2;
                modelPlaced.transform.position = new Vector3(planes.center.x, planes.center.y + offset, planes.center.z);
                modelPlaced.transform.forward = planes.normal;
                StopDetection();
            }
        }
    }

    public void StopDetection()
    {
        aRPlaneManager.requestedDetectionMode = PlaneDetectionMode.None;
        foreach (var planes in plane)
        {
            planes.gameObject.SetActive(false);
        }
    }


}
