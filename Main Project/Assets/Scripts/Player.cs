using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField] float runSpeed = 5f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.velocity = moveInput * runSpeed;
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Old Lady")
        {
            SceneManager.LoadScene("Old Lady's house");
        }
        if (trigger.gameObject.tag == "Kid")
        {
            SceneManager.LoadScene("Kid's house");
        }
        if (trigger.gameObject.tag == "Business Dad")
        {
            SceneManager.LoadScene("Business Dad's house");
        }
        if (trigger.gameObject.tag == "Gamer")
        {
            SceneManager.LoadScene("Gamer Bro's house");
        }
    }

}
