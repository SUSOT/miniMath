using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterImageChange : MonoBehaviour
{
    public Image characterImage { get; private set; }
    public int currentCardNum { get; private set; }

    public CharacterImageSO characterImageSO;
    private List<Sprite> spriteList = new();
    private int currentSprite;

    private TeamSignatureNumber signature;

    private void Awake()
    {
        characterImage= GetComponent<Image>();
        signature = transform.parent.GetComponent<TeamSignatureNumber>();
    }

    private void Start()
    {
        foreach (Sprite sprite in characterImageSO.characterImage)
        {
            spriteList.Add(sprite);
        }

        characterImage.sprite = spriteList[0];
        currentCardNum = int.Parse(gameObject.name.Substring(0, 1));
        print(currentCardNum);
        signature.cardSO.cardImage = characterImage.sprite;
    }

    private void OnDisable()
    {
        signature.cardSO.cardImage = null;
    }

    public void RightSlide()
    {
        if (!(currentSprite == (spriteList.Count - 1)))
            currentSprite++;
        else
            currentSprite = 0;

        ChangeSpriteImage(currentSprite);
    }

    public void LeftSlide()
    {
        if (currentSprite > 0)
            currentSprite--;
        else
            currentSprite = spriteList.Count -1;

        ChangeSpriteImage(currentSprite);
    }

    private void ChangeSpriteImage(int count)
    {
        characterImage.sprite = spriteList[count];
        signature.cardSO.cardImage = characterImage.sprite;
    }
}
