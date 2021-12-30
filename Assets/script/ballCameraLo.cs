using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO.Ports;
using System.Text;
using System.Threading.Tasks;

public class ballCameraLo : MonoBehaviour
{
    public GameObject ball;
    public GameObject camera;
    Vector3 location;
    Vector3 distance = new Vector3(0, 9, -16);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        camera.transform.position = ball.transform.position + distance;
    }
}
