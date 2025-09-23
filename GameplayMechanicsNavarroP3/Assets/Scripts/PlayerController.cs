using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 5.0f;
    private GameObject focalPoint;
    private Rigidbody playerRb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Verticle");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
    }
}
