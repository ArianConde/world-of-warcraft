using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JugarCarta : MonoBehaviour
{
    public GameObject Card;
    public GameObject Zona;
    public bool jugable = false;
    public bool PartidaTerminada;
    public bool Fenixrend;
    public bool Arthasrend;
    public bool Turno = true;

    // Referencias a zonas
    public GameObject ManoPlayer;
    public GameObject ManoEnemy;
    public GameObject CuerpoaCuerpoP ;
    public GameObject DistanciaP;
    public GameObject AsedioP;
    public GameObject CuerpoaCuerpoE;
    public GameObject DistanciaE;
    public GameObject AsedioE;
    public GameObject ClimaCaCp;
    public GameObject ClimaDP;
    public GameObject ClimaAP;
    public GameObject ClimaCaCE;
    public GameObject ClimaDE;
    public GameObject ClimaAE;

    private List<GameObject> Alianza;
    private List<GameObject> Horda;
    private int position = 0;
    private bool Fenixleg;
    private bool Arthasleg;

    void Start()
    {
           CuerpoaCuerpoP= GameObject.Find("Zona CuerpoaCuerpoP");
           DistanciaP = GameObject.Find("Zona DistanciaP");
           AsedioP = GameObject.Find("Zona AsedioP");
           CuerpoaCuerpoE = GameObject.Find("Zona CuerpoaCuerpoE");
           DistanciaE = GameObject.Find("Zona DistanciaE");
           AsedioE = GameObject.Find("Zona AsedioE");
           ClimaCaCp = GameObject.Find("Clima CaC player");
           ClimaDP = GameObject.Find("Clima D player");
           ClimaAP = GameObject.Find("Clima A player");
           ClimaCaCE = GameObject.Find("Clima CaC Enemigo");
           ClimaDE = GameObject.Find("Clima D Enemigo");
           ClimaAE = GameObject.Find("Clima A Enemigo");
           ManoPlayer = GameObject.Find("Mano Player");
           ManoEnemy = GameObject.Find("Mano Enemigo");
           PartidaTerminada = GameObject.Find("CalcGanador").GetComponent<Gestordeturnosymastallas>().FinPartida;
    }

    public void Play()
    {
        if (PartidaTerminada == false)
        {
            var carta = Card.GetComponent<Clasecarta>();
            GameObject destino = null;

            if (carta.Faccion == "Alianza")
            {
                destino = GetDestination(carta.Franja, Fenixleg,Fenixrend );
            }
            else if (carta.Faccion == "Horda")
            {
                destino = GetDestination(carta.Franja, Arthasleg, Arthasrend);
            }

            if (destino!= null && jugable)
            {
                Card.transform.SetParent(destino.transform, false);
                Card.transform.position = destino.transform.position;
                jugable = false;
            }
        }
    }

    private GameObject GetDestination(int Franjita, bool elegido, bool rendido)
    {
        switch (Franjita)
        {
            case 1:
                return elegido? CuerpoaCuerpoP : CuerpoaCuerpoE;
            case 2:
                return elegido? DistanciaP : DistanciaE;
            case 3:
                return elegido? AsedioP: AsedioE;
            case 4:
                return elegido? ClimaCaCp : ClimaCaCE;
            case 5:
                return elegido? ClimaDP: ClimaDE;
            case 6:
                return elegido? ClimaAP : ClimaAE;
            default:
                return null;
        }
    }

    public void verificadorAlianza()
    {
        if (Alianza.Count > 0)
        {
            position = Random.Range(0, Alianza.Count);
            if (Alianza[position].GetComponent<Clasecarta>().cartasenmano == false)
            {
                GameObject Card = Instantiate(Alianza[position], new Vector2(0, 0), Quaternion.identity);
                Card.transform.SetParent(ManoPlayer.transform, false);
                Alianza[position].GetComponent<Clasecarta>().cartasenmano = true;
            }
            else
            {
                verificadorAlianza(); // Considera usar un bucle infinito o un temporizador para evitar recursión infinita
            }
        }
    }

    public void verificadorHorda()
    {
        if (Horda.Count > 0)
        {
            position = Random.Range(0, Horda.Count);
            if (Horda[position].GetComponent<Clasecarta>().cartasenmano == false)
            {
                GameObject Card = Instantiate(Horda[position], new Vector2(0, 0), Quaternion.identity);
                Card.transform.SetParent(ManoEnemy.transform, false);
                Horda[position].GetComponent<Clasecarta>().cartasenmano = true;
            }
            else
            {
                verificadorHorda(); // Similarmente, considera alternativas a la recursión
            }
        }
    }

    void Update()
    {
       ManoPlayer = GameObject.Find("Mano Player");
      ManoEnemy = GameObject.Find("Mano Enemigo");
      Fenixleg= GameObject.Find("ElecCDA").GetComponent<Eleccion>().Fenixelegido;
      Arthasleg = GameObject.Find("ElecMordor").GetComponent<Eleccion>().Arthaselegido;
      Turno = GameObject.Find("GestTurno").GetComponent<Turnos>().Turno;
      Alianza = GameObject.Find("Mazo CDA").GetComponent<robarAlianza>().Alianza;
      Horda= GameObject.Find("Mazo Mordor").GetComponent<RobarHorda>().Horda;
      Fenixrend = GameObject.Find("Mano").GetComponent<ClaseJugador>().rendered;
      Arthasrend = GameObject.Find("Mano rival").GetComponent<ClaseJugador>().rendered;
    }
}