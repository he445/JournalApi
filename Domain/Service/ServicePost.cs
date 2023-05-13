using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class PostService : InterfaceServices
    {
        private readonly IPost _IPost;

        public PostService(IPost IPost)
        {
            _IPost = IPost;
        }

        public async Task Add(Post Object)
        {
            var validateTitle = Object.ValidateStringProperty(Object.Title, "Title");
            if (validateTitle)
            {
                Object.CreatedDate = DateTime.Now;
                Object.ModifiedDate = DateTime.Now;
                Object.Active = true;
                await _IPost.Add(Object);
            }
        }

        public async Task Update(Post Object)
        {
            var validateTitle = Object.ValidateStringProperty(Object.Title, "Title");
            if (validateTitle)
            {
                Object.ModifiedDate = DateTime.Now;
                await _IPost.Update(Object);
            }
        }

        public async Task<List<Post>> GetActivePosts()
        {
            return await _IPost.GetPosts(n => n.Active);
        }
    }
}

