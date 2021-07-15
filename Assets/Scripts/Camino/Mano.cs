using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Mano : MonoBehaviour
{

    public List<GameObject> cartasEnMano = new List<GameObject>(); // Array de las cartas en la mano
    private List<int> tipoCartasMano = new List<int>(); // Tipos de las cartas de la mano
    public List<int> mazo = new List<int>(); // Mazo en la mochila
    public Jugador propiedadesJugador; // Propiedades del ScriptableObject Jugador
    public GameObject[] cartas; // Prefabs de Carta Camino Llano, Carta Compañía Agradable, Carta Motivación Extra, Carta Almuerzo en Grupo, Carta Oración a la Catedral de Burgos
    public float movementSpeed = 1.5f; // Velocidad de movimiento de las cartas
    int maxNumCartas = 4; // Número máximo de cartas en mano
    private GameObject mochila; // GameObject de la mochila de la UI
    private bool[] creating; // Booleanos que indican si se está creando una carta
    private float[] timeCreating; // Timestamps desde que se inicio la creación de una carta
    private bool arrastrables; // Indica si se puede arrastrar cartas
    private bool principioDeTurno; // Indica si es el principio de turno

    private float timePrincipioDeTurno; // Timestamp desde principio de turno

    public GameObject jugador; // Jugador


    // Start is called before the first frame update
    void Start()
    {
        creating = new bool[maxNumCartas];
        timeCreating = new float[maxNumCartas];
        arrastrables = true;
        principioDeTurno = true;
        transform.GetChild(1).gameObject.SetActive(false);
        foreach(int num in propiedadesJugador.mazo){
            mazo.Add(num);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Actualiza la posicion de las cartas de la mano
        if (principioDeTurno)
        {   
            int aux = cartasEnMano.Count;
            for (int i =aux-1; i>=0;i--){
                Destroy(cartasEnMano[i]);
                cartasEnMano.RemoveAt(i);
                mazo.Add(tipoCartasMano[i]); // Poner la carta de vuelta en el mazo
                tipoCartasMano.RemoveAt(i);
            }
            transform.GetChild(1).gameObject.SetActive(true);
            for (int i =0; i<maxNumCartas;i++){
                RobarCarta();
            }
            principioDeTurno = false;
            
        }
        else
        {
            ReorganizarMano();
        }

        // Si ha pasado un segundo desde la creación de la carta, creating[i]=false
        int auxs = cartasEnMano.Count;
        for (int i = 0; i < auxs; i++)
        {
            
            if (cartasEnMano[i].GetComponent<Carta>().creating == true && Time.realtimeSinceStartup - timeCreating[i] > 3f)
            {
                cartasEnMano[i].GetComponent<Carta>().creating = false;
            }
        }

        if (Time.realtimeSinceStartup - timePrincipioDeTurno > 1f){
            transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    public List<GameObject> GetCartas()
    {
        return cartasEnMano;
    }

    // Roba una carta del mazo
    void RobarCarta()
    {
        print(mazo[1]);
        creating[cartasEnMano.Count] = true;
        timeCreating[cartasEnMano.Count] = Time.realtimeSinceStartup;
        int index = (int)Math.Floor(mazo.Count*UnityEngine.Random.value);
        tipoCartasMano.Add(mazo[index]); // Añadir el tipo de la carta
        GameObject nuevaCarta = Instantiate(cartas[mazo[index]], new Vector3(-350, 54, 0), transform.rotation);
        mazo.RemoveAt(index); // Quitar carta del mazo porque está en la mano
        nuevaCarta.transform.SetParent(transform, false);
        nuevaCarta.name = "Carta_" + cartasEnMano.Count.ToString();
        nuevaCarta.GetComponent<Carta>().posicionEnMano = cartasEnMano.Count;
        cartasEnMano.Add(nuevaCarta);

        ReorganizarMano();
    }


    // Coloca las cartas en el mazo
    void ReorganizarMano()
    {
        int numeroDeCartas = cartasEnMano.Count;
        RectTransform rt = (RectTransform)cartas[0].transform;
        float width = rt.rect.width;
        float anchura = (float)1.5 * (numeroDeCartas - 1) * width;
        for (int i = 0; i < numeroDeCartas; i++)
        {
            Vector3 endPosition = new Vector3((float)1.5 * width * i - anchura / 2 + 100, 1, 0);
            Vector3 currentPosition = cartasEnMano[i].transform.localPosition;

            if (cartasEnMano[i].transform.localPosition != endPosition)
            {
                cartasEnMano[i].transform.localPosition = currentPosition + (endPosition - currentPosition) * movementSpeed * Time.deltaTime;
            }
        }
    }

    // Usa una carta de la mano
    public void UsarCarta(int numCarta)
    {
        // Si la carta no se está creando
        if (!cartasEnMano[numCarta].GetComponent<Carta>().creating && !principioDeTurno)
        {
            // Provocar el efecto de la carta
            cartasEnMano[numCarta].GetComponent<Carta>().LlamarEfecto();
            // Destruir la instancia de la carta
            Destroy(cartasEnMano[numCarta]);
            cartasEnMano.RemoveAt(numCarta);
            mazo.Add(tipoCartasMano[numCarta]); // Poner la carta de vuelta en el mazo
            tipoCartasMano.RemoveAt(numCarta);

            // Reorganizar la mano
            for (int i = numCarta; i < cartasEnMano.Count; i++)
            {
                cartasEnMano[i].name = "Carta_" + i.ToString();
                cartasEnMano[i].GetComponent<Carta>().posicionEnMano = i;
            }
        }
    }

    public bool GetArrastrables(){
        return arrastrables;
    }

    public void TerminarTurno(){
        principioDeTurno = true;
        timePrincipioDeTurno = Time.realtimeSinceStartup;
        jugador.GetComponent<Jugador_Mapa>().RestarMotivacion(1);
    }

    // True si el raton esta sobre la mano
    public bool MouseSobreMano(){
        Ray ray;
        RaycastHit hit;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit))
        {
            return true;
        }
        else{
            return false;
        }
    }
}
