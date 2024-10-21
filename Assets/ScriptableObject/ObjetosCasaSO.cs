using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewObjectHouse", menuName = "ScriptableObject/Objeto Casa")]

public class ObjetosCasaSO : ScriptableObject
{
    public string titulo;
    public string descripcion;
    public Sprite objeto;
};
