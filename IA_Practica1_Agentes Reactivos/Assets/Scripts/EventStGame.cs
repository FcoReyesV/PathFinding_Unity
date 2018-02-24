using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class EventStGame : MonoBehaviour {
    public GameObject Doggito;

    public GameObject Juego;
    public GameObject Instrucciones;
    public static EventStGame instance;
    public int num_huesos=0;
    public Text scoreText;

    public void Awake()
    { //Creamos un singleton para que en la siguiente escena no se instancie de nuevo el jugador
        if (EventStGame.instance == null)
        {
            EventStGame.instance = this;
        }
        else if (EventStGame.instance != this)
        {
            Destroy(gameObject);
            Debug.LogWarning("EventStGame ha sido instanciado por segunda vez. No debería pasar");
        }
    }


    public void Btn_IniciarJuego()
    {
        Juego.SetActive(true);
        Instrucciones.SetActive(false);
       
            Instantiate(Doggito, new Vector2(5.5f,3.5f), Quaternion.identity);

    }
    public void Btn_Reiniciar()
    {
        SceneManager.LoadScene("Main");
    }

    public void Huesos_Agregados()
    {
        num_huesos++;
        scoreText.text = "" + num_huesos;
    }



}
