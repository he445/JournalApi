using Domain.Interfaces;
using Entity.Entities;
using Infra.config;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryPost : RepositoryGenerics<Post>, IPost
    {

        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryPost()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();

        }
        public async Task<List<Post>> GetPosts(Expression<Func<Post, bool>> exMessage)
        {
            using (var Db = new ContextBase(_OptionsBuilder))
            {
                return await Db.Posts.Where(exMessage).AsNoTracking().ToListAsync();
            }
        }


    }
}