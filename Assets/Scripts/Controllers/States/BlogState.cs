using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States {

    public class BlogState : BaseState {

        #region Public Behaviour

        public BlogState (object parent) : base(parent) { }

        public override void Enter () {
            BlogSystem.GetPosts(OnGetPostsSuccess);
            if (app.posts == null) { // First time shows loader, rest of times, shows the already loaded posts
                blogScreenController.Load();
            } else {
                blogScreenController.Show(app.posts);
            }
        }

        public override void Exit () {
            blogScreenController.Hide();
        }

        public void OnGetPostsSuccess (List<Post> posts) {
            app.SetPosts(posts);
            blogScreenController.Show(app.posts);
        }

        #endregion

    }

}