using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharTemple : MonoBehaviour
{
    public GameObject charPrefab;
    public GameObject followcharPrefab; //임시 캐릭터
    public Weapon[] weapon; //캐릭터 정보

    [System.Serializable]
    public struct Weapon
    {
        public Sprite sprite; //이미지
        public float damage;  //데미지
        public int count;     //공 생성 개수
        public int cost;      //필요골드
        public int sell;      //판매골드
    }
}
