using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishedLevel : MonoBehaviour
{
    //public int coins;
    public Text coinsTextF;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish Line"))
        {

            while (ItemCollector.coins >= 6)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;
            }

        }
    }
}
