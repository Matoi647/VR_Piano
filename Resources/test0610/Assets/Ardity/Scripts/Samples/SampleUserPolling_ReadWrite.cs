/**
 * Ardity (Serial Communication for Arduino + Unity)
 * Author: Daniel Wilches <dwilches@gmail.com>
 *
 * This work is released under the Creative Commons Attributions license.
 * https://creativecommons.org/licenses/by/2.0/
 */

using UnityEngine;
using System.Collections;

/**
 * Sample for reading using polling by yourself, and writing too.
 */


public class SampleUserPolling_ReadWrite : MonoBehaviour
{
    public SerialController serialController;
    public Transform[] points;
    public AudioSource[] keys;
    bool b1 = false;
    bool b2 = false;
    bool b3 = false;
    bool b4 = false;
    bool b5 = false;

    // Initialization
    void Start()
    {
        serialController = GameObject.Find("SerialController").GetComponent<SerialController>();

        Debug.Log("Press A or Z to execute some actions");
    }

    // Executed each frame
    void Update()
    {
        //---------------------------------------------------------------------
        // Send data
        //---------------------------------------------------------------------

        // If you press one of these keys send it to the serial device. A
        // sample serial device that accepts this input is given in the README.
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Sending A");
            serialController.SendSerialMessage("A");
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Sending Z");
            serialController.SendSerialMessage("Z");
        }


        //---------------------------------------------------------------------
        // Receive data
        //---------------------------------------------------------------------

        string message = serialController.ReadSerialMessage();

        if (message == null)
            return;

        // Check if the message is plain data or a connect/disconnect event.
        if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_CONNECTED))
            Debug.Log("Connection established");
        else if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_DISCONNECTED))
            Debug.Log("Connection attempt failed or disconnection detected");
        else
        //Debug.Log("Message arrived: " + message);
        {
            string[] m = message.Split(',');
            int F1 = int.Parse(m[0]);
            int F2 = int.Parse(m[1]);
            int F3 = int.Parse(m[2]);
            int F4 = int.Parse(m[3]);
            int F5 = int.Parse(m[4]);
            

            if (F1 > 150 && b1 == false)
            {
                b1 = true;
                float vol1 = (float)(F1) / (float)(600.0);
                float xpos;
                if (points[0].transform.localPosition.x < points[4].transform.localPosition.x)
                    xpos = points[0].transform.localPosition.x; 
                else
                    xpos = points[5].transform.localPosition.x;
                if (xpos > -1.8 && xpos <= -0.9)
                {
                    keys[0].volume = vol1;
                    keys[0].Play();
                }
                if (xpos > -0.9 && xpos <= 0)
                {
                    keys[1].volume = vol1;
                    keys[1].Play();
                }
                if (xpos > 0 && xpos <= 0.9)
                {
                    keys[2].volume = vol1;
                    keys[2].Play();
                }
                if (xpos > 0.9 && xpos <= 1.8)
                {
                    keys[3].volume = vol1;
                    keys[3].Play();
                }
                if (xpos > 1.8 && xpos <= 2.6)
                {
                    keys[4].volume = vol1;
                    keys[4].Play();
                }
                if (xpos > 2.6 && xpos <= 3.4)
                {
                    keys[5].volume = vol1;
                    keys[5].Play();
                }
                if (xpos > 3.4 && xpos <= 4.4)
                {
                    keys[6].volume = vol1;
                    keys[6].Play();
                }
                if (xpos > 4.4 && xpos <= 5.3)
                {
                    keys[7].volume = vol1;
                    keys[7].Play();
                }
            }
        
            if (F1 < 20 && b1 == true)
            {
                b1 = false;
            }

            if (F2 > 150 && b2 == false)
            {
                b2 = true;
                float vol2 = (float)(F2) / (float)(600.0);
                float xpos;
                if (points[0].transform.localPosition.x < points[4].transform.localPosition.x)
                    xpos = points[1].transform.localPosition.x;
                else
                    xpos = points[6].transform.localPosition.x;
                if (xpos > -1.8 && xpos <= -0.9)
                {
                    keys[0].volume = vol2;
                    keys[0].Play();
                }
                if (xpos > -0.9 && xpos <= 0)
                {
                    keys[1].volume = vol2;
                    keys[1].Play();
                }
                if (xpos > 0 && xpos <= 0.9)
                {
                    keys[2].volume = vol2;
                    keys[2].Play();
                }
                if (xpos > 0.9 && xpos <= 1.8)
                {
                    keys[3].volume = vol2;
                    keys[3].Play();
                }
                if (xpos > 1.8 && xpos <= 2.6)
                {
                    keys[4].volume = vol2;
                    keys[4].Play();
                }
                if (xpos > 2.6 && xpos <= 3.4)
                {
                    keys[5].volume = vol2;
                    keys[5].Play();
                }
                if (xpos > 3.4 && xpos <= 4.4)
                {
                    keys[6].volume = vol2;
                    keys[6].Play();
                }
                if (xpos > 4.4 && xpos <= 5.3)
                {
                    keys[7].volume = vol2;
                    keys[7].Play();
                }
            }
            if (F2 < 20 && b2 == true)
            {
                b2 = false;
            }

            if (F3 > 150 && b3 == false)
            {
                b3 = true;
                float vol3 = (float)(F3) / (float)(600.0);
                float xpos;
                if (points[0].transform.localPosition.x < points[4].transform.localPosition.x)
                    xpos = points[2].transform.localPosition.x;
                else
                    xpos = points[7].transform.localPosition.x;
                if (xpos > -1.8 && xpos <= -0.9)
                {
                    keys[0].volume = vol3;
                    keys[0].Play();
                } 
                if (xpos > -0.9 && xpos <= 0)
                {
                    keys[1].volume = vol3;
                    keys[1].Play();
                }
                if (xpos > 0 && xpos <= 0.9)
                {
                    keys[2].volume = vol3;
                    keys[2].Play();
                }
                if (xpos > 0.9 && xpos <= 1.8)
                {
                    keys[3].volume = vol3;
                    keys[3].Play();
                }
                if (xpos > 1.8 && xpos <= 2.6)
                {
                    keys[4].volume = vol3;
                    keys[4].Play();
                }
                if (xpos > 2.6 && xpos <= 3.4)
                {
                    keys[5].volume = vol3;
                    keys[5].Play();
                }
                if (xpos > 3.4 && xpos <= 4.4)
                {
                    keys[6].volume = vol3;
                    keys[6].Play();
                }
                if (xpos > 4.4 && xpos <= 5.3)
                {
                    keys[7].volume = vol3;
                    keys[7].Play();
                }
            }
            if (F3 < 20 && b3 == true)
            {
                b3 = false;
            }

            if (F4 > 150 && b4 == false)
            {
                b4 = true;
                float vol4 = (float)(F4) / (float)(600.0);
                float xpos;
                if (points[0].transform.localPosition.x < points[4].transform.localPosition.x)
                    xpos = points[3].transform.localPosition.x;
                else
                    xpos = points[8].transform.localPosition.x;
                if (xpos > -1.8 && xpos <= -0.9)
                {
                    keys[0].volume = vol4;
                    keys[0].Play();
                }
                if (xpos > -0.9 && xpos <= 0)
                {
                    keys[1].volume = vol4;
                    keys[1].Play();
                }
                if (xpos > 0 && xpos <= 0.9)
                {
                    keys[2].volume = vol4;
                    keys[2].Play();
                }
                if (xpos > 0.9 && xpos <= 1.8)
                {
                    keys[3].volume = vol4;
                    keys[3].Play();
                }
                if (xpos > 1.8 && xpos <= 2.6)
                {
                    keys[4].volume = vol4;
                    keys[4].Play();
                }
                if (xpos > 2.6 && xpos <= 3.4)
                {
                    keys[5].volume = vol4;
                    keys[5].Play();
                }
                if (xpos > 3.4 && xpos <= 4.4)
                {
                    keys[6].volume = vol4;
                    keys[6].Play();
                }
                if (xpos > 4.4 && xpos <= 5.3)
                {
                    keys[7].volume = vol4;
                    keys[7].Play();
                }
            }
            if (F4 < 20 && b4 == true)
            {
                b4 = false;
            }

            if (F5 > 150 && b5 == false)
            {
                b5 = true;
                float vol5 = (float)(F5) / (float)(600.0);
                float xpos;
                if (points[0].transform.localPosition.x < points[4].transform.localPosition.x)
                    xpos = points[4].transform.localPosition.x;
                else
                    xpos = points[9].transform.localPosition.x;
                if (xpos > -1.8 && xpos <= -0.9)
                {
                    keys[0].volume = vol5;
                    keys[0].Play();
                }
                if (xpos > -0.9 && xpos <= 0)
                {
                    keys[1].volume = vol5;
                    keys[1].Play();
                }
                if (xpos > 0 && xpos <= 0.9)
                {
                    keys[2].volume = vol5;
                    keys[2].Play();
                }
                if (xpos > 0.9 && xpos <= 1.8)
                {
                    keys[3].volume = vol5;
                    keys[3].Play();
                }
                if (xpos > 1.8 && xpos <= 2.6)
                {
                    keys[4].volume = vol5;
                    keys[4].Play();
                }
                if (xpos > 2.6 && xpos <= 3.4)
                {
                    keys[5].volume = vol5;
                    keys[5].Play();
                }
                if (xpos > 3.4 && xpos <= 4.4)
                {
                    keys[6].volume = vol5;
                    keys[6].Play();
                }
                if (xpos > 4.4 && xpos <= 5.3)
                {
                    keys[7].volume = vol5;
                    keys[7].Play();
                }
            }
            if (F5 < 20 && b5 == true)
            {
                b5 = false;
            }
        }

    }
}
