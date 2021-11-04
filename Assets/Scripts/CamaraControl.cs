using UnityEngine;

public class CamaraControl : MonoBehaviour
{
    public GameObject camaraEncendido;
    public GameObject camaraApagado;
    public bool camOn = false;
    public int cameraNumber;

    void Start()
    {
        cameraNumber = 1;
        //StartCoroutine(CameraSwitch());
    }

    /*     IEnumerator CameraSwitch()
        {
            yield return new WaitForSeconds(5);
            cameraTwo.SetActive(true);
            cameraOne.SetActive(false);
            camOn = true;
            cameraNumber = 2;
        } */

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            camaraEncendido.SetActive(true);
            //camaraEncendido.GetComponent<AudioListener>().enabled = true;
            camaraApagado.SetActive(false);
            //camaraApagado.GetComponent<AudioListener>().enabled = false;
        }
    }
}
