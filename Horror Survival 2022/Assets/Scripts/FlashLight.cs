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

    private void Awake()
    {
        batteryChunksImage = batteryChunksGameObject.GetComponent<Image>();
    }

    private void Update()
    {
        batteryChunksImage.fillAmount = batteryPower;
    }

    public void EnableFlashLight()
    {
        // activate canvas
        gameObject.SetActive(true);
        // activates spotlight
        flaslightGameObject.SetActive(true);
    }

    public void DisableFlashLight()
    {
        // activate canvas
        gameObject.SetActive(false);
        // activates spotlight
        flaslightGameObject.SetActive(false);
    }

    public bool HasFlaslightBattery()
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
