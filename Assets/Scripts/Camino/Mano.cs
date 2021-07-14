using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mano : MonoBehaviour
{

    public List<GameObject> cartasEnMano = new List<GameObject>(); // Array de las cartas en la mano
    public GameObject carta; // Prefab de Carta
    public float movementSpeed = 1.5f; // Velocidad de movimiento de las cartas
    int maxNumCartas = 4; // Número máximo de cartas en mano
    private GameObject mochila; // GameObject de la mochila de la UI
    private bool[] creating; // Booleanos que indican si se está creando una carta
    private float[] timeCreating; // Timestamps desde que se inicio la creación de una carta
    private bool arrastrables; // Indica si se puede arrastrar cartas

    // Start is called before the first frame update
    void Start()
    {
        creating = new bool[maxNumCartas];
        timeCreating = new float[maxNumCartas];
        arrastrables = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Actualiza la posicon de las cartas de la mano
        if (cartasEnMano.Count < maxNumCartas)
        {
            RobarCarta();
        }
        else
        {
            ReorganizarMano();
        }

        // Si ha pasado un segundo desde la creación de la carta, creating[i]=false
        for (int i = 0; i < maxNumCartas; i++)
        {
            if (creating[i] == true && Time.realtimeSinceStartup - timeCreating[i] > 1f)
            {
                creating[i] = false;
            }
        }
    }

    List<GameObject> GetCartas()
    {
        return cartasEnMano;
    }

    // Roba una carta del mazo
    void RobarCarta()
    {
        creating[cartasEnMano.Count] = true;
        timeCreating[cartasEnMano.Count] = Time.realtimeSinceStartup;
        GameObject nuevaCarta = Instantiate(carta, new Vector3(-350, 54, 0), transform.rotation);
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
        RectTransform rt = (RectTransform)carta.transform;
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
        if (!creating[numCarta])
        {
            // Provocar el efecto de la carta
            cartasEnMano[numCarta].GetComponent<Carta>().LlamarEfecto();
            // Destruir la instancia de la carta
            Destroy(cartasEnMano[numCarta]);
            cartasEnMano.RemoveAt(numCarta);

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
}
