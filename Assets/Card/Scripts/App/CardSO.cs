using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Book ", menuName = "Data/Scriptable Object/Book Infor SO")]
public class CardSO : ScriptableObject
{
    public CardInfor[] bookInfors;

    public CardInfor GetBookWithID(int id)
    {
        int n = bookInfors.Length;
        for (int i = 0; i < n; i++)
        {
            if (id == bookInfors[i].songID) return bookInfors[i];
        }

        return null;
    }

    [Button]
    public void SetID()
    {
        int n = bookInfors.Length;
        for (int i = 0; i < n; i++)
        {
            bookInfors[i] = new CardInfor()
            {
                songID = i
            };
        }
    }


#if UNITY_EDITOR
    [Header("Get Audio Clips")] public string folderPath;

    [Button]
    public void SetAllDatas()
    {
        var spriteGUIDs = UnityEditor.AssetDatabase.FindAssets("t:sprite", new[] {folderPath});

        bookInfors = new CardInfor[spriteGUIDs.Length];

        SetID();

        int n = bookInfors.Length;

        for (int i = 0; i < n; i++)
        {
            string audioPath =
                UnityEditor.AssetDatabase.GUIDToAssetPath(spriteGUIDs[i]); // Chuyển đổi GUID sang đường dẫn
            var sprite = UnityEditor.AssetDatabase.LoadAssetAtPath<Sprite>(audioPath); // Tải T từ đường dẫn

            bookInfors[i].icon = sprite;
        }

        /*var assets = UnityEditor.AssetDatabase.FindAssets("t:audioclip", new[] {folderPath});

        for (int i = 0; i < n; i++)
        {
            string audioPath = UnityEditor.AssetDatabase.GUIDToAssetPath(assets[i]); // Chuyển đổi GUID sang đường dẫn
            var audioClip = UnityEditor.AssetDatabase.LoadAssetAtPath<AudioClip>(audioPath); // Tải T từ đường dẫn

            bookInfors[i].song = audioClip;
        }*/
    }
#endif
}

[Serializable]
public class CardInfor
{
    public int songID;
    public string name;
    public string content;
    public int price = 200;
    public AudioClip song;
    public Sprite icon;
}