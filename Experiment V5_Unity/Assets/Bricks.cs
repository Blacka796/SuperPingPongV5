using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour
{

    public GameManager ui;
    public Transform explosion;
    AudioSource Audio;
    // Start is called before the first frame update
    void Start()
    {
        Audio = GetComponent<AudioSource>();
        ui = GameObject.FindWithTag("ui").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ball")
        {
            Instantiate(explosion, coll.transform.position, coll.transform.rotation);
            ui.IncrementScore();
            Audio.Play();
            Destroy(gameObject);
        }
    }
}
