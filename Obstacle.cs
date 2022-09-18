using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerControllor.instance.parabolacontroller.Animation = false;
            PlayerControllor.instance.parabolacontroller.Speed = 0;
            PlayerControllor.instance.UImanager.failPanel.SetActive(true);
            print("Fail");
            SceneManager.LoadScene(0);
        }

    }

}
