using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlmacenajeCasa : MonoBehaviour
{
    [SerializeField] private ObjetosCasaSO objetoalmacenado;

    public ObjetosCasaSO ObjetosColocadoCasaSO() { return objetoalmacenado; }
}
