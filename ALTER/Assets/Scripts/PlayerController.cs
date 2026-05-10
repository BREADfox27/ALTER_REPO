using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    public float CurrentSpeed { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(h, 0, v);

        CurrentSpeed = direction.magnitude;

        if (direction.magnitude > 0.1f)
        {
            transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);
            transform.forward = direction.normalized;
        }
    }
}
