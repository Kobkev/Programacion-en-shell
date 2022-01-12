using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoMueble : MonoBehaviour
{
    public float LaDistancia;
    public GameObject ActionDisplay;
    //public GameObject ActionText;
    public GameObject ElMueble;
    private Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
    }

    void Update()
    {
        LaDistancia = PlayerCasting.DistanceFromTarget;
    }

    private void OnTriggerStay(Collider other)
    {
        //if (LaDistancia <= 2)
        //{
        ActionDisplay.SetActive(true);
        //ActionText.SetActive(true);
        //}
        if (Input.GetButtonDown("Action"))
        {
            //if (LaDistancia <= 2)
            //{
            this.GetComponent<BoxCollider>().enabled = false;
            ActionDisplay.SetActive(false);
            //ActionText.SetActive(false);
            anim.Play("Base Layer.Closet_Open", 0, 0f);
            //}
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ActionDisplay.SetActive(false);
        //ActionText.SetActive(false);
    }
}
