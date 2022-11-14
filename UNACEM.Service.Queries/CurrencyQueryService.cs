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
        Task<CurrencyResponse> Create(CurrencyRequest budgetCiCurrencyRequest);
        Task<CurrencyResponse> Update(CurrencyRequest budgetCiCurrencyRequest);
        Task<CurrencyResponse> Delete(CurrencyRequest budgetCiCurrencyRequest);
        Task<CurrencyResponse> GetAll(string type = "budget", int entityId = 0);
    }

    public class CurrencyQueryService : ICurrencyQueryService
    {
        private readonly ApplicationDbContext _context;

        public CurrencyQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CurrencyResponse> Create(CurrencyRequest request)
        {
            CurrencyResponse result = new CurrencyResponse();

            try
            {
                if (request.Type == "budget")
                {
                    await _context.AddAsync(new BudgetCurrency()
                    {
                        BudgetId = request.EntityId,
                        Name = request.Name,
                        Symbol = request.Symbol,
                        Equivalence = request.Equivalence,

                    });
                }
                else {
                    await _context.AddAsync(new BudgetCICurrency()
                    {
                        BudgetCIId = request.EntityId,
                        Name = request.Name,
                        Symbol = request.Symbol,
                        Equivalence = request.Equivalence,

                    });
                }
                

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

        public async Task<CurrencyResponse> Delete(CurrencyRequest budgetCiCurrencyRequest)
        {
            CurrencyResponse result = new CurrencyResponse();

            try
            {
                var budgetCiCurrency = _context.BudgetCICurrency.Where(b => b.Id == budgetCiCurrencyRequest.Id).FirstOrDefault();

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

        public async Task<CurrencyResponse> GetAll(string type = "budget", int entityId = 0)
        {
            CurrencyResponse result = new CurrencyResponse();

            try
            {
                var collection = new List<object>();
                if (type == "budget")
                {
                    collection = _context.BudgetCurrency.Where(x => x.BudgetId == entityId && x.DeletedAt == null).Cast<object>().ToList();
                }
                else {
                    collection = _context.BudgetCICurrency.Where(x => x.BudgetCIId == entityId && x.DeletedAt == null).Cast<object>().ToList();
                }

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

        public async Task<CurrencyResponse> Update(CurrencyRequest request)
        {
            CurrencyResponse result = new CurrencyResponse();

            try
            {
                var budgetCiCurrency = _context.BudgetCICurrency.Where(b => b.Id == request.Id).FirstOrDefault();

                if (budgetCiCurrency != null)
                {
                    budgetCiCurrency.BudgetCIId = request.EntityId;
                    budgetCiCurrency.Name = request.Name;
                    budgetCiCurrency.Symbol = request.Symbol;
                    budgetCiCurrency.Equivalence = request.Equivalence;

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
