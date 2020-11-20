using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EScoreEvent
{
    draw,
    mine,
    mineGold,
    gameWin,
    gameLose
}

public class ScoreManager : MonoBehaviour
{
    static private ScoreManager S;

    static public int SCORE_FROM_PREV_ROUND = 0;
    static public int HIGH_SCORE = 0;

    public int chain = 1;
    public int scoreRun = 1;
    public int score = 0;
    public GameObject scoreboard;
    public Text scoreGT;

    void Awake()
    {
        if (S == null)
        {
            S = this;
        }
        else
        {
            Debug.LogError("ERROR: ScoreManager.Awake(): S is already set!");
        }

        if (PlayerPrefs.HasKey("ProspectorHighScore"))
        {
            HIGH_SCORE = PlayerPrefs.GetInt("ProspectorHighScore");
        }

        score += SCORE_FROM_PREV_ROUND;
        SCORE_FROM_PREV_ROUND = 0;
    }

    static public void EVENT(EScoreEvent evt)
    {
        try
        {
            S.Event(evt);
        }
        catch (System.NullReferenceException nre)
        {
            Debug.LogError("ScoreManager:EVENT() called while S=null.\n" + nre);
        }
    }

    void Event(EScoreEvent evt)
    {
        scoreboard = GameObject.Find("Scoreboard");
        scoreGT = scoreboard.GetComponent<Text>();

        switch (evt)
        {
            case EScoreEvent.draw:
            case EScoreEvent.gameWin:
            case EScoreEvent.gameLose:
                chain = 1;
                score += scoreRun;
                scoreRun = 1;
                break;

            case EScoreEvent.mine:
                chain++;
                if (CheckIfGold(Prospector.S.GetTarget())) { scoreRun += (chain * 2); } else { scoreRun += chain; }
                scoreGT.text = scoreRun.ToString();
                break;
        }

        switch (evt)
        {
            case EScoreEvent.gameWin:
                SCORE_FROM_PREV_ROUND = score;
                print("You won this round! Round Score: " + score);
                break;

            case EScoreEvent.gameLose:
                if (HIGH_SCORE <= score)
                {
                    print("You got the high score! High score: " + score);
                    HIGH_SCORE = score;
                    PlayerPrefs.SetInt("ProspectorHighScore", score);
                }
                else
                {
                    print("Your final score for the game was: " + score);
                }
                break;

            default:
                print("score: " + score + " scoreRun: " + scoreRun + " chain: " + chain);
                break;
        }
    }

    public bool CheckIfGold(CardProspector cTarget)
    {
        if (cTarget.tag == "Gold") return (true);
        return (false);
    }

    static public int CHAIN { get { return S.chain; } }
    static public int SCORE { get { return S.score; } }
    static public int SCORE_RUN { get { return S.scoreRun; } }
}
