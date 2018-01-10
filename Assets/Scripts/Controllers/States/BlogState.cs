using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States {

    public class BlogState : BaseState {

        #region Public Behaviour

        public BlogState (object parent) : base(parent) { }

        public override void Enter () {
            blogScreenController.Load();
            BlogService.GetPosts()
               .Then((posts) => {
                   blogScreenController.Show(posts);
                   if (posts == null) {
                       mainController.ToMainMenuState();
                   } else {
                       blogScreenController.Show(posts);
                   }
               });
        }

        public override void Exit () {
            blogScreenController.Hide();
        }

        #endregion

    }

}