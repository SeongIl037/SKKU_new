using System;
using UnityEngine;
using Firebase;
using Firebase.Extensions;

public class FirebaseManager : MonoBehaviour
{
    private FirebaseApp _app;
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
                _app = Firebase.FirebaseApp.DefaultInstance;

            }
            else {
                Debug.Log($"파이어베이스 연결 실패했습니다 {dependencyStatus}");
            }
        });
    }

}
