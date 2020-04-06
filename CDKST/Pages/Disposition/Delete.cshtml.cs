using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyData.Data.Models.Disposition;
using Microsoft.Extensions.Logging;
using MyRepo;


namespace CDKST.Pages.Disposition
{
    public class DeleteModel : PageModel
    {
       
       private readonly ILogger<IndexModel> _logger;
        private readonly IUnitOfWork _UOW;

        public DeleteModel(ILogger<IndexModel> logger, IUnitOfWork uow)
        {
            _logger = logger;
            _UOW = uow;            
        }
             

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

               await _UOW.GetRepositoryAsync<DispositionInstance>().DeleteAsync(id);

           

            return RedirectToPage("./Index");
        }
    }
}
