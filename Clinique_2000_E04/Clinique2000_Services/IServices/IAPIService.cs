using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinique2000_Core.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Clinique2000_Services.IServices
{
    public interface IAPIService
    {
         Task<bool> UserPossedeUneCleAPI(string? userName); 
    }
}
