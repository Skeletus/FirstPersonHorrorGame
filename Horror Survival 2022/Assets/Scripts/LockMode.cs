using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class LockMode : MonoBehaviour
{
    [SerializeField] private PostProcessProfile standard;
    [SerializeField] private PostProcessProfile nightVision;
    [SerializeField] private GameObject nightVisionOverlay;

    private PostProcessVolume postProcessVolume;
    private bool nightVisionOn = false;

    private void Awake()
    {
        postProcessVolume = GetComponent<PostProcessVolume>();
        
    }

    private void Start()
    {
        nightVisionOverlay.SetActive(false);
        postProcessVolume.profile = standard;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            if(!nightVisionOn)
            {
                postProcessVolume.profile = nightVision;
                nightVisionOverlay.SetActive(true);
                nightVisionOn = true;
            }
            else
            {
                postProcessVolume.profile = standard;
                nightVisionOverlay.SetActive(false);
                this.gameObject.GetComponent<Camera>().fieldOfView = 60;
                nightVisionOn = false;
            }
        }
    }
}
