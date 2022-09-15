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
    public interface IRowsQueryService
    {
        Task<RowsResponse> Create(BudgetCiRowsRequest budgetCiRowsRequest);
        Task<RowsResponse> Update(BudgetCiRowsRequest budgetCiRowsRequest);
        Task<RowsResponse> Delete(BudgetCiRowsRequest budgetCiRowsRequest);
    }
    public class RowsQueryService : IRowsQueryService
    {
        private readonly ApplicationDbContext _context;

        public RowsQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RowsResponse> Create(BudgetCiRowsRequest budgetCiRowsRequest)
        {
            RowsResponse result = new RowsResponse();

            try
            {
                await _context.AddAsync(new BudgetCiRows()
                {
                    BudgetCiId = budgetCiRowsRequest.BudgetCiId,
                    Zone = budgetCiRowsRequest.Zone,
                    Area = budgetCiRowsRequest.Area,
                    ThicknessC = budgetCiRowsRequest.ThicknessC,
                    ThicknessI = budgetCiRowsRequest.ThicknessI,
                    ProviderInsulatingId = budgetCiRowsRequest.ProviderInsulatingId,
                    ProviderConcretesId = budgetCiRowsRequest.ProviderConcretesId,
                    CostC = budgetCiRowsRequest.CostC,
                    CostI = budgetCiRowsRequest.CostI,
                    Total = budgetCiRowsRequest.Total,

                });

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

        public async Task<RowsResponse> Delete(BudgetCiRowsRequest budgetCiRowsRequest)
        {
            RowsResponse result = new RowsResponse();

            try
            {
                var budgetCiRows = _context.BudgetCiRows.Where(b => b.Id == budgetCiRowsRequest.Id).FirstOrDefault();

                if (budgetCiRows != null)
                {
                    budgetCiRows.DeletedAt = DateTime.Now;

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

        public async Task<RowsResponse> Update(BudgetCiRowsRequest budgetCiRowsRequest)
        {
            RowsResponse result = new RowsResponse();

            try
            {
                var budgetCiRows = _context.BudgetCiRows.Where(b => b.Id == budgetCiRowsRequest.Id).FirstOrDefault();

                if (budgetCiRows != null)
                {
                    budgetCiRows.BudgetCiId = budgetCiRowsRequest.BudgetCiId;
                    budgetCiRows.Zone = budgetCiRowsRequest.Zone;
                    budgetCiRows.Area = budgetCiRowsRequest.Area;
                    budgetCiRows.ThicknessC = budgetCiRowsRequest.ThicknessC;
                    budgetCiRows.ThicknessI = budgetCiRowsRequest.ThicknessI;
                    budgetCiRows.ProviderInsulatingId = budgetCiRowsRequest.ProviderInsulatingId;
                    budgetCiRows.ProviderConcretesId = budgetCiRowsRequest.ProviderConcretesId;
                    budgetCiRows.CostC = budgetCiRowsRequest.CostC;
                    budgetCiRows.CostI = budgetCiRowsRequest.CostI;
                    budgetCiRows.Total = budgetCiRowsRequest.Total;

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
