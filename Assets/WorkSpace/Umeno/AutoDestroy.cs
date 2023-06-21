using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField] float _destroyTime;
    void Start()
    {
        Destroy(gameObject, _destroyTime);
    }
}
