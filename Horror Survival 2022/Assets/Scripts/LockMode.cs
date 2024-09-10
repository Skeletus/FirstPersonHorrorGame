using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class LockMode : MonoBehaviour
{
    [SerializeField] private PostProcessProfile standard;
    [SerializeField] private PostProcessProfile nightVisionPostProcessProfile;
    [SerializeField] private GameObject nightVisionOverlay;

    private PostProcessVolume postProcessVolume;
    private NightVision nightVision;
    private bool nightVisionOn = false;

    private void Awake()
    {
        postProcessVolume = GetComponent<PostProcessVolume>();
        nightVision = nightVisionOverlay.GetComponent<NightVision>();
    }

    private void Start()
    {
        nightVisionOverlay.SetActive(false);
        postProcessVolume.profile = standard;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            nightVisionOn = !nightVisionOn;
        }
        if (nightVisionOn)
        {
            if (!HasNightVisionBattery())
            {
                EnableNormalVision();
            }
            else
            {
                nightVision.DrainBattery();
                EnableNightVision();
            }
        }
        if(!nightVisionOn)
        {
            EnableNormalVision();
        }
        

    }

    private bool HasNightVisionBattery()
    {
        return nightVision.batteryPower > 0.0f;
    }

    private void EnableNormalVision()
    {
        postProcessVolume.profile = standard;
        nightVisionOverlay.SetActive(false);
        this.gameObject.GetComponent<Camera>().fieldOfView = 60;
    }

    private void EnableNightVision()
    {
        postProcessVolume.profile = nightVisionPostProcessProfile;
        nightVisionOverlay.SetActive(true);
    }
}
