using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motivacion_Extra : MonoBehaviour
{
    // +2 de motivacion
    public void ProvocarEfecto(){
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");
        jugador.GetComponent<Jugador_Mapa>().RestarEnergia(3); // Restar 2 puntos de energía
        jugador.GetComponent<Jugador_Mapa>().SumarMotivacion(2); // Sumar 2 puntos de motivación

    }
}
