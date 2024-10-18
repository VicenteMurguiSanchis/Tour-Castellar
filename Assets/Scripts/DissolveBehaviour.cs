using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveBehaviour : MonoBehaviour
{

    [SerializeField] Material[] dissolveMatArray;
    public float fadeIn;

    public bool work;
    public bool dissolve;

    void Awake()
    {
        foreach (Material mat in dissolveMatArray)
        {
            mat.SetFloat("_Fade", 1);
        }
        fadeIn = 1;
    }

    private void OnEnable()
    {
        foreach (Material mat in dissolveMatArray)
        {
            mat.SetFloat("_Fade", 1);
        }
        fadeIn = 1;
    }

    void Update()
    {
        
        if(work)
        {
            if (!dissolve)
            {
                Aparecer();
            }

            else
            {
                Desaparecer();
            }
        }
    }

    public void Activar()
    {
        work = true;
        dissolve = false;
    }

    public void Desactivar()
    {
        work = true;
        dissolve = true;
    }

    private void Aparecer()
    {
        if (fadeIn > 0)
        {
            fadeIn -= Time.deltaTime;
        }

        else
        {
            fadeIn = 0;
            work = false;
        }

        foreach (Material mat in dissolveMatArray)
        {
            mat.SetFloat("_Fade", fadeIn);
        }
    }

    private void Desaparecer()
    {
        if (fadeIn < 1)
        {
            fadeIn += Time.deltaTime;
        }

        else
        {
            fadeIn = 1;
            work = false;
        }

        foreach (Material mat in dissolveMatArray)
        {
            mat.SetFloat("_Fade", fadeIn);
        }

        if (fadeIn == 1)
        {
            this.gameObject.SetActive(false);
        }
    }
}
