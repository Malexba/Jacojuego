using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compañia_Agradable : MonoBehaviour
{
    // Moverse de 2 a 3 casillas
    public void ProvocarEfecto(){
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");
        jugador.GetComponent<Jugador_Mapa>().RestarEnergia(3); // Restar 3 puntos de energía
        GameObject casillaActual = jugador.GetComponent<Jugador_Mapa>().casillaActual;
        List<GameObject> casillasPosibles = new List<GameObject>();
        List<GameObject> auxs = new List<GameObject>();
        // Encuentra las casillas a distancia de entre 2 y 3
        for(int i =2;i < 3; i++){
            auxs = casillaActual.GetComponent<Casilla_Mapa>().GetCasillasADistancia(i);
            foreach(GameObject aux in auxs){
                casillasPosibles.Add(aux);
            }
        }

        // Activa el halo de todas ellas
        foreach (GameObject casilla in casillasPosibles){
            casilla.transform.GetChild(1).gameObject.SetActive(true);
        }

    }
}
