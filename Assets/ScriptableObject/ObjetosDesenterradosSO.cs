using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewObjectDesenterrado", menuName = "ScriptableObject/Objeto Desenterrado")]

public class ObjetosDesenterradosSO : ScriptableObject
{
    public string titulo;
    public string descripcion;
    public GameObject objeto;
};
