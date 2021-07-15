using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Almuerzo_en_grupo : MonoBehaviour
{
    // +4 de energía ya gastada
    public void ProvocarEfecto(){
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");
        jugador.GetComponent<Jugador_Mapa>().SumarEnergia(4); // Sumar 2 puntos de motivación

    }
}
