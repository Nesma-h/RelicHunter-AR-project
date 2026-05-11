using UnityEngine;

[CreateAssetMenu(fileName = "NewRelic", menuName = "Relic/Data")]
public class RelicData : ScriptableObject
{
    public string relicNameArabic;
    [TextArea(3, 10)] public string description;
    public string era;
    public Sprite relicIcon; // ضفنا مكان للصورة
    public AudioClip narrationClip; // ضفنا مكان للصوت
}