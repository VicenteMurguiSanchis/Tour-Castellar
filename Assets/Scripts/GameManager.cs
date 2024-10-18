using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{

    public bool sectionActive;

    [SerializeField] private GameObject MenuSection, MenuPrincipal; 
    [SerializeField] private ControllerMenuVuforia MenuVuforia;

    void Start()
    {
        sectionActive = false;
    }

    public void closeSection()
    {
        if(sectionActive)
        {
            GameObject SayDialogActual = GameObject.Find("SayDialog");
            GameObject[] seccion_actual = GameObject.FindGameObjectsWithTag("Seccion");

            if(SayDialogActual != null)
            {
                Destroy(SayDialogActual);
            }
            
            if(seccion_actual.Length > 0)
            {
                foreach (GameObject go in seccion_actual)
                {
                    Destroy(go);
                }
            }

            MenuPrincipal.SetActive(true);
            MenuSection.SetActive(false);
            sectionActive = false;
        }
    }

    public void ReiniciarMenuVuforia()
    {
        MenuVuforia.ResetMenuVuforia();
    }

    public void openSection()
    {
        sectionActive = true;
        MenuSection.SetActive(true);
    }
}
