using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Movement : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private float speed = 1.9f;
    [Header("Player Script Cameras")]
    [SerializeField] private Transform playerCamera;
    [Header("Player Animator and Gravity")]
    [SerializeField] private CharacterController cC;
    [Header("Velocity")]
    [SerializeField] private float turnCalmTime = 0.5f;
    [SerializeField] private float turnCalmTime2 = 0.3f;
    [SerializeField] float turnCalmVelocity;
    [SerializeField] private float angle;
   [SerializeField] private VisualEffect _fogEffect;
   [SerializeField] private GameObject _fogPlayerPos;
    private bool _isWalking;


    public TextMeshProUGUI goodness;

    [Header("PowerUp")]
    [SerializeField] int powerUpCount = 0;
    [SerializeField] bool hasPowerUp;
    [SerializeField] GameObject powerUpIndicator;
    [SerializeField] GameObject normalLight;

    [SerializeField] ParticleSystem particle;

    [Header("Enemy variables")]
    public bool enemy_close;
    public GameObject dusmen;

    // Start is called before the first frame update
    void Start()
    {
        hasPowerUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
       _fogEffect.SetVector3("Position0", _fogPlayerPos.transform.position);

        FindEnemy();

        if (powerUpCount >= 1)
        {
            hasPowerUp = true;
            powerUpIndicator.SetActive(true);
            normalLight.SetActive(false);

        }

        if (hasPowerUp && enemy_close)
        {
            dusmen.SetActive(false);
            enemy_close = false;
            Instantiate(particle, transform.position, transform.rotation);
            hasPowerUp = false;
            powerUpCount--;
            powerUpIndicator.SetActive(false);  
            normalLight.SetActive(true);

        }
        if (!hasPowerUp && enemy_close)
        {
            //bura basqa effect qoymaq lazimdir. Player olende ayri, dusmen olende ayri olsun
            gameObject.SetActive(false);
            Instantiate(particle, transform.position, transform.rotation);
            hasPowerUp = false;
            powerUpCount--;
        }
    }

    public bool FindEnemy()
    {
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject en in enemies)
        {
            float mesafe = Vector3.Distance(gameObject.transform.position, en.transform.position);
            if (mesafe <= 3f)
            {
               dusmen = en;
               enemy_close = true;
            }
        }
       return enemy_close;
    }

    //POWERUPLAR
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup1") && !hasPowerUp)
        {
            powerUpCount++;            
            Destroy(other.gameObject);
            goodness.text = "You've fed homeless cats in the streets ;) ";
            StartCoroutine(Goodness());
        }
        if (other.CompareTag("Powerup2") && !hasPowerUp)
        {
            powerUpCount++;
            Destroy(other.gameObject);
            goodness.text = "You were donating to charity each month :)";
            StartCoroutine(Goodness());
        }
        if (other.CompareTag("Powerup3") && !hasPowerUp)
        {
            powerUpCount++;
            Destroy(other.gameObject);
            goodness.text = "You have bought a toy for a poor child <3";
            StartCoroutine(Goodness());
        }
    }



    //IENumerators

    IEnumerator Goodness()
    {
        yield return new WaitForSeconds(4);
        goodness.gameObject.SetActive(false);
    }


    void PlayerMove()
    {
        // -1 ya da +1 qiymet alsin deye
        float horizontal_axis = Input.GetAxisRaw("Horizontal");
        float vertical_axis = Input.GetAxisRaw("Vertical");

        // wasd basanda hansi terefe getmeli oldugu
        Vector3 direction = new Vector3(horizontal_axis, 0f, vertical_axis).normalized;

        if (direction.magnitude >= 0.1f)
        {

            // donub baxsin
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + playerCamera.eulerAngles.y;
            // baxacagi yere yavas yavas donsun
            angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnCalmVelocity, turnCalmTime);
            // donsun
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // hansi terefe irelilesin
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            
            _isWalking = moveDirection != Vector3.zero;
            

            // irelilesin
            cC.Move(moveDirection.normalized * speed * Time.deltaTime);



        }
        else
        {
            _isWalking = false;
        }

    }

    public bool Iswalking()
    {
        return _isWalking;
    }
}
