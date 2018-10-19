using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ObjectMovement : MonoBehaviour {
    public List<Sprite> frames;
    public float forceBase;
    public float enemiesForceBase;
    public LevelGenerator gameControlRef;
    public Vector3 initPos;
    public AudioClip hitChihuahua;
    public AudioClip trampolin;

    //velocimeter
    public Slider Velocimeter;
    public float velocDownVelocity = 0.07f;
    public float velocUpVelocity = 0.03f;

    private AudioSource source;

    bool flying = false;
    bool activatedCollisions = false;
    float velocimeterCounter;
    bool activateVelocimeter = true;
    bool up = true;
    // Use this for initialization
    void Start () {
        //initPos = this.transform.position;
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
        if (flying)
        {

            if (this.GetComponent<Rigidbody2D>().velocity.magnitude <= 3 && this.transform.position.y < -1)
            {
                this.GetComponent<SpriteRenderer>().sprite = frames[0];
                this.transform.rotation = Quaternion.identity;
                this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                this.GetComponent<Rigidbody2D>().angularVelocity = 0;
                gameControlRef.GetComponent<ScoreManager>().parseScore = false;
                gameControlRef.GetComponent<ScoreManager>().CompareScore();
                gameControlRef.GetComponent<ScoreManager>().SetMaxScoreScreen();
                activatedCollisions = false;
                flying = false;
                gameControlRef.GetComponent<InterfaceControl>().ActivateRestartMenu();
            }
        }
        else if (this.GetComponent<Rigidbody2D>().velocity.magnitude < 0.1 && this.transform.position.y < -1)
        {
            this.GetComponent<SpriteRenderer>().sprite = frames[0];
            this.transform.rotation = Quaternion.identity;
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            this.GetComponent<Rigidbody2D>().angularVelocity = 0;
            gameControlRef.GetComponent<ScoreManager>().parseScore = false;
            gameControlRef.GetComponent<ScoreManager>().CompareScore();
            gameControlRef.GetComponent<ScoreManager>().SetMaxScoreScreen();
            flying = false;
            activatedCollisions = false;
            gameControlRef.foot.deactivateInput = false;
            gameControlRef.GetComponent<InterfaceControl>().ActivateRestartMenu();
        }
        else if (!flying && activateVelocimeter)
        {
            if (up)
            {
                velocimeterCounter += velocUpVelocity;
                if (velocimeterCounter > 1) up = false;
            }
            else
            {
                velocimeterCounter -= velocDownVelocity;
                if (velocimeterCounter < -0.5) up = true;
            }
            Velocimeter.value = velocimeterCounter;
        }
    }

    public void ResetObject()
    {
        this.GetComponent<SpriteRenderer>().sprite = frames[1];
        this.transform.position = initPos;
        ActivateVelocimeter(true);
        this.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        this.GetComponent<Rigidbody2D>().angularVelocity = 0;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1) * Random.Range(2000, 5500));
        activatedCollisions = true;
        flying = false;
    }

    float GetShotForce()
    {
        float force = Mathf.Clamp(velocimeterCounter, 0.3f, 1); ;
        force *= forceBase;
        return force;
    }
    public void ActivateVelocimeter(bool active)
    {
        activateVelocimeter = active;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (activatedCollisions)
        {
            if (col.gameObject.tag == "Shooter")
            {
                source.PlayOneShot(hitChihuahua, 1.0f);
                this.GetComponent<SpriteRenderer>().sprite = frames[1];
                Vector2 dir = new Vector2(this.transform.position.x, this.transform.position.y) - col.contacts[0].point;
                this.GetComponent<Rigidbody2D>().AddForce(dir * GetShotForce());
                this.GetComponent<Rigidbody2D>().AddTorque(-200);
                ActivateVelocimeter(false);
                gameControlRef.GetComponent<ScoreManager>().parseScore = true;
                gameControlRef.AttachCamera();
                Velocimeter.GetComponentInParent<DeactivateButton>().activateSelf(false);
                gameControlRef.foot.deactivateInput = false;
                flying = true;
            }
            else if (col.gameObject.tag == "Enemy")
            {
                Vector2 dir = new Vector2(-1, 1).normalized;
                source.PlayOneShot(trampolin, 1.0f);
                //this.GetComponent<Rigidbody2D>().AddForce(dir * enemiesForceBase);
                this.GetComponent<Rigidbody2D>().AddForce(dir * this.GetComponent<Rigidbody2D>().velocity.magnitude * enemiesForceBase);
                this.GetComponent<Rigidbody2D>().AddTorque(5.0f);
            }
        }
        
    }

   
}
