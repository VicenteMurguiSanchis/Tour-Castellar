using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorProyectil : MonoBehaviour
{
    [SerializeField] private GameObject proyectilPrefab;
    [SerializeField] private Transform targetProyectil;
    [SerializeField] private float timer, contadorProyectiles;
    [SerializeField] private bool shoots;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        contadorProyectiles = 0;
        shoots = false;
    }

    void Update()
    {
        if(contadorProyectiles < 6 && shoots)
        {
            if (timer > 2)
            {
                timer = 0;
                var proyectil = Instantiate(proyectilPrefab, Vector3.zero, Quaternion.identity);
                proyectil.transform.SetParent(this.transform, false);
                proyectil.GetComponent<Proyectil>().Disparar(targetProyectil);
                contadorProyectiles++;
                if (contadorProyectiles >= 6)
                    shoots = false;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
    }

    public void BeginShoots()
    {
        shoots = true;
    }
}
