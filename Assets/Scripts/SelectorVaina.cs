using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectorVaina : MonoBehaviour
{
    [SerializeField] private List<Button> botonesVainas;
    [SerializeField] private int botonActual;

    private void Start()
    {
        botonActual = 0;
    }

    public void ActualizarBoton(int b)
    {
        botonActual = b;
    }

    public void ResetearBotonesVainas()
    {
        foreach (Button b in botonesVainas)
        {
            b.interactable = true;
        }
        botonActual = 0;
    }

    public void DesactiveButton()
    {
        switch (botonActual)
        {
            case 0:
                break;
            case 1:
                botonesVainas[0].interactable = false;
                botonActual = 0;
                break;
            case 2:
                botonesVainas[1].interactable = false;
                botonActual = 0;
                break;
            case 3:
                botonesVainas[2].interactable = false;
                botonActual = 0;
                break;
        }
    }
}
