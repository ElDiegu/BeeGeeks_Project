using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BeeUpdateUI : MonoBehaviour
{
    [SerializeField] private Image _forceImage;
    [SerializeField] private Sprite[] _forceSprites;

    [SerializeField] private Image _honeyImage;
    [SerializeField] private TextMeshProUGUI _honeyText;
    [SerializeField] private Sprite[] _honeySprites;

    [SerializeField] private Image _shootingImage;
    [SerializeField] private Sprite[] _shootingSprites;

    [SerializeField] private Image _livesImage;
    [SerializeField] private Sprite[] _livesSprites;

    public void UpdateLivesSprite(int lives)
    {
        switch (lives)
        {
            case 0:
                _livesImage.sprite = _livesSprites[0];
                break;
            case 1:
                _livesImage.sprite = _livesSprites[1];
                break;
            case 2:
                _livesImage.sprite = _livesSprites[2];
                break;
            case 3:
                _livesImage.sprite = _livesSprites[3];
                break;
            case 4:
                _livesImage.sprite = _livesSprites[4];
                break;
        }
    }

    public void UpdateHoneySprite(int honey)
    {
        if(honey == 0)
        {
            _honeyImage.sprite = _honeySprites[1];
            UpdateForceSprite(false);
            UpdateShootingSprite(false);
        }
        else
        {
            _honeyImage.sprite = _honeySprites[0];
            UpdateShootingSprite(true);
            if (honey == 1)
            {
                UpdateForceSprite(false);
            }
            else
            {
                UpdateForceSprite(true);
            }
        }
        _honeyText.text = honey.ToString();

    }

    private void UpdateForceSprite(bool force)
    {
        if (force)
        {
            _forceImage.sprite = _forceSprites[0];
        }
        else
        {
            _forceImage.sprite = _forceSprites[1];
        }
    }

    private void UpdateShootingSprite(bool shooting)
    {
        if (shooting)
        {
            _shootingImage.sprite = _shootingSprites[0];
        }
        else
        {
            _shootingImage.sprite = _shootingSprites[1];
        }
    }
}
