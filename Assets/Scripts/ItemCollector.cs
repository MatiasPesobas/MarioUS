using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public static int coins = 0;
    public Text coinsText;

    [SerializeField] AudioSource CollecionSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coins++;
            Debug.Log("Coins:" + coins);
            coinsText.text = "Monedas:" + coins + "/6";
            CollecionSound.Play();

        }
    }
}
 


