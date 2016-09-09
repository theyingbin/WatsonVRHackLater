﻿using UnityEngine;
using System.Collections;

public class MasterTiming : MonoBehaviour
{

    public AudioSource audioSource;

    int poseIndex = 0;
    private Color[] colors = { Color.blue, Color.cyan, Color.green, Color.magenta, Color.red, Color.yellow};

    PoseAudioSync[] posesToSync = new PoseAudioSync[4];

    PoseStruct.Pose[] poses;

    private string[] resources = { "Prefabs/PoseY", "Prefabs/PoseM", "Prefabs/PoseC", "Prefabs/PoseA"};

    private bool ready = true;

    // Use this for initialization
    void Start()
    {

        //audioSource = GameObject.Find("AudioMainSource").GetComponent<AudioSource>();


        poses = PoseStruct.poses;

        for (int i = 0; i < 4; i++)
        {
            GameObject instance =
                Instantiate(Resources.Load(resources[i], typeof(GameObject))) as GameObject;
            instance.name = "Pose" + i;
            posesToSync[i] = instance.GetComponent<PoseAudioSync>();
            posesToSync[i].setResources();
        }
    }

    // Update is called once per frame
    void Update()
    {
        float t = audioSource.time;
        if (poseIndex >= poses.Length/2)
        {
            return;
        }
        if (t > (poses[poseIndex].timeStart - .50f))
        {
            posesToSync[poseIndex % 4].timeTarget = poses[poseIndex].timeStart;

            poseIndex++;
        }
        if (poses[poseIndex].timeStart - t > 2.0f && audioSource.isPlaying && ready)
        {
            StartCoroutine(MakeFlyingObject());
        }
    }

    IEnumerator MakeFlyingObject()
    {
        ready = false;
        int colorIndex = Random.Range(0, colors.Length);
        Vector3 position = new Vector3(Random.Range(-2.2f, 2.2f), Random.Range(0.2f, 2.2f), 5.5f);
        Quaternion rotation = Quaternion.identity;
        GameObject instance = Instantiate(Resources.Load("Prefabs/Sphere", typeof(GameObject)), position, rotation) as GameObject;
        instance.GetComponent<Renderer>().material.color = colors[colorIndex];
        yield return new WaitForSeconds(3.0f);
        ready = true;
    }
}
