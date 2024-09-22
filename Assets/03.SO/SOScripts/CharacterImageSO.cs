using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/CharacterImageList")]
public class CharacterImageSO : ScriptableObject
{
    public List<Sprite> characterImage = new List<Sprite>();
}
