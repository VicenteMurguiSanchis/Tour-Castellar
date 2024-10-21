using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;

public class PanelInfoObjectController : MonoBehaviour
{
    [SerializeField] private GameObject ObjectMenuExtracted;
    [SerializeField] private ObjetosDesenterradosSO soObject;
    [SerializeField] private bool rotateR = false, rotateL = false;
    [SerializeField] private TextMeshProUGUI titulo, descripcion;

    private void Update()
    {
        if (ObjectMenuExtracted.activeInHierarchy)
        {
            if(rotateR)
            {
                ObjectMenuExtracted.transform.Rotate(0, -1f, 0);
            }

            if (rotateL)
            {
                ObjectMenuExtracted.transform.Rotate(0, 1f, 0);
            }
        }
    }
    public void RotateModelMenuRightDown()
    {
        if (ObjectMenuExtracted.activeInHierarchy)
        {
            rotateR = true;
        }
    }

    public void RotateModelMenuRightUp()
    {
        if (ObjectMenuExtracted.activeInHierarchy)
        {
            rotateR = false;
        }
    }

    public void RotateModelMenuLeftDown()
    {
        if (ObjectMenuExtracted.activeInHierarchy)
        {
            rotateL = true;
        }
    }

    public void RotateModelMenuLeftUp()
    {
        if (ObjectMenuExtracted.activeInHierarchy)
        {
            rotateL = false;
        }
    }

    public void ExitModelMenu()
    {
        ObjectMenuExtracted.transform.rotation = Quaternion.identity;
        Destroy(ObjectMenuExtracted.transform.GetChild(0).gameObject);
        ObjectMenuExtracted.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public void InitModelMenu(ObjetosDesenterradosSO newSO)
    {

        soObject = newSO;

        ObjectMenuExtracted.SetActive(true);

        GameObject obj = Instantiate(soObject.objeto, new Vector3(0,0,0), Quaternion.identity);

        obj.transform.parent = ObjectMenuExtracted.transform;

        titulo.text = soObject.titulo;
        descripcion.text = soObject.descripcion;

    }
}
