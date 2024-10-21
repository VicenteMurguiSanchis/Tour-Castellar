using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using MoreMountains.Feedbacks;
using System;

public class Seccion : MonoBehaviour
{
    [SerializeField]
    private Flowchart flujo_dialogo_inicial;
    [SerializeField]
    private MMF_Player feeddback_inicial;
    /*
    [SerializeField] AudioClip audio_principal;
    [SerializeField] AudioSource _audioSource;
    */
    [SerializeField] string blockName;
    [SerializeField] private string SectionName;
    [SerializeField] private GameObject[] elements;
    [SerializeField] private GameObject Init_Section;

    private void OnEnable()
    {
        foreach(GameObject go in elements)
        {
            go.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camara_pos = Camera.main.transform.position;

        var rotacion = transform.position - camara_pos;

        rotacion.y = 0f;

        var rotacion_Quaternion = Quaternion.LookRotation(rotacion.normalized);

        transform.rotation = rotacion_Quaternion;
    }

    public void IniciarSeccion()
    {
        Vector3 camara_pos = Camera.main.transform.position;

        var rotacion = transform.position - camara_pos;

        rotacion.y = 0f;

        var rotacion_Quaternion = Quaternion.LookRotation(rotacion.normalized);

        transform.rotation = rotacion_Quaternion;

        flujo_dialogo_inicial.ExecuteBlock(blockName);
        feeddback_inicial.PlayFeedbacks();
    }

    private void CerrarSeccionVuforia()
    {
        GameObject SayDialogActual = GameObject.Find("SayDialog");
        flujo_dialogo_inicial.StopBlock(blockName);
        Destroy(SayDialogActual);
        feeddback_inicial.StopFeedbacks();
    }

    public void LostTargetSectionVuforia()
    {
        CerrarSeccionVuforia();

        GameManager.instance.ReiniciarMenuVuforia();
    }

    public void FinalizarSeccionVuforia()
    {
        CerrarSeccionVuforia();

        foreach (GameObject go in elements)
        {
            go.SetActive(false);
        }

        Init_Section.SetActive(true);
        Init_Section.GetComponent<DissolveBehaviour>().Activar();

        GameManager.instance.ReiniciarMenuVuforia();
    }

    public string getSectionName()
    {
        return SectionName;
    }
}
