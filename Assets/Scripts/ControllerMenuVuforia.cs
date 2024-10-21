using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Antlr3.Runtime.Tree.TreeWizard;

public class ControllerMenuVuforia : MonoBehaviour
{
    [SerializeField] GameObject ButtonIniciar, ButtonVolver, ButtonSalir, Visor;

    public void ResetMenuVuforia()
    {
        ButtonIniciar.SetActive(true); 
        ButtonVolver.SetActive(true);
        Visor.SetActive(true);
        ButtonSalir.SetActive(false);
    }
}
