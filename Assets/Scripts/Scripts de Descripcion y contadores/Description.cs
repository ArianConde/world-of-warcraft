using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ObjectDescription : MonoBehaviour
{
public Text Descripciones;
public GameObject Card;
private GameObject Descript;
private Text Informacion;
//declaracion de variables y objetos

public void InfoCard()
{
     //este metodo y los dos siguientes son para obtener de la Clase Carta todas las caracteristicas de las cartas y luego instanciarlas en la parte del tablero que le corresponde en forma de texto
     Descripciones.text = Card.GetComponent<Clasecarta>().Name + ". Poder: " + Card.GetComponent<Clasecarta>().poder.ToString() + ". Facción: " + Card.GetComponent<Clasecarta>().Faccion + ". Rango: " + Card.GetComponent<Clasecarta>().Range + ". Franja: " + Card.GetComponent<Clasecarta>().Franja + ". Descripción: " + Card.GetComponent<Clasecarta>().descripcionefecto+ ". Habilidad: " + Card.GetComponent<Clasecarta>().Effected;
     Informacion = Instantiate(Descripciones, new Vector2(0,0), Quaternion.identity);
     Informacion.transform.SetParent(Descript.transform, false);
}
public void InfoClimate()
{
     Descripciones.text = Card.GetComponent<Clasecarta>().Name + ". Facción: " + Card.GetComponent<Clasecarta>().Faccion + ". Franja afectada: " + Card.GetComponent<Clasecarta>().franjaAfectada + ". Descripción: " + Card.GetComponent<Clasecarta>().descripcionefecto+ ". Habilidad: " + Card.GetComponent<Clasecarta>().Effected;
     Informacion = Instantiate(Descripciones, new Vector2(0,0), Quaternion.identity);
     Informacion.transform.SetParent(Descript.transform, false);
}

public void InfoLeader()
{
     Descripciones.text = "Líder de la facción.  " + Card.GetComponent<ClaseLider>().Nombre + ". Facción: " + Card.GetComponent<ClaseLider>().Faccion + ". Descripción: " + Card.GetComponent<ClaseLider>().Descripcion + ". Habilidad: " + Card.GetComponent<ClaseLider>().Effected;
     Informacion = Instantiate(Descripciones, new Vector2(0,0), Quaternion.identity);
     Informacion.transform.SetParent(Descript.transform, false);
}

public void cerrarinfo()
{
Destroy(Informacion.gameObject);
//metodo para que el texto desaparezca cuando el cursor deje de estar sobre la carta
}

void Start()
{
     Descript = GameObject.Find("InfoZone");
    //metodo para que la descripcion de las cartas se ubique en la zona que le asigné del tablero
}
}
