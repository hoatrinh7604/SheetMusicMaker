using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalController : MonoBehaviour
{
    [SerializeField] int id;

    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
    }


    public int GetID()
    {
        return id;
    }
}
