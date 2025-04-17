using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerDie : MonoBehaviour
{
    private void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.gameObject.name.Equals ("Player"))
        {
            Debug.Log("Player Died");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
