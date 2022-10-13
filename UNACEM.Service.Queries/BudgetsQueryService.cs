using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNACEM.Common.Collection;
using UNACEM.Common.Mapping;
using UNACEM.Common.Paging;
using UNACEM.Domain;
using UNACEM.Persistence.Database;
using UNACEM.Service.Queries.DTO;
using UNACEM.Service.Queries.ViewModel.Request;
using UNACEM.Service.Queries.ViewModel.Response;

namespace UNACEM.Service.Queries
{
    public interface IBudgetsQueryService
    {
        Task<BudgetsResponse> GetAll(int VersionId, int Start, int Limit);
        Task<BudgetsResponse> Create(BudgetsRequest budgetsRequest);
    }

    public class BudgetsQueryService : IBudgetsQueryService
    {
        private readonly ApplicationDbContext _context;
        public BudgetsQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BudgetsResponse> Create(BudgetsRequest budgetsRequest)
        {
            BudgetsResponse result = new BudgetsResponse();

            try
            {
                Budgets budgets = new Budgets();

                budgets.VersionId = budgetsRequest.VersionId;
                budgets.TotalAmount = budgetsRequest.TotalAmount;

                await _context.AddAsync(budgets);
                await _context.SaveChangesAsync();

                int budgetId = budgets.Id;

                foreach (var item in budgetsRequest.budgetStretchs)
                {
                    BudgetStretch budgetStretch = new BudgetStretch();

                    budgetStretch.BudgetId = budgetId;
                    budgetStretch.StretchId = item.StretchId;
                        
                    budgetStretch.BrickACost = item.BrickACost;
                    budgetStretch.BrickBCost = item.BrickBCost;
                    budgetStretch.WedgeAQuantity = item.WedgeAQuantity;
                    budgetStretch.WedgeBQuantity = item.WedgeBQuantity;
                    budgetStretch.WedgeACost = item.WedgeACost;
                    budgetStretch.WedgeBCost = item.WedgeBCost;
                    budgetStretch.TotalAmount = item.TotalAmount;

                    await _context.AddAsync(budgetStretch);
                    await _context.SaveChangesAsync();
                }

                result.Success = true;
                result.Message = "Se realizó satisfactoriamente";

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al ejecutar";
                result.Details = ex.Message + " || " + ex.StackTrace;
            }

            return result;
        }

        public async Task<BudgetsResponse> GetAll(int VersionId, int Start, int Limit)
        {
            BudgetsResponse result = new BudgetsResponse();

            try
            {
                var collection = await _context.Budgets.AsNoTracking().Where(b => b.VersionId == VersionId).OrderBy(x => x.VersionId).GetPagedAsync(Start, Limit);
                var budgetsresult = collection.MapTo<DataCollection<BudgetsDto>>();

                result.Success = true;
                result.Message = "Se realizó satisfactoriamente";
                result.Data = (List<BudgetsDto>)budgetsresult.Items;

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
