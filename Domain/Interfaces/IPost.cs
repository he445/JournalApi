using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Entities.Entities;
using static Domain.Interfaces.IGeneric;

namespace Domain.Interfaces
{
    public interface IPost : IGeneric<Post>
    {
        Task<List<Post>> ListarMessage(Expression<Func<Post, bool>> exMessage);
    }
}