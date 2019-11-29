using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementJoint : MonoBehaviour
{
    [SerializeField]
    private SpringJoint joint;
    private Rigidbody rb;
    public GameObject teleporte;

    [SerializeField]
    private Camera cameraMove;

    public float velocity;
    public float vento;
    public float force;
    public float tamanhoRay;
    public float newYJoint;


    public bool podePular;
    public bool isGrounded;
    public bool ventilador;
    

    private Vector3 move;
    public Vector3 target;
    public Vector3 direction;


    void Start()
    {
        move = Vector3.zero;
        podePular = true;
        rb = gameObject.GetComponent<Rigidbody>();
        direction = Vector3.zero;
        ventilador = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (!isGrounded)
            newYJoint = transform.position.y - 10.0f;

        float zMov = Input.GetAxisRaw("Horizontal");
        

        move = (transform.forward * zMov).normalized * velocity;


        target = new Vector3(0, Input.mousePosition.y, Input.mousePosition.x);

        

        cameraMove.transform.position = new Vector3(12.0f, gameObject.transform.position.y, gameObject.transform.position.z);
        if (isGrounded)
        {
            if (Input.GetMouseButtonDown(0))
            {

                direction = cameraMove.ScreenToWorldPoint(target) - gameObject.transform.position;
                direction.z = direction.x;
                direction.x = 0;
                direction.Normalize();
                AddForceOnMouseButton();
            }
        }

        Debug.DrawRay(transform.position, Vector3.down * tamanhoRay);

        JointMoviment();



    }

    private void FixedUpdate()
    {
        Movement(move);
       
        if (ventilador)
            rb.AddForce(transform.up * vento * Time.fixedDeltaTime, ForceMode.Force);
    }

    void Movement(Vector3 _direction)
    {
        if(_direction != Vector3.zero)
        {
            rb.MovePosition(rb.position + _direction * Time.fixedDeltaTime);
        }
    }

    void JointMoviment()
    {

        joint.connectedAnchor = new Vector3(gameObject.transform.position.x, newYJoint, gameObject.transform.position.z);
    }

    void AddForceOnMouseButton()
    {
        rb.AddForce(transform.up * force, ForceMode.Force);
    }

    void Teleport()
    {
        transform.position = teleporte.transform.position;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.name == "Vento")
        {
            ventilador = true;

        }

        if (other.gameObject.name == "HexagonoVerde")
        {
            other.gameObject.GetComponent<Hexagono>().rotation = 10;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Vento")
            ventilador = false;
        if (other.gameObject.name == "HexagonoVerde")
        {
            other.gameObject.GetComponent<Hexagono>().rotation = 40;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "EstrelaVerde")
        {
            Destroy(other.gameObject);
            rb.mass += 2;
            force += 2000;
            velocity += 3;
            joint.spring += 10;
        }
        if(other.name == "EstrelaVermelha")
        {
            Destroy(other.gameObject);
            velocity += 5;
            force += 500;
            gameObject.GetComponent<DestroyObject>().DestroyFogo();
        }
        if(other.name == "EstrelaAzul")
        {
            Destroy(other.gameObject);
            rb.mass += 4;
            force += 2000;
            gameObject.GetComponent<DestroyObject>().DestroyEspinhos();
        }
        if(other.name == "EstrelaAmarela")
        {
            Destroy(other.gameObject);
        }
        if(other.name == "Teleporte")
        {
            Teleport();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "Rampa")
        {
            podePular = false;
        }
        if (collision.gameObject.tag == "Chao")
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, tamanhoRay))
            {
                if (hit.collider.tag == "Chao")
                {
                    isGrounded = true;
                    newYJoint = transform.position.y - 0.5f;
                    Debug.Log("colidi com chao");
                }
            }

            
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Chao")
        {
            isGrounded = false;
            Debug.Log("sai da colisao com chao");
        }
        
    }

}
