using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AudioData
{
    public string Id;
    public AudioClip Audio;
}

[CreateAssetMenu]
public class AudioDatabase : ScriptableObject
{
    public AudioData[] AudioDB;
}
