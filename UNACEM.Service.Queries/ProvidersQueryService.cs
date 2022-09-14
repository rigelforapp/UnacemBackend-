﻿using System;
using System.Text;
using UNACEM.Common.Collection;
using UNACEM.Common.Mapping;
using UNACEM.Common.Paging;
using System.Threading.Tasks;
using UNACEM.Domain;
using UNACEM.Persistence.Database;
using UNACEM.Service.Queries.ViewModel.Request;
using UNACEM.Service.Queries.ViewModel.Response;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UNACEM.Service.Queries.DTO;
using System.Collections.Generic;
using System.IO;
using System.Data;
using ExcelDataReader;
using Microsoft.Data.SqlClient;
using System.Transactions;
using System.Xml.Linq;

namespace UNACEM.Service.Queries
{
    public interface IProvidersQueryService
    {
        Task<ProvidersResponse> Create(ProvidersRequest providersRequest);
        Task<ProvidersResponse> Update(ProvidersRequest providersRequest);
        Task<ProvidersResponse> GetAll(int Start, int Limit);
        Task<ProvidersResponse> Upload(Stream stream, ProvidersRequest providersRequest);
     }

    public class ProvidersQueryService : IProvidersQueryService
    {
        private readonly ApplicationDbContext _context;
        public ProvidersQueryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ProvidersResponse> Create(ProvidersRequest providersRequest)
        {
            ProvidersResponse result = new ProvidersResponse();
            try
            {
                await _context.AddAsync(new Providers()
                {
                    Name = providersRequest.Name,
                    CreatedBy = "Usuario"
                }
                );

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
        public async Task<ProvidersResponse> Update(ProvidersRequest providersRequest)
        {
            ProvidersResponse result = new ProvidersResponse();
            try
            {
                var providers = _context.Providers.Where(a => a.Id == providersRequest.Id).FirstOrDefault();
                if (providers != null)
                {
                    providers.Name = providersRequest.Name;
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
        public async Task<ProvidersResponse> GetAll(int Start, int Limit)
        {

            ProvidersResponse result = new ProvidersResponse();
            try
            {

                //var q = (from d in _context.Providers
                //         join c in _context.ProviderImportations on d.ProviderId equals c.ProviderId
                //         select new ProvidersDto
                //         {
                //             ProviderId = d.ProviderId,
                //             Name = d.Name,
                //             CreatedAt = c.CreatedAt
                //         })

                //         .OrderByDescending(d => d.ProviderId).GroupBy(x=> x.CreatedAt).ToList();


                var collection = await _context.Providers.AsNoTracking().OrderBy(x => x.Id).GetPagedAsync(Start, Limit);
                var providersresult = collection.MapTo<DataCollection<ProvidersDto>>();

                foreach (var item in providersresult.Items)
                {
                    item.LastImportationDate = string.Empty;
                    var ProviderImportations= _context.ProviderImportations.Where(x => x.ProviderId == item.Id).OrderByDescending(c => c.CreatedAt).FirstOrDefault();
                    if (ProviderImportations!=null)
                    {
                        item.LastImportationDate = Convert.ToDateTime(ProviderImportations.CreatedAt).ToString("dd/MM/yyyy HH:mm");
                    }
                }
                result.Success = true;
                result.Message = "Se realizó satisfactoriamente";
                result.Data = (List<ProvidersDto>)providersresult.Items;

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al consultar";
                result.Details = ex.Message + " || " + ex.StackTrace;
            }

            return result;
        }
        public async Task<ProvidersResponse> Upload(Stream stream, ProvidersRequest providersRequest)
        {
            List<ProviderBricksDto> LstProviderBricks = new List<ProviderBricksDto>();
            List<ProviderInsulatingsDto> LstProviderInsulatings = new List<ProviderInsulatingsDto>();
            List<ProviderConcretesDto> LstProviderConcretes = new List<ProviderConcretesDto>();

            ProvidersResponse result = new ProvidersResponse();
            DataTableCollection hojas_excel = Execute(stream);
            var ProviderImportations = new ProviderImportations();

            try
            {
                    //using (TransactionScope tx = new TransactionScope())
                    //{
                      //  await SomeAsyncMethod();
                ProviderImportations.ProviderId = providersRequest.Id;
                ProviderImportations.CreatedBy = providersRequest.CreatedBy;
                await _context.AddAsync(ProviderImportations);
                await _context.SaveChangesAsync();

                int ProviderImportationId = ProviderImportations.Id;

                for (int i = 0; i < hojas_excel.Count; i++)
                {
                    string nombreHoja = hojas_excel[i].TableName;              

                    DataTable table = hojas_excel[i];
                    if (nombreHoja == "ladrillos")
                    {                              
                        LstProviderBricks = ListProviderBricks(table, ProviderImportationId);
                        await BulkInsert(LstProviderBricks);
                    }
                    else if (nombreHoja == "concreto refractario")
                    {
                        LstProviderConcretes = ListProviderConcretes(table, ProviderImportationId);
                        await BulkInsertProviderConcretes(LstProviderConcretes);
                    }
                    else if (nombreHoja == "concreto aislante")
                    {
                        LstProviderInsulatings = ListProviderInsulatings(table, ProviderImportationId);
                        await BulkInsertProviderInsulatings(LstProviderInsulatings);
                    }
                    
                }
                result.Success = true;
                result.Message = "Se realizó satisfactoriamente";
                       // tx.Complete();
                   // }                                    
            }
            catch (Exception ex)
            {
                _context.Remove(ProviderImportations);
                await _context.SaveChangesAsync();
                result.Success = false;
                result.Message = "Error al consultar";
                result.Details = ex.Message + " || " + ex.StackTrace;

            }                    

            return  result;
        }
        private async Task SomeAsyncMethod()
        {
            await Task.Delay(1000);
        }
        public DataTableCollection Execute(Stream stream)
        {
            DataSet result;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream))
            {
                

                result = excelReader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                    {
                        //UseHeaderRow = true,
                        FilterRow = rowReader =>
                        {
                            var hasData = false;
                            for (var i = 0; i < rowReader.FieldCount; i++)
                            {
                                if (rowReader[i] == null || string.IsNullOrEmpty(rowReader[i].ToString()))
                                {
                                    continue;
                                }

                                hasData = true;
                                break;
                            }

                            return hasData;
                        },
                    }
                });
            }


            //this.Sheets = result.Tables;
            return result.Tables;
        }
        public async Task BulkInsert(List<ProviderBricksDto> lstData)
        {
            DataTable table = new DataTable();
            table.TableName = "ProviderBricks";

            table.Columns.Add("ProviderImportationId", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("RecommendedZone", typeof(string));
            table.Columns.Add("Composition", typeof(string));
            table.Columns.Add("Density", typeof(string));
            table.Columns.Add("Porosity", typeof(string));
            table.Columns.Add("Ccs", typeof(string));
            table.Columns.Add("ThermalConductivity300", typeof(decimal));
            table.Columns.Add("ThermalConductivity700", typeof(decimal));
            table.Columns.Add("ThermalConductivity100", typeof(decimal));


            foreach (var item in lstData)
            {
                DataRow row = table.NewRow();
                row["ProviderImportationId"] = item.ProviderImportationId;
                row["Name"] = item.Name;
                row["RecommendedZone"] = item.RecommendedZone;
                row["Composition"] = item.Composition;
                row["Density"] = item.Density;
                row["Porosity"] = item.Porosity;
                row["Ccs"] = item.Ccs;
                row["ThermalConductivity300"] = item.ThermalConductivity300;
                row["ThermalConductivity700"] = item.ThermalConductivity700;
                row["ThermalConductivity100"] = item.ThermalConductivity100;
               

                table.Rows.Add(row);
            }
            try
            {
                using (var bulkInsert = new SqlBulkCopy(_context.Database.GetDbConnection().ConnectionString))
                {
                    bulkInsert.DestinationTableName = table.TableName;
                    bulkInsert.ColumnMappings.Add("ProviderImportationId", "ProviderImportationId");
                    bulkInsert.ColumnMappings.Add("Name", "Name");
                    bulkInsert.ColumnMappings.Add("RecommendedZone", "RecommendedZone");
                    bulkInsert.ColumnMappings.Add("Composition", "Composition");
                    bulkInsert.ColumnMappings.Add("Density", "Density");
                    bulkInsert.ColumnMappings.Add("Porosity", "Porosity");
                    bulkInsert.ColumnMappings.Add("Ccs", "Ccs");
                    bulkInsert.ColumnMappings.Add("ThermalConductivity300", "ThermalConductivity300");
                    bulkInsert.ColumnMappings.Add("ThermalConductivity700", "ThermalConductivity700");
                    bulkInsert.ColumnMappings.Add("ThermalConductivity100", "ThermalConductivity100");


                  await  bulkInsert.WriteToServerAsync(table);
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            
        }

        public async Task BulkInsertProviderInsulatings(List<ProviderInsulatingsDto> lstData)
        {
            DataTable table = new DataTable();
            table.TableName = "ProviderInsulatings";

            table.Columns.Add("ProviderImportationId", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("RecommendedZone", typeof(string));
            table.Columns.Add("Composition", typeof(string));
            table.Columns.Add("MaterialNeeded", typeof(double));
            table.Columns.Add("WaterMix", typeof(string));
            table.Columns.Add("Temperature", typeof(double));
            table.Columns.Add("ThermalConductivity300", typeof(double));
            table.Columns.Add("ThermalConductivity700", typeof(double));
            table.Columns.Add("ThermalConductivity100", typeof(double));


            foreach (var item in lstData)
            {
                DataRow row = table.NewRow();
                row["ProviderImportationId"] = item.ProviderImportationId;
                row["Name"] = item.Name;
                row["RecommendedZone"] = item.RecommendedZone;
                row["Composition"] = item.Composition;
                row["MaterialNeeded"] = item.MaterialNeeded;
                row["WaterMix"] = item.WaterMix;
                row["Temperature"] = item.Temperature;
                row["ThermalConductivity300"] = item.ThermalConductivity300;
                row["ThermalConductivity700"] = item.ThermalConductivity700;
                row["ThermalConductivity100"] = item.ThermalConductivity100;

                table.Rows.Add(row);
            }
            try
            {
                using (var bulkInsert = new SqlBulkCopy(_context.Database.GetDbConnection().ConnectionString))
                {
                    bulkInsert.DestinationTableName = table.TableName;
                    bulkInsert.ColumnMappings.Add("ProviderImportationId", "ProviderImportationId");
                    bulkInsert.ColumnMappings.Add("Name", "Name");
                    bulkInsert.ColumnMappings.Add("RecommendedZone", "RecommendedZone");
                    bulkInsert.ColumnMappings.Add("Composition", "Composition");
                    bulkInsert.ColumnMappings.Add("MaterialNeeded", "MaterialNeeded");
                    bulkInsert.ColumnMappings.Add("WaterMix", "WaterMix");
                    bulkInsert.ColumnMappings.Add("Temperature", "Temperature");
                    bulkInsert.ColumnMappings.Add("ThermalConductivity300", "ThermalConductivity300");
                    bulkInsert.ColumnMappings.Add("ThermalConductivity700", "ThermalConductivity700");
                    bulkInsert.ColumnMappings.Add("ThermalConductivity100", "ThermalConductivity100");


                    await bulkInsert.WriteToServerAsync(table);
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }


        public async Task BulkInsertProviderConcretes(List<ProviderConcretesDto> lstData)
        {
            DataTable table = new DataTable();
            table.TableName = "ProviderConcretes";

            table.Columns.Add("ProviderImportationId", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("RecommendedZone", typeof(string));
            table.Columns.Add("Composition", typeof(string));
            table.Columns.Add("MaterialNeeded", typeof(double));
            table.Columns.Add("WaterMix", typeof(string));
            table.Columns.Add("Temperature", typeof(double));
            table.Columns.Add("ThermalConductivity300", typeof(double));
            table.Columns.Add("ThermalConductivity700", typeof(double));
            table.Columns.Add("ThermalConductivity100", typeof(double));


            foreach (var item in lstData)
            {
                DataRow row = table.NewRow();
                row["ProviderImportationId"] = item.ProviderImportationId;
                row["Name"] = item.Name;
                row["RecommendedZone"] = item.RecommendedZone;
                row["Composition"] = item.Composition;
                row["MaterialNeeded"] = item.MaterialNeeded;
                row["WaterMix"] = item.WaterMix;
                row["Temperature"] = item.Temperature;
                row["ThermalConductivity300"] = item.ThermalConductivity300;
                row["ThermalConductivity700"] = item.ThermalConductivity700;
                row["ThermalConductivity100"] = item.ThermalConductivity100;


                table.Rows.Add(row);
            }
            try
            {
                using (var bulkInsert = new SqlBulkCopy(_context.Database.GetDbConnection().ConnectionString))
                {
                    bulkInsert.DestinationTableName = table.TableName;
                    bulkInsert.ColumnMappings.Add("ProviderImportationId", "ProviderImportationId");
                    bulkInsert.ColumnMappings.Add("Name", "Name");
                    bulkInsert.ColumnMappings.Add("RecommendedZone", "RecommendedZone");
                    bulkInsert.ColumnMappings.Add("Composition", "Composition");
                    bulkInsert.ColumnMappings.Add("MaterialNeeded", "MaterialNeeded");
                    bulkInsert.ColumnMappings.Add("WaterMix", "WaterMix");
                    bulkInsert.ColumnMappings.Add("Temperature", "Temperature");
                    bulkInsert.ColumnMappings.Add("ThermalConductivity300", "ThermalConductivity300");
                    bulkInsert.ColumnMappings.Add("ThermalConductivity700", "ThermalConductivity700");
                    bulkInsert.ColumnMappings.Add("ThermalConductivity100", "ThermalConductivity100");


                    await bulkInsert.WriteToServerAsync(table);
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }


        public List<ProviderBricksDto> ListProviderBricks(DataTable table, int ProviderImportationId)
        {
            bool iniciarLectura = false;
            List<ProviderBricksDto> Lista = new List<ProviderBricksDto>();
            using (var reader = table.CreateDataReader())
            {
                while (reader.Read())
                {
                    var cab = reader[1] == null ? string.Empty : reader[1].ToString();
                    if (cab.Trim().ToUpper() == "")
                    {
                        iniciarLectura = true;
                        continue;
                    }

                    if (iniciarLectura)
                    {
                        try
                        {
                            var providerBricksDto = new ProviderBricksDto();
                            providerBricksDto.ProviderImportationId = ProviderImportationId;
                            providerBricksDto.Name = reader.GetString(0);
                            providerBricksDto.RecommendedZone = reader.GetString(1);
                            providerBricksDto.Composition = reader.GetString(2);
                            providerBricksDto.Density = reader.GetString(3);
                            providerBricksDto.Porosity = reader.GetString(4);
                            providerBricksDto.Ccs = reader.GetDouble(5).ToString();
                            providerBricksDto.ThermalConductivity300 = Convert.ToDecimal(reader.GetString(6));
                            providerBricksDto.ThermalConductivity700 = Convert.ToDecimal(reader.GetString(7));
                            providerBricksDto.ThermalConductivity100 = Convert.ToDecimal(reader.GetString(8));

                            Lista.Add(providerBricksDto);



                        }
                        catch (Exception ex)
                        {

                            throw ex;
                        }
                    }
                }
            }

            return Lista;
        }

        public List<ProviderInsulatingsDto> ListProviderInsulatings(DataTable table, int ProviderImportationId)
        {
            bool iniciarLectura = false;
            List<ProviderInsulatingsDto> Lista = new List<ProviderInsulatingsDto>();
            using (var reader = table.CreateDataReader())
            {
                while (reader.Read())
                {
                    var cab = reader[1] == null ? string.Empty : reader[1].ToString();
                    if (cab.Trim().ToUpper() == "")
                    {
                        iniciarLectura = true;
                        continue;
                    }

                    if (iniciarLectura)
                    {
                        try
                        {
                            var providerInsulatingsDto = new ProviderInsulatingsDto();
                            providerInsulatingsDto.ProviderImportationId = ProviderImportationId;
                            providerInsulatingsDto.Name = reader.GetString(0);
                            providerInsulatingsDto.RecommendedZone = reader.GetString(1);
                            providerInsulatingsDto.Composition = reader.GetString(2);
                            providerInsulatingsDto.MaterialNeeded = Convert.ToDouble(reader.GetString(3));
                            providerInsulatingsDto.WaterMix = reader.GetString(4);
                            providerInsulatingsDto.Temperature = Convert.ToDouble(reader.GetDouble(5));
                            providerInsulatingsDto.ThermalConductivity300 = Convert.ToDouble(reader.GetString(6));
                            providerInsulatingsDto.ThermalConductivity700 = Convert.ToDouble(reader.GetString(7));
                            providerInsulatingsDto.ThermalConductivity100 = Convert.ToDouble(reader.GetString(8));


                            Lista.Add(providerInsulatingsDto);

                        }
                        catch (Exception ex)
                        {

                            throw ex;
                        }
                    }
                }
            }

            return Lista;
        }



        public List<ProviderConcretesDto> ListProviderConcretes(DataTable table, int ProviderImportationId)
        {
            bool iniciarLectura = false;
            List<ProviderConcretesDto> Lista = new List<ProviderConcretesDto>();
            using (var reader = table.CreateDataReader())
            {
                while (reader.Read())
                {
                    var cab = reader[1] == null ? string.Empty : reader[1].ToString();
                    if (cab.Trim().ToUpper() == "")
                    {
                        iniciarLectura = true;
                        continue;
                    }

                    if (iniciarLectura)
                    {
                        try
                        {
                            var providerConcretesDto = new ProviderConcretesDto();
                            providerConcretesDto.ProviderImportationId = ProviderImportationId;
                            providerConcretesDto.Name = reader.GetString(0);
                            providerConcretesDto.RecommendedZone = reader.GetString(1);
                            providerConcretesDto.Composition = reader.GetString(2);
                            providerConcretesDto.MaterialNeeded = Convert.ToDouble(reader.GetString(3));
                            providerConcretesDto.WaterMix = reader.GetString(4);
                         
                            providerConcretesDto.Temperature = Convert.ToDouble(reader.GetDouble(5));
                           // var a = reader.GetString(6);
                            providerConcretesDto.ThermalConductivity300 = Convert.ToDouble(reader.GetString(6));
                            providerConcretesDto.ThermalConductivity700 = Convert.ToDouble(reader.GetString(7));
                            providerConcretesDto.ThermalConductivity100 = Convert.ToDouble(reader.GetString(8));


                            Lista.Add(providerConcretesDto);

                        }
                        catch (Exception ex)
                        {

                            throw ex;
                        }
                    }
                }
            }

            return Lista;
        }




        public class ArticuloSaldo
        {
            public int Id { get; set; }
            public string NombreProducto { get; set; }
            public decimal Precio { get; set; }
            public int Cantidad { get; set; }
        }


    }

}
