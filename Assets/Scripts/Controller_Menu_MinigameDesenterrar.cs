using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller_Menu_MinigameDesenterrar : Singleton<Controller_Menu_MinigameDesenterrar>
{
    [SerializeField] private List<GameObject> vainas;
    [SerializeField] private GameObject menu_Vainas, modos;
    [SerializeField] private GameObject menu_observacion, menu_extraccion, menuInfoObject, menu_Carteles, menuFinish, menuMinijuego;
    [SerializeField] private GameObject PlaceIndicatorVainas, PlaceIndicatorDetector, PlaceIndicatorCarteles;
    [SerializeField] private Vaina vaina_actual;
    [SerializeField] private int modoMenu = 1;

    [SerializeField] private PanelInfoObjectController infoObjectExtracted;

    // Start is called before the first frame update
    void Start()
    {
        menu_Vainas.SetActive(true);
        PlaceIndicatorVainas.SetActive(true);
        menu_Carteles.SetActive(false);
        modos.SetActive(false);
        menu_extraccion.SetActive(false);
        PlaceIndicatorDetector.SetActive(false);
        PlaceIndicatorCarteles.SetActive(false);
        menu_observacion.SetActive(false);
        menuFinish.SetActive(false);
        modoMenu = 1;
    }

    private void OnEnable()
    {
        menu_Vainas.SetActive(true);
        PlaceIndicatorVainas.SetActive(true);
        menu_Carteles.SetActive(false);
        modos.SetActive(false);
        menu_extraccion.SetActive(false);
        PlaceIndicatorDetector.SetActive(false);
        PlaceIndicatorCarteles.SetActive(false);
        menu_observacion.SetActive(false);
        menuFinish.SetActive(false);
        modoMenu = 1;
    }

    public void AddVaina(GameObject new_vaina)
    {
        vainas.Add(new_vaina);
        if(vainas.Count >= 3)
        {
            menu_Vainas.SetActive(false);
            PlaceIndicatorVainas.SetActive(false);
            modos.SetActive(true);
            menu_extraccion.SetActive(true);
            PlaceIndicatorDetector.SetActive(true);
        }
    }

    public void ResetearVainas()
    {
        if(vainas.Count > 0)
        {
            foreach (GameObject vaina in vainas)
            {
                Destroy(vaina);
            }

            vainas.Clear();
        }

    }

    public void SetVainaActual(Vaina vaina)
    {
        vaina_actual = vaina;
    }

    public Vaina GetVainaActual()
    {
        if(vaina_actual != null)
            return vaina_actual;
        else return null;
    }

    public bool GetEstadoVainaExtraccion()
    {
        if(vaina_actual != null)
            return vaina_actual.ObjetoExtraido;
        else return true;
    }

    public bool GetEstadoVainaCartelColocado()
    {
        if (vaina_actual != null)
            return vaina_actual.CartelColocado;
        else return false;
    }

    public void DesenterrarObjeto()
    {
        if(vaina_actual != null)
        {
            vaina_actual.DesenterrarObjeto();
            PlaceIndicatorDetector.GetComponentsInChildren<Detector_Objetos>()[0].ResetDetector();
        }
    }

    public void GameIsFinished()
    {
        if(vainas.Count > 0)
        {
            bool gameFinished = true;
            foreach (GameObject vaina in vainas)
            {
                if(!vaina.GetComponentInChildren<Vaina>().AciertoCartel)
                {
                    gameFinished = false;
                }
            }
            if(gameFinished)
            {
                menu_extraccion.SetActive(false);
                PlaceIndicatorDetector.SetActive(false);
                menu_observacion.SetActive(false);
                menu_Carteles.SetActive(false);
                PlaceIndicatorCarteles.SetActive(false);
                menuFinish.SetActive(true);
            }
        }
    }

    public void FinalizarJuego()
    {
        if (vainas.Count > 0)
        {
            foreach (GameObject vaina in vainas)
            {
                Destroy(vaina);
            }
        }
        menu_Vainas.SetActive(false);
        PlaceIndicatorVainas.SetActive(false);
        menu_Carteles.SetActive(false);
        modos.SetActive(false);
        menu_extraccion.SetActive(false);
        PlaceIndicatorDetector.SetActive(false);
        PlaceIndicatorCarteles.SetActive(false);
        menu_observacion.SetActive(false);
        menuFinish.SetActive(false);
        modoMenu = 1;
        menuMinijuego.SetActive(false);
    }

    public void CambiarModo()
    {
        modoMenu++;
        if (modoMenu > 3)
            modoMenu = 1;

        switch(modoMenu)
        {
            case 1:
                menu_extraccion.SetActive(true);
                PlaceIndicatorDetector.SetActive(true);
                menu_observacion.SetActive(false);
                menu_Carteles.SetActive(false);
                PlaceIndicatorCarteles.SetActive(false);
                break;
            case 2:
                menu_extraccion.SetActive(false);
                PlaceIndicatorDetector.SetActive(false);
                menu_observacion.SetActive(true);
                menu_Carteles.SetActive(false);
                PlaceIndicatorCarteles.SetActive(false);
                break;
            case 3:
                menu_extraccion.SetActive(false);
                PlaceIndicatorDetector.SetActive(false);
                menu_observacion.SetActive(false);
                menu_Carteles.SetActive(true);
                PlaceIndicatorCarteles.SetActive(true);
                break;
        }
    }

    public void ShowMenuObject(ObjetosDesenterradosSO soObject)
    {
        menuInfoObject.SetActive(true);
        infoObjectExtracted.InitModelMenu(soObject);
    }

    public void QuitarCartel()
    {
        this.GetVainaActual().QuitarCartel();
    }
}
