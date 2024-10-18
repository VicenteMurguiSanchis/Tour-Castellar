using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    //Declaraci�n de las clases que ser�n Singleton

    protected static T _instance;
    public static T instance
    { get
        { if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
            }
            return _instance;
        }
    }
}
