using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mochila_HUD : MonoBehaviour
{
    private float posMano;
    private float posManoOculta;
    private float posMochila;
    private bool mochilaOculta;

    void Start(){
        posMano = GameObject.FindGameObjectWithTag("Mano").transform.position.y;
        posManoOculta = -550;
        posMochila = transform.position.y;
        mochilaOculta = false;
    }
    public void OcultarMochila(){
        GameObject mano = GameObject.FindGameObjectWithTag("Mano");
        if (!mochilaOculta){
            mano.transform.position = new Vector3(mano.transform.position.x, posManoOculta, mano.transform.position.z);
            mochilaOculta = true;
        } else {
            mano.transform.position = new Vector3(mano.transform.position.x, posMano, mano.transform.position.z);
            mochilaOculta = false;
        }
        transform.position = new Vector3(transform.position.x, posMochila, transform.position.z);
    }
}
