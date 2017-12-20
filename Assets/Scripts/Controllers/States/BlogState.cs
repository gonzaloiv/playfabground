using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States {

    public class BlogState : BaseState {

        #region Public Behaviour

        public BlogState (object parent) : base(parent) { }

        public override void Enter () {
            BlogService.GetPosts()
               .Then((posts) =>  {
                   blogScreenController.Show(posts);
                   if (posts == null) { // First time shows loader, rest of times, shows the already loaded posts
                       blogScreenController.Load(); // TODO: Would be better a common loading state ?
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