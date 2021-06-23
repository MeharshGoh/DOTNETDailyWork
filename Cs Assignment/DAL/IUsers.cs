using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cs_Assignment.Models;

namespace Cs_Assignment.DAL
{
    interface IUsers<TModel,in Tkey> where TModel : class
    {
        public Task<TModel> CreateAsyncUser(TModel model);
    }

}
