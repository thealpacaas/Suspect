using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
public enum GamePhase
{
    INTRO, WATCH, WINDOW, CROWD, ROOM, ENDING
}

public enum GameScene
{
    Scene1, Scene2, Scene3, Scene4, Scene5
}

public class GM : MonoBehaviour
{
    [SerializeField] private List<GameObject> _Scenes;

    public GamePhase gamePhase;
    public GameScene gameScene;
    public static GM _instance;
    public static GM Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GM>();

                if (_instance == null)
                {
                    GameObject container = new GameObject("GameManager");
                    _instance = container.AddComponent<GM>();
                }
            }

            return _instance;
        }
    }

    public SpriteRenderer MCsprite;
    public int Day = 1;
    public GameObject Knocking;
    public List<PlayableDirector> CrowdDirectors;
    public PlayableDirector Director;
    public PlayableDirector Director2;
    public PlayableDirector HomeDirector;
    public PlayableDirector FinalDirector;
    public GameObject NewFriendUI;
    public bool isInfected;
    public int Point=1;
    public bool isOnEvent;
    public Text DayText;
    public Text Cases;

    private void Awake()
    {
        _instance = this;
        AudioManager.Initialize();
    }

    private void Start()
    {
       
        
    }

    public void Change_Gamephase(GamePhase gp)
    {
        gamePhase = gp;
        switch (gamePhase)
        {
            case GamePhase.INTRO:
                if (Day == 10)
                {
                    FinalDirector.Play();
                }
                else if (Day < 10)
                {
                    AudioManager.Instance.PlaySFXLoop("BGM001");
                    Cases.text = "COVID-19: " + Point * 8 + " Cases";
                    Director.Play();
                    OnActivating_DoorEvent(GameScene.Scene1);
                }
                break;
            case GamePhase.WATCH:
                break;
            case GamePhase.WINDOW:
                break;
            case GamePhase.CROWD:
                Play_DirectorOnDay(Day);
                break;
            case GamePhase.ROOM:
                Stop_DirectorOnDay(Day);
                HomeDirector.Play();
                break;
            case GamePhase.ENDING:
                break;
        }
    }

    public void Play_DirectorOnDay(int d)
    {
        switch (d)
        {
            case 1:
                CrowdDirectors[0].Play();
                break;
            case 4:
                CrowdDirectors[1].Play();
                break;
            case 7:
                CrowdDirectors[2].Play();
                break;
        }

        if (d == 1)
        {
            StartCoroutine(ChangePlayerColor(28f));
        }
    }
    public void Stop_DirectorOnDay(int d)
    {
       
        switch (d)
        {
            case 1:
                CrowdDirectors[0].Stop();
                break;
            case 4:
                CrowdDirectors[1].Stop();
                break;
            case 7:
                CrowdDirectors[2].Stop();
                break;
        }
    }

    public void OnActivating_DoorEvent(GameScene gs)
    {
        gameScene = gs;
        switch (gameScene)
        {
            case GameScene.Scene1:
                StartCoroutine(ActivatingObj_Auto(5f, Knocking));
                break;
            case GameScene.Scene2:
                Director2.Play();
                DayText.text = "DAY " + Day.ToString();
                break;
            case GameScene.Scene3:
                break;
            case GameScene.Scene4:
                break;
            case GameScene.Scene5:
                break;
        }
    }


    public void StopAnyDirector(PlayableDirector dir)
    {
        dir.Stop();
    }

    public void stopdirector()
    { Director2.Stop(); }
    public void playdirector()
    { Director2.Play(); }

    IEnumerator ActivatingObj_Auto(float delay, GameObject obj)
    {
        yield return new WaitForSeconds(delay);
        obj.SetActive(true);
    }
    IEnumerator DeactivatingObj_Auto(float delay, GameObject obj)
    {
        yield return new WaitForSeconds(delay);
        obj.SetActive(false);
    }
    IEnumerator ChangePlayerColor(float delay)
    {
        yield return new WaitForSeconds(delay);
        isInfected = true;
        MCsprite.color = Color.red;

    }
   


    public void GotNewFriend_Activated()
    {
        Point += 1;
        NewFriendUI.SetActive(true);
        StartCoroutine(DeactivatingObj_Auto(6f, NewFriendUI));

    }



}
