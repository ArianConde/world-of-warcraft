using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gestordeturnosymastallas : MonoBehaviour
{
    public Text VictoriaCDA;
    public Text VictoriaMordor;
    public string PuntosCDA;
    public string PuntosMordor;
    public int Ronda = 1;
    public string GanadordeRonda;
    public Turnos Turnito;

    public bool CDARendido;
    public bool MordorRendido;
    public int CDAWin = 0;
    public int MordorWin = 0;
    public bool FinPartida = false;

    private int ManoCDA;
    private int ManoMordor;

    void Awake()
    {
        GanadordeRonda = "nulo";
        Turnito = GameObject.FindGameObjectWithTag("ContTurno").GetComponent<Turnos>();
    }

    void Update()
    {
        ActualizarDatos();

        if (!FinPartida)
        {
            DeterminarGanador();
        }
    }

    void ActualizarDatos()
    {
        ManoCDA = GameObject.Find("Mano").GetComponent<ClaseJugador>().cards;
        ManoMordor = GameObject.Find("Mano rival").GetComponent<ClaseJugador>().cards;
        CDARendido = GameObject.Find("Mano").GetComponent<ClaseJugador>().rendered;
        MordorRendido = GameObject.Find("Mano rival").GetComponent<ClaseJugador>().rendered;
        PuntosCDA = GameObject.Find("contcda").GetComponent<Text>().text;
        PuntosMordor = GameObject.Find("contmordor").GetComponent<Text>().text;
    }

    void DeterminarGanador()
    {
        int ptsCDA = int.Parse(PuntosCDA);
        int ptsMordor = int.Parse(PuntosMordor);

        if (ManoCDA == 0 && ManoMordor == 0)
        {
            if (ptsCDA > ptsMordor)
            {
                CDAWin++;
                VictoriaCDA.text = CDAWin.ToString();
                GanadordeRonda = "CDA";
                Turnito.Turno = true;
            }
            else if (ptsMordor > ptsCDA)
            {
                MordorWin++;
                VictoriaMordor.text = MordorWin.ToString();
                GanadordeRonda = "Mordor";
                Turnito.Turno = false;
            }
            Ronda++;
        }
        else if (CDARendido && MordorRendido)
        {
            if (ptsCDA > ptsMordor)
            {
                CDAWin++;
                VictoriaCDA.text = CDAWin.ToString();
                GanadordeRonda = "CDA";
                Turnito.Turno = true;
            }
            else if (ptsMordor > ptsCDA)
            {
                MordorWin++;
                VictoriaMordor.text = MordorWin.ToString();
                GanadordeRonda = "Mordor";
                Turnito.Turno = false;
            }
            Ronda++;
        }

        if (Ronda > 3)
        {
            FinPartida = true;
            if (CDAWin > MordorWin)
            {
                SceneManager.LoadScene(7); // Cambiar por el ID de la escena de victoria de CDA
            }
            else if (MordorWin > CDAWin)
            {
                SceneManager.LoadScene(6); // Cambiar por el ID de la escena de victoria de Mordor
            }
            else
            {
                SceneManager.LoadScene(8); // Cambiar por el ID de la escena de empate
            }
        }
    }
}