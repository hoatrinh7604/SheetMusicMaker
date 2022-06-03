using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] GameObject[] listImage;
    [SerializeField] int index;
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => OnPress());
    }

    public void SetInfo(int index = -1)
    {
        Reset();
        if(index == -1)
        {
            return;
        }

        GameObject image = Instantiate(listImage[index], Vector3.zero, Quaternion.identity, transform);
        image.transform.localPosition = Vector3.zero;
    }

    public void OnPress()
    {
        //Send index
        GamePlayController.Instance.OnPress(index);
    }

    public void Reset()
    {
        for(int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
