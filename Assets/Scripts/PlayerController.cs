using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float force = 0.1f;
    public float cooldown = 0.5f;
    public float lastPush = 0;
    public AudioClip hit;
    public AudioClip bounce;
    public ParticleSystem jet;
    public float rotationSpeed = 0.05f;
    public float jetDrag = 2f;
    public AudioSource perduckAudioSource;
    public AudioSource musicSource;
    public AudioClip winMusic;
    public GodScript gs;

	// Use this for initialization
	void Start () {
		
	}

    void WasdControls()
    {
        Vector3 direction = transform.rotation * Vector3.up;
	    if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().AddTorque(rotationSpeed, ForceMode2D.Impulse);
        }
	    if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().AddTorque(-rotationSpeed, ForceMode2D.Impulse);
        }
	    if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().angularDrag = jetDrag;
            GetComponent<Rigidbody2D>().AddForce(direction.normalized * force * Time.deltaTime, ForceMode2D.Impulse);
            jet.Play();
            if (!perduckAudioSource.isPlaying)
            {
                perduckAudioSource.Play();
            }
        } else
        {
            jet.Stop();
            GetComponent<Rigidbody2D>().angularDrag = 0f;
            perduckAudioSource.Stop();
        }
    }

    void MouseControls()
    {
        if (Input.GetKey(KeyCode.Space)/* && (Time.fixedTime > lastPush + cooldown)*/)
        {
            jet.Play();
            //GetComponent<AudioSource>().pla
            lastPush = Time.fixedTime;
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 0f;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            mousePosition.z = 0f;
            Vector3 direction = (mousePosition - transform.position).normalized;
            Quaternion correction = Quaternion.AngleAxis(MyMath.SomewhatNormal(-60f, 60f, 5), Vector3.forward);
            GetComponent<Rigidbody2D>().AddForce(correction * direction * force * Time.deltaTime, ForceMode2D.Impulse);

        }
        else
        {
            jet.Stop();
        }

    }
	
	// Update is called once per frame
	void Update () {
        WasdControls();
	}

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("space"))
        {
            gs.GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("exit"))
        {
            GetComponent<Joint2D>().enabled = true;
            GetComponent<Joint2D>().connectedBody = collision.attachedRigidbody;
            musicSource.Stop();
            musicSource.clip = winMusic;
            musicSource.Play();
            Debug.Log("Won");
            gs.Win();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bouncer"))
        {
            GetComponent<AudioSource>().PlayOneShot(bounce);
        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(hit);
        }
    }
}
