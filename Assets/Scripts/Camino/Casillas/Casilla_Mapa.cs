using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casilla_Mapa : MonoBehaviour
{
    public List<GameObject> casillasSiguientes; // Casillas siguientes

    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(1).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown(){
        
        // Si tiene el halo activo, el jugador se puede mover hacia alli
        if (transform.GetChild(1).gameObject.activeSelf){
            GameObject.FindGameObjectWithTag("Player").GetComponent<Jugador_Mapa>().MoverACasilla(transform);
        }
    }

    public List<GameObject> GetCasillasADistancia(int dist) // Devuelve una lista de las casillas a distancia dist
    {
        List<GameObject> casillas = new List<GameObject>();

        if (dist == 1){
            casillas = casillasSiguientes;
        } else {
            List<GameObject> auxs;
            foreach (GameObject casilla in casillasSiguientes){
                auxs = casilla.GetComponent<Casilla_Mapa>().GetCasillasADistancia(dist-1);
                foreach (GameObject aux in auxs){
                    casillas.Add(aux);
                }
            }
        }

        return casillas;
    }

    public void ActivarHalo(){
        transform.GetChild(1).gameObject.SetActive(true);
    }

    public void DesactivarHalo(){
        transform.GetChild(1).gameObject.SetActive(false);
    }
}
