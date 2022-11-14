using Microsoft.EntityFrameworkCore;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Database;
using System;
using System.Collections;
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
    public interface IBudgetCiQueryService
    {
        Task<BudgetCiResponse> Create(BudgetCiRequest budgetCiRequest, Users user);
        Task<BudgetCiResponse> Update(BudgetCiRequest budgetCiRequest, Users user);
        Task<BudgetCiResponse> Delete(BudgetCiRequest budgetCiRequest, Users user);
        Task<object> GetAll(int Start, int Limit, Users user);
    }

    public class BudgetCiQueryService : IBudgetCiQueryService
    {
        private readonly ApplicationDbContext _context;

        public BudgetCiQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BudgetCiResponse> Create(BudgetCiRequest budgetCiRequest, Users user)
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

                budgetCi.UserId = user.Id;

                await _context.AddAsync(budgetCi);

                await _context.SaveChangesAsync();

                foreach (var rowRequest in budgetCiRequest.Rows)
                {
                    var row = new BudgetCiRows();
                    row.Area = rowRequest.Area;
                    row.ProviderConcreteId = rowRequest.ProviderConcreteId;
                    row.ProviderInsulatingId = rowRequest.ProviderInsulatingId;
                    row.BudgetCiId = budgetCi.Id;
                    row.CostC = rowRequest.CostC;
                    row.CostI = rowRequest.CostI;
                    row.materialRequirementC = rowRequest.materialRequirementC;
                    row.materialRequirementI = rowRequest.materialRequirementI;
                    row.ThicknessC = rowRequest.ThicknessC;
                    row.ThicknessI = rowRequest.ThicknessI;
                    row.Total = rowRequest.Total;

                    await _context.AddAsync(row);
                }

                foreach (var cRequest in budgetCiRequest.Currencies)
                {
                    var c = new BudgetCICurrency();
                    c.BudgetCIId = budgetCi.Id;
                    c.Name = cRequest.Name;
                    c.Symbol = cRequest.Symbol;
                    c.Equivalence = cRequest.Equivalence;

                    await _context.AddAsync(c);
                }

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

        public async Task<BudgetCiResponse> Delete(BudgetCiRequest budgetCiRequest, Users user)
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

        public async Task<object> GetAll(int Start, int Limit, Users user)
        {
            BudgetCiResponse result = new BudgetCiResponse();

            try
            {
                var collection = await _context.BudgetsCi.AsNoTracking().Where(b => b.UserId == user.Id).Where(b => b.DeletedAt == null).OrderBy(x => x.Id).GetPagedAsync(Start, Limit);
                var budgetCiResult = collection.MapTo<DataCollection<BudgetCiDto>>();
                var list = (List<BudgetCiDto>)budgetCiResult.Items;

                foreach (var budget in list)
                {
                    var rows = await _context.BudgetCiRows.Where(x => x.BudgetCiId == budget.Id && x.DeletedAt == null).GetPagedAsync(Start, Limit);
                    var rowsDto = rows.MapTo<DataCollection<BudgetCiRowsDto>>();
                    budget.Rows = (List<BudgetCiRowsDto>)rowsDto.Items;

                    foreach (var row in budget.Rows)
                    {
                        var concrete = _context.ProviderConcretes.Where(pc => pc.Id == row.ProviderConcreteId).FirstOrDefault();
                        var ConcreteDto = concrete.MapTo<ProviderConcretesDto>();
                        row.Concrete = ConcreteDto;

                        var insulating = _context.ProviderInsulatings.Where(pc => pc.Id == row.ProviderInsulatingId).FirstOrDefault();
                        var InsulatingDto = concrete.MapTo<ProviderInsulatingsDto>();
                        row.Insulating = InsulatingDto;
                    }
                }

                foreach (var budget in list)
                {
                    var currencies = await _context.BudgetCICurrency.Where(x => x.BudgetCIId == budget.Id && x.DeletedAt == null).GetPagedAsync(Start, Limit);
                    var currenciesDto = currencies.MapTo<DataCollection<BudgetCiCurrencyDto>>();
                    budget.Currencies = (List<BudgetCiCurrencyDto>)currenciesDto.Items;
                }



                result.Success = true;
                result.Message = "Se realizo correctamente";
                result.Data = (List<BudgetCiDto>)budgetCiResult.Items;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al consultar";
                result.Details = ex.Message + " || " + ex.StackTrace;
            }

            return result;
        }

        public async Task<BudgetCiResponse> Update(BudgetCiRequest budgetCiRequest, Users user)
        {
            BudgetCiResponse result = new BudgetCiResponse();

            try
            {
                var budgetCi = _context.BudgetsCi.Where(b => b.Id == budgetCiRequest.Id).FirstOrDefault();

                if (budgetCi != null)
                {
                    if (budgetCiRequest.deleted == true)
                    {
                        budgetCi.DeletedAt = DateTime.Now;
                    }

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

                    var rows = _context.BudgetCiRows.Where(x => x.BudgetCiId == budgetCiRequest.Id && x.DeletedAt == null).ToList();

                    foreach (var row in rows)
                    {
                        row.DeletedAt = DateTime.Now;
                        _context.BudgetCiRows.Update(row);
                    }

                    await _context.SaveChangesAsync();

                    foreach (var rowRequest in budgetCiRequest.Rows)
                    {
                        var row = new BudgetCiRows();

                        if (rowRequest.Id > 0)
                        {
                            row = _context.BudgetCiRows.Where(br => br.Id == rowRequest.Id).FirstOrDefault();
                            row.DeletedAt = null;
                        }

                        row.Area = rowRequest.Area;
                        row.ProviderConcreteId = rowRequest.ProviderConcreteId;
                        row.ProviderInsulatingId = rowRequest.ProviderInsulatingId;
                        row.BudgetCiId = budgetCi.Id;
                        row.CostC = rowRequest.CostC;
                        row.CostI = rowRequest.CostI;
                        row.materialRequirementC = rowRequest.materialRequirementC;
                        row.materialRequirementI = rowRequest.materialRequirementI;
                        row.ThicknessC = rowRequest.ThicknessC;
                        row.ThicknessI = rowRequest.ThicknessI;
                        row.Total = rowRequest.Total;

                        if (rowRequest.Id > 0)
                        {
                            _context.BudgetCiRows.Update(row);
                        } else {
                            _context.BudgetCiRows.Add(row);
                        }
                    }

                    // Currencies

                    var currencies = _context.BudgetCICurrency.Where(x => x.BudgetCIId == budgetCiRequest.Id && x.DeletedAt == null).ToList();

                    foreach (var c in currencies)
                    {
                        c.DeletedAt = DateTime.Now;
                        _context.BudgetCICurrency.Update(c);
                    }

                    await _context.SaveChangesAsync();

                    foreach (var cRequest in budgetCiRequest.Currencies)
                    {
                        var c = new BudgetCICurrency();

                        if (cRequest.Id > 0)
                        {
                            c.Id = cRequest.Id;
                        }

                        c.BudgetCIId = budgetCi.Id;
                        c.Name = cRequest.Name;
                        c.Symbol = cRequest.Symbol;
                        c.Equivalence = cRequest.Equivalence;

                        if (cRequest.Id > 0)
                        {
                            _context.Update(c);
                        }
                        else
                        {
                            await _context.AddAsync(c);
                        }
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
