using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Menu_House : Singleton<Controller_Menu_House>
{
    [SerializeField] GameObject menuObservacion, menuEmplazarSpawn, menuEmplazarSeleccion, menuDesplegableObjeto, menuMinijuego, rotationIndicator;
    [SerializeField] GameObject PlacementIndicatorHouse;
    [SerializeField] private int modoMenu = 1;

    // Start is called before the first frame update
    void Start()
    {
        menuEmplazarSeleccion.SetActive(true);
        PlacementIndicatorHouse.SetActive(true);
        menuEmplazarSpawn.SetActive(false);
        menuObservacion.SetActive(false);
        modoMenu = 1;
    }

    private void OnEnable()
    {
        menuEmplazarSeleccion.SetActive(true);
        PlacementIndicatorHouse.SetActive(true);
        menuEmplazarSpawn.SetActive(false);
        menuObservacion.SetActive(false);
        modoMenu = 1;
    }

    public void ResetearObjetos()
    {

        GameObject[] objetosEmplazados = GameObject.FindGameObjectsWithTag("Casa");
        if (objetosEmplazados.Length > 0)
        {
            foreach (GameObject obj in objetosEmplazados)
            {
                Destroy(obj);
            }
        }
    }

    public void FinalizarJuego()
    {
        ResetearObjetos();
        menuEmplazarSeleccion.SetActive(false);
        PlacementIndicatorHouse.SetActive(false);
        menuEmplazarSpawn.SetActive(false);
        menuObservacion.SetActive(false);
        modoMenu = 1;
        menuMinijuego.SetActive(false);
    }

    public void CambiarModo()
    {
        modoMenu++;
        if (modoMenu > 2)
            modoMenu = 1;

        switch (modoMenu)
        {
            case 1:
                menuEmplazarSeleccion.SetActive(true);
                PlacementIndicatorHouse.SetActive(true);
                rotationIndicator.SetActive(false);
                menuEmplazarSpawn.SetActive(false);
                menuObservacion.SetActive(false);
                break;
            case 2:
                menuEmplazarSeleccion.SetActive(false);
                PlacementIndicatorHouse.SetActive(false);
                rotationIndicator.SetActive(false);
                menuEmplazarSpawn.SetActive(false);
                menuObservacion.SetActive(true);
                break;
        }
    }

    public void OpenMenuObjeto(ObjetosCasaSO objetoCasaVisto)
    {
        menuDesplegableObjeto.SetActive(true);
        menuDesplegableObjeto.GetComponent<PanelInfoObjectsHouseController>().InitModelMenu(objetoCasaVisto);
    }
}
