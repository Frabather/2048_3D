using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using Image = UnityEngine.UI.Image;

public class ThrowCubes : MonoBehaviour
{
    private GameObject cube;
    public GameObject[] selectorArr;
    public GameObject[] RandomCubes;
    public Mesh newMesh;
    public Material CubeMaterial_2;
    public Material CubeMaterial_4;
    public Material CubeMaterial_8;
    public Material CubeMaterial_16;
    public Material CubeMaterial_32;
    public Material CubeMaterial_64;
    public Material CubeMaterial_128;
    public Material CubeMaterial_256;
    public Material CubeMaterial_512;
    public Material CubeMaterial_1024;
    public Material CubeMaterial_2048;
    public Material CubeMaterial_4096;
    public Material CubeMaterial_8192;


    private int x = 0, size = 4999, randomNumer, randomNumer2;

    private GameObject ball;
    private Rigidbody ball_rb;
    private bool isSpacePressed, isWaiting, isBallThrown;
    private string nameOfNextBall;
    public int ThrowsLeft;

    float velx, vely, angle;
    private GameObject ThrowingAngleStep;
    public Material Step1, Step2, Step3;

    private float randomX, randomY, randomZ;


    private GameObject soundEffects;
    private AudioClip clickSound;
    private AudioSource effectsSource;

    void Awake()
    {
        soundEffects = GameObject.Find("EmptyToManageThemAll");
        AudioSource[] effectSources = soundEffects.GetComponents<AudioSource>();
        effectsSource = effectSources[1];
        clickSound = effectSources[1].clip;

        ThrowingAngleStep = GameObject.Find("ThrowingAngleImage");
        cube = GameObject.Find("Cube");
        selectorArr = new GameObject[size];

        randomNumer2 = Random.Range(10, 15);
        RandomCubes = new GameObject[randomNumer2];

        ball = GameObject.Find("Cube");
        ball_rb = ball.GetComponent<Rigidbody>();
        isSpacePressed = false;
        ThrowsLeft = size + 1;

        for (x = 0; x < randomNumer2; x++)
        {
            randomX = Random.Range(-18f, -12f);
            randomZ = Random.Range(-7f, 7f);
            randomY = Random.Range(2f, 5f);

            RandomCubes[x] = new GameObject();
            RandomCubes[x].name = "RandomCube nr. " + x.ToString();
            RandomCubes[x].tag = "Balls";
            RandomCubes[x].GetComponent<Transform>().position = new Vector3(randomX, randomY, randomZ);
            RandomCubes[x].AddComponent<CollisionDetection>();
            RandomCubes[x].AddComponent<MeshFilter>();
            RandomCubes[x].GetComponent<MeshFilter>().mesh = newMesh;
            RandomCubes[x].AddComponent<MeshRenderer>();
            randomNumer = Random.Range(1, 21);
            if (randomNumer < 10)
            {
                RandomCubes[x].GetComponent<MeshRenderer>().material = CubeMaterial_2;
            }
            else if (randomNumer >= 10 && randomNumer < 15)
            {
                RandomCubes[x].GetComponent<MeshRenderer>().material = CubeMaterial_4;
            }
            else if (randomNumer >= 15 && randomNumer < 19)
            {
                RandomCubes[x].GetComponent<MeshRenderer>().material = CubeMaterial_8;
            }
            else
            {
                RandomCubes[x].GetComponent<MeshRenderer>().material = CubeMaterial_16;
            }

            RandomCubes[x].AddComponent<BoxCollider>();
            RandomCubes[x].AddComponent<Rigidbody>();
            RandomCubes[x].SetActive(true);

        }


        for (x = 0; x < size; x++)
        {
            selectorArr[x] = new GameObject();
            selectorArr[x].name = "go nr. " + x.ToString();
            selectorArr[x].tag = "Balls";
            selectorArr[x].GetComponent<Transform>().position = new Vector3(7.5f, 2f, 0f);
            selectorArr[x].AddComponent<CollisionDetection>();
            selectorArr[x].AddComponent<MeshFilter>();
            selectorArr[x].GetComponent<MeshFilter>().mesh = newMesh;
            selectorArr[x].AddComponent<MeshRenderer>();
            randomNumer = Random.Range(1, 21);
            if (randomNumer < 10)
            {
                selectorArr[x].GetComponent<MeshRenderer>().material = CubeMaterial_2;
            }
            else if (randomNumer >= 10 && randomNumer < 15)
            {
                selectorArr[x].GetComponent<MeshRenderer>().material = CubeMaterial_4;
            }
            else if (randomNumer >= 15 && randomNumer < 19)
            {
                selectorArr[x].GetComponent<MeshRenderer>().material = CubeMaterial_8;
            }
            else
            {
                selectorArr[x].GetComponent<MeshRenderer>().material = CubeMaterial_16;
            }

            selectorArr[x].AddComponent<BoxCollider>();
            selectorArr[x].AddComponent<Rigidbody>();
            selectorArr[x].SetActive(false);
        }
        x = 0;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown("1"))
        {
            effectsSource.PlayOneShot(clickSound);
            angle = 0;
            ThrowingAngleStep.GetComponent<Image>().material = Step1;
        }
        if (Input.GetKeyDown("2"))
        {
            effectsSource.PlayOneShot(clickSound);
            angle = 45;
            ThrowingAngleStep.GetComponent<Image>().material = Step2;
        }
        if (Input.GetKeyDown("3"))
        {
            effectsSource.PlayOneShot(clickSound);
            angle = 90;
            ThrowingAngleStep.GetComponent<Image>().material = Step3;
        }


        if (Input.GetKeyDown("space") && !isSpacePressed)
        {
            BallThrow();
        }

        if (!isSpacePressed)
        {

            ball_rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

            if (ball_rb.transform.position.z >= -7.7f && ball_rb.transform.position.z <= 7.5f)
            {
                ball_rb.transform.position = ball_rb.transform.position + new Vector3(0, 0, horizontalInput * 0.075f * Time.timeScale);
                ball_rb.velocity = new Vector3(0, 0, 0);
            }
            else
            {
                if (ball_rb.transform.position.z < -7.7f)
                {
                    ball_rb.AddForce(0, 0, 25);
                }
                if (ball_rb.transform.position.z > 7.5f)
                {
                    ball_rb.AddForce(0, 0, -25);
                }
            }
        }
        else
        {
            if (x < size && !isBallThrown)
            {
                BallThrow();
            }
        }
    }

    public void BallThrow()
    {
        if (!isBallThrown && !isSpacePressed)
        {
            ThrowsLeft = size - x;
            ball_rb.constraints = RigidbodyConstraints.None;

            vely = Mathf.Sin(angle * Mathf.Deg2Rad) * 10;
            ball_rb.velocity = new Vector3(-25 + (vely * 1.25f), vely, 0);

            isSpacePressed = true;
            isBallThrown = true;
            StartCoroutine(ballSpawnWaiter());
        }
    }

    private void NextBall()
    {
        if (x == size)
        {
            Application.LoadLevel(0);

        }
        ball = selectorArr[x];
        ball.SetActive(true);
        ball_rb = ball.GetComponent<Rigidbody>();
        isSpacePressed = false;
        isBallThrown = false;
        x++;
    }

    IEnumerator ballSpawnWaiter()
    {
        yield return new WaitForSeconds(0.5f);
        NextBall();
    }


    public void TestMoveRight()
    {
        if (ball_rb.transform.position.z >= -7.7f && ball_rb.transform.position.z <= 7.5f)
        {
            //Debug.Log(horizontalInput);
            ball_rb.transform.position = ball_rb.transform.position + new Vector3(0, 0, 1 * 0.075f * Time.timeScale);
            ball_rb.velocity = new Vector3(0, 0, 0);
        }
        else
        {
            if (ball_rb.transform.position.z < -7.7f)
            {
                ball_rb.AddForce(0, 0, 25);
            }
            if (ball_rb.transform.position.z > 7.5f)
            {
                ball_rb.AddForce(0, 0, -25);
            }
        }
    }

    public void TestMoveLeft()
    {
        if (ball_rb.transform.position.z >= -7.7f && ball_rb.transform.position.z <= 7.5f)
        {
            //Debug.Log(horizontalInput);
            ball_rb.transform.position = ball_rb.transform.position + new Vector3(0, 0, -1 * 0.075f * Time.timeScale);
            ball_rb.velocity = new Vector3(0, 0, 0);
        }
        else
        {
            if (ball_rb.transform.position.z < -7.7f)
            {
                ball_rb.AddForce(0, 0, 25);
            }
            if (ball_rb.transform.position.z > 7.5f)
            {
                ball_rb.AddForce(0, 0, -25);
            }
        }
    }
}
