using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServicePost : InterfaceServices
    {
        private readonly IPost _PostService;

        public ServicePost(IPost PostService)
        {
            _PostService = PostService;
        }
    }
}
