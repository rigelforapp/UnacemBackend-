using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNACEM.Domain;
using UNACEM.Persistence.Database;
using UNACEM.Service.Queries.ViewModel.Request;
using UNACEM.Service.Queries.ViewModel.Response;

namespace UNACEM.Service.Queries
{
    public interface IBudgetCiQueryService
    {
        Task<BudgetCiResponse> Create(BudgetCiRequest budgetCiRequest);
        Task<BudgetCiResponse> Update(BudgetCiRequest budgetCiRequest);
        Task<BudgetCiResponse> Delete(BudgetCiRequest budgetCiRequest);
    }

    public class BudgetCiQueryService : IBudgetCiQueryService
    {
        private readonly ApplicationDbContext _context;

        public BudgetCiQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BudgetCiResponse> Create(BudgetCiRequest budgetCiRequest)
        {
            BudgetCiResponse result = new BudgetCiResponse();

            try
            {
                BudgetsCi budgetCi = new BudgetsCi();
                if (!string.IsNullOrEmpty(budgetCiRequest.Line))
                {
                    budgetCi.Line = budgetCiRequest.Line;
                }
                if (!string.IsNullOrEmpty(budgetCiRequest.Description))
                {
                    budgetCi.Description = budgetCiRequest.Description;
                }
                if (!string.IsNullOrEmpty(budgetCiRequest.Date))
                {
                    budgetCi.Date = Convert.ToDateTime(budgetCiRequest.Date);
                }
                if (budgetCiRequest.Total != null)
                {
                    budgetCi.Total = Convert.ToDouble(budgetCiRequest.Total);
                }

                await _context.AddAsync(budgetCi);

                await _context.SaveChangesAsync();
                result.Success = true;
                result.Message = "Se realizo satisfactoriamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al ejecutar";
                result.Details = ex.Message + " || " + ex.StackTrace;
            }

            return result;
        }

        public async Task<BudgetCiResponse> Delete(BudgetCiRequest budgetCiRequest)
        {
            BudgetCiResponse result = new BudgetCiResponse();

            try
            {
                var budgetCi = _context.BudgetsCi.Where(b => b.Id == budgetCiRequest.Id).FirstOrDefault();

                if (budgetCi != null)
                {
                    budgetCi.DeletedAt = DateTime.Now;

                    await _context.SaveChangesAsync();

                    result.Success = true;
                    result.Message = "Se realizo satisfactoriamente";

                }
                else
                {
                    result.Success = false;
                    result.Message = "No se encontro datos";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al ejecutar";
                result.Details = ex.Message + " || " + ex.StackTrace;
            }

            return result;
        }

        public async Task<BudgetCiResponse> Update(BudgetCiRequest budgetCiRequest)
        {
            BudgetCiResponse result = new BudgetCiResponse();

            try
            {
                var budgetCi = _context.BudgetsCi.Where(b => b.Id == budgetCiRequest.Id).FirstOrDefault();

                if (budgetCi != null)
                {

                    if (!string.IsNullOrEmpty(budgetCiRequest.Line))
                    {
                        budgetCi.Line = budgetCiRequest.Line;
                    }
                    if (!string.IsNullOrEmpty(budgetCiRequest.Description))
                    {
                        budgetCi.Description = budgetCiRequest.Description;
                    }
                    if (!string.IsNullOrEmpty(budgetCiRequest.Date))
                    {
                        budgetCi.Date = Convert.ToDateTime(budgetCiRequest.Date);
                    }
                    if (budgetCiRequest.Total!=null)
                    {
                        budgetCi.Total = Convert.ToDouble(budgetCiRequest.Total);
                    }

                  
                    
                    await _context.SaveChangesAsync();
                    result.Success = true;
                    result.Message = "Se realizo satistactoriamente";
                }
                else
                {
                    result.Success = false;
                    result.Message = "No se encontro datos";
                }

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al ejecutar";
                result.Details = ex.Message + " || " + ex.StackTrace;
            }

            return result;
        }
    }
}
