using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class robarAlianza : MonoBehaviour
{
    //aca declaro todas las cartas del mazo de la Comunidad del Anillo
public GameObject GondorWarrior1;
public GameObject GondorWarrior2;
public GameObject GondorWarrior3;
public GameObject ElficArcher1;
public GameObject ElficArcher2;
public GameObject ElficArcher3;
public GameObject SiegeMachine1;
public GameObject SiegeMachine2;
public GameObject SiegeMachine3;
public GameObject Barbol;
public GameObject Boromir;
public GameObject Elrond;
public GameObject Frodo;
public GameObject Galadriel;
public GameObject Gandalf;
public GameObject Gimli;
public GameObject Legolas;
public GameObject Sam;
public GameObject Talion;
public GameObject Despeje;
public GameObject Despeje2;
public GameObject Lluvia;
public GameObject Lluvia2;
public GameObject Niebla;
public GameObject Niebla2;
public GameObject Nevada;
public GameObject Nevada2;
public GameObject CuernoGondorMelee;
public GameObject CuernoGondorRanged;
public GameObject CuernoGondorSiege;

public bool robo1 = false;
public bool robo2 = false;
public bool robo3 = false;
private int Ronda = 1;
private bool Turno;
private int posicion = 0;

public List <GameObject> Alianza = new List<GameObject>(); //aca creo una lista en la que se van a meter las cartas
public GameObject Mano;

public void revisarjugada()
    {
        posicion = Random.Range(0, Alianza.Count);
        if(Alianza[posicion].GetComponent<Clasecarta>().cartasenmano == false)
        {
            GameObject Card = Instantiate(Alianza[posicion], new Vector2(0,0), Quaternion.identity);
            Card.transform.SetParent(Mano.transform, false);
            Alianza[posicion].GetComponent<Clasecarta>().cartasenmano  = true;
        }
        else
        {
            revisarjugada();
        }
    }

public void OnClick()
{
        if(Turno)
        {
        if(robo1 == false && Ronda == 1)
        {
        for (int i= 0; i < 10; i ++)
        { 
            revisarjugada();
        }
        robo1 = true;
        }

        if(robo2 == false && Ronda == 2)
        {
        for (int i= 0; i < 2; i ++)
        {
            revisarjugada();
        }
        robo2 = true;
        }

        if(robo3 == false && Ronda == 3)
        {
        for (int i= 0; i < 2; i ++)
        { 
            revisarjugada();
        }
        robo3 = true;
        }
}
    }
    void Start()
    {
    //aca añado todas las cartas a la lista de cartas

    Alianza.Add(GondorWarrior2);
    Alianza.Add(GondorWarrior3);
    Alianza.Add(ElficArcher1);
    Alianza.Add(ElficArcher2);
    Alianza.Add(ElficArcher3);
    Alianza.Add(SiegeMachine1);
    Alianza.Add(SiegeMachine2);
    Alianza.Add(SiegeMachine3); 
    Alianza.Add(Barbol);
    Alianza.Add(Boromir);
    Alianza.Add(Elrond);
    Alianza.Add(Frodo);
    Alianza.Add(Galadriel);
    Alianza.Add(Gandalf);
    Alianza.Add(Gimli);
    Alianza.Add(Legolas);
    Alianza.Add(Sam);
    Alianza.Add(Talion);




    
}}
