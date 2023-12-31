using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.y < -20f)
        {
            Die();
        }
    }
    
        
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Die();

        }
    }
    void Die()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<PlayerAnim>().enabled = false;
        Invoke(nameof(ReloadLevel), 1.3f);
    }
    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}