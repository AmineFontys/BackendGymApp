using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Data.Repositories
{
    public class RepositoryResponse<T>
    {
        public bool Success { get; set; } = true;
        public string? Message { get; set; }
        public List<string> Errors { get; set; } = [];
        public T? Data { get; set; }
    }
}
