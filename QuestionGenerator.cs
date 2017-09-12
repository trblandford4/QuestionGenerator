using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class QuestionGenerator : MonoBehaviour {

    public Material grid;
    public GameObject parent;
    public Text questionText;

    private string question;
    private GameObject go1;
    private GameObject go2;
    private GameObject go3;
    private GameObject go4;
    private GameObject go5;

    // Use this for initialization
    void Start () {
        generateQuestion();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void generateQuestion()
    {
        float x = UnityEngine.Random.Range(1, 9);
        float y = UnityEngine.Random.Range(1, 9);
        float z = UnityEngine.Random.Range(1, 9);


        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        for (float i = 0; i < x * 0.05; i = i + 0.05f)
        {
            for (float j = 0; j < y * 0.05; j = j + 0.05f)
            {
                for (float k = -0.05f * z; k < -0.01f; k = k + 0.05f)
                {
                    GameObject go = Instantiate(cube, new Vector3(i, j, k), Quaternion.Euler(0, 0, 0));
                    print(k);
                    go.transform.SetParent(parent.transform);
                    go.layer = 10;
                    go.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
                    go.GetComponent<Renderer>().material = grid;
                }
            }
        }

        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Cube);

        // xy plane
        GameObject go1 = Instantiate(plane, new Vector3(0.05f * (x / 2) - 0.025f, 0.05f * (y / 2) - 0.025f, -0.05f * z - 0.025f), Quaternion.Euler(0, 0, 0));
        go1.transform.localScale = new Vector3(0.05f * x, 0.05f * y, 0.0001f);
        go1.GetComponent<Renderer>().enabled = false;
        go1.transform.SetParent(parent.transform);
        go1.AddComponent<BoxCollider>();
        go1.layer = 10;

        // xz plane
        GameObject go2 = Instantiate(plane, new Vector3(0.05f * (x / 2) - 0.025f, 0.05f * y - 0.025f, -0.05f * (z / 2) - 0.025f), Quaternion.Euler(0, 0, 0));
        go2.transform.localScale = new Vector3(0.05f * x, 0.0001f, 0.05f * z);
        go2.GetComponent<Renderer>().enabled = false;
        go2.transform.SetParent(parent.transform);
        go2.AddComponent<BoxCollider>();
        go2.layer = 10;

        // yz plane right side
        GameObject go3 = Instantiate(plane, new Vector3(0.05f * x - 0.025f, 0.05f * (y / 2) - 0.025f, -0.05f * (z / 2) - 0.025f), Quaternion.Euler(0, 0, 0));
        go3.transform.localScale = new Vector3(0.0001f, 0.05f * y, 0.05f * z);
        go3.GetComponent<Renderer>().enabled = false;
        go3.transform.SetParent(parent.transform);
        go3.AddComponent<BoxCollider>();
        go3.layer = 10;

        // yz plane left side
        GameObject go4 = Instantiate(plane, new Vector3(-0.025f, 0.05f * (y / 2) - 0.025f, -0.05f * (z / 2) - 0.025f), Quaternion.Euler(0, 0, 0));
        go4.transform.localScale = new Vector3(0.0001f, 0.05f * y, 0.05f * z);
        go4.GetComponent<Renderer>().enabled = false;
        go4.transform.SetParent(parent.transform);
        go4.AddComponent<BoxCollider>();
        go4.layer = 10;

        // xz plane
        GameObject go5 = Instantiate(plane, new Vector3(0.05f * (x / 2) - 0.025f, -0.025f, -0.05f * (z / 2) - 0.025f), Quaternion.Euler(0, 0, 0));
        go5.transform.localScale = new Vector3(0.05f * x, 0.0001f, 0.05f * z);
        go5.GetComponent<Renderer>().enabled = false;
        go5.transform.SetParent(parent.transform);
        go5.AddComponent<BoxCollider>();
        go5.layer = 10;

        float[] surfaceArea = new float[3] { x * y, y * z, x * z};
        float[] perimeter = new float[3] { 2 * x + 2 * y, 2 * y + 2 * z, 2 * x + 2 * z };
        int pOrSA = UnityEngine.Random.Range(1, 3);

        if (pOrSA == 1)
        {
            int qNumber = UnityEngine.Random.Range(0, 3);
            question = string.Format("Select the side that has a perimeter of {0}.", perimeter[qNumber]);
            questionText.text = question;

            if (qNumber == 0)
            {
                go1.tag = "Target";
            }
            if (qNumber == 1)
            {
                go3.tag = "Target";
                go4.tag = "Target";
            }
            if (qNumber == 2)
            {
                go2.tag = "Target";
                go5.tag = "Target";
            }
        }
        else
        {
            int qNumber = UnityEngine.Random.Range(0, 3);
            question = string.Format("Select the side that has a surface area of {0}", surfaceArea[qNumber]);
            questionText.text = question;

            if (qNumber == 0)
            {
                go1.tag = "Target";
            }
            if (qNumber == 1)
            {
                go3.tag = "Target";
                go4.tag = "Target";
            }
            if (qNumber == 2)
            {
                go2.tag = "Target";
                go5.tag = "Target";
            }
        }
    }
}
