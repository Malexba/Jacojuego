using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Casilla_Buena : MonoBehaviour
{
    // Provocar efecto beneficioso
    public void ProvocarEfecto(){
        // Selecciona un efecto beneficoso al azar
        int efecto = (int)Math.Floor(2*UnityEngine.Random.value);
        if (efecto==2) efecto=1;
        // 0 = Un compañero peregrino te invita a un almuerzo. Recuperas 5 de energía.
        if (efecto == 0){
            // Poner popup (el efecto se implementa en un método al pulsar el botón "Aceptar" del popup)
        }
        // 1 = Rebuscas en tu mochila y te encuentras con un hallazgo fortuito. Escoges una cartade tu mazo y la robas.
        else if (efecto==1) {
            // Poner selección de cartas de la mochila (el efecto se implamenta al clickar sobre la carta deseada)
        }
    }
}
