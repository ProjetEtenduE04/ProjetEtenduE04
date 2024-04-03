using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Services.IServices
{
    public interface IApiKeyAuthenticationService
    { 
        Task<bool> AuthenticateAsync(HttpContext context);
    }
}
