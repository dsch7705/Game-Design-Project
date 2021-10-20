using UnityEngine.UI;
using LootLocker.Requests;
using TMPro;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    public TMP_InputField MemberID;
    public TMP_Text[] entries;
    public int maxScores = 15;
    private int score;
    public int ID;

    private void Start()
    {
        GameEvents.current.OnPlayerDied += FetchScores;

        string playerIdentifier = "unique_player_identifier_here";
        LootLockerSDKManager.StartSession(playerIdentifier, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Successful");
            }
            else
            {
                Debug.LogWarning("failed: " + response.Error);
            }
        });
    }

    public void FetchScores()
    {
        LootLockerSDKManager.GetScoreList(ID, maxScores, (response) =>
        {
            if (response.success)
            {
                LootLockerLeaderboardMember[] scores = response.items;

                for (int i = 0; i < scores.Length; i++)
                {
                    entries[i].text = (scores[i].rank + ".  " + scores[i].member_id + " - " + scores[i].score);
                }

                if (scores.Length < maxScores)
                {
                    for (int i = scores.Length; i < maxScores; i++)
                    {
                        entries[i].text = (i + 1).ToString() + ".  none";
                    }
                }
            }
            else
            {
                Debug.LogWarning("failed: " + response.Error);
            }
        });
    }

    public void SubmitScore()
    {
        score = Player.current.kills;

        LootLockerSDKManager.SubmitScore(MemberID.text, score, ID, (response) => 
        {
            if (response.success)
            {
                Debug.Log("Score sent successfully.");
            }
            else
            {
                Debug.LogWarning("Score failed to send. " + response.Error);
            }
        });
    }
}
