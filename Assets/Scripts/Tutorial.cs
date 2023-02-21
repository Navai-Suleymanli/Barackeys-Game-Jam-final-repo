using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public GameObject foto1;
    public GameObject foto2;
    public GameObject foto3;
    public GameObject foto4;

    void Start()
    {

        foto1.SetActive(true);

    }

    


    // Update is called once per frame
    void Update()
    {
       

    }

    public void Pass()
    {
        foto1.SetActive(false);
        foto2.SetActive(true);
    }

    public void Pass2()
    {
        foto2.SetActive(false);
        foto3.SetActive(true);
    }
    public void Pass3()
    {
        foto3.SetActive(false);
        foto4.SetActive(true);        
    }

    public void Pass4()
    {
        foto2.SetActive(false);
        foto3.SetActive(false);

        SceneManager.LoadScene(2);
    }

}