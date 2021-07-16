using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicota : MonoBehaviour
{
    public GameObject g;
    public AudioClip[] clip;
    public Jugador jugador;
    // Start is called before the first frame update
    void Start()
    {
        
        g = GameObject.FindGameObjectWithTag("Musica");
        if (g.GetComponent<AudioSource>().clip == null)
        {
            jugador.inicio = true;
        }
        DontDestroyOnLoad(g);
        cambioPista(0);
        
    }

    public void cambioPista(int i)
    {
        if (g.GetComponent<AudioSource>().clip != clip[i])
        {
            g.GetComponent<AudioSource>().clip = clip[i];
            g.GetComponent<AudioSource>().Play();
        }
        
    }
}
