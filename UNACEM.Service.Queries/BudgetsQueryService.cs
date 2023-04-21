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
        Task<BudgetsResponse> GetAll(int Start, int Limit, Users user);
        Task<BudgetsResponse> Create(BudgetsRequest budgetsRequest, Users user);
        Task<BudgetsResponse> Update(BudgetsRequest budgetsRequest, Users user);
    }

    public class BudgetsQueryService : IBudgetsQueryService
    {
        private readonly ApplicationDbContext _context;
        public BudgetsQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BudgetsResponse> Update(BudgetsRequest br, Users user)
        {
            BudgetsResponse result = new BudgetsResponse();

            try
            {
                Budgets b = _context.Budgets.Where( b => b.Id == br.Id ).FirstOrDefault();

                if (br.deleted == true)
                {
                    b.DeletedAt = DateTime.Now;
                }

                b.TotalAmount = br.TotalAmount;
                b.OvenDiameter = br.OvenDiameter;
                b.Description = br.Description;

                _context.Budgets.Update(b);
                await _context.SaveChangesAsync();

                int budgetId = b.Id;

                var streches = _context.BudgetStretch.Where(bs => bs.BudgetId == budgetId).ToList();
                foreach (var strech in streches)
                {
                    strech.DeletedAt = DateTime.Now;
                    _context.BudgetStretch.Update(strech);
                }
                await _context.SaveChangesAsync();

                foreach (var bsR in br.budgetStretches)
                {
                    BudgetStretch bs = new BudgetStretch();

                    if (bsR.Id != 0)
                    {
                        bs = _context.BudgetStretch.Where(s => s.Id == bsR.Id).FirstOrDefault();
                        bs.DeletedAt = null;
                    }

                    bs.BudgetId = budgetId;
                    bs.BrickACost = bsR.BrickACost;
                    bs.BrickBCost = bsR.BrickBCost;
                    bs.BrickFormatId = bsR.BrickFormatId;
                    bs.BrickLNormal = bsR.BrickLNormal;
                    bs.positionIni = bsR.positionIni;
                    bs.positionEnd = bsR.positionEnd;
                    bs.ProviderBrickId = bsR.ProviderBrickId;
                    bs.TotalAmount = bsR.TotalAmount;
                    bs.WedgeAQuantity = bsR.WedgeAQuantity;
                    bs.WedgeBQuantity = bsR.WedgeBQuantity;
                    bs.WedgeACost = bsR.WedgeACost;
                    bs.WedgeBCost = bsR.WedgeBCost;

                    if (bsR.Id != 0)
                    {
                        _context.BudgetStretch.Update(bs);
                    }
                    else {
                        _context.BudgetStretch.Add(bs);
                    }
                    
                    await _context.SaveChangesAsync();
                }

                // Currencies

                var currencies = _context.BudgetCurrency.Where(x => x.BudgetId == br.Id && x.DeletedAt == null).ToList();

                foreach (var c in currencies)
                {
                    c.DeletedAt = DateTime.Now;
                    _context.BudgetCurrency.Update(c);
                }

                await _context.SaveChangesAsync();

                foreach (var cRequest in br.Currencies)
                {
                    var c = new BudgetCurrency();

                    if (cRequest.Id > 0)
                    {
                        c = this._context.BudgetCurrency.Where( c => c.Id == cRequest.Id).First();
                        c.DeletedAt = null;
                    }

                    c.BudgetId = b.Id;
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


        public async Task<BudgetsResponse> Create(BudgetsRequest br, Users user)
        {
            BudgetsResponse result = new BudgetsResponse();

            try
            {
                Budgets b = new Budgets();

                b.TotalAmount = br.TotalAmount;
                b.OvenDiameter = br.OvenDiameter;
                b.Description = br.Description;
                b.UserId = user.Id;

                await _context.AddAsync(b);
                await _context.SaveChangesAsync();

                int budgetId = b.Id;

                foreach (var item in br.budgetStretches)
                {
                    BudgetStretch bs = new BudgetStretch();
                    bs.BudgetId = budgetId;
                    bs.BrickACost = item.BrickACost;
                    bs.BrickBCost = item.BrickBCost;
                    bs.BrickFormatId = item.BrickFormatId;
                    bs.BrickLNormal = item.BrickLNormal;
                    bs.positionIni = item.positionIni;
                    bs.positionEnd = item.positionEnd;
                    bs.ProviderBrickId = item.ProviderBrickId;
                    bs.TotalAmount = item.TotalAmount;
                    bs.WedgeAQuantity = item.WedgeAQuantity;
                    bs.WedgeBQuantity = item.WedgeBQuantity;
                    bs.WedgeACost = item.WedgeACost;
                    bs.WedgeBCost = item.WedgeBCost;

                    await _context.AddAsync(bs);
                    await _context.SaveChangesAsync();
                }

                foreach (var cR in br.Currencies)
                {
                    var c = new BudgetCurrency();
                    c.BudgetId = budgetId;
                    c.Name = cR.Name;
                    c.Symbol = cR.Symbol;
                    c.Equivalence = cR.Equivalence;

                    _context.BudgetCurrency.Add(c);
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

        public async Task<BudgetsResponse> GetAll(int Start, int Limit, Users user)
        {
            BudgetsResponse result = new BudgetsResponse();

            try
            {
                var collection = await _context.Budgets.AsNoTracking().Where(b => b.UserId == user.Id).Where(b => b.DeletedAt == null).GetPagedAsync(Start, Limit);
                var budgetsresult = collection.MapTo<DataCollection<BudgetsDto>>();
                var list = (List<BudgetsDto>)budgetsresult.Items;

                foreach (var b in (List<BudgetsDto>)budgetsresult.Items)
                {
                    var strechesC = _context.BudgetStretch.Where(bs => bs.BudgetId == b.Id && bs.DeletedAt == null).ToList();
                    b.budgetStretches = strechesC.MapTo<List<BudgetsStrechesDTO>>();

                    foreach (var bs in b.budgetStretches)
                    {
                        var pb = _context.ProviderBricks.Where(pi => pi.Id == bs.ProviderBrickId).FirstOrDefault();
                        var pi = _context.ProviderImportations.Where(pi => pi.Id == pb.ProviderImportationId).FirstOrDefault();
                        bs.ProviderId = pi.ProviderId;
                        bs.Bricks = (from ProviderBricks in _context.Set<ProviderBricks>()
                                     join ProviderImportations in _context.Set<ProviderImportations>()
                                         on ProviderBricks.ProviderImportationId equals ProviderImportations.Id
                                     join Providers in _context.Set<Providers>()
                                         on ProviderImportations.ProviderId equals Providers.Id
                                     where (Providers.Id == bs.ProviderId)
                                     where (ProviderBricks.DeletedAt != null)
                                     select ProviderBricks).ToList<ProviderBricks>();
                    }
                }

                foreach (var budget in list)
                {
                    var currencies = await _context.BudgetCurrency.Where(x => x.BudgetId == budget.Id && x.DeletedAt == null).GetPagedAsync(Start, Limit);
                    var currenciesDto = currencies.MapTo<DataCollection<BudgetCurrencyDto>>();
                    budget.Currencies = (List<BudgetCurrencyDto>)currenciesDto.Items;
                }

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
