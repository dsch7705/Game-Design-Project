using UnityEngine.UI;
using LootLocker.Requests;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    public InputField MemberID, PlayerScore;
    public int ID;

    private void Start()
    {
        LootLockerSDKManager.StartSession("Player", (response) =>
        {
            if (response.success)
            {
                Debug.Log("Server handshake successful.");
            }
            else
            {
                Debug.LogWarning("Server handshake failed.");
            }
        });
    }

    public void SubmitScore()
    {
        LootLockerSDKManager.SubmitScore(MemberID.text, int.Parse(PlayerScore.text), ID, (response) => 
        {
            if (response.success)
            {
                Debug.Log("Score sent successfully.");
            }
            else
            {
                Debug.LogWarning("Score failed to send.");
            }
        });
    }
}
