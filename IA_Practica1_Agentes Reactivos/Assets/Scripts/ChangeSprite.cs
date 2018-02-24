using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour{
    public Sprite[] Hueso = new Sprite[2];
    public Sprite[] Cesped = new Sprite[2];
    public Sprite Caja;
    private int num_huesos_coloc=0;
 


    //Modificamos el sprite cuando se pasa el mouse por encima y se clickea en el gameobject
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {


            if (this.gameObject.tag == "Grass2")
            {
                this.GetComponent<SpriteRenderer>().sprite = Hueso[1];
                this.transform.gameObject.tag = "Hueso2";
                
            }

            else if (this.gameObject.tag == "Grass1")
            {
                this.GetComponent<SpriteRenderer>().sprite = Hueso[0];
                this.transform.gameObject.tag = "Hueso1";
            }
            num_huesos_coloc++;



        }
        if (Input.GetMouseButtonDown(1)){
            if (this.gameObject.tag == "Grass2")
            {
               
                this.transform.gameObject.tag = "CajaPuesta2";
            }

            else if (this.gameObject.tag == "Grass1")
            {
                
                this.transform.gameObject.tag = "CajaPuesta1";
            }

            this.GetComponent<SpriteRenderer>().sprite = Caja;

        }

        if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.Q))
        {
            if(this.gameObject.tag == "Hueso2" || this.gameObject.tag == "Hueso1")
                num_huesos_coloc--;
            if (this.gameObject.tag == "Hueso2" || this.gameObject.tag== "CajaPuesta2")
            {
                this.GetComponent<SpriteRenderer>().sprite = Cesped[1];
                this.transform.gameObject.tag = "Grass2";
            }

            else if (this.gameObject.tag == "Hueso1" || this.gameObject.tag == "CajaPuesta1")
            {
                this.GetComponent<SpriteRenderer>().sprite = Cesped[0];
                this.transform.gameObject.tag = "Grass1";
            }
           

        }




    }


      

}









