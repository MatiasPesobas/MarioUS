using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public string enemyTag = "Enemy Body";
    bool Dead = false;
    [SerializeField] AudioSource DeathSound;
    [SerializeField] AudioSource SpawnSound;
    public Text timeText;
    public GameObject player, spriteHeart1, spriteHeart2, spriteHeart3;
    int lives = 3;
    Transform Spawner;
    [SerializeField] Text livesText;

    void Update()
    {
        timeText.text = "Time Left: " + (60 - Mathf.Floor(Time.timeSinceLevelLoad)).ToString();
        
        if (Mathf.Floor(Time.timeSinceLevelLoad) == 60)
        {
            Die();
        }

        if (Dead)
        {
            SceneManager.LoadScene("BadEnd");
        }
        //livesText.text = "Lives: " + lives;
    }

    void Start()
    {
        SpawnSound.Play();
        player = GameObject.Find("Player");
        Spawner = GameObject.FindGameObjectWithTag("Spawner").transform;
        lives = 3;
        spriteHeart3.SetActive(true);
        spriteHeart2.SetActive(true);
        spriteHeart1.SetActive(true);
    }

    void Die ()
    {
        if (lives > 0)
        {
            //GetComponent<MeshRenderer>().enabled = false;
            //GetComponent<Rigidbody>().isKinematic = true;
            //GetComponent<PlayerMovement>().enabled = false;
            //Invoke(nameof(ReloadLevel), 1.3f);
            player.transform.position = Spawner.position;
            ItemCollector.coins = 0;
            lives--;
            if (lives == 2) { spriteHeart3.SetActive(false); }
            else if (lives == 1) { spriteHeart2.SetActive(false); }
            else if (lives == 0) { spriteHeart1.SetActive(false); }
        }
        if (lives == 0)
        {
            DeathSound.Play();
            Dead = true;
        }
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy Body")
        {
            Die();
        }
    }
}
