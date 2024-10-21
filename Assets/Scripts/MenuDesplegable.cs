using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDesplegable : MonoBehaviour
{
    [SerializeField] private GameObject menuAsociado;

    private void Start()
    {
        menuAsociado.SetActive(false);
    }

    public void ActivarMenu()
    {
        menuAsociado.SetActive(true);
    }

    public void DesactivarMenu()
    {
        menuAsociado.SetActive(false);
    }
}
