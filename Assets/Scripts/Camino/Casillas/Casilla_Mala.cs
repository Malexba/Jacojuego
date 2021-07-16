using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Casilla_Mala : MonoBehaviour
{
    public GameObject popup; // Popup
    // Provocar efecto negativo
    public void ProvocarEfecto(){
        // Selecciona un efecto negativo al azar
        int efecto = (int)Math.Floor(2*UnityEngine.Random.value);
        if (efecto==2) efecto=1;
        // 0 = ¡Te ha salido una agujeta! Pierdes 4 de energía.
        if (efecto == 0){
            // Poner popup (el efecto se implementa en un método al pulsar el botón "Aceptar" del popup)

            // Popup de información
            GameObject info = popup.transform.GetChild(0).gameObject;
            // Poner texto
            info.transform.GetChild(0).gameObject.GetComponent<Text>().text = "¡Te ha salido una agujeta!\nPierdes 4 de energía.";
            // Poner métodos al botón
            Button aceptar = info.transform.GetChild(1).gameObject.GetComponent<Button>();
            aceptar.onClick.RemoveAllListeners();
            aceptar.onClick.AddListener(delegate{GameObject.FindGameObjectWithTag("Player").GetComponent<Jugador_Mapa>().RestarEnergia(4);});
            aceptar.onClick.AddListener(delegate{CerrarPopUp();});
            // Mostrar popup de información
            popup.SetActive(true);
            popup.transform.GetChild(1).gameObject.SetActive(false);
            popup.transform.GetChild(2).gameObject.SetActive(false);
            info.SetActive(true);
        }
        // 1 = ¡Te han asaltado unos labrones! Pierdes una carta aleatoria de tu mano.
        else if (efecto==1) {
            // Poner popup (el efecto se implementa en un método al pulsar el botón "Aceptar" del popup)

             // Popup de información
            GameObject info = popup.transform.GetChild(0).gameObject;
            // Poner texto
            info.transform.GetChild(0).gameObject.GetComponent<Text>().text = "¡Te han asaltado unos ladrones!\nPierdes una carta aleatoria de tu mano.";
            // Poner métodos al botón
            Button aceptar = info.transform.GetChild(1).gameObject.GetComponent<Button>();
            aceptar.onClick.RemoveAllListeners();
            aceptar.onClick.AddListener(delegate{
                GameObject mano = GameObject.FindGameObjectWithTag("Mano");
                int carta = (int)Math.Floor(mano.GetComponent<Mano>().GetCartas().Count*UnityEngine.Random.value);
                if (carta==mano.GetComponent<Mano>().GetCartas().Count) carta = mano.GetComponent<Mano>().GetCartas().Count-1;
                mano.GetComponent<Mano>().DestruirCarta(carta);
            });
            aceptar.onClick.AddListener(delegate{CerrarPopUp();});
            // Mostrar popup de información
            popup.SetActive(true);
            popup.transform.GetChild(1).gameObject.SetActive(false);
            popup.transform.GetChild(2).gameObject.SetActive(false);
            info.SetActive(true);
            
        }
        // Bloquear arrastre de cámara
        Camera.main.gameObject.GetComponent<Main_Camera>().BloquearArrastreCámara();
    }

    public void CerrarPopUp(){
        popup.SetActive(false);
        Camera.main.gameObject.GetComponent<Main_Camera>().DesbloquearArrastreCámara();
    }
}
