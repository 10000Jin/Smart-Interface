using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Text;
using System.Threading.Tasks;

public class palmCollider : MonoBehaviour
{
    public GameObject ball;

    //=============================================
    SerialPort sp;
    private bool check = false;
    public static byte[] parsing_send_data = new byte[8];
    public static int recv_num = 0;
    public static string recv_str = "000";

    public string serial_input;
    private string result_string;
    private int vibe=0;
    public Camera maincamera;
    public Camera ballcamera;
    //===========================================


    // Start is called before the first frame update
    void Start()
    {
        //===============================================
        sp = new SerialPort(serial_input, 9600, Parity.None, 8, StopBits.None);     //시리얼 포트 열어주기
        sp.Open();              //포트 열어줌
        sp.ReadTimeout = 100;

        // sp.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived); //이것이 꼭 필요하다
        foreach (string str in SerialPort.GetPortNames())
        {
            Debug.Log(string.Format("Existing COM port: {0}", str));
        }
        //===============================================
    }

    // Update is called once per frame
    void Update()
    {
        sp_Check();

        if (result_string == "ON")
        {
            ball.transform.position = new Vector3(20, 29.5f, 1840);
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            showMainCamera();
        }

        if(vibe != 0)
        {
            vibe++;
            if (vibe > 20)
            {
                vibe = 0;
                sp.Write("b");
            }
        }
    }

    public void sp_Check()
    {
        if (sp.IsOpen)          //포트 열리면
        {
            try
            {
                recv_str = sp.ReadExisting();
                foreach (char c in recv_str)
                {
                    if (c == '$' && check == false)
                    {
                        check = true;
                        result_string = null;
                    }
                    else if (c == '#' && check == true)
                    {
                        check = false;
                        Debug.Log("command :" + result_string);
                    }
                    else
                    {
                        result_string += c;
                    }

                }
            }
            catch (System.Exception e)
            {
                print(e);
                sp.Close();
                throw;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "baseball")
        {
            sp.Write("a");
            vibe = 1;
            GetComponent<AudioSource>().Play();
            showBallCamera();
        }
    }

    public void showMainCamera()
    {
        maincamera.enabled = true;
        ballcamera.enabled = false;
    }
    public void showBallCamera()
    {
        maincamera.enabled = false;
        ballcamera.enabled = true;
    }
}
