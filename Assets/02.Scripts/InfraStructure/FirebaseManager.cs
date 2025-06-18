using System;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Extensions;
using Firebase.Firestore;

public class FirebaseManager : MonoBehaviour
{
    private FirebaseApp _app;
    private FirebaseAuth _auth;
    private FirebaseFirestore _db;
    private void Start()
    {
        Init();

    }

    private void Init()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                Debug.Log("파이어베이스 연결에 성공했습니다.");
                _app = FirebaseApp.DefaultInstance;
                _auth = FirebaseAuth.DefaultInstance;
                _db = FirebaseFirestore.DefaultInstance;
                   // Register();
                Login();
            }
            else
            {
                Debug.Log($"파이어베이스 연결 실패했습니다 {dependencyStatus}");
            }
        });
    }

    private void Register()
    {
        string email = "kerect2@naver.com";
        string password = "1234567";
        
        _auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task => {
            if (task.IsCanceled || task.IsFaulted) {
                
                Debug.LogError($"회원가입에 실패했습니다 : {task.Exception.Message}");
                return false;
            }
            // Firebase user has been created.
            Firebase.Auth.AuthResult result = task.Result;
            Debug.LogFormat("회원가입에 성공했습니다.: {0} ({1})",
                result.User.DisplayName, result.User.UserId);

            return true;
        });
    }

    private void Login()
    {
        
        string email = "kerect2@naver.com";
        string password = "1234567";
        
        _auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task => {
            if (task.IsCanceled || task.IsFaulted) {
                Debug.LogError($"로그인에 실패했습니다.{task.Exception.Message}");
                return;
            }

            Firebase.Auth.AuthResult result = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                result.User.DisplayName, result.User.UserId);
        });

        AddRanking();
        // NicknameChanged();
        // GetMyRankings();
        
        GetRankings();
    }

    private void NicknameChanged()
    {
        FirebaseUser user = _auth.CurrentUser;
        if (user == null)
        {
            return;
        }

        var profile = new UserProfile()
        {
            DisplayName = "teemo"
        };

        user.UpdateUserProfileAsync(profile).ContinueWith(task =>
        {
            if (task.IsCanceled || task.IsFaulted)
            {
                Debug.LogError($"닉네임 변경에 실패했습니다. : {task.Exception.Message}");
                return;
            }

            Debug.Log("닉네임 변경에 성공했습니다.");
        });
    }

    private void GetProfile()
    {
        Firebase.Auth.FirebaseUser user = _auth.CurrentUser;
        if (user == null)
        {
            return;
        }
        

        string nickName = user.DisplayName;
        string email = user.Email;

        Account account = new Account(email, nickName, "FIREBASE");

    }

    private void AddRanking()
    {
        Ranking ranking = new Ranking("gind","huc@gmail.com", 2300);
        
        Dictionary<string, object> rankingDict = new Dictionary<string, object>
        {
            { "Email", ranking.Email },
            { "Nickname", ranking.Nickname },
            { "Score", ranking.Score}
        };
        _db.Collection("rankings").Document(ranking.Email).SetAsync(rankingDict).ContinueWithOnMainThread(task => {
            Debug.Log(String.Format("Added document with ID: {0}.", task.Id)); 
        });
    }

    private void GetMyRankings()
    {
        string email = "hu@gmail.com";
        
        DocumentReference docRef = _db.Collection("rankings").Document(email);
        docRef.GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            var snapshot = task.Result;
            if (snapshot.Exists) {
       
                Debug.Log(String.Format("Document data for {0} document:", snapshot.Id));
                var rankingDict = snapshot.ToDictionary();
                foreach (var pair in rankingDict) {
                    Debug.Log(String.Format("{0}: {1}", pair.Key, pair.Value));
                }
            } else {
                Debug.Log(String.Format("Document {0} does not exist!", snapshot.Id));
            }
        });
    }


    private void GetRankings()
    {
        // 쿼리 : 컬렉션으로부터 데이터를 가져올 때 어떻게 가져오라고 쓰는 명령문
        Query allRankingsQuery = _db.Collection("rankings").OrderByDescending("Score");
        
        allRankingsQuery.GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            QuerySnapshot allCitiesQuerySnapshot = task.Result;
            foreach (DocumentSnapshot documentSnapshot in allCitiesQuerySnapshot.Documents)
            {
                Debug.Log(String.Format("Document data for {0} document:", documentSnapshot.Id));
                Dictionary<string, object> ranking = documentSnapshot.ToDictionary();
                foreach (KeyValuePair<string, object> pair in ranking)
                {
                    Debug.Log(String.Format("{0}: {1}", pair.Key, pair.Value));
                }

                // Newline to separate entries
                Debug.Log("");
            }
        });
    }
}
