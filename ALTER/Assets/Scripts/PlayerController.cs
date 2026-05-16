using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    public float speed = 4f;
    public float rotationSpeed = 10f;

    private Animator anim;
    private CharacterController controller;

    [Header("Raycast hit")]
    public float rayDistance = 5f;
    public LayerMask layermask;

    public GameObject cat;

    public float points;

    public GameObject interactiveText;
    public GameObject dialoguePanel1;
    public GameObject dialoguePanel1_1;
    public GameObject dialoguePanel2;
    public GameObject dialoguePanel2_1;
    public GameObject dialoguePanel3;
    public GameObject dialoguePanel3_1;
    public GameObject dialoguePanel4;
    public GameObject dialoguePanel5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();

        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        RayCast();
        
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);

        // Movimiento
        if (dir.magnitude > 0.1f)
        {
            // Rotación hacia la dirección
            Quaternion targetRot = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, rotationSpeed * Time.deltaTime);
        }

        controller.Move(dir.normalized * speed * Time.deltaTime);

        // Parámetro Speed para el Animator
        anim.SetFloat("Speed", dir.magnitude);

        if (points == 2)
        {
            Debug.Log("You have 2 points.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("IntTextCollider"))
        {
            interactiveText.gameObject.SetActive(true);
        }

        if (other.CompareTag("PlusOne"))
        {
            points++;
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag("Cat"))
        {
            cat.gameObject.SetActive(false);
            dialoguePanel3.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("IntTextCollider"))
        {
            interactiveText.gameObject.SetActive(false);
        }
    }

    void RayCast()
    {
        RaycastHit hit;
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;

        if (Physics.Raycast(origin, direction, out hit, rayDistance, layermask))
        {
            Debug.Log("Hemos colisionado con: " + hit.collider.gameObject.name);
            Debug.DrawLine(origin, hit.point, Color.red);

            if (hit.collider.tag == "Medicine")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactiveText.gameObject.SetActive(false);
                    dialoguePanel5.gameObject.SetActive(true);
                    hit.collider.transform.GetComponent<DeactivateObject>().Deactivate();
                }
            }

            if (hit.collider.tag == "Wool")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactiveText.gameObject.SetActive(false);
                    dialoguePanel5.gameObject.SetActive(true);
                    hit.collider.transform.GetComponent<DeactivateObject>().Deactivate();
                }
            }

            if (hit.collider.tag == "FirstDialogue1")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.transform.GetComponent<DeactivateObject>().Deactivate();
                    dialoguePanel1.gameObject.SetActive(true);
                }
            }

            if (hit.collider.tag == "SecondDialogue1" && points == 2)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    dialoguePanel4.gameObject.SetActive(true);
                }
            }

            if (hit.collider.tag == "SecondDialogue1" && points != 2)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    dialoguePanel1_1.gameObject.SetActive(true);
                }
            }

            if (hit.collider.tag == "FirstDialogue2")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.transform.GetComponent<DeactivateObject>().Deactivate();
                    dialoguePanel2.gameObject.SetActive(true);
                    points++;
                }
            }

            if (hit.collider.tag == "SecondDialogue2")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    dialoguePanel2_1.gameObject.SetActive(true);
                }
            }

            if (hit.collider.tag == "FirstDialogue3")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.transform.GetComponent<DeactivateObject>().Deactivate();
                    dialoguePanel3.gameObject.SetActive(true);
                    points++;
                }
            }

            if (hit.collider.tag == "SecondDialogue3")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    dialoguePanel3_1.gameObject.SetActive(true);
                }
            }
        }
    }
}
