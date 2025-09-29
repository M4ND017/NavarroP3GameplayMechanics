using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyrb;
    private GameObject Player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyrb = GetComponent<Rigidbody>();
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (Player.transform.position - transform.forward).normalized;
        enemyrb.AddForce((lookDirection * speed));
    }
}