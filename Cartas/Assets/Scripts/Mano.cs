using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mano : MonoBehaviour
{
    
    public List<GameObject> cartasEnMano = new List<GameObject>(); // Array de las cartas en la mano
    public GameObject carta ; // Prefab de Carta
    public float movementSpeed = 3f; // Velocidad de movimiento de las cartas
    int maxNumCartas = 4; // Número máximo de cartas en mano
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (cartasEnMano.Count < maxNumCartas){
            RobarCarta();
        } else {
            ReorganizarMano();
        }
    }

    List<GameObject> GetCartas(){
        return cartasEnMano;
    }

    // Roba una carta del mazo
    void RobarCarta(){
        GameObject nuevaCarta = Instantiate(carta, new Vector3(-350,54,0), transform.rotation);
        nuevaCarta.transform.SetParent(transform, false);
        nuevaCarta.name = "Carta_" + cartasEnMano.Count.ToString();
        nuevaCarta.GetComponent<Carta>().posicionEnMano = cartasEnMano.Count;
        cartasEnMano.Add(nuevaCarta);
        ReorganizarMano();
    }


    // Coloca las cartas en el mazo
    void ReorganizarMano(){
        int numeroDeCartas = cartasEnMano.Count;
        RectTransform rt = (RectTransform) carta.transform;
        float width = rt.rect.width;
        float anchura = (float) 1.5*(numeroDeCartas-1)*width ;
        for (int i=0; i < numeroDeCartas; i++){
            Vector3 endPosition = new Vector3((float)1.5*width*i-anchura/2+100,1,0);
            Vector3 currentPosition = cartasEnMano[i].transform.localPosition;
            
            if (cartasEnMano[i].transform.localPosition != endPosition){
                cartasEnMano[i].transform.localPosition = currentPosition + (endPosition-currentPosition)*movementSpeed*Time.deltaTime;//Vector3.MoveTowards(carta.transform.position, endPosition, 1f * Time.deltaTime);
            }
            
        }
    }

    // Usa una carta de la mano
    public void UsarCarta(int numCarta){
        // PROVOCAR EL EFECTO DE LA CARTA!!
        cartasEnMano[numCarta].GetComponent<Carta>().LlamarEfecto();
        // Destruir la instancia de la carta
        Destroy(cartasEnMano[numCarta]);
        cartasEnMano.RemoveAt(numCarta);
        
        // Reorganizar la mano
        for (int i=numCarta; i<cartasEnMano.Count;i++){
            cartasEnMano[i].name = "Carta_" + i.ToString();
            cartasEnMano[i].GetComponent<Carta>().posicionEnMano = i;
        }
    }
}
