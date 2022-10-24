using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;
    
    public float speed;
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    private int scoreValue;
    private int livesValue;

    public AudioSource audioSource;
     public AudioSource audioSourceWin;


    public GameObject winTextObject;
    public GameObject loseTextObject;
    public GameObject AudioClip;
    public GameObject AudioClipWin;

    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        scoreValue = 0;
        
        rd2d = GetComponent<Rigidbody2D>();
        scoreValue = 0;
        livesValue = 3;

        SetCountText();
        winTextObject.SetActive(false);
        loseTextObject.SetActive(false);
    }

    void SetCountText()
    {
        //scoreText.text = "Score: " + scoreValue.ToString();
        //if (scoreValue >= 4)
        //{
        //    winTextObject.SetActive(true);
        //}

        //scoreText.text = "Score: " + scoreValue.ToString();
        //if (scoreValue < 4)
        //{
        //    winTextObject.SetActive(false);
        //}

        livesText.text = "Lives: " + livesValue.ToString();
        if (livesValue == 0)
        {
            loseTextObject.SetActive(true);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float verMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, verMovement * speed));

        scoreText.text = "Score: " + scoreValue.ToString();
        if (scoreValue >= 4)
        {
            winTextObject.SetActive(true);
            AudioClipWin.SetActive(true);
            AudioClip.SetActive(false);
        }

        scoreText.text = "Score: " + scoreValue.ToString();
        if (scoreValue < 4)
        {
            winTextObject.SetActive(false);
            AudioClipWin.SetActive(false);
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            scoreText.text = scoreValue.ToString();
            Destroy(collision.collider.gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
           if(Input.GetKey(KeyCode.W)) 
           {
            rd2d.AddForce(new Vector2(0, 4),ForceMode2D.Impulse);
           }
        }
    }

}
