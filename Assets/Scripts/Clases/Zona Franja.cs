using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ClaseFranja : MonoBehaviour
{
private GameObject CartaJugada;
public List<GameObject> CartasenFranja;
public int Suma = 0;
public int Cartas = 0;
public Text puntuationText;
public string Faccion;
public int franja;
public GameObject CementerioAlianza;
public GameObject CementerioHorda;
public GameObject ManoPlayer;
public GameObject ManoEnemy;
public int sumaparcial = 0;
public bool climaafectado = false;
public bool aumentoafectado = false;


 ClaseFranja CuerpoaCuerpoP; //pcc
private ClaseFranja DistanciaP; //pd
private ClaseFranja AsedioP; //ps
private ClaseFranja CuerpoaCuerpoE; //ec
private ClaseFranja DistanciaE ;
private ClaseFranja AsedioE;


private int Ronda = 1;
private int ComprobadordeRonda = 1;


private void OnCollisionEnter2D(Collision2D collision)
{
CartaJugada = collision.gameObject;
CartasenFranja.Add(CartaJugada);
Cartas += 1;
}


    public int MayorCarta()
    {
        int mayor = 0;
        foreach(GameObject Card in CartasenFranja)
        {
            mayor = Mathf.Max(mayor, Card.GetComponent<Clasecarta>().poder);
        }
        return mayor;
    }

    public void EliminarMayorCarta(int puntos)
    {
        if(CartasenFranja.Count == 1 || CartasenFranja.Count > 1)
        {
            foreach(GameObject Card in CartasenFranja)
            {
                if(Card.GetComponent<Clasecarta>().poder == puntos && Faccion == "Comunidad del Anillo")
                {
                    Card.transform.position = CementerioAlianza.transform.position;
                    Card.transform.SetParent(CementerioAlianza.transform, true);
                    CartasenFranja.Remove(Card);
                    return;
                }
            }
        }
    }


public void Legolas()
{
    if(CartasenFranja.Count == 1 || CartasenFranja.Count > 1)
        {
            int cartamenor = CartasenFranja[0].GetComponent<Clasecarta>().poder;
            for(int i = 0; i < CartasenFranja.Count; i++)
            {
                cartamenor = Mathf.Min(cartamenor, CartasenFranja[i].GetComponent<Clasecarta>().poder);
            }
            foreach(GameObject Card in CartasenFranja)
            {
            if(Card.GetComponent<Clasecarta>().poder == cartamenor)
            {
                Card.transform.position = CementerioHorda.transform.position;
                Card.transform.SetParent(CementerioHorda.transform, true);
                CartasenFranja.Remove(Card);
                break;
            }
            }
        }
}

public int Gandalf()
{
    int promediocartas = 0;
    foreach(GameObject Card in CartasenFranja)
    {
        promediocartas += Card.GetComponent<Clasecarta>().poder;
    }
    return promediocartas;
}

public void GandalfUsado(int promediocartas)
{
    foreach(GameObject Card in CartasenFranja)
    {
        Card.GetComponent<Clasecarta>().poder = promediocartas;
    }

}

public void Gollum()
{
    if(CartasenFranja.Count == 1 || CartasenFranja.Count > 1)
    {
    int mayor = CartasenFranja[0].GetComponent<Clasecarta>().poder;
    for(int i = 0; i < CartasenFranja.Count; i++)
    {
        mayor = Mathf.Max(mayor, CartasenFranja[i].GetComponent<Clasecarta>().poder);
    }
    foreach(GameObject Card in CartasenFranja)
    {
         if(Card.GetComponent<Clasecarta>().poder == mayor && Card.GetComponent<Clasecarta>().Faccion == "Comunidad del Anillo")
        {
            Card.transform.SetParent(ManoPlayer.transform, false);
            Card.transform.position = ManoPlayer.transform.position;
            Card.GetComponent<JugarCarta>().jugable = true;
            Card.GetComponent<Clasecarta>().ClimaAfectado= false;
            Card.GetComponent<Clasecarta>().AumentoAfectado = false;
            Card.GetComponent<Clasecarta>().poder = Card.GetComponent<Clasecarta>().PoderInicial;
            CartasenFranja.Remove(Card);
            return;
        }
        if(Card.GetComponent<Clasecarta>().poder == mayor && Card.GetComponent<Clasecarta>().Faccion == "Horda")
        {
            Card.transform.SetParent(ManoEnemy.transform, false);
            Card.transform.position = ManoEnemy.transform.position;
            Card.GetComponent<JugarCarta>().jugable = true;
            Card.GetComponent<Clasecarta>().ClimaAfectado = false;
            Card.GetComponent<Clasecarta>().AumentoAfectado = false;
            Card.GetComponent<Clasecarta>().poder = Card.GetComponent<Clasecarta>().PoderInicial;
            CartasenFranja.Remove(Card);
            return;
        }
    }
    }
}


public void Balrog(int Franja)
{
        if(CartasenFranja.Count == 1 || CartasenFranja.Count > 1)
        {
            if(CartasenFranja.Count < 10)
            {
                if(CartasenFranja.Count == Franja)
                {
                foreach(GameObject Card in CartasenFranja)
                {
                    Card.transform.position = CementerioAlianza.transform.position;
                    Card.transform.SetParent(CementerioAlianza.transform, true);
                }
                CartasenFranja.Clear();
                }
            }
        }
}

public void Climas()
{
    climaafectado = true;
}

public void Cuerno()
    {
       aumentoafectado = true;  
    }

public void Anillo()
    {
       aumentoafectado = true;  
    }

public void Despeje()
    {
        climaafectado = false;
        foreach(GameObject Card in CartasenFranja)
        {
            Card.GetComponent<Clasecarta>().ClimaAfectado = false;
            Card.GetComponent<Clasecarta>().AumentoAfectado = false;
            Card.GetComponent<Clasecarta>().poder = Card.GetComponent<Clasecarta>().PoderInicial;
        }
    }




void Update()
{

if(ComprobadordeRonda != Ronda)
        {
            ComprobadordeRonda = Ronda;
            if(Faccion == "Alianza")
            {
                foreach(GameObject Card in CartasenFranja)
                {
                    Card.transform.SetParent(CementerioAlianza.transform, true);
                    Card.transform.position = CementerioAlianza.transform.position;
                }
                CartasenFranja.Clear();
                 Suma = 0;
                puntuationText.text = Suma.ToString();
            }

             if(Faccion == "Horda")
            {
                foreach(GameObject Card in CartasenFranja)
                {
                    Card.transform.SetParent(CementerioHorda.transform, true);
                    Card.transform.position =CementerioHorda.transform.position;
                }
                CartasenFranja.Clear();
                Suma = 0;
                puntuationText.text = Suma.ToString();
            }
            CuerpoaCuerpoP.aumentoafectado = false;
            CuerpoaCuerpoP.climaafectado = false;
            DistanciaP.aumentoafectado = false;
            DistanciaP.climaafectado = false;
            AsedioP.aumentoafectado = false;
            AsedioP.climaafectado = false;
            CuerpoaCuerpoE.aumentoafectado = false;
            CuerpoaCuerpoE.climaafectado = false;
            DistanciaE.aumentoafectado = false;
            DistanciaE.climaafectado = false;
            AsedioE.aumentoafectado = false;
            AsedioE.climaafectado = false;
        }

sumaparcial = 0;
for(int i = 0; i < CartasenFranja.Count; i++)
{
sumaparcial += CartasenFranja[i].GetComponent<Clasecarta>().poder;
}
Suma = sumaparcial;



if(aumentoafectado)
        {
          foreach(GameObject Card in CartasenFranja)
          {
            if(Card.GetComponent<Clasecarta>().Range != "Oro" && Card.GetComponent<Clasecarta>().AumentoAfectado == false) //si no es de oro y no esta afectada le suma 1
            {
                Card.GetComponent<Clasecarta>().AumentoAfectado = true;
                Card.GetComponent<Clasecarta>().poder += 1;
            }
          }
        }

if(climaafectado)
        {
            foreach(GameObject Card in CartasenFranja)
          {
            if(Card.GetComponent<Clasecarta>().Range!= "Oro" && Card.GetComponent<Clasecarta>().ClimaAfectado == false) // si no es de oro y no esta afectada ya la vuelve 1
            {
                Card.GetComponent<Clasecarta>().ClimaAfectado = true;
                Card.GetComponent<Clasecarta>().poder = 1;
            }
          }
        }
}

}




