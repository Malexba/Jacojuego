using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Casilla_Final : MonoBehaviour
{
    public GameObject popup; // Popup

    public Jugador jugador; // ScriptableObject Jugador
    // Muestra el popup de fin de etapa
    public void ProvocarEfecto(){
        // Mostrar popup de fin de etapa(Pulsar el botón lleva al albergue)

        // Popup de información
            GameObject info = popup.transform.GetChild(0).gameObject;
            // Poner texto
            info.transform.GetChild(0).gameObject.GetComponent<Text>().text = "¡Has llegado al final de la etapa!\nToca descansar tras un duro día de camino.";
            // Poner métodos al botón
            Button aceptar = info.transform.GetChild(1).gameObject.GetComponent<Button>();
            aceptar.onClick.RemoveAllListeners();
            aceptar.onClick.AddListener(delegate{CerrarPopUp();});
            aceptar.onClick.AddListener(delegate{
                jugador.inicio = false;
                SceneManager.LoadScene("Intermedio");
            });
            // Mostrar popup de información
            popup.SetActive(true);
            popup.transform.GetChild(1).gameObject.SetActive(false);
            popup.transform.GetChild(2).gameObject.SetActive(false);
            info.SetActive(true);
            // Bloquear arrastre de cámara
            Camera.main.gameObject.GetComponent<Main_Camera>().BloquearArrastreCámara();
    }

    public void CerrarPopUp(){
        popup.SetActive(false);
        Camera.main.gameObject.GetComponent<Main_Camera>().DesbloquearArrastreCámara();
    }
}
