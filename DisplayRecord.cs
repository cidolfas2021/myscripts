using HeathenEngineering.SteamworksIntegration;
using HeathenEngineering.SteamworksIntegration.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayRecord : MonoBehaviour, ILeaderboardEntryDisplay
{
    [SerializeField]
    private SetUserAvatar avatar;
    [SerializeField]
    private SetUserName userName;
    [SerializeField]
    private TMPro.TextMeshProUGUI score;
    [SerializeField]
    private TMPro.TextMeshProUGUI rank;
    [SerializeField]
    private TMPro.TextMeshProUGUI totaldeaths;
    [SerializeField]
    private TMPro.TextMeshProUGUI bosskills;
    [SerializeField]
    private TMPro.TextMeshProUGUI goonkills;
    [SerializeField]
    private TMPro.TextMeshProUGUI totalplayerKills;
    private LeaderboardEntry _entry;
    public LeaderboardEntry Entry
    {
        get => _entry;
        set => SetEntry(value);
    }

    private void SetEntry(LeaderboardEntry entry)
    {
        avatar.UserData = entry.User;
        userName.UserData = entry.User;
        score.text = entry.Score.ToString();
        rank.text = entry.Rank.ToString();
        
        _entry = entry;

        totalplayerKills.text = entry.details[0].ToString(); //<-- that is your totalplayerKills
           bosskills.text = entry.details[1].ToString(); //<-- bosskills
           goonkills.text = entry.details[2].ToString(); //<-- goonkills
           totaldeaths.text = entry.details[3].ToString(); //<-- totaldeaths

    }

}
