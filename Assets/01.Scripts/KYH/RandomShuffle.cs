using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomShuffle : MonoBehaviour
{//이 코드의 절반은 내가 짠 코드가 아님
    public static List<T> GetRandomShuffleList<T>(List<T> _list)
    {
        for(int i = _list.Count -1; i> 0; i--)
        {
            int rnd = Random.Range(0, i);

            T temp = _list[i];
            _list[i] = _list[rnd];
            _list[rnd] = temp;
        }

        return _list;
    }
}
