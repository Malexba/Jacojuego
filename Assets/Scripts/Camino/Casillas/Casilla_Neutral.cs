using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Casilla_Neutral : MonoBehaviour
{
    public GameObject popup; // Popup
    public GameObject casillaFinal; // Casilla final

    public GameObject casillaInicial; // Casilla inicial

    
    // Provocar efecto neutral
    public void ProvocarEfecto(){
        // Selecciona un efecto negativo al azar
        int efecto = (int)Math.Floor(2*UnityEngine.Random.value);
        if (efecto==2) efecto=1;
        /* 0 = ¿Quieres tomar un atajo?
            ◦Sí (de manera aleatoria avanzas o retrocedes 4 casillas)
            ◦No (no sucede nada)
            */
        if (efecto == 0){
            // Poner popup (cada botón activa el efecto correspondiente y cierra el popup)

            // Popup de decisión
            GameObject decision = popup.transform.GetChild(1).gameObject;
            // Poner texto
            decision.transform.GetChild(0).gameObject.GetComponent<Text>().text = "¿Quieres tomar un atajo?";
            // Poner métodos al botón
            Button aceptar = decision.transform.GetChild(1).gameObject.GetComponent<Button>();
            Button declinar = decision.transform.GetChild(2).gameObject.GetComponent<Button>();
            aceptar.onClick.RemoveAllListeners();
            declinar.onClick.RemoveAllListeners();
            aceptar.onClick.AddListener(delegate{ // Si dices sí, avanza o retrocede 4 casillas de forma aleatoria
                int efecto = (int)Math.Floor(2*UnityEngine.Random.value);
                if (efecto==2) efecto=1;
                GameObject info = popup.transform.GetChild(0).gameObject;
                // Dar la función de cerrar el popup al botón de Info
                Button aceptarInfo = info.transform.GetChild(1).gameObject.GetComponent<Button>();
                aceptarInfo.onClick.RemoveAllListeners();
                aceptarInfo.onClick.AddListener(delegate{CerrarPopUp();});
                // Texto y efecto de avanzar o retroceder
                if (efecto==0){
                    info.transform.GetChild(0).gameObject.GetComponent<Text>().text = "El atajo te lleva más adelante en el camino.\nAvanzas 4 casillas.";
                    GameObject jugador = GameObject.FindGameObjectWithTag("Player");
                    GameObject casillaActual = transform.gameObject;
                    List<GameObject> casillasPosibles = casillaActual.GetComponent<Casilla_Mapa>().GetCasillasADistancia(4);
                    if (casillasPosibles.Count==0){
                        casillasPosibles = new List<GameObject>();
                        casillasPosibles.Add(casillaFinal);
                    }
                    int casilla = (int)Math.Floor(casillasPosibles.Count*UnityEngine.Random.value);
                    if (casilla==casillasPosibles.Count) casilla = casillasPosibles.Count-1;
                    // Añadir efecto de mover 4 casillas adelante al botón
                    aceptarInfo.onClick.AddListener(delegate{jugador.GetComponent<Jugador_Mapa>().MoverACasilla(casillasPosibles[casilla].transform);});
                } else if (efecto==1){
                    info.transform.GetChild(0).gameObject.GetComponent<Text>().text = "El atajo te lleva más atrás en el camino.\nRetrocedes 4 casillas.";
                    GameObject jugador = GameObject.FindGameObjectWithTag("Player");
                    GameObject casillaActual = transform.gameObject;
                    List<GameObject> casillasPosibles = new List<GameObject>();
                    GameObject[] todasCasillas = GameObject.FindGameObjectsWithTag("Casilla");
                    foreach(GameObject casilla in todasCasillas){
                        List<GameObject> casillasA4 = casilla.GetComponent<Casilla_Mapa>().GetCasillasADistancia(4);
                        if (casillasA4.Contains(transform.gameObject)){
                            casillasPosibles.Add(casilla);
                        }
                    }
                    if (casillasPosibles.Count==0){
                        casillasPosibles = new List<GameObject>();
                        casillasPosibles.Add(casillaInicial);
                    }
                    int casIndex = (int)Math.Floor(casillasPosibles.Count*UnityEngine.Random.value);
                    if (casIndex==casillasPosibles.Count) casIndex = casillasPosibles.Count-1;
                    // Añadir efecto de mover 4 casillas atrás al botón
                    aceptarInfo.onClick.AddListener(delegate{jugador.GetComponent<Jugador_Mapa>().MoverACasilla(casillasPosibles[casIndex].transform);});
                }
                // Mostrar popup de información
                info.SetActive(true);
                decision.SetActive(false);
                
            });
            declinar.onClick.AddListener(delegate{CerrarPopUp();}); // Si dices no, cierra el popup
            // Mostrar popup de decisión
            popup.SetActive(true);
            popup.transform.GetChild(0).gameObject.SetActive(false);
            popup.transform.GetChild(2).gameObject.SetActive(false);
            decision.SetActive(true);
        }
        /* 1 = Te encuentras con un compañero peregrino herido.¿Decides ayudarle?
            ◦Sí (pierdes 5 de energía. Añade 2 cartas de “Compañía agradable ” a tu mazo )
            ◦No(no sucede nada)
            */
        else if (efecto==1) {
            // Poner popup (cada botón activa el efecto correspondiente y cierra el popup)

            // Popup de información
            GameObject decision = popup.transform.GetChild(1).gameObject;
            // Poner texto
            decision.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Te encuentras con un compañero peregrino herido.¿Decides ayudarle?";
            // Poner métodos al botón
            Button aceptar = decision.transform.GetChild(1).gameObject.GetComponent<Button>();
            Button declinar = decision.transform.GetChild(2).gameObject.GetComponent<Button>();
            aceptar.onClick.RemoveAllListeners();
            declinar.onClick.RemoveAllListeners();
            aceptar.onClick.AddListener(delegate{
                GameObject info = popup.transform.GetChild(0).gameObject;
                info.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Pierdes 5 de energía. Añades 1 carta de “Compañía agradable” a tu mano.";
                // Dar la función de cerrar el popup al botón de Info
                Button aceptarInfo = info.transform.GetChild(1).gameObject.GetComponent<Button>();
                aceptarInfo.onClick.RemoveAllListeners();
                aceptarInfo.onClick.AddListener(delegate{CerrarPopUp();});
                // Añadir efecto de -5 energía y añade 2 cartas de "Compañía Agradable"
                aceptarInfo.onClick.AddListener(delegate{
                    GameObject jugador = GameObject.FindGameObjectWithTag("Player");
                    jugador.GetComponent<Jugador_Mapa>().RestarEnergia(5); // Resta 5 de energía
                    GameObject mano = GameObject.FindGameObjectWithTag("Mano");
                    mano.GetComponent<Mano>().RobarCartaEspecifica(1); // Añade una carta de "Compañía Agradable"
                });
                // Mostrar popup de información
                info.SetActive(true);
                decision.SetActive(false);
            });
            declinar.onClick.AddListener(delegate{CerrarPopUp();});
            // Mostrar popup de decisión
            popup.SetActive(true);
            popup.transform.GetChild(0).gameObject.SetActive(false);
            popup.transform.GetChild(2).gameObject.SetActive(false);
            decision.SetActive(true);
        }
        // Bloquear arrastre de cámara
        Camera.main.gameObject.GetComponent<Main_Camera>().BloquearArrastreCámara();
    }

    public void CerrarPopUp(){
        popup.SetActive(false);
        Camera.main.gameObject.GetComponent<Main_Camera>().DesbloquearArrastreCámara();
    }
}
