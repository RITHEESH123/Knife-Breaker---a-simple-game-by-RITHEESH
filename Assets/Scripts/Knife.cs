using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody myBody;
    private bool onWood;

    private KnifeSpawner knifeSpawner;

    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        knifeSpawner = GameObject.Find("Knife Spawner").GetComponent<KnifeSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !onWood)
        {
            myBody.velocity = new Vector3(0f, speed, 0f);
        }
    }

    void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Wood")
        {
            gameObject.transform.SetParent(target.transform);
            myBody.velocity = Vector3.zero;
            onWood = true;
            myBody.detectCollisions = false;

            //spawn more knifes
            knifeSpawner.SpawnKnife();

            //add score
            knifeSpawner.IncrementScore();
        }
        if (target.tag == "Knife")
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("End");
        }
    }

    
}
