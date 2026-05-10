using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 4f;
    public float rotationSpeed = 10f;

    private Animator anim;
    private CharacterController controller;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
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
}
