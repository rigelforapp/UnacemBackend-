using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UNACEM.Common.Collection;
using UNACEM.Domain;
using UNACEM.Persistence.Database;
using UNACEM.Service.Queries.DTO;
using UNACEM.Service.Queries.ViewModel.Request;
using UNACEM.Service.Queries.ViewModel.Response;

namespace UNACEM.Service.Queries
{
    public interface ICurrencyQueryService
    {
        Task<CurrencyResponse> Create(BudgetCiCurrencyRequest budgetCiCurrencyRequest);
        Task<CurrencyResponse> Update(BudgetCiCurrencyRequest budgetCiCurrencyRequest);
        Task<CurrencyResponse> Delete(BudgetCiCurrencyRequest budgetCiCurrencyRequest);
        Task<CurrencyResponse> GetAll(BudgetCiCurrencyRequest budgetCiCurrencyRequest);
    }

    public class CurrencyQueryService : ICurrencyQueryService
    {
        private readonly ApplicationDbContext _context;

        public CurrencyQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CurrencyResponse> Create(BudgetCiCurrencyRequest budgetCiCurrencyRequest)
        {
            CurrencyResponse result = new CurrencyResponse();

            try
            {
                await _context.AddAsync(new BudgetCiCurrency()
                {
                    BudgetCiId = budgetCiCurrencyRequest.BudgetCiId,
                    Name = budgetCiCurrencyRequest.Name,
                    Symbol = budgetCiCurrencyRequest.Symbol,
                    Equivalence = budgetCiCurrencyRequest.Equivalence,

                });

                await _context.SaveChangesAsync();
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

        public async Task<CurrencyResponse> Delete(BudgetCiCurrencyRequest budgetCiCurrencyRequest)
        {
            CurrencyResponse result = new CurrencyResponse();

            try
            {
                var budgetCiCurrency = _context.BudgetCiCurrency.Where(b => b.Id == budgetCiCurrencyRequest.Id).FirstOrDefault();

                if (budgetCiCurrency != null)
                {
                    budgetCiCurrency.DeletedAt = DateTime.Now;
                    
                    await _context.SaveChangesAsync();
                    result.Success = true;
                    result.Message = "Se realizó satisfactoriamente";
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

        public async Task<CurrencyResponse> GetAll(BudgetCiCurrencyRequest budgetCiCurrencyRequest)
        {
            CurrencyResponse result = new CurrencyResponse();

            try
            {
                var collection = _context.BudgetCiCurrency.Where(x => x.BudgetCiId == budgetCiCurrencyRequest.BudgetCiId && x.DeletedAt == null).Cast<object>().ToList();
                result.Data = collection;
                
                //var budgetCiCurrency = collection.MapTo<DataCollection<BudgetCiCurrencyDto>>();

                result.Success = true;
                result.Message = "Se realizó satisfactoriamente";
                //result.Data = (List<BudgetCiCurrencyDto>)budgetCiCurrency.Items;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al consultar";
                result.Details = ex.Message + " || " + ex.StackTrace;
            }

            return result;
        }

        public async Task<CurrencyResponse> Update(BudgetCiCurrencyRequest budgetCiCurrencyRequest)
        {
            CurrencyResponse result = new CurrencyResponse();

            try
            {
                var budgetCiCurrency = _context.BudgetCiCurrency.Where(b => b.Id == budgetCiCurrencyRequest.Id).FirstOrDefault();

                if (budgetCiCurrency != null)
                {
                    budgetCiCurrency.BudgetCiId = budgetCiCurrencyRequest.BudgetCiId;
                    budgetCiCurrency.Name = budgetCiCurrencyRequest.Name;
                    budgetCiCurrency.Symbol = budgetCiCurrencyRequest.Symbol;
                    budgetCiCurrency.Equivalence = budgetCiCurrencyRequest.Equivalence;

                    await _context.SaveChangesAsync();
                    result.Success = true;
                    result.Message = "Se realizó satisfactoriamente";
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
