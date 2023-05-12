using Apis.Model;
using AutoMapper;
using Domain.Interfaces;
using Entity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPost _post;

        public PostController(IMapper mapper, IPost post)
        {
            _mapper = mapper;
            _post = post;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/Add")]
        public async Task<List<Notifies>> Add(PostViewModel post)
        {
            post.UserId = GetLoggedInUserId();
            var postMap = _mapper.Map<Post>(post);
            await _post.Add(postMap);
            return postMap.Notifications;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/Update")]
        public async Task<List<Notifies>> Update(PostViewModel post)
        {
            var postMap = _mapper.Map<Post>(post);
            await _post.Update(postMap);
            return postMap.Notifications;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/Delete")]
        public async Task<List<Notifies>> Delete(PostViewModel post)
        {
            var postMap = _mapper.Map<Post>(post);
            await _post.Delete(postMap);
            return postMap.Notifications;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/GetEntityById")]
        public async Task<PostViewModel> GetEntityById(Post post)
        {
            post = await _post.GetEntityById(post.Id);
            var postMap = _mapper.Map<PostViewModel>(post);
            return postMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/List")]
        public async Task<List<PostViewModel>> List()
        {
            var posts = await _post.List();
            var postMap = _mapper.Map<List<PostViewModel>>(posts);
            return postMap;
        }

        private string GetLoggedInUserId()
        {
            if (User == null)
            {
                return string.Empty;
            }

            var userId = User.FindFirst("userId");
            return userId.Value;
        }
    }
}
