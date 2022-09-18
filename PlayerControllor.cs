using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllor : MonoBehaviour
{
    public static PlayerControllor instance;

    public Parabolacontrollor parabolacontroller;
    public Boxjump boxjump;
    public svervesmove Svervemovement;
    public UiManager UImanager;


    public float targetRotation = 90;
  


    public bool playerThrow;
    protected float Animation;
    public float maxPos = 0.1f;
    public float targetRspeed = 0.3f;
    public AudioSource CoinSoind;

    float targetR;
    float playerStartPosZ;
    float playerStartAngle;
    public GameObject playerTwoRotate;
    [SerializeField] Vector3 startEularAnglesOfChild;

    void Start()
    {
        instance = this;
        playerStartPosZ = transform.position.z;
        playerStartAngle = transform.localEulerAngles.y;
        startEularAnglesOfChild = playerTwoRotate.transform.localEulerAngles;
    }

    void Update()
    {
        //    Animation += Time.deltaTime;
        //    Animation = Animation % 5f;
        //    transform.position = MathParabloa.Parabola(Vector3.zero, Vector3.forward * 10f, 5f, Animation / 5f);     

        if (!playerThrow)
        {
          //  transform.LookAt(parabolacontroller.spheres[1].transform);

           playerTwoRotate.transform.LookAt(parabolacontroller.spheres[1].transform);
        }
        else
        {

          //    playerTwoRotate.transform.localEulerAngles = Vector3.Lerp(playerTwoRotate.transform.localEulerAngles,startEularAnglesOfChild,10*Time.deltaTime);
            playerTwoRotate.transform.localEulerAngles = startEularAnglesOfChild;
        }

        if (Input.GetMouseButtonUp(0))
        {

            if (!playerThrow)
            {
                GetComponent<Parabolacontrollor>().FollowParabola();
                playerThrow = true;
                Svervemovement.swervespeed = 0;
                parabolacontroller.OffPathLine();
            }
            if (Svervemovement.transform.position.x < maxPos)
            {
            targetRotation = 180;            
            }
             if (Svervemovement.transform.position.x > maxPos)
            {
                targetRotation = 0;

            }
        }
        parabolacontroller.DrawPathLine();



        if (playerThrow)
        {
            Vector3 temp = transform.localEulerAngles;
            /*targetR*/ temp.y = Mathf.Lerp(playerStartAngle, targetRotation, Mathf.InverseLerp(playerStartPosZ, Svervemovement.lastPoint.position.z, transform.position.z));
         //   temp.y = Mathf.Lerp(transform.eulerAngles.y, targetR, targetRspeed);
            transform.localEulerAngles = temp;

        }

    }
}


   
   
   



