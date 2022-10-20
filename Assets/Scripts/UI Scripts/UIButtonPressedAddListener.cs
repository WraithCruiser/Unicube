using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonPressedAddListener : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _image;
    [SerializeField] private List<GameObject> _images;

    private void ImageEnable()
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

    private void OnEnable() 
    {
        _button.onClick.AddListener(ImageEnable);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ImageEnable);
    }
}
