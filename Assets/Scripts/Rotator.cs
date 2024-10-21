using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float velocity;

    void Update()
    {
        transform.Rotate(0, velocity * Time.deltaTime, 0);
    }
}
