using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RobarHorda : MonoBehaviour
{
    //aca declaro todas las cartas de uno de los mazos
public GameObject Card;
public GameObject UrukHai1;
public GameObject UrukHai2;
public GameObject UrukHai3;
public GameObject OrcArcher1;
public GameObject OrcArcher2;
public GameObject OrcArcher3;
public GameObject OlogHai1;
public GameObject OlogHai2;
public GameObject OlogHai3;
public GameObject Bolg;
public GameObject Lurtz;
public GameObject Ratbag;
public GameObject Azog;
public GameObject Balrog;
public GameObject Smaug;
public GameObject Saruman;
public GameObject Gollum;
public GameObject Nazgul;
public GameObject RingMelee;
public GameObject RingRanged;
public GameObject RingSiege;
public GameObject Despeje3;
public GameObject Despeje4;
public GameObject Lluvia3;
public GameObject Lluvia4;
public GameObject Niebla3;
public GameObject Niebla4;
public GameObject Nevada3;
public GameObject Nevada4;

public bool robo1 = false;
public bool robo2 = false;
public bool robo3 = false;
private int Ronda = 1;
private bool Turno;
private int posicion = 0;


public List <GameObject> Horda = new List<GameObject>(); //aca creo una lista en la que se van a meter las cartas
public GameObject Mano;



public void revisarjugada()
    {
        posicion = Random.Range(0, Horda.Count);
        if(Horda[posicion].GetComponent<Clasecarta>().cartasenmano == false)
        {
            GameObject Card = Instantiate(Horda[posicion], new Vector2(0,0), Quaternion.identity);
            Card.transform.SetParent(Mano.transform, false);
            Horda[posicion].GetComponent<Clasecarta>().cartasenmano  = true;
        }
        else
        {
            revisarjugada();
        }
    }

public void OnClick()
{
    if(Turno == false)
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
    Horda.Add(UrukHai1);
    Horda.Add(UrukHai2);
    Horda.Add(UrukHai3);
    Horda.Add(OrcArcher1);
    Horda.Add(OrcArcher2);
    Horda.Add(OrcArcher3);
    Horda.Add(OlogHai1);
    Horda.Add(OlogHai2);
    Horda.Add(OlogHai3);
    Horda.Add(Bolg);
    Horda.Add(Lurtz);
    Horda.Add(Ratbag);
    Horda.Add(Azog);
    Horda.Add(Balrog);
    Horda.Add(Smaug);
    Horda.Add(Saruman);
    Horda.Add(Gollum);
    Horda.Add(Nazgul);
    Horda.Add(RingMelee);
    Horda.Add(RingRanged);
    Horda.Add(RingSiege);
    
    

    foreach(GameObject Card in Horda)
    {
        Card.GetComponent<Clasecarta>().cartasenmano = false;
    }
    }

    void Update()
    {}}
    
