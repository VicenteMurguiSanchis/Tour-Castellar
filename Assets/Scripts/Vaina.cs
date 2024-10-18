using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaina : MonoBehaviour
{

    [SerializeField] private int id;
    [SerializeField] private GameObject objectEnterrado;
    [SerializeField] private GameObject almacenajeObject;
    public bool CartelColocado = false, AciertoCartel = false;
    public bool ObjetoExtraido = false;

    // Start is called before the first frame update
    void Start()
    {
        CartelColocado = false;
        AciertoCartel = false;
        ObjetoExtraido = false;
    }

    public void DesenterrarObjeto()
    {
        Destroy(objectEnterrado);
        almacenajeObject.SetActive(true);
        ObjetoExtraido = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Cartel")
        {
            CartelColocado=true;
            if(collision.gameObject.GetComponent<Cartel>().GetId() == id)
            {
                AciertoCartel = true;
                Controller_Menu_MinigameDesenterrar.instance.GameIsFinished();
            }
            collision.gameObject.GetComponent<Cartel>().PutCheck(AciertoCartel);
        }
    }

    public void QuitarCartel()
    {
        CartelColocado = false;
        AciertoCartel = false;
        Destroy(this.transform.parent.GetComponentInChildren<Cartel>().gameObject);
    }
}
