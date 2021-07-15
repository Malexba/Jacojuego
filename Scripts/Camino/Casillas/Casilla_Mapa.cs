using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casilla_Mapa : MonoBehaviour
{
    public List<GameObject> casillasSiguientes; // Casillas siguientes

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
