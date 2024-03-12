using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharTemple : MonoBehaviour
{
    public GameObject charPrefab;
    public GameObject followcharPrefab; //�ӽ� ĳ����
    public Weapon[] weapon; //ĳ���� ����

    [System.Serializable]
    public struct Weapon
    {
        public Sprite sprite; //�̹���
        public float damage;  //������
        public int count;     //�� ���� ����
        public int cost;      //�ʿ���
        public int sell;      //�ǸŰ��
    }
}
