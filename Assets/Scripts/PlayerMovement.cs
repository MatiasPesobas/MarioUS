using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody Rb;
    [SerializeField] Transform GroundCheck;
    [SerializeField] LayerMask Ground;
    [SerializeField] AudioSource jumpSound;
    [SerializeField] AudioSource FaltanMonedas;
    public Text coinsTextF;
    public float speed;
    public float jumpForce;
    public GameObject coin;
    GameObject clon;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown ("space") && ItsGrounded())
        {
            //Rb.velocity = new Vector3(Rb.velocity.x, 8f, Rb.velocity.z);
            Rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            jumpSound.Play();
        }

        if (Input.GetKey("z"))
        {
            Rb.velocity = new Vector3(Rb.velocity.x, -9f, Rb.velocity.z);
        }

        if (Input.GetKey("w"))
        {
            //Rb.velocity = new Vector3(Rb.velocity.x, Rb.velocity.y, 5f);
            transform.position += transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey("s"))
        {
            //Rb.velocity = new Vector3(Rb.velocity.x, Rb.velocity.z, -5f);
            transform.position += -transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey("d"))
        {
            //Rb.velocity = new Vector3(5f, Rb.velocity.y, Rb.velocity.z);
            transform.position += transform.right * speed * Time.deltaTime;
        }

        if (Input.GetKey("a"))
        {
            //Rb.velocity = new Vector3(-5f, Rb.velocity.y, Rb.velocity.z);
            transform.position += -transform.right * speed * Time.deltaTime;
        }


        
    }

    bool ItsGrounded()
    {
        return Physics.CheckSphere(GroundCheck.position, 1f, Ground);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player" && ItemCollector.coins < 6)
        {
            Debug.Log("asdads");
            coinsTextF.text = "FALTAN MONEDAS!";
            FaltanMonedas.Play();
        }

        if (other.gameObject.name == "Floor (2)")
        {
            Debug.Log("Choco");

            for (int i = 0; i < 6; i++)
            {
                clon = Instantiate(coin);
                clon.transform.position = new Vector3(17.5f, -0.9f, 20 + i);
                
            }
        }
    }
}
