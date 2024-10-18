using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomatizadorSecciones : MonoBehaviour
{

    [SerializeField] Seccion seccion;
    // Start is called before the first frame update
    void Start()
    {
        seccion.IniciarSeccion();
    }

    public void FinalizarSeccion()
    {
        GameManager.instance.closeSection();
    }
}
