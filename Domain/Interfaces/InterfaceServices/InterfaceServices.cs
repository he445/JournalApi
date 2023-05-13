using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Entities;

namespace Domain.Interfaces.InterfaceServices
{
    public interface InterfaceServices
    {


        Task Add(Post Object);

        Task Update(Post Object);

        Task<List<Post>> GetActivePosts();


    }
}