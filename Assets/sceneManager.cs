using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    //Depois de entrar
    public GameObject Dad;
    public GameObject Canvas;

    //antes
    public GameObject CanvasLog;
    public GameObject mainCam1;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
   

    }


    public void VisualLogin()
    {
        mainCam1.SetActive(false);
        CanvasLog.SetActive(false);

        //activo
        Canvas.SetActive(true);

        foreach (Transform filhos in Dad.transform)
        {
            filhos.gameObject.SetActive(true);
        }
    }
}
