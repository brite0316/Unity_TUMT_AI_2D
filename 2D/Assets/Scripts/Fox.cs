using UnityEngine;

public class Fox: MonoBehaviour
{
    [Header("對話內容")]
    public string start = "嗨! 幫我找水果";
    public string not_complete = "我找到了";
    public string complete = "感謝你的幫忙";

    [Header("對話速度")]
    public float speed = 1.5f;

    [Header("任務相關")]
    public bool missing_completer = true;
    public string count_player = "0";
    public string count_finish = "75";



        
}
