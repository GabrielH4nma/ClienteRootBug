using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Networking.Transport;
using UnityEngine;

public class server_player : MonoBehaviour
{

    public NetworkDriver m_Driver;
    public NetworkConnection m_Connection;
    public bool m_Done;

    public int laneFinal;
    public string plant;

    public IncrementRecurso ir;

    void Start()
    {
        m_Driver = NetworkDriver.Create();
        m_Connection = default(NetworkConnection);

        var endpoint = NetworkEndPoint.Parse("192.168.54.206", 9000);

        m_Connection = m_Driver.Connect(endpoint);
    }

    public void OnDestroy()
    {
        m_Driver.Dispose();
    }

    void Update()
    {
        m_Driver.ScheduleUpdate().Complete();



        DataStreamReader stream;
        NetworkEvent.Type cmd;

        while ((cmd = m_Connection.PopEvent(m_Driver, out stream)) != NetworkEvent.Type.Empty)
        {
            if (cmd == NetworkEvent.Type.Connect)
            {
                Debug.Log("We are now connected to the server");

                string value = "mandei";
                m_Driver.BeginSend(m_Connection, out var writer);
                writer.WriteFixedString32(value);
                m_Driver.EndSend(writer);
            }
            else if (cmd == NetworkEvent.Type.Data)
            {
                //uint value = stream.ReadUInt();
                //Debug.Log("Got the value = " + value + " back from the server");
                m_Done = true;
                m_Connection.Disconnect(m_Driver);
                m_Connection = default(NetworkConnection);
            }
            else if (cmd == NetworkEvent.Type.Disconnect)
            {
                Debug.Log("Client got disconnected from server");
                m_Connection = default(NetworkConnection);
            }
        }
    }


    public void escolhePlanta(int planta)
    {
        //string value = IP.GetComponent<TMP_InputField>().text;
        string value = "nada";
        switch (planta)
        {
            case 1:
                value = "0";
                break;
            case 2:
                value = "1";
                break;
            case 3:
                value = "2";
                break;
            default:
                break;
        }

        plant = value;
        //  m_Driver.BeginSend(m_Connection, out var writer);
        // writer.WriteFixedString32(value+";"+"Lane"+laneFinal);
        // m_Driver.EndSend(writer);
    }

    public void escolherLane(int lane)
    {

        if (plant != "")
        {
            m_Driver.BeginSend(m_Connection, out var writer);
            writer.WriteFixedString32(plant + ";" + lane +";"+ ir._coins.ToString());
            m_Driver.EndSend(writer);

        }


        plant = "";
    }



    public void sendSun()
    {
       // m_Driver.BeginSend(m_Connection, out var writer);
       // writer.WriteFixedString32("Sun" + ir._coins);
      //  m_Driver.EndSend(writer);
    }
}