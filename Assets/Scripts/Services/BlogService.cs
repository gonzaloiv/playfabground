using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Linq;

public class BlogService : BaseService {

    #region Public Behaviour

    public static void GetPosts (Action<List<Post>> OnGetPostsSuccess) {
        var request = new GetTitleNewsRequest();
        PlayFabClientAPI.GetTitleNews(request, (result) => {
            List<Post> posts = new List<Post>();
            result.News.ForEach(item => { posts.Add(new Post(item.NewsId, item.Timestamp, item.Title, item.Body)); });
            GetPostsSuccessCallback(result);
            OnGetPostsSuccess(posts);
        }, ErrorCallback);
    }

    #endregion

    #region Private Behaviour

    private static void GetPostsSuccessCallback<PlayFabResultCommon> (PlayFabResultCommon result) {
        Debug.Log("You have " + (result as GetTitleNewsResult).News.Count + " unread news");
    }

    #endregion

}
