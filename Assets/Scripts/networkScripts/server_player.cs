using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using Unity.Networking.Transport;
using UnityEngine;

public class server_player : MonoBehaviour
{

    public NetworkDriver m_Driver;
    public NetworkConnection m_Connection;
    public bool m_Done;

    public int laneFinal;
    public string plant;

    public GetText gt;

    public IncrementRecurso ir;

    public sceneManager sceneManager;


    public string nomeDoPlayer;

    public bool iamLogin;

    void Start()
    {
        iamLogin = false;
        m_Driver = NetworkDriver.Create();
        m_Connection = default(NetworkConnection);
    }

    public void OnDestroy()
    {
        m_Driver.Dispose();
    }

    void Update()
    {

        if (iamLogin)
        {
             m_Driver.ScheduleUpdate().Complete();



        DataStreamReader stream;
        NetworkEvent.Type cmd;

        while ((cmd = m_Connection.PopEvent(m_Driver, out stream)) != NetworkEvent.Type.Empty)
        {
            if (cmd == NetworkEvent.Type.Connect)
            {
                Debug.Log("We are now connected to the server");

                // string value = "mandei";
                //m_Driver.BeginSend(m_Connection, out var writer);
                //writer.WriteFixedString32(value);
                //m_Driver.EndSend(writer);
               
            }
            else if (cmd == NetworkEvent.Type.Data)
            {
                print("ENTREI");
                
                string value  = stream.ReadFixedString32().ToString();

                UpdateMyResources(value);

                Debug.Log("Got the value = " + value + " back from the server");
          
            }
            else if (cmd == NetworkEvent.Type.Disconnect)
            {
                Debug.Log("Client got disconnected from server");
                m_Connection = default(NetworkConnection);
            }
        }
        }
       
    }



    //LOGIN
    public void Login()
    {
   

        string ip = gt.inputFieldIP.GetComponent<TextMeshProUGUI>().text; 
        nomeDoPlayer = gt.inputField.GetComponent<TextMeshProUGUI>().text;

        ip = ip.Substring(0, ip.Length - 1);


        var endpoint = NetworkEndPoint.Parse(ip, 9000);

        m_Connection = m_Driver.Connect(endpoint);

        //TODO devolver O SUCESSO OU NAO

        sceneManager.VisualLogin();
        iamLogin = true;
    }


    public void Logout()
    {
        m_Driver.BeginSend(m_Connection, out var writer);
        writer.WriteFixedString32("L");
        m_Driver.EndSend(writer);
    }

    public void escolhePlanta(int planta)
    {
        //string value = IP.GetComponent<TMP_InputField>().text;
        string value = "nada";
        switch (planta)
        {
            case 0:
                value = "0";
                break;
            case 1:
                value = "1";
                break;
            case 2:
                value = "2";
                break;
            default:
                break;
        }

        plant = value;
        m_Driver.BeginSend(m_Connection, out var writer);
        writer.WriteFixedString32(value+";"+"Lane"+laneFinal);
        m_Driver.EndSend(writer);
    }

    public void escolherLane(int lane)
    {

        if (plant != "")
        {
            m_Driver.BeginSend(m_Connection, out var writer);
            writer.WriteFixedString32("P;"+plant + ";" + lane +";"+ ir._coins.ToString());
            m_Driver.EndSend(writer);

        }


        plant = "";
    }


    //TODO do this tommorrow 
    public void UpdateMyResources(string msg) { 
    
    if(msg.Substring(0, 1) == "R")
        {
            string result = msg.Split("R")[1]; 
            
            string coins = result.Split("/")[0];
            string water = result.Split("/")[1];
            string seeds = result.Split("/")[2];
       
        
            ir._coins = int.Parse(coins);
            ir._minerals= int.Parse(seeds);
            ir._sol = int.Parse(water);


            ir._solText.text = ir._sol.ToString();
            ir._mineralsText.text = ir._minerals.ToString();
            ir._coinsText.text = ir._coins.ToString();
        }
            
    }

    public void sendSun()
    {
       m_Driver.BeginSend(m_Connection, out var writer);
       writer.WriteFixedString32("Sun" + ";" + ir._coins);
      m_Driver.EndSend(writer);
    }


   
}