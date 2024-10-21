using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    [SerializeField] float velocity, deathTime, timer;
    [SerializeField] private Vector3 targetDirection;

    void Start()
    {
        timer = 0;
    }

    void Update()
    {
        if(timer > deathTime)
        {
            Destroy(this.gameObject);
        }
        else
        {
            timer += Time.deltaTime;
            this.transform.position += (targetDirection * velocity * Time.deltaTime);
        }
    }

    public void Disparar(Transform target)
    {
        targetDirection = Vector3.Normalize(target.position - this.transform.position);
    }
}
