using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public TextMeshProUGUI Tutorial1;
    public TextMeshProUGUI Tutorial2;
    public TextMeshProUGUI Tutorial3;
    public TextMeshProUGUI Tutorial4;

    public GameObject powerup;
    public GameObject enemy;

    public Light light;
    public Light light2;


    private Vector3 mesafe = new Vector3(5, 0, 0);
    private Vector3 mesaf2 = new Vector3(10,0, 0);
    public bool created = false;

    // Start is called before the first frame update
    void Start()
    {
        Tutorial1.gameObject.SetActive(true);
        if (!created)
        {
            StartCoroutine(Pass());
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Yaxsiliq"))
        {
            Destroy(other.gameObject);
            Tutorial3.gameObject.SetActive(true);
            Tutorial2.gameObject.SetActive(false);
            light.gameObject.SetActive(true);
            light2.gameObject.SetActive(false);

            Instantiate(enemy, this.transform.position + mesaf2, this.transform.rotation);

        }

        if (other.CompareTag("Enemy"))
        {
            Tutorial4.gameObject.SetActive(true);
            Destroy(other.gameObject);

        }

    }

    // Update is called once per frame
    void Update()
    {
       

    }


    IEnumerator Pass()
    {
        yield return new WaitForSeconds(5);
        Tutorial1.gameObject.SetActive(false);
        Tutorial2.gameObject.SetActive(true);

        Instantiate(powerup, this.transform.position + mesafe, this.transform.rotation);

        created = true;
        

    }


}