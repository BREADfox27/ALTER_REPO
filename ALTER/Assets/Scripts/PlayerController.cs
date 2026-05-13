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

    public GameObject interactiveText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
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
                interactiveText.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactiveText.gameObject.SetActive(false);
                    hit.collider.transform.GetComponent<DeactivateObject>().Deactivate();
                }
            }

            if (hit.collider.tag == "Wool")
            {
                interactiveText.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactiveText.gameObject.SetActive(false);
                    hit.collider.transform.GetComponent<DeactivateObject>().Deactivate();
                }
            }

            if (hit.collider.tag == "Police")
            {
                interactiveText.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactiveText.gameObject.SetActive(false);
                }
            }

            if (hit.collider.tag == "MafiaBoss")
            {
                interactiveText.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactiveText.gameObject.SetActive(false);
                }
            }

            if (hit.collider.tag == "Grandma")
            {
                interactiveText.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactiveText.gameObject.SetActive(false);
                }
            }

            if (hit.collider.tag == "Pedo")
            {
                interactiveText.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactiveText.gameObject.SetActive(false);
                }
            }

            if (hit.collider.tag == "Cat")
            {
                interactiveText.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactiveText.gameObject.SetActive(false);
                }
            }

            if (hit.collider.tag == "Criminal")
            {
                interactiveText.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactiveText.gameObject.SetActive(false);
                }
            }

            if (hit.collider.tag == "BulliedVictim")
            {
                interactiveText.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactiveText.gameObject.SetActive(false);
                }
            }
        }
    }
}
