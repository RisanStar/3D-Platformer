using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public void escape()
    {
        Application.Quit();
        Debug.Log("Closed Game");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cog"))
        {
            Destroy(other.gameObject);
            Application.Quit();
            Debug.Log("Closed Game");
        }
    }
}
