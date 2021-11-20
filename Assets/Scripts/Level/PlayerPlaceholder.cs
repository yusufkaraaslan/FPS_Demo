using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlaceholder : MonoBehaviour
{
    [SerializeField] GameObject lookDir;

    private void Start()
    {
        lookDir.SetActive(false);
        gameObject.SetActive(false);
    }

}
