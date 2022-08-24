﻿using Microsoft.EntityFrameworkCore;
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
    public interface IStretchsQueryService
    {
        Task<StretchsResponse> Create(StretchsRequest stretchsRequest);
        Task<StretchsResponse> Update(StretchsRequest stretchsRequest);
        Task<StretchsResponse> GetAll(int VersionId, int Start, int Limit);
    }
    public class StretchsQueryService : IStretchsQueryService
    {
        private ApplicationDbContext _context;
        public StretchsQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<StretchsResponse> Create(StretchsRequest stretchsRequest)
        {
            StretchsResponse result = new StretchsResponse();

            try
            {
                await _context.AddAsync(new Stretchs()
                {

                    VersionId = stretchsRequest.VersionId,
                    Position_Ini = stretchsRequest.Position_Ini,
                    Position_End = stretchsRequest.Position_End,
                    Color_Id = stretchsRequest.Color_Id,
                    Texture_Id = stretchsRequest.Texture_Id,
                    ProviderBrickId = stretchsRequest.ProviderBrickId,
                    BrickFormatId = stretchsRequest.BrickFormatId,
                    CreatedBy = stretchsRequest.CreatedBy
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

        public async Task<StretchsResponse> GetAll(int VersionId, int Start, int Limit)
        {
            StretchsResponse result = new StretchsResponse();

            try
            {
                var collection = await _context.Stretchs.AsNoTracking().Where(a => a.VersionId == VersionId).OrderBy(x => x.VersionId).GetPagedAsync(Start, Limit);
                var versionresult = collection.MapTo<DataCollection<StretchsDto>>();

                result.Success = true;
                result.Message = "Se realizo correctamente";
                result.ListaStrech = (List<StretchsDto>)versionresult.Items;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al ejecutar";
                result.Details = ex.Message + " || " + ex.StackTrace;
            }

            return result;
        }

        public async Task<StretchsResponse> Update(StretchsRequest stretchsRequest)
        {
            StretchsResponse result = new StretchsResponse();

            try
            {
                var versions = _context.Stretchs.Where(s => s.StretchId == stretchsRequest.StretchId).FirstOrDefault();

                if (versions != null)
                {
                    versions.VersionId = stretchsRequest.VersionId;
                    versions.Position_Ini = stretchsRequest.Position_Ini;
                    versions.Position_End = stretchsRequest.Position_End;
                    versions.Color_Id = stretchsRequest.Color_Id;
                    versions.Texture_Id = stretchsRequest.Texture_Id;
                    versions.ProviderBrickId = stretchsRequest.ProviderBrickId;
                    versions.BrickFormatId = stretchsRequest.BrickFormatId;
                    versions.CreatedBy = stretchsRequest.CreatedBy;

                    await _context.SaveChangesAsync();
                    result.Success = true;
                    result.Message = "Se realizo satisfactoriamente";
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
