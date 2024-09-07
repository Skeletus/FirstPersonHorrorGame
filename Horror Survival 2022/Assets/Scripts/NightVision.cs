using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NightVision : MonoBehaviour
{
    [SerializeField] private GameObject zoomBarGameObject;
    [SerializeField] private Camera cam;

    private Image zoombarImage;

    private void Awake()
    {
        zoombarImage = zoomBarGameObject.GetComponent<Image>();
        cam = Camera.main;
    }

    private void Update()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (cam.fieldOfView > 10)
            {
                cam.fieldOfView -= 5;
                zoombarImage.fillAmount = cam.fieldOfView / 100;
            }
            
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (cam.fieldOfView < 60)
            {
                cam.fieldOfView += 5;
                zoombarImage.fillAmount = cam.fieldOfView / 100;
            }
        }
    }
}
