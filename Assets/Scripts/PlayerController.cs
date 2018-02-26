using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    private int count;
    public float speed;
    public Text countText;
    public Text winText;
    public float maxSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        rb.AddForce(movement * speed);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    private void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 7)
        {
            winText.text = "You win!";
        }
    }
}
