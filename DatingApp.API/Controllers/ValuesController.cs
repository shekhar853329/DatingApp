using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public ValuesController(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        public DataContext DataContext { get; }

        public async Task<IActionResult> Get()
        {
            var result = await DataContext.Values.ToListAsync();
            return Ok(result);
        }
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await DataContext.Values.FirstOrDefaultAsync(v => v.Id == id);
            return Ok(result);
        }
    }
}
