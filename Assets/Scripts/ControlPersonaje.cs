using UnityEngine;

public class ControlPersonaje : MonoBehaviour
{

    public GameObject elPersonaje;
    public bool enMovimiento;
    bool estaCorriendo;
    float movimientoHorizontal;
    float movimientoVertical;
    [SerializeField] float velocidadRotacion = 150f;
    [SerializeField] float velocidadCaminar = 0.5f;
    float velocidadCorrer = .01f;

    void Update()
    {
        if (ControlGlobal.pausaAbierto == false)
        {
            if (ControlGlobal.inventarioAbierto == false)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    estaCorriendo = true;
                }
                else
                {
                    estaCorriendo = false;
                }
                if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
                {
                    if (Input.GetKey(KeyCode.S))
                    {
                        movimientoVertical = Input.GetAxis("Vertical") * Time.deltaTime * velocidadCaminar / 2;
                        elPersonaje.GetComponent<Animator>().Play("WalkBack");
                    }
                    else
                    {
                        if (estaCorriendo == false)
                        {
                            movimientoVertical = Input.GetAxis("Vertical") * Time.deltaTime * velocidadCaminar;
                            //elPersonaje.GetComponent<Animator>().Play("StartWalk");
                            elPersonaje.GetComponent<Animator>().Play("Walk");
                        }
                        else if (Input.GetKey(KeyCode.W) && estaCorriendo == true)
                        {
                            movimientoVertical = Input.GetAxis("Vertical") * Time.deltaTime * velocidadCaminar * velocidadCorrer;
                            elPersonaje.GetComponent<Animator>().Play("Run");
                        }
                    }
                    movimientoHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime * velocidadRotacion;
                    elPersonaje.transform.Rotate(0, movimientoHorizontal, 0);
                    elPersonaje.transform.Translate(0, 0, movimientoVertical);
                }
                else
                {
                    enMovimiento = false;
                    elPersonaje.GetComponent<Animator>().Play("Idle");
                }
            }
        }
    }
}
