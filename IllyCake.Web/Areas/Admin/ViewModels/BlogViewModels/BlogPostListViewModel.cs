﻿namespace IllyCake.Web.Areas.Admin.ViewModels.BlogViewModels
{
    using IllyCake.Data.Models;
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;

    public class BlogPostListViewModel : BlogPostBaseViewModel
    {
        public string Id { get; set; }

        [DisplayName("Статус")]
        public BlogPostStates LastState { get; set; }

        [DisplayName("Създател")]
        public string CreatorName { get; set; }

        [DisplayName("Създател")]
        public string Email { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }

        public static Expression<Func<BlogPost, BlogPostListViewModel>> ExpressionFromBlogPost
        {
            get
            {
                return x => new BlogPostListViewModel()
                {
                    Created = x.Created,
                    Modified = x.Modified,
                    Id = x.Id,
                    CreatorName = x.User.FirstName + " " + x.User.LastName,
                    Email = x.User.Email,
                    Alias = x.Alias,
                    //EmbededVideo = x.EmbedetVideo,
                    LastState = x.LastState,
                    //ShortDescription = x.ShortDescription,
                    //Subtitle = x.Subtitle,
                    //ThumbImageId = x.ThumbImageId,
                    Title = x.Title
                };
            }
        }
    }
}
