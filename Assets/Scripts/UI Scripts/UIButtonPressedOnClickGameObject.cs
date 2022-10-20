using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonPressedOnClickGameObject : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _image;
    [SerializeField] private List<GameObject> _images;
    public void ImageEnable()
    {
        if (!_image.activeInHierarchy)
        {
            foreach (GameObject item in _images)
            {
                if (item.activeInHierarchy)
                {
                    item.SetActive(false);
                }
            }
            _image.SetActive(true);
        }
        else
        {
            _image.SetActive(false);
        }
    }
}
