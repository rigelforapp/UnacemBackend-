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
    public interface IBudgetCiQueryService
    {
        Task<BudgetCiResponse> Create(BudgetCiRequest budgetCiRequest);
        Task<BudgetCiResponse> Update(BudgetCiRequest budgetCiRequest);
        Task<BudgetCiResponse> Delete(BudgetCiRequest budgetCiRequest);
        Task<object> GetAll(int Start, int Limit);
        Task<object> GetAllBudgetId(int budgetCiId);
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

        public async Task<object> GetAll(int Start, int Limit)
        {
            BudgetCiResponse result = new BudgetCiResponse();

            try
            {
                var collection = await _context.BudgetsCi.AsNoTracking().OrderBy(x => x.Id).GetPagedAsync(Start, Limit);
                var budgetCiResult = collection.MapTo<DataCollection<BudgetCiDto>>();

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

        public async Task<object> GetAllBudgetId(int budgetCiId)
        {
            BudgetCiResponse result = new BudgetCiResponse();
            List<BudgetsCi> lstbudgetsCis = new List<BudgetsCi>();
            List<BudgetCiDto> listaBudgetCiDTO = new List<BudgetCiDto>();
            List<BudgetCiRows> lstBudgetCiRows = new List<BudgetCiRows>();
            BudgetCiDto budgetCiDto = new BudgetCiDto();
            BudgetCiRowsDto BudgetCiRowsDto = new BudgetCiRowsDto();
            List<BudgetCiRowsDto> lstBudgetCiRowsDto = new List<BudgetCiRowsDto>();
            List<BudgetCiCurrencyDto> lstBudgetCiCurrencyDto = new List<BudgetCiCurrencyDto>();
            List<BudgetCiCurrency> lstBudgetCiCurrency = new List<BudgetCiCurrency>();
            BudgetCiCurrencyDto BudgetCiCurrencyDto = new BudgetCiCurrencyDto();
            try
            {
                lstbudgetsCis = _context.BudgetsCi.Where(x => x.Id == budgetCiId && x.DeletedAt == null).ToList();
              

                foreach (var item in lstbudgetsCis)
                {
                    budgetCiDto = new BudgetCiDto();
                    budgetCiDto.Id = item.Id;
                    budgetCiDto.Line = item.Line;
                    budgetCiDto.Date = Convert.ToDateTime(item.Date);
                    budgetCiDto.Total = Convert.ToDouble(item.Total);

                    lstBudgetCiCurrency = _context.BudgetCiCurrency.Where(x => x.BudgetCiId == item.Id && x.DeletedAt == null).ToList();

                    foreach (var BudgetCiCurrency in lstBudgetCiCurrency)
                    {
                        BudgetCiCurrencyDto = new BudgetCiCurrencyDto();
                        BudgetCiCurrencyDto.Id = BudgetCiCurrency.Id;
                        BudgetCiCurrencyDto.Name = BudgetCiCurrency.Name;
                        BudgetCiCurrencyDto.Symbol = BudgetCiCurrency.Symbol;
                        BudgetCiCurrencyDto.Equivalence = BudgetCiCurrency.Equivalence;
                        budgetCiDto.Currencies.Add(BudgetCiCurrencyDto);

                    }



                    listaBudgetCiDTO.Add(budgetCiDto);
                }


                foreach (var item in listaBudgetCiDTO)
                {
                    lstBudgetCiRows = _context.BudgetCiRows.Where(x => x.BudgetCiId == item.Id && x.DeletedAt == null).ToList();
                
                    foreach (var row in lstBudgetCiRows)
                    {
                        BudgetCiRowsDto = new BudgetCiRowsDto();

                        BudgetCiRowsDto.Id = row.Id;
                        BudgetCiRowsDto.BudgetCiId = row.BudgetCiId;
                        BudgetCiRowsDto.Zone = row.Zone;
                        BudgetCiRowsDto.Area = row.Area;
                        BudgetCiRowsDto.ThicknessC = row.ThicknessC;
                        BudgetCiRowsDto.ThicknessI = row.ThicknessI;
                        BudgetCiRowsDto.CostC = row.CostC;
                        BudgetCiRowsDto.CostI = row.CostI;
                        BudgetCiRowsDto.Total = row.Total;

                        var ProviderInsulatings = _context.ProviderInsulatings.Where(x => x.Id== row.ProviderInsulatingId).FirstOrDefault();
                        if (ProviderInsulatings!=null)
                        {
                            BudgetCiRowsDto.ProviderInsulatings = new ProviderInsulatingsDto();
                            BudgetCiRowsDto.ProviderInsulatings.Id = ProviderInsulatings.Id;
                            BudgetCiRowsDto.ProviderInsulatings.Name = ProviderInsulatings.Name;
                            BudgetCiRowsDto.ProviderInsulatings.RecommendedZone= ProviderInsulatings.RecommendedZone;
                            BudgetCiRowsDto.ProviderInsulatings.Composition = ProviderInsulatings.Composition;
                            BudgetCiRowsDto.ProviderInsulatings.MaterialNeeded = ProviderInsulatings.MaterialNeeded;
                            BudgetCiRowsDto.ProviderInsulatings.WaterMix = ProviderInsulatings.WaterMix;
                            BudgetCiRowsDto.ProviderInsulatings.Temperature= ProviderInsulatings.Temperature;
                            BudgetCiRowsDto.ProviderInsulatings.ThermalConductivity100 = ProviderInsulatings.ThermalConductivity100;
                            BudgetCiRowsDto.ProviderInsulatings.ThermalConductivity300 = ProviderInsulatings.ThermalConductivity300;
                            BudgetCiRowsDto.ProviderInsulatings.ThermalConductivity700 = ProviderInsulatings.ThermalConductivity700;
                        }
                        var ProviderConcretes = _context.ProviderConcretes.Where(x => x.Id == row.ProviderInsulatingId).FirstOrDefault();
                        if (ProviderConcretes != null)
                        {
                            BudgetCiRowsDto.ProviderConcretes = new ProviderConcretesDto();
                            BudgetCiRowsDto.ProviderConcretes.Id = ProviderConcretes.Id;
                            BudgetCiRowsDto.ProviderConcretes.Name = ProviderConcretes.Name;
                            BudgetCiRowsDto.ProviderConcretes.RecommendedZone = ProviderConcretes.RecommendedZone;
                            BudgetCiRowsDto.ProviderConcretes.Composition = ProviderConcretes.Composition;
                            BudgetCiRowsDto.ProviderConcretes.MaterialNeeded = ProviderConcretes.MaterialNeeded;
                            BudgetCiRowsDto.ProviderConcretes.WaterMix = ProviderConcretes.WaterMix;
                            BudgetCiRowsDto.ProviderConcretes.Temperature = ProviderConcretes.Temperature;
                            BudgetCiRowsDto.ProviderConcretes.ThermalConductivity100 = ProviderConcretes.ThermalConductivity100;
                            BudgetCiRowsDto.ProviderConcretes.ThermalConductivity300 = ProviderConcretes.ThermalConductivity300;
                            BudgetCiRowsDto.ProviderConcretes.ThermalConductivity700 = ProviderConcretes.ThermalConductivity700;
                        }

                        lstBudgetCiRowsDto.Add(BudgetCiRowsDto);


                    }

                    item.Rows = lstBudgetCiRowsDto;


                }


                result.Data = listaBudgetCiDTO;
                result.Success = true;
                result.Message = "Se realizó correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al consultar";
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
