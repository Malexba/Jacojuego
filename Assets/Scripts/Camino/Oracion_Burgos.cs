using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oracion_Burgos : MonoBehaviour
{
    // +1 energía, +1 motivación, avanza una casilla
    public void ProvocarEfecto(){
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");
        jugador.GetComponent<Jugador_Mapa>().RestarEnergia(2); // Restar 2 puntos de energía
        jugador.GetComponent<Jugador_Mapa>().SumarMotivacion(1); // Sumar 1 punto de motivación
        GameObject casillaActual = jugador.GetComponent<Jugador_Mapa>().casillaActual;
        List<GameObject> casillasPosibles = new List<GameObject>();
        List<GameObject> auxs = new List<GameObject>();
        // Encuentra las casillas a distancia de 1
        auxs = casillaActual.GetComponent<Casilla_Mapa>().GetCasillasADistancia(1);
        foreach(GameObject aux in auxs){
            casillasPosibles.Add(aux);
        }

        // Activa el halo de todas ellas
        foreach (GameObject casilla in casillasPosibles){
            casilla.transform.GetChild(1).gameObject.SetActive(true);
        }

    }
}
