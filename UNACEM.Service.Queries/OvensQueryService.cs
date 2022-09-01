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
                ovens.HeadquarterId = ovensRequest.Headquarter_Id;
                ovens.UserId = ovensRequest.UserId;
                ovens.Name = ovensRequest.Name;
                ovens.Large = ovensRequest.Large;
                ovens.Diameter = ovensRequest.Diameter;

                await _context.AddAsync(ovens);
                await _context.SaveChangesAsync();
                int TyresImportationId = ovens.OvenId;

                foreach (var item in ovensRequest.Tyres)
                {
                    Tyres tyres = new Tyres();

                    tyres.OvenId = TyresImportationId;
                    tyres.ColorId = item.Color_Id;
                    tyres.Texture_Id = item.Texture_Id;
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
                var collection = await _context.Ovens.AsNoTracking().OrderBy(x => x.OvenId).GetPagedAsync(Start, Limit);
                var ovensresult = collection.MapTo<DataCollection<OvensDto>>();

                #region Calculamos la cantidad de versiones

                foreach (var ovens in ovensresult.Items)
                {
                  
                    var ovenstemporal = _context.Versions.Where(x => x.OvenId == ovens.Id).OrderByDescending(c => c.Date_End).FirstOrDefault();
                    if (ovenstemporal != null)
                    {
                        var QuantityVersions = _context.Versions.Where(a => a.OvenId == ovens.Id).ToList().Count();
                        ovens.QuantityVersions = QuantityVersions;
                        ovens.Last_date_end = Convert.ToDateTime(ovenstemporal.Date_End).ToString("dd/MM/yyyy");

                        #region Calculamos la cantidad de presupuestos
                        int cantidad = 0;
              
                        foreach (var version in _context.Versions.Where(a => a.OvenId == ovens.Id).ToList())
                        {
                            var QuantityBudgets = _context.Budgets.Where(a => a.VersionId == version.VersionId).ToList().Count();
                            cantidad = QuantityBudgets+cantidad;
                            ovens.QuantityBudgets = cantidad;
                        }
                        #endregion

                    }


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
                var ovens = _context.Ovens.Where(a => a.OvenId == ovensRequest.Id).FirstOrDefault();
                if (ovens != null)
                {
                    ovens.HeadquarterId = ovensRequest.Headquarter_Id;
                    ovens.UserId = ovensRequest.UserId;
                    ovens.Name = ovensRequest.Name;
                    ovens.Large = ovensRequest.Large;
                    ovens.Diameter = ovensRequest.Diameter;
                    //ovens.UpdatedBy = ovensRequest.UpdatedBy;

                    await _context.SaveChangesAsync();

                    if ( ovensRequest.Tyres.Count > 0)
                    {
                        Tyres tyres = new Tyres();
                        foreach (var item in ovensRequest.Tyres)
                        {
                           
                            tyres = _context.Tyres.Where(t => t.TyreId == item.Id).FirstOrDefault();

                            if(tyres == null)
                            {
                                tyres = new Tyres();
                                
                                tyres.OvenId = ovensRequest.Id;
                                tyres.ColorId = item.Color_Id;
                                tyres.Texture_Id = item.Texture_Id;
                                tyres.Position = item.Position;
                                //tyres.CreatedBy = ovensRequest.CreatedBy;

                                await _context.AddAsync(tyres);
                                await _context.SaveChangesAsync();
                                
                            }
                            else
                            {
                                tyres.ColorId = item.Color_Id;
                                tyres.OvenId = ovensRequest.Id;
                                tyres.Texture_Id = item.Texture_Id;
                                tyres.Position = item.Position;
                                //tyres.CreatedBy = ovensRequest.CreatedBy;
                            
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
