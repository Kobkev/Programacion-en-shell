using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPersonaje : MonoBehaviour{

    public GameObject elPersonaje;
    public bool enMovimiento;
    float movimientoHorizontal;
    float movimientoVertical;
    [SerializeField] float velocidadRotacion = 150f; 
    [SerializeField] float velocidadCaminar= 1.5f;

    void Update(){
        if(Input.GetButton("Horizontal") || Input.GetButton("Vertical")){
            if(Input.GetKey(KeyCode.S)){
                movimientoVertical = Input.GetAxis("Vertical") * Time.deltaTime * velocidadCaminar/2;
                elPersonaje.transform.Translate(0, 0, movimientoVertical);
                elPersonaje.GetComponent<Animator>().Play("WalkBack");
            } else {
                movimientoVertical = Input.GetAxis("Vertical") * Time.deltaTime * velocidadCaminar;
                elPersonaje.transform.Translate(0, 0, movimientoVertical);
                //elPersonaje.GetComponent<Animator>().Play("StartWalk");
                elPersonaje.GetComponent<Animator>().Play("Walk");
            }
            movimientoHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime * velocidadRotacion;
            
            elPersonaje.transform.Rotate(0, movimientoHorizontal, 0);
            
        } else {
            enMovimiento = false;
            elPersonaje.GetComponent<Animator>().Play("Idle");
        }   

    }
}
