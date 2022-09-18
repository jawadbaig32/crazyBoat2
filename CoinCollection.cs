using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollection : MonoBehaviour



{

    public Vector3 RotateCoin;
    public float Speed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag( "Player"))
        {
            gameObject.SetActive(false);
            PlayerControllor.instance.CoinSoind.Play();
            coinScore.coinAmount +=1;
           

            

        }
 
    }

     void Update()
    {
        transform.Rotate(RotateCoin * Speed * Time.deltaTime);
   
    }


}
