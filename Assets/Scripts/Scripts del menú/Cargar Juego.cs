using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Cargarjuego : MonoBehaviour
{
   public Animator trans;
   public float transtime = 1f;
   public void Iniciarjuego()
   {
   //este y todos los metodos de este script que tiene SceneManager.LoadScene son para cargar la escene a la que corresponde el numero entre parentesis
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(2);
   }

   public void Cerrarjuego ()
   {
      //este metodo sirve para cerrar el juego. El Debug.Log era para probar que funcionaba antes de hacer la build
      Debug.Log ("Cerrar juego");
      Application.Quit();
   }

   public void Opciones()
   {
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(1);
   }

   public void LoadCreditos()
   {
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(5);
   }

  
   

   public void LoadMainMenu()
   {
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(0);
   }

   
  

void Update()
{
   if(Input.GetKeyDown(KeyCode.Backspace))
   {
      LoadMainMenu();
   }
}
}