using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Wintrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerControllor.instance.parabolacontroller.Animation = false;
            PlayerControllor.instance.parabolacontroller.Speed = 0;
            PlayerControllor.instance.UImanager.winPanel.SetActive(true);
            print("Win");
            SceneManager.LoadScene(0);
        }

    }

}

