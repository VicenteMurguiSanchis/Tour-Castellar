using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [SerializeField] private GeneradorProyectil[] generadorProyectiles;
    [SerializeField] private GameObject army;

    public void ActivarDisparos()
    {
        foreach(GeneradorProyectil gp in generadorProyectiles)
        {
            gp.BeginShoots();
        }
    }

    public void ActivateArmy()
    {
        army.SetActive(true);
    }

    public void DeactivateArmy()
    {
        army.SetActive(false);
    }
}
