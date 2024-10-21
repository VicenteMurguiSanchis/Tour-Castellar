using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CambiarTituloModo : MonoBehaviour
{
    [SerializeField] private string[] modos;
    [SerializeField] private int actualMode;
    [SerializeField] private TextMeshProUGUI textMode;

    private void Start()
    {
        actualMode = 0;
        textMode.text = modos[actualMode];
    }

    private void OnEnable()
    {
        actualMode = 0;
        textMode.text = modos[actualMode];
    }

    public void changeMode()
    {
        actualMode++;
        if(actualMode >= modos.Length)
        {
            actualMode = 0;
        }
        textMode.text = modos[actualMode];
    }
}
