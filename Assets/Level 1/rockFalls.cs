using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rockFalls : MonoBehaviour
{
    public GameObject rock;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.name.Equals("Player"))
        {
            rb.isKinematic = false;
            Destroy(rock, 2f);
        }
    }

    // Update is called once per frame
    private void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            Debug.Log("Player Died");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }
}
