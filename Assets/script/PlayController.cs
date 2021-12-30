using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO.Ports;
using System.Text;
using System.Threading.Tasks;


public class PlayController : MonoBehaviour
{
    private Rigidbody rb;

    public Text myScore;
    public GameObject Plane;
    public GameObject ball;
    private float timeCount = 0;
    private float getDistance = 0;
    private int finish = 0;
    BatCapsule batCap;

    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }


    /*
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }
    */
    // Update is called once per frame
    void Update()
        {
            
            if (finish == 0)
            {
                timeCount += Time.deltaTime;
                getDistance = Vector3.Distance(ball.transform.position, new Vector3(20, 29.5f, 1840));
                SetCountText();
            }

        }
    /*
    void OnTriggEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Plane"))
        {
            getDistance = Vector3.Distance( new Vector3(0, 0, 0), other.gameObject.transform.position);
        }
    }
    */
    void SetCountText()
    {
        myScore.text = "[Distance] : " + string.Format("{0:0.00} ", getDistance/30) + "m\n[Time] : " + string.Format("{0:0.00} ", timeCount) + "s";
        if (getDistance >= 1000000)
        {
            myScore.text = "You Win! " + "[Time] : " + timeCount.ToString();
            finish = 1;
        }
    }
    /*
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag=="bat")
        {
            Vector3 force = new Vector3(10, 10, 10);
            GetComponent<Rigidbody>().AddForce(force);
            sp.Write("a");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "bat")
        {
            sp.Write("b");
        }
    }
    */
    
    

    //================================================
    

    //================================================
}