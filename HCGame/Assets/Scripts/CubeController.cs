using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeController : MonoBehaviour
{
    [SerializeField] private GameObject _destroyEffect;
    private void Update()
    {
        transform.Rotate(0f, 0.5f, 0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        MoneyController.Money += 50;
        GameObject effect = (GameObject)Instantiate(_destroyEffect, transform.position, Quaternion.identity);
    }

}
