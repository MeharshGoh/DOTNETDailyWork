using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cs_Assignment.Models;

namespace Cs_Assignment.DAL
{
    interface IRole<TModel,in TKey> where TModel : class
    {
        public Task<TModel> CreateRoleAsync(TModel model);

    }
}
