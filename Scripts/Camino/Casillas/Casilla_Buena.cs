using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Casilla_Buena : MonoBehaviour
{
    public GameObject popup; // Popup
    private int posLista = 0; // Posicion en la lista de cartas (mod 3)

    // Provocar efecto beneficioso
    public void ProvocarEfecto(){
        // Selecciona un efecto beneficoso al azar
        int efecto = (int)Math.Floor(2*UnityEngine.Random.value);
        if (efecto==2) efecto=1;
        // 0 = Un compañero peregrino te invita a un almuerzo. Recuperas 5 de energía.
        if (efecto == 0){
            // Poner popup (el efecto se implementa en un método al pulsar el botón "Aceptar" del popup)
            
            // Popup de información
            GameObject info = popup.transform.GetChild(0).gameObject;
            // Poner texto
            info.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Un compañero peregrino te invita a un almuerzo.\nRecuperas 5 de energía.";
            // Poner métodos al botón
            Button aceptar = info.transform.GetChild(1).gameObject.GetComponent<Button>();
            aceptar.onClick.RemoveAllListeners();
            aceptar.onClick.AddListener(delegate{GameObject.FindGameObjectWithTag("Player").GetComponent<Jugador_Mapa>().SumarEnergia(5);});
            aceptar.onClick.AddListener(delegate{CerrarPopUp();});
            // Mostrar popup de información
            popup.SetActive(true);
            popup.transform.GetChild(1).gameObject.SetActive(false);
            popup.transform.GetChild(2).gameObject.SetActive(false);
            info.SetActive(true);
        }
        // 1 = Rebuscas en tu mochila y te encuentras con un hallazgo fortuito. Escoges una carta de tu mazo y la robas.
        else if (efecto==1) {
            // Poner selección de cartas de la mochila (el efecto se implamenta al clickar sobre la carta deseada)

            // Popup de información
            GameObject info = popup.transform.GetChild(0).gameObject;
            // Poner texto
            info.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Rebuscas en tu mochila y te encuentras con un hallazgo fortuito. Escoges una carta de tu mazo y la robas.";
            // Poner métodos al botón
            Button aceptar = info.transform.GetChild(1).gameObject.GetComponent<Button>();
            aceptar.onClick.RemoveAllListeners();
            aceptar.onClick.AddListener(delegate{ 
                // Popup de mazo
                GameObject mazo = popup.transform.GetChild(2).gameObject;
                posLista = 0;
                mostrarMazo();
            });
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

    public void mostrarMazo()
    {
        // Mostrar popup de mano
        popup.SetActive(true);
        popup.transform.GetChild(0).gameObject.SetActive(false);
        popup.transform.GetChild(1).gameObject.SetActive(false);
        GameObject pantallaMazo = popup.transform.GetChild(2).gameObject;
        pantallaMazo.SetActive(true);

        
        GameObject jugador =  GameObject.FindGameObjectWithTag("Player"); // Jugador
        GameObject mano =  GameObject.FindGameObjectWithTag("Mano"); // Mano
        List<int> mazo = mano.GetComponent<Mano>().mazo; // Mazo en la mochila
        GameObject botonAbajo = pantallaMazo.transform.GetChild(4).gameObject; // Botón de abajo
        if (mazo.Count > 3*(posLista+1)) // Quedan elementos después de estos tres, podemos seguir bajando
            botonAbajo.GetComponent<Button>().interactable = true;
        muestraCartas();
    }

    public void desplazoLista(bool arr)
    {
        GameObject jugador =  GameObject.FindGameObjectWithTag("Player"); // Jugador
        GameObject mano =  GameObject.FindGameObjectWithTag("Mano"); // Mano
        List<int> mazo = mano.GetComponent<Mano>().mazo; // Mazo en la mochila
        GameObject pantallaMazo = popup.transform.GetChild(2).gameObject; // Popup de mazo
        GameObject botonArriba = pantallaMazo.transform.GetChild(3).gameObject; // Botón de arriba
        GameObject botonAbajo = pantallaMazo.transform.GetChild(4).gameObject; // Botón de abajo
        if (arr) // Pulsamos botón subir
        {
            posLista--;
            botonAbajo.GetComponent<Button>().interactable = true; // Venimos de abajo, sabemos que podemos bajar
            if (posLista == 0) // Estamos en el comienzo de la lista, no podemos subir más
            {
                botonArriba.GetComponent<Button>().interactable = false;
            }
        } else // Pulsamos botón bajar
        {
            posLista++;
            botonArriba.GetComponent<Button>().interactable = true; // Venimos de arriba, sabemos que podemos subir
            if (mazo.Count > 3*(posLista+1)) // Quedan elementos después de estos tres, podemos seguir bajando
                botonAbajo.GetComponent<Button>().interactable = true;
            else // Estamos en los tres, dos o un último elemento
                botonAbajo.GetComponent<Button>().interactable = false;
        }
        muestraCartas();
    }

    private void muestraCartas()
    {
        GameObject jugador =  GameObject.FindGameObjectWithTag("Player"); // Jugador
        GameObject mano =  GameObject.FindGameObjectWithTag("Mano"); // Mano
        List<int> mazo = mano.GetComponent<Mano>().mazo; // Mazo en la mochila
        GameObject pantallaMazo = popup.transform.GetChild(2).gameObject; // Popup de mazo
        GameObject botonArriba = pantallaMazo.transform.GetChild(3).gameObject; // Botón de arriba
        GameObject botonAbajo = pantallaMazo.transform.GetChild(4).gameObject; // Botón de abajo
        // Array de objetos para poner los sprites de cartas
        GameObject[] carta = new GameObject[3];
        for (int index =0;index<3;index++){
            carta[index] = pantallaMazo.transform.GetChild(index).gameObject;
        }

        int i = 3;
        if (mazo.Count < 3*(posLista+1)) // En esta parte de la lista hay menos de tres cartas
            i = mazo.Count % 3;
        for (int j = 0; j < 3; j++) // Muestro u oculto las tres cartas; así como actualizo sus sprites
        {
            if (j < i)
            {
                carta[j].SetActive(true);
                carta[j].GetComponent<Image>().sprite = mano.GetComponent<Mano>().spriteCarta[mazo[3*posLista+j]];
            } else
                carta[j].SetActive(false);
        }
    }

    public void SeleccionarCarta(int c){
        GameObject pantallaMazo = popup.transform.GetChild(2).gameObject; // Popup de mazo
        // Array de objetos para poner los sprites de cartas
        GameObject[] carta = new GameObject[3];
        for (int index =0;index<3;index++){
            carta[index] = pantallaMazo.transform.GetChild(index).gameObject;
        }
        GameObject mano =  GameObject.FindGameObjectWithTag("Mano"); // Mano        
        mano.GetComponent<Mano>().RobarCartaEspecifica(mano.GetComponent<Mano>().spriteCarta.IndexOf(carta[c].GetComponent<Image>().sprite));
        pantallaMazo.SetActive(false);
        popup.transform.GetChild(0).gameObject.SetActive(false);
        popup.transform.GetChild(1).gameObject.SetActive(false);
        popup.SetActive(false);
        Camera.main.gameObject.GetComponent<Main_Camera>().DesbloquearArrastreCámara();
    }
}
