using UnityEngine;

public class GPGSLeaderboards : MonoBehaviour
{
    public void OpenLeaderboard()
    {
        Social.ShowLeaderboardUI();
    }

    //public void UpdateLeaderboardScore(long TimeInMilliseconds)
    //{
    //    Social.ReportScore(TimeInMilliseconds, GPGSIds.leaderboard_level_1, (bool success) =>
    //    {
    //        if (success)
    //        {
    //            Debug.Log("Updated To LeaderBoard");
    //        }
    //    });
    //} Staat in GPGSAUtenthicator

    //leaderboards voor level 2,3,4 en saven naar leaderboard, en score als parameter, hoe moet je de score pushen? welk format zeg maar
}
