using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelInfoObjectsHouseController : MonoBehaviour
{
    [SerializeField] private ObjetosCasaSO soObject;
    [SerializeField] private TextMeshProUGUI titulo, descripcion;
    [SerializeField] private Image imagenSO;

    public void ExitModelMenu()
    {
        this.gameObject.SetActive(false);
    }

    public void InitModelMenu(ObjetosCasaSO newSO)
    {

        soObject = newSO;

        titulo.text = soObject.titulo;
        descripcion.text = soObject.descripcion;
        imagenSO.sprite = soObject.objeto;


    }
}
