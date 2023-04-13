using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CollisionDetection : MonoBehaviour
{
    private int randomNumber;
    public static int Score;
    private Rigidbody OwnRb, HittedRb;

    private Material OwnMat, HittedMat;
    private GameObject soundEffects;
    private AudioClip ballHit;
    private AudioClip VictorySound;
    private AudioSource effectsSource;
    private AudioSource winningEffectsSource;

    private Text ScoreText;

    void Awake()
    {
        ScoreText = GameObject.Find("Score").GetComponent<Text>();
        soundEffects = GameObject.Find("EmptyToManageThemAll");
        AudioSource[] effectSources = soundEffects.GetComponents<AudioSource>();
        effectsSource = effectSources[0];
        winningEffectsSource = effectSources[3];
        ballHit = effectSources[0].clip;
        VictorySound = effectSources[3].clip;
    }

    void Update()
    {
        ScoreText.text = "Score: " + CollisionDetection.Score.ToString();

        if ((this.transform.position.x > -2f) && (this.GetComponent<MeshRenderer>().material.name == "Material_32 (Instance)" || this.GetComponent<MeshRenderer>().material.name == "Material_64 (Instance)" || this.GetComponent<MeshRenderer>().material.name == "Material_128 (Instance)" || this.GetComponent<MeshRenderer>().material.name == "Material_256 (Instance)" || this.GetComponent<MeshRenderer>().material.name == "Material_512 (Instance)" || this.GetComponent<MeshRenderer>().material.name == "Material_1024 (Instance)"))
        {
            this.GetComponent<Rigidbody>().AddForce(-500 * Time.deltaTime, 100 * Time.deltaTime, 0);
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Balls")
        {
            OwnMat = gameObject.GetComponent<MeshRenderer>().material;
            HittedMat = GameObject.Find(collision.gameObject.name).GetComponent<MeshRenderer>().material;


            if (OwnMat.name == HittedMat.name)
            {

                effectsSource.PlayOneShot(ballHit);

                HittedRb = GameObject.Find(collision.gameObject.name).GetComponent<Rigidbody>();

                switch (OwnMat.name)
                {

                    case "Material_2 (Instance)":
                        GameObject.Find(collision.gameObject.name).GetComponent<MeshRenderer>().material = GameObject.Find("EmptyToManageThemAll").GetComponent<ThrowCubes>().CubeMaterial_4;
                        randomNumber = Random.Range(500, 751);
                        HittedRb.AddForce(0, randomNumber, 0);
                        ScoreCounter(1);
                        Destroy(this.gameObject);
                        break;

                    case "Material_4 (Instance)":
                        GameObject.Find(collision.gameObject.name).GetComponent<MeshRenderer>().material = GameObject.Find("EmptyToManageThemAll").GetComponent<ThrowCubes>().CubeMaterial_8;
                        randomNumber = Random.Range(500, 751);
                        HittedRb.AddForce(0, randomNumber, 0);
                        ScoreCounter(2);
                        Destroy(this.gameObject);
                        break;

                    case "Material_8 (Instance)":
                        GameObject.Find(collision.gameObject.name).GetComponent<MeshRenderer>().material = GameObject.Find("EmptyToManageThemAll").GetComponent<ThrowCubes>().CubeMaterial_16;
                        randomNumber = Random.Range(500, 751);
                        HittedRb.AddForce(0, randomNumber, 0);
                        ScoreCounter(3);
                        Destroy(this.gameObject);
                        break;

                    case "Material_16 (Instance)":
                        GameObject.Find(collision.gameObject.name).GetComponent<MeshRenderer>().material = GameObject.Find("EmptyToManageThemAll").GetComponent<ThrowCubes>().CubeMaterial_32;
                        randomNumber = Random.Range(500, 751);
                        HittedRb.AddForce(0, randomNumber, 0);
                        ScoreCounter(4);
                        Destroy(this.gameObject);
                        break;

                    case "Material_32 (Instance)":
                        GameObject.Find(collision.gameObject.name).GetComponent<MeshRenderer>().material = GameObject.Find("EmptyToManageThemAll").GetComponent<ThrowCubes>().CubeMaterial_64;
                        randomNumber = Random.Range(500, 751);
                        HittedRb.AddForce(0, randomNumber, 0);
                        ScoreCounter(5);
                        Destroy(this.gameObject);
                        break;

                    case "Material_64 (Instance)":
                        GameObject.Find(collision.gameObject.name).GetComponent<MeshRenderer>().material = GameObject.Find("EmptyToManageThemAll").GetComponent<ThrowCubes>().CubeMaterial_128;
                        randomNumber = Random.Range(500, 751);
                        HittedRb.AddForce(0, randomNumber, 0);
                        ScoreCounter(6);
                        Destroy(this.gameObject);
                        break;

                    case "Material_128 (Instance)":
                        GameObject.Find(collision.gameObject.name).GetComponent<MeshRenderer>().material = GameObject.Find("EmptyToManageThemAll").GetComponent<ThrowCubes>().CubeMaterial_256;
                        randomNumber = Random.Range(500, 751);
                        HittedRb.AddForce(0, randomNumber, 0);
                        ScoreCounter(7);
                        Destroy(this.gameObject);
                        break;

                    case "Material_256 (Instance)":
                        GameObject.Find(collision.gameObject.name).GetComponent<MeshRenderer>().material = GameObject.Find("EmptyToManageThemAll").GetComponent<ThrowCubes>().CubeMaterial_512;
                        randomNumber = Random.Range(500, 751);
                        HittedRb.AddForce(0, randomNumber, 0);
                        ScoreCounter(8);
                        Destroy(this.gameObject);
                        break;

                    case "Material_512 (Instance)":
                        GameObject.Find(collision.gameObject.name).GetComponent<MeshRenderer>().material = GameObject.Find("EmptyToManageThemAll").GetComponent<ThrowCubes>().CubeMaterial_1024;
                        randomNumber = Random.Range(500, 751);
                        HittedRb.AddForce(0, randomNumber, 0);
                        ScoreCounter(9);
                        Destroy(this.gameObject);
                        break;

                    case "Material_1024 (Instance)":
                        GameObject.Find(collision.gameObject.name).GetComponent<MeshRenderer>().material = GameObject.Find("EmptyToManageThemAll").GetComponent<ThrowCubes>().CubeMaterial_2048;
                        randomNumber = Random.Range(500, 751);
                        HittedRb.AddForce(0, randomNumber, 0);
                        ScoreCounter(10);
                        Destroy(this.gameObject);
                        WinGame();
                        break;
                    case "Material_2048 (Instance)":
                        GameObject.Find(collision.gameObject.name).GetComponent<MeshRenderer>().material = GameObject.Find("EmptyToManageThemAll").GetComponent<ThrowCubes>().CubeMaterial_4096;
                        randomNumber = Random.Range(500, 751);
                        HittedRb.AddForce(0, randomNumber, 0);
                        ScoreCounter(11);
                        Destroy(this.gameObject);
                        break;
                    case "Material_4096 (Instance)":
                        GameObject.Find(collision.gameObject.name).GetComponent<MeshRenderer>().material = GameObject.Find("EmptyToManageThemAll").GetComponent<ThrowCubes>().CubeMaterial_8192;
                        randomNumber = Random.Range(500, 751);
                        HittedRb.AddForce(0, randomNumber, 0);
                        ScoreCounter(12);
                        Destroy(this.gameObject);
                        break;
                    case "Material_8192 (Instance)":
                        GameObject.Find(collision.gameObject.name).GetComponent<MeshRenderer>().material = GameObject.Find("EmptyToManageThemAll").GetComponent<ThrowCubes>().CubeMaterial_8192;
                        randomNumber = Random.Range(500, 751);
                        HittedRb.AddForce(0, randomNumber, 0);
                        ScoreCounter(13);
                        Destroy(this.gameObject);
                        WinGame();
                        break;
                }
            }
        }
    }

    void ScoreCounter(int typ)
    {
        switch (typ)
        {
            case 1:
                CollisionDetection.Score += 2;
                break;
            case 2:
                CollisionDetection.Score += 4;
                break;
            case 3:
                CollisionDetection.Score += 8;
                break;
            case 4:
                CollisionDetection.Score += 16;
                break;
            case 5:
                CollisionDetection.Score += 32;
                break;
            case 6:
                CollisionDetection.Score += 64;
                break;
            case 7:
                CollisionDetection.Score += 128;
                break;
            case 8:
                CollisionDetection.Score += 256;
                break;
            case 9:
                CollisionDetection.Score += 512;
                break;
            case 10:
                CollisionDetection.Score += 1024;
                break;
            case 11:
                CollisionDetection.Score += 2048;
                break;
            case 12:
                CollisionDetection.Score += 4096;
                break;
            case 13:
                CollisionDetection.Score += 8192;
                break;
            default:
                CollisionDetection.Score = CollisionDetection.Score;
                Debug.Log("Error");
                break;
        }
    }

    void WinGame()
    {
        Debug.Log("wygrales");
        winningEffectsSource.PlayOneShot(VictorySound);
    }
       
}
