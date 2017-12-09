﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class BlogScreenController : BaseScreenController  {

    #region Fields / Properties

    [SerializeField] private Text titleText;
    [SerializeField] private Text bodyText;
	[SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;

    private List<Post> posts;
    private int currentPostIndex = 0;

    #endregion

    #region Public Behaviour

    public override void Init() {
        base.Init();
        rightButton.onClick.AddListener(OnRightButtonClick);
        leftButton.onClick.AddListener(OnLeftButtonClick);
    }

    public void Show (List<Post> posts) {
        base.Show();
        this.posts = posts.OrderBy(post => post.timestamp).ToList();
        ShowCurrentPost();
    }

    public void OnRightButtonClick() {
        currentPostIndex = (currentPostIndex + 1) % posts.Count;
        ShowCurrentPost();
    }

    public void OnLeftButtonClick () {
        currentPostIndex = (currentPostIndex - 1) % posts.Count;
        ShowCurrentPost();
    }

    #endregion

    #region Private Behaviour

    private void ShowCurrentPost () {
        titleText.text = posts[currentPostIndex].title;
        bodyText.text = posts [currentPostIndex].body;
    }

    #endregion

}
