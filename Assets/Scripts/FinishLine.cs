using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishLine : MonoBehaviour
{
    
    [SerializeField] AudioSource FaltanMonedas;
    public Text coinsTextF;

    private void OnCollisionEnter(Collision other)
    {
        if (ItemCollector.coins >= 6 && other.gameObject.name == "Player")
        {                     
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);           
        }
    }


}
