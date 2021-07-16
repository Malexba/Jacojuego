using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Jugador_Mapa : MonoBehaviour

{
    public GameObject casillaActual; // Casilla en la que se encuentra
    public Sprite sprite; // Sprite que usa el jugador
    private int energiaMaxima = 30; // Energia maxima
    public int energia; // Energía actual
    private int motivacionMaxima = 10; // Motivacion maxima
    public int motivacion; // Motivación actual

    public GameObject barraEnergia; // Barra de energía
    public GameObject barraMotivacion; // Barra de motivación

    public Text numEnergia; // Barra de energía
    public Text numMotivacion; // Barra de motivación
    private float alturaMaxEnergia;
    private float alturaMaxMotivacion;

    public GameObject popup; // Popup
    public Jugador jugador; // ScriptableObject jugador
    public Character[] characters; // ScriptableObjects de Experto, Motivado y Veloz

    private int tipoJugador; // Tipo de jugador

    // Start is called before the first frame update
    void Start()
    {
        // Modificaciones de personaje
        tipoJugador = jugador.personaje;
        energiaMaxima = characters[tipoJugador].energia;
        motivacionMaxima = characters[tipoJugador].motivacion;
        GameObject.FindGameObjectWithTag("Mano").GetComponent<Mano>().maxNumCartas = characters[tipoJugador].tamInv;
        GetComponent<SpriteRenderer>().sprite = characters[tipoJugador].img;
        sprite = characters[tipoJugador].img;
        if (tipoJugador !=0){
            GetComponent<SpriteRenderer>().flipX = true;
        } else {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        // Mover a casilla inicial
        MoverACasilla(casillaActual.transform);
        // Ajustes de energía
        energia = energiaMaxima;
        motivacion = motivacionMaxima;
        alturaMaxEnergia = barraEnergia.GetComponent<RectTransform>().rect.width;
        alturaMaxMotivacion = barraMotivacion.GetComponent<RectTransform>().rect.width;
    }

    // Update is called once per frame
    void Update()
    {
        barraEnergia.GetComponent<RectTransform>().sizeDelta = new Vector2(energia*alturaMaxEnergia/energiaMaxima, barraEnergia.GetComponent<RectTransform>().rect.height);
        barraMotivacion.GetComponent<RectTransform>().sizeDelta = new Vector2(motivacion*alturaMaxMotivacion/motivacionMaxima, barraMotivacion.GetComponent<RectTransform>().rect.height);
        numEnergia.text = energia.ToString();
        numMotivacion.text = motivacion.ToString();

        if (energia==0){
            // Popup de información
            GameObject info = popup.transform.GetChild(0).gameObject;
            // Poner texto
            info.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Te has quedado sin energía.";
            // Poner métodos al botón
            Button aceptar = info.transform.GetChild(1).gameObject.GetComponent<Button>();
            aceptar.onClick.RemoveAllListeners();
            aceptar.onClick.AddListener(delegate{CerrarPopUp();});
            aceptar.onClick.AddListener(delegate{
                jugador.inicio = true;
                SceneManager.LoadScene("Intermedio");
            });
            // Mostrar popup de información
            popup.SetActive(true);
            popup.transform.GetChild(1).gameObject.SetActive(false);
            popup.transform.GetChild(2).gameObject.SetActive(false);
            info.SetActive(true);
            // Bloquear arrastre de cámara
            Camera.main.gameObject.GetComponent<Main_Camera>().BloquearArrastreCámara();
        } else if (motivacion == 0){
            // Popup de información
            GameObject info = popup.transform.GetChild(0).gameObject;
            // Poner texto
            info.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Te has quedado sin motivación.";
            // Poner métodos al botón
            Button aceptar = info.transform.GetChild(1).gameObject.GetComponent<Button>();
            aceptar.onClick.RemoveAllListeners();
            aceptar.onClick.AddListener(delegate{CerrarPopUp();});
            aceptar.onClick.AddListener(delegate{
                jugador.inicio = true;
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
    }

    public void CerrarPopUp(){
        popup.SetActive(false);
        Camera.main.gameObject.GetComponent<Main_Camera>().DesbloquearArrastreCámara();
    }

    public void MoverACasilla(Transform casilla){ // Mover jugador a una casilla
        
        // Mover la posición del jugador
        if (tipoJugador==2){
            transform.position = casilla.position + new Vector3(-GetComponent<SpriteRenderer>().size.x/5,GetComponent<SpriteRenderer>().size.y,0);
        } else {
            transform.position = casilla.position + new Vector3(0,GetComponent<SpriteRenderer>().size.y/2,0);
        }
        // Actualizar la casilla actual
        casillaActual = casilla.gameObject;
        // Desactivar el halo de todas las casillas del mapa 
        GameObject[] casillas = GameObject.FindGameObjectsWithTag("Casilla");
        foreach(GameObject cas in casillas){
            cas.transform.GetChild(1).gameObject.SetActive(false);
        }
        // Llamar al efecto de la nueva casilla
        casilla.gameObject.GetComponent<Casilla_Mapa>().Efecto();
    }

    public void SetEnergiaMaxima(int i){
        energiaMaxima = i;
    }

    public void SetMotivacionMaxima(int i){
        motivacionMaxima = i;
    }

    public void RestarEnergia(int i){
        if (energia - i <0){
            energia = 0;
        } else {
            energia = energia - i;
        }        
    }

    public void RestarMotivacion(int i){
        if (motivacion - i <0){
            motivacion = 0;
        } else {
            motivacion = motivacion - i;
        }        
    }

    public void SumarEnergia(int i){
        if (energia + i > energiaMaxima){
            energia = energiaMaxima;
        } else {
            energia = energia + i;
        }
    }
    public void SumarMotivacion(int i){
        if (motivacion + i > motivacionMaxima){
            motivacion = motivacionMaxima;
        } else {
            motivacion = motivacion + i;
        }
    }

    

    public int GetEnergia(){
        return energia;
    }

    public int GetMotivacion(){
        return motivacion;
    }
}
