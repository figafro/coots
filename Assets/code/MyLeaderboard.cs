using Dan.Main;
using Dan.Models;
using TMPro;
using UnityEngine;


    public class MyLeaderboard : MonoBehaviour
    {
        [SerializeField] private string _leaderboardPublicKey = "e0790a373d1048808b698d1f0f9d7156bf8c8f8e62c782cb123b5c85538df2b6";

        [SerializeField] private TextMeshProUGUI _playerScoreText;
        [SerializeField] private TextMeshProUGUI[] _entryFields;

        [SerializeField] private TMP_InputField _playerUsernameInput;

        public int _playerScore = 55555;

        private void Start()
        {
            Load();
        }


        // public void AddPlayerScore()
        // {
        //    _playerScore++;
        //    _playerScoreText.text = "Your score: " + _playerScore;
        // }

        public void Load() => LeaderboardCreator.GetLeaderboard(_leaderboardPublicKey, OnLeaderboardLoaded);

        private void OnLeaderboardLoaded(Entry[] entries)
        {
            foreach (var entryField in _entryFields)
            {
                entryField.text = "";
            }

            for (int i = 0; i < entries.Length; i++)
            {
            float s = (-(entries[i].Score - 1000000) / 100f);
                _entryFields[i].text = $"{i + 1}. {entries[i].Username} : { Mathf.FloorToInt(s / 60).ToString() + ":" + (s - Mathf.Floor(s / 60) * 60).ToString() }";
            }
        }

        public void Submit()
        {
            LeaderboardCreator.UploadNewEntry(_leaderboardPublicKey, _playerUsernameInput.text, _playerScore, OnUploadComplete);
        }

        private void OnUploadComplete(bool success)
        {
            if (success)
                Load();
        }
    }


