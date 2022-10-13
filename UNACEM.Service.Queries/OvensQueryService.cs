using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
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
    public interface IOvensQueryService
    {
        #region Interfaces
        Task<OvensResponse> Create(OvensRequest ovensRequest);
        Task<OvensResponse> Update(OvensRequest ovensRequest);
        Task<OvensResponse> GetAll(int Start, int Limit);
        #endregion

    }

    public class OvensQueryService : IOvensQueryService
    {
        private readonly ApplicationDbContext _context;

        public OvensQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<OvensResponse> Create(OvensRequest ovensRequest)
        {
            OvensResponse result = new OvensResponse();

            try
            {
                Ovens ovens = new Ovens();
                // await SomeAsyncMethod();
                ovens.Headquarter = ovensRequest.Headquarter;
                ovens.UserId = 2;
                ovens.Name = ovensRequest.Name;
                ovens.Large = ovensRequest.Large;
                ovens.Diameter = ovensRequest.Diameter;

                await _context.AddAsync(ovens);
                await _context.SaveChangesAsync();
                int TyresImportationId = ovens.Id;

                foreach (var item in ovensRequest.Tyres)
                {
                    Tyres tyres = new Tyres();

                    tyres.OvenId = TyresImportationId;
                    tyres.ColorId = item.ColorId;
                    tyres.TextureId = item.TextureId;
                    tyres.Position = item.Position;

                    await _context.AddAsync(tyres);
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

        private async Task SomeAsyncMethod()
        {
            await Task.Delay(1000);
        }

        public async Task<OvensResponse> GetAll(int Start, int Limit)
        {
            OvensResponse result = new OvensResponse();
            
            try
            {
                var collection = await _context.Ovens.AsNoTracking().OrderBy(x => x.Id).GetPagedAsync(Start, Limit);

                //var collection = (from Ovens in _context.Set<Ovens>() select Ovens).ToList<Object>();

                var ovensresult = collection.MapTo<DataCollection<OvensDto>>();

                #region Calculamos la cantidad de versiones

                foreach (var oven in ovensresult.Items)
                {
                  
                    var ovenstemporal = _context.Versions.Where(x => x.OvenId == oven.Id).OrderByDescending(c => c.DateEnd).FirstOrDefault();
                    if (ovenstemporal != null)
                    {
                        var QuantityVersions = _context.Versions.Where(a => a.OvenId == oven.Id).ToList().Count();
                        oven.QuantityVersions = QuantityVersions;
                        oven.LastDateEnd = Convert.ToDateTime(ovenstemporal.DateEnd).ToString("dd/MM/yyyy");

                        #region Calculamos la cantidad de presupuestos
                        int cantidad = 0;
              
                        foreach (var version in _context.Versions.Where(a => a.OvenId == oven.Id).ToList())
                        {
                            var QuantityBudgets = _context.Budgets.Where(a => a.VersionId == version.Id).ToList().Count();
                            cantidad += QuantityBudgets;
                            oven.QuantityBudgets = cantidad;
                        }
                        #endregion
                    }
                    else
                    {
                        oven.QuantityVersions = 0;
                        oven.QuantityBudgets = 0;
                        oven.LastDateEnd = null;
                        oven.tyres = new List<Tyres>();
                    }

                    #region Tyres
                    oven.tyres = _context.Tyres.Where(t => t.OvenId == oven.Id).Where(t => t.DeletedAt == null).ToList();

                    #endregion
                }


                #endregion

                result.Success = true;
                result.Message = "Se realizó correctamente";
                result.Data = (List<OvensDto>)ovensresult.Items;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al Consultar";
                result.Details = ex.Message + " || " + ex.StackTrace;
            }

            return result;
        }

        public async Task<OvensResponse> Update(OvensRequest ovensRequest)
        {
            OvensResponse result = new OvensResponse();
            
            try
            {
                var oven = _context.Ovens.Where(a => a.Id == ovensRequest.Id).FirstOrDefault();
                if (oven != null)
                {
                    oven.Headquarter = ovensRequest.Headquarter;
                    oven.Name = ovensRequest.Name;
                    oven.Large = ovensRequest.Large;
                    oven.Diameter = ovensRequest.Diameter;

                    await _context.SaveChangesAsync();

                    var tyresToDelete = _context.Tyres.Where(t => t.OvenId == oven.Id).ToList();
                    foreach (var t in tyresToDelete)
                    {
                        t.DeletedAt = DateTime.Now;
                        _context.Tyres.Update(t);
                    }

                    if ( ovensRequest.Tyres.Count > 0)
                    {
                        Tyres tyre = new Tyres();
                        foreach (var item in ovensRequest.Tyres)
                        {

                            tyre = _context.Tyres.Where(t => t.Id == item.Id).FirstOrDefault();

                            if(tyre == null)
                            {
                                tyre = new Tyres();

                                tyre.OvenId = ovensRequest.Id;
                                tyre.ColorId = item.ColorId;
                                tyre.TextureId = item.TextureId;
                                tyre.Position = item.Position;                                

                                await _context.AddAsync(tyre);
                                await _context.SaveChangesAsync();
                                
                            }
                            else
                            {
                                tyre.ColorId = item.ColorId;
                                tyre.OvenId = ovensRequest.Id;
                                tyre.TextureId = item.TextureId;
                                tyre.Position = item.Position;
                                tyre.DeletedAt = null;

                                await _context.SaveChangesAsync();
                            }
                        }

                        result.Success = true;
                        result.Message = "Se realizó correctamente";                        
                    }
                    else
                    {               
                        var list = _context.Tyres.Where(a => a.OvenId == ovensRequest.Id).ToList();
                        _context.Tyres.RemoveRange(list);
                        _context.SaveChanges();
                        result.Message = "Se elimino el regitro de Tyres";
                    }                    
                }
                else
                {
                    result.Success = false;
                    result.Message = "No se encontro datos";
                }
            }catch(Exception ex)
            {
                result.Success = false;
                result.Message = "Error al ejecutar";
                result.Details = ex.Message + " || " + ex.StackTrace;
            }

            return result;
        }
    }
}
