using Kolokwium_02.DTOs.Responses;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium_02.Services
{
    public interface IDbService
    {
       public  LabelResponse GetLabel(int id);
        public string DeleteMusician(int id);
    }
}
