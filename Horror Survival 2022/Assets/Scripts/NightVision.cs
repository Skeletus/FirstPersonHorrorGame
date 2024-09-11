using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NightVision : MonoBehaviour
{
    [SerializeField] private GameObject zoomBarGameObject;
    [SerializeField] private GameObject batteryChunkGameObject;
    [SerializeField] private Camera cam;

    [Header("Battery parameters")]
    [HideInInspector] public float batteryPower = 1f;
    [SerializeField] private float batteryDrainTimer = 2f;
    [SerializeField] private float batteryDrainRate = 2f;

    private Image zoombarImage;
    private Image batteryChunkImage;

    private void Awake()
    {
        zoombarImage = zoomBarGameObject.GetComponent<Image>();
        batteryChunkImage = batteryChunkGameObject.GetComponent<Image>();
        cam = Camera.main;
    }

    private void OnEnable()
    {
        zoombarImage.fillAmount = 0.6f;
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

        batteryChunkImage.fillAmount = batteryPower;
    }

    public bool HasNightVisionBattery()
    {
        return batteryPower > 0.0f;
    }

    public void DrainBattery()
    {
        batteryDrainTimer -= Time.deltaTime;
        // drain the battery every 5 seconds
        if (batteryDrainTimer <= 0f)
        {
            batteryDrainTimer = 5f;

            if (batteryPower > 0f)
            {
                batteryPower -= batteryDrainRate;
            }
        }
    }

}
