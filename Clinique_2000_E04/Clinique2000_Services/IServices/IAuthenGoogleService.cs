using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Services.IServices
{
    public interface IAuthenGoogleService
    {
        Task LoginAsync();
        Task<IActionResult> HandleGoogleResponseAsync();
        Task LogoutAsync();

    }
}
