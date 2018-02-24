using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pruebaFor : MonoBehaviour {
    public float distance = 1f;
    public LayerMask boxMask;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        RaycastHit2D rightmov = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, boxMask);
        string[] tsprites = new string[9];
        tsprites[0] = "Limites";
        tsprites[1] = "Grass1";
        tsprites[2] = "Grass2";
        tsprites[3] = "Grass3";
        tsprites[4] = "Hueso1";
        tsprites[5] = "Hueso2";
        tsprites[6] = "CajaPuesta1";
        tsprites[7] = "CajaPuesta2";
        tsprites[8] = "Casa";

         
    }
    private void movimientos(int n)
    {
        RaycastHit2D[] moves = new RaycastHit2D[5];
        moves[1] = Physics2D.Raycast(transform.position, Vector2.up * transform.localScale.x, distance, boxMask);
        moves[2] = Physics2D.Raycast(transform.position, Vector2.down * transform.localScale.y, distance, boxMask);
        moves[3] = Physics2D.Raycast(transform.position, Vector2.left * transform.localScale.x, distance, boxMask);
        moves[4] = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.y, distance, boxMask);
        if (moves[n].collider != null && moves[n].collider.gameObject.tag == "Limites")
        {

        }
        else if (moves[n].collider != null && (moves[n].collider.gameObject.tag == "Grass1" || moves[n].collider.gameObject.tag == "Grass2"))
        {

        }
        else if (moves[n].collider != null && moves[n].collider.gameObject.tag == "Hueso1")
        {

        }
        else if (moves[n].collider != null && moves[n].collider.gameObject.tag == "Hueso2")
        {

        }
        else if (moves[n].collider != null && (moves[n].collider.gameObject.tag == "CajaPuesta1" || moves[n].collider.gameObject.tag == "CajaPuesta2"))
        {

        }
        else if (moves[n].collider != null && moves[n].collider.gameObject.tag == "Casa")
        {

        }
    }
}
