using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Almacenaje : MonoBehaviour
{

    [SerializeField] private ObjetosDesenterradosSO objetoalmacenado;

    public ObjetosDesenterradosSO getObjetoAlmacenado() { return objetoalmacenado;}
}
