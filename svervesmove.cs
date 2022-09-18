using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class svervesmove : MonoBehaviour
{
    // Start is called before the first frame update

    private float lastframefingerpositionX;
    public float movefactorX;
    public float swervespeed = 0.5f;
    public float maxswerveamount = 1f;
    public float extremeSwerveAmount;
    public Transform lastPoint;
    public float swerveamount;
    public float targetxSpeed;
    [SerializeField] float minZ;
    [SerializeField] float maxZ;
    public float diffZ;

   // public float MovefactorX => movefactorX;


    void Start() {
        maxZ = lastPoint.position.z;
        minZ = maxZ - diffZ;



    }

    void Update()
    {
    

            if (Input.GetMouseButtonDown(0))
        {
            lastframefingerpositionX = Input.mousePosition.x;

        }
        else if (Input.GetMouseButton(0))
        {
            movefactorX = Input.mousePosition.x - lastframefingerpositionX;
            lastframefingerpositionX = Input.mousePosition.x;


        }
        else if (Input.GetMouseButtonUp(0))
        {
            movefactorX = 0f;

        }

        swerveamount = Time.deltaTime * swervespeed * movefactorX;
        transform.Translate(-swerveamount, 0, 0);


        //  MoveLastPoint(swerveamount);
        Vector3 Temp = transform.position;
        Temp.x = Mathf.Clamp(transform.position.x, -maxswerveamount, maxswerveamount);

        transform.position = Temp;
        MoveLastPoint();

    
}

   public void MoveLastPoint()

    {
        float targetX;
        float targetZ;



        Vector3 Temp = lastPoint.position;
        Temp.z = lastPoint.position.z;
        if (transform.position.x > extremeSwerveAmount)
        {
            Vector3 target = lastPoint.position;
            targetX= Mathf.Lerp(extremeSwerveAmount, -extremeSwerveAmount, Mathf.InverseLerp( extremeSwerveAmount, maxswerveamount,transform.position.x));
            target.x= Mathf.Lerp(lastPoint.position.x, targetX, targetxSpeed);
            targetZ= Mathf.Lerp(maxZ, minZ, Mathf.InverseLerp(extremeSwerveAmount, maxswerveamount, transform.position.x));
            target.z = Mathf.Lerp(lastPoint.position.z, targetZ, targetxSpeed);
            lastPoint.position = target;
         


        }
        else if (transform.position.x < - extremeSwerveAmount)
        {
           
            Vector3 target = lastPoint.position;
            targetX = Mathf.Lerp(-extremeSwerveAmount,extremeSwerveAmount, Mathf.InverseLerp(-extremeSwerveAmount, -maxswerveamount, transform.position.x));
             target.x=Mathf.Lerp(target.x, targetX, targetxSpeed);

           
            targetZ=Mathf.Lerp(maxZ, minZ, Mathf.InverseLerp(-extremeSwerveAmount,- maxswerveamount, transform.position.x));
            target.z = Mathf.Lerp(lastPoint.position.z, targetZ, targetxSpeed);
            lastPoint.position = target;

      
        }
        else
        {
           
            Temp = lastPoint.position;
            Temp.x = Mathf.Lerp(Temp.x, transform.position.x, 10 * Time.deltaTime);
            lastPoint.position = Temp;
         //   print(Temp);

        }

     

    }
    
    
}



