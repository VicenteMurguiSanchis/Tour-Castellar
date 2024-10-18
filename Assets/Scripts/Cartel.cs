using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cartel : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private Sprite checkOK, checkBad;
    [SerializeField] private Image imagenCheck;

    void Update()
    {
        Vector3 camara_pos = Camera.main.transform.position;

        var rotacion = transform.position - camara_pos;

        rotacion.y = 0f;

        var rotacion_Quaternion = Quaternion.LookRotation(rotacion.normalized);

        transform.rotation = rotacion_Quaternion;
    }

    public int GetId() { return id; }

    public void PutCheck(bool check)
    {
        if(check)
            imagenCheck.sprite = checkOK;
        else imagenCheck.sprite = checkBad;
    }
}
