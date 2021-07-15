using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mochila_HUD : MonoBehaviour
{
    private float posMano;
    private float posManoOculta;
    private float posMochila;

    void Start(){
        posMano = GameObject.FindGameObjectWithTag("Mano").transform.position.y;
        posManoOculta = -550;
        posMochila = transform.position.y;
    }
    public void OcultarMochila(){
        GameObject mano = GameObject.FindGameObjectWithTag("Mano");
        if (mano.transform.position.y == posMano){
            mano.transform.position = new Vector3(mano.transform.position.x, posManoOculta, mano.transform.position.z);
        } else if (mano.transform.position.y == posManoOculta){
            mano.transform.position = new Vector3(mano.transform.position.x, posMano, mano.transform.position.z);
        }
        transform.position = new Vector3(transform.position.x, posMochila, transform.position.z);
    }
}
