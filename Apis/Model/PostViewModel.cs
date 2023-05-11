using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apis.Model
{
    public class PostViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool Active { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string UserId { get; set; }

    }
}