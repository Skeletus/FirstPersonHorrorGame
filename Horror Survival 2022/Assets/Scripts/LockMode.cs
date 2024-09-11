using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class LockMode : MonoBehaviour
{
    [SerializeField] private PostProcessProfile standard;
    [SerializeField] private PostProcessProfile nightVisionPostProcessProfile;
    [SerializeField] private GameObject nightVisionOverlay;
    [SerializeField] private GameObject flashLightOverlay;

    private PostProcessVolume postProcessVolume;
    private NightVision nightVision;
    private FlashLight flashLight;

    private bool flaslightOn = false;
    private bool nightVisionOn = false;

    private void Awake()
    {
        postProcessVolume = GetComponent<PostProcessVolume>();
        nightVision = nightVisionOverlay.GetComponent<NightVision>();
        flashLight = flashLightOverlay.GetComponent<FlashLight>();
    }

    private void Start()
    {
        nightVisionOverlay.SetActive(false);
        flashLightOverlay.SetActive(false);
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
            if (!nightVision.HasNightVisionBattery())
            {
                EnableNormalVision();
            }
            else
            {
                EnableNightVision();
                nightVision.DrainBattery();
            }
        }
        if(!nightVisionOn)
        {
            EnableNormalVision();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            flaslightOn = !flaslightOn;
        }
        if (flaslightOn)
        {
            if (!flashLight.HasFlaslightBattery())
            {
                flashLight.DisableFlashLight();
            }
            else
            {
                flashLight.EnableFlashLight();
                flashLight.DrainBattery();
            }
        }
        if (!flaslightOn)
        {
            flashLight.DisableFlashLight();
        }

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
