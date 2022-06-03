using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawObject : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject[] musicNotes;
    [SerializeField] float timeDelay;

    [SerializeField] Transform[] pos;
    [SerializeField] Transform[] parent;

    private int times;
    private float time;

    [SerializeField] int minDelayTime;
    [SerializeField] int maxDelayTime;

    void Start()
    {
        timeDelay = Random.Range(minDelayTime, maxDelayTime);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time > timeDelay)
        {
            time = 0;
            Spaw();

            timeDelay = Random.Range(minDelayTime, maxDelayTime);
        }
    }

    public void Spaw()
    {
        int randomIndex = Random.Range(0, parent.Length);
        GameObject obj = Instantiate(musicNotes[Random.Range(0, musicNotes.Length)], Vector2.zero, Quaternion.identity, parent[randomIndex]);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localScale = Vector3.one;
        obj.transform.position = new Vector3(pos[randomIndex].position.x, pos[randomIndex].position.y, 0);

        // Set current note in GamePlay
        GamePlayController.Instance.AddNewNote(obj);
    }
}
