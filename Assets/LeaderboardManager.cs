using UnityEngine.UI;
using LootLocker.Requests;
using TMPro;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    public TMP_InputField MemberID;
    private int score;
    public int ID;

    private void Start()
    {
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
