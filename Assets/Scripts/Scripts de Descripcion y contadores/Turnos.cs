using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turnos : MonoBehaviour
{
    public int Ronda = 1;
    public bool Turno = true;
    public ClaseJugador ManoAlianza;
    public ClaseJugador ManoHorda;
   
    public Text Alianzarendidotxt;
    public Text MordorRendidotxt;
    public bool skillsauron;
    private int sauron = 1;
    private int Mano1 = 0;
    private int Mano2 = 0;
    private int comparador1 = 0;
    private int comparador2 = 0;
    private RectTransform taparmanoCDA;
    private RectTransform taparmanomordor;
    bool eligearagorn;
    bool eligesauron;
     private bool CDARoboRonda1;
    private bool CDARoboRonda2;
    private bool CDARoboRonda3;
    private bool MordorRoboRonda1;
    private bool MordorRoboRonda2;
    private bool MordorRoboRonda3;

    public string Ganador;
    private int CompRonda = 1;

    void Start()
    {
    }

    public void EmpCDA()
    {
        Turno = true;
    }

    public void EmpMordor()
    {
        Turno = false;
    }

    void Update()
    {
    
      
        Mano1 = GameObject.Find("Mano Player").GetComponent<ClaseJugador>().cards;
        Mano2 = GameObject.Find("Mano Enemigo").GetComponent<ClaseJugador>().cards;

        // Simplificación de la lógica de cambio de turno
        if (skillsauron && sauron == 1 && eligesauron)
        {
            sauron += 1;
            Turno =!Turno; // Cambio de turno simplificado
        }

        
    }
}