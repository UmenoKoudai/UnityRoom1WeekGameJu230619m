using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputText : MonoBehaviour
{
    [SerializeField] InputField _input;

    private void Update()
    {
        GetComponent<Text>().text = _input.NowText;
    }
}
