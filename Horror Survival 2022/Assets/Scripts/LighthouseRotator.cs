using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighthouseRotator : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 3.5f;

    private void Update()
    {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }
}
