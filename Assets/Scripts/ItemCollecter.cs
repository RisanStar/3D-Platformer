using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollecter : MonoBehaviour
{
    int cogs = 0;

    [SerializeField] TextMeshProUGUI cogsText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cog"))
        {
            Destroy(other.gameObject);
            cogs++;
            cogsText.text = "Cogs: " + cogs;
        }
    }
}