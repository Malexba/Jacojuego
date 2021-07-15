using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprite;
        MoverACasilla(casillaActual);
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
    }

    public void MoverACasilla(GameObject casilla){
        transform.position = casillaActual.transform.position + new Vector3(0,sprite.bounds.size.y/2,0);
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
