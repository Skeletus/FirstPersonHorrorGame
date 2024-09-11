using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashLight : MonoBehaviour
{
    [SerializeField] private GameObject batteryChunksGameObject;
    [SerializeField] private GameObject flaslightGameObject;
    [SerializeField] private float batteryDrainTimer;
    [SerializeField] private float batteryDrainRate;

    private Image batteryChunksImage;
    private float batteryPower = 1.0f;
    private bool flaslightOn = false;

    private void Awake()
    {
        flaslightGameObject.gameObject.SetActive(false);
        batteryChunksImage = batteryChunksGameObject.GetComponent<Image>();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.L))
        {
            flaslightOn = !flaslightOn;
        }
        if (flaslightOn)
        {
            if (!HasFlaslightBattery())
            {
                DisableFlashLight();
            }
            else
            {
                EnableFlashLight();
                DrainBattery();
            }
        }
        if (!flaslightOn)
        {
            DisableFlashLight();
        }

        batteryChunksImage.fillAmount = batteryPower;
    }

    private void EnableFlashLight()
    {
        flaslightGameObject.gameObject.SetActive(true);
    }

    private void DisableFlashLight()
    {
        flaslightGameObject.gameObject.SetActive(false);
    }

    private bool HasFlaslightBattery()
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
