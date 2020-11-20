using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    public static Scoreboard S;

    public GameObject prefabFloatingScore;

    [SerializeField] private int _score = 0;
    [SerializeField] private string _scoreString;

    private Transform canvasTrans;

    public int Score
    {
        get
        {
            return (_score);
        }
        set
        {
            _score = value;
            _scoreString = _score.ToString("N0");
        }
    }

    public string ScoreString
    {
        get
        {
            return (_scoreString);
        }
        set
        {
            _scoreString = value;
            GetComponent<Text>().text = _scoreString;
        }
    }

    void Awake()
    {
        if (S == null)
        {
            S = this;
        }
        else
        {
            Debug.LogError("Error: Scoreboard.Awake(): S is already set!");
        }
        canvasTrans = transform.parent;
    }

    public void FSCallback(FloatingScore fs)
    {
        Score += fs.Score;
    }

    public FloatingScore CreateFloatingScore(int amt, List<Vector2> pts)
    {
        GameObject go = Instantiate<GameObject>(prefabFloatingScore);
        go.transform.SetParent(canvasTrans);
        FloatingScore fs = go.GetComponent<FloatingScore>();
        fs.Score = amt;
        fs.reportFinishTo = this.gameObject;
        fs.Init(pts);
        return (fs);
    }
}
