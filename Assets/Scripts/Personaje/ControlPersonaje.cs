using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    public InventoryObject inventory;
    public MouseItem mouseItem = new MouseItem();
    public GameObject anadido;
    public AudioSource recoger;
    public GameObject ActionDisplay;
    [SerializeField] private DialogueUI dialogueUI;
    public GameObject ActionText;
    public TMP_Text aText;
    //public DialogueManager trigger;
    public DialogueUI DialogueUI => dialogueUI;
    public IInteractable Interactable { get; set; }

    void Update()
    {
        if (dialogueUI.IsOpen) return;

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

        /* if (Input.GetKeyDown(KeyCode.Space))
        {
            inventory.Save();
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            inventory.Load();
        } */
    }



    private void OnTriggerStay(Collider other)
    {
        var item = other.GetComponent<GroundItem>();
        var inter = other.GetComponent<DialogueActivator>();
        if (item)
        {
            ActionDisplay.SetActive(true);
            aText.text = "Recoger";
            ActionText.SetActive(true);
            if (Input.GetButtonDown("Action"))
            {
                recoger.Play();
                elPersonaje.GetComponent<Animator>().Play("PickUp");
                anadido.SetActive(true);
                Item _item = new Item(item.item);
                //Debug.Log(_item.Id);
                inventory.AddItem(_item, 1);
                Destroy(other.gameObject);
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                StartCoroutine(MensajeAnadido());
            }
        }
        else if (inter)
        {
            ActionDisplay.SetActive(true);
            aText.text = "Interactuar";
            ActionText.SetActive(true);
            if (Input.GetButtonDown("Action"))
            {
                Interactable?.Interact(this);
            }
            if (dialogueUI.IsOpen)
            {
                ActionText.SetActive(false);
                ActionDisplay.SetActive(false);
                ControlGlobal.inventarioAbierto = true;
            }
            else
            {
                {
                    ControlGlobal.inventarioAbierto = false;
                }
            }
        }
        else
        {
            ActionDisplay.SetActive(false);
            aText.text = string.Empty;
            ActionText.SetActive(false);
        }
    }

    private void OnApplicationQuit()
    {
        inventory.Container.Items = new InventorySlot[6];
    }

    IEnumerator MensajeAnadido()
    {
        yield return new WaitForSeconds(2f);
        anadido.SetActive(false);
    }
}
