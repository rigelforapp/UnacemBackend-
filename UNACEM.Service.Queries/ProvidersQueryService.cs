using ExcelDataReader;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UNACEM.Domain;
using UNACEM.Persistence.Database;
using UNACEM.Service.Queries.DTO;
using UNACEM.Service.Queries.ViewModel.Request;
using UNACEM.Service.Queries.ViewModel.Response;

namespace UNACEM.Service.Queries
{
    public interface IProvidersQueryService
    {
        Task<ProvidersResponse> Create(ProvidersRequest providersRequest);
        Task<ProvidersResponse> Update(ProvidersRequest providersRequest, Users user);
        Task<ProvidersResponse> GetAll(int Start, int Limit);
        Task<ProvidersResponse> Upload(Stream stream, int ProviderId, Users user);
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
        public async Task<ProvidersResponse> Update(ProvidersRequest providersRequest, Users user)
        {
            ProvidersResponse result = new ProvidersResponse();
            try
            {
                var providers = _context.Providers.Where(a => a.Id == providersRequest.Id).FirstOrDefault();
                if (providers != null)
                {
                    providers.Name = providersRequest.Name;

                    if (providersRequest.Deleted && user.IsAdmin == true)
                    {
                        providers.DeletedAt = providersRequest.Deleted ? DateTime.Now : null;
                    }
                    

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
                var providers = _context.Providers.Where(p => p.DeletedAt == null).ToList();
                var providersDto = new List<ProvidersDto>();

                foreach (var provider in providers)
                {
                    var pResponse = new ProvidersDto();
                    pResponse.Id = provider.Id;
                    pResponse.Name = provider.Name;

                    var pImportation = _context.ProviderImportations.Where(x => x.ProviderId == provider.Id).OrderByDescending(c => c.CreatedAt).FirstOrDefault();
                    if (pImportation != null)
                    {
                        pResponse.LastImportationDate = pImportation.CreatedAt ?? null;
                    }

                    providersDto.Add(pResponse);
                }

                result.Success = true;
                result.Message = "Se realizó satisfactoriamente";
                result.Data = providersDto;

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al consultar";
                result.Details = ex.Message + " || " + ex.StackTrace;
            }

            return result;
        }
        public async Task<ProvidersResponse> Upload(Stream stream, int ProviderId, Users user)
        {
            List<ProviderBricksDto> LstProviderBricks = new List<ProviderBricksDto>();
            List<ProviderInsulatingsDto> LstProviderInsulatings = new List<ProviderInsulatingsDto>();
            List<ProviderConcretesDto> LstProviderConcretes = new List<ProviderConcretesDto>();

            ProvidersResponse result = new ProvidersResponse();
            var ProviderImportations = new ProviderImportations();

            try
            {
                DataTableCollection hojas_excel = Execute(stream);
                
                //using (TransactionScope tx = new TransactionScope())
                //{
                //  await SomeAsyncMethod();
                ProviderImportations.ProviderId = ProviderId;
                //@change: Update after implement token auth.
                ProviderImportations.CreatedBy = user.Id;
                await _context.AddAsync(ProviderImportations);
                await _context.SaveChangesAsync();

                int ProviderImportationId = ProviderImportations.Id;

                for (int i = 0; i < hojas_excel.Count; i++)
                {
                    string nombreHoja = hojas_excel[i].TableName;

                    DataTable table = hojas_excel[i];
                    if (nombreHoja == "ladrillos")
                    {
                        LstProviderBricks = await ListProviderBricks(table, ProviderImportationId);
                        await BulkInsert(LstProviderBricks);
                    }
                    else if (nombreHoja == "concreto refractario")
                    {
                        LstProviderConcretes = await ListProviderConcretes(table, ProviderImportationId);
                        await BulkInsertProviderConcretes(LstProviderConcretes);
                    }
                    else if (nombreHoja == "concreto aislante")
                    {
                        LstProviderInsulatings = await ListProviderInsulatings(table, ProviderImportationId);
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

            return result;
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
            table.Columns.Add("ThermalConductivity300", typeof(string));
            table.Columns.Add("ThermalConductivity700", typeof(string));
            table.Columns.Add("ThermalConductivity100", typeof(string));
            table.Columns.Add("CreatedAt", typeof(DateTime));


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
                row["CreatedAt"] = DateTime.Now;

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
                    bulkInsert.ColumnMappings.Add("CreatedAt", "CreatedAt");

                    await bulkInsert.WriteToServerAsync(table);
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
            table.Columns.Add("MaterialNeeded", typeof(string));
            table.Columns.Add("WaterMix", typeof(string));
            table.Columns.Add("Temperature", typeof(string));
            table.Columns.Add("ThermalConductivity300", typeof(string));
            table.Columns.Add("ThermalConductivity700", typeof(string));
            table.Columns.Add("ThermalConductivity100", typeof(string));
            table.Columns.Add("CreatedAt", typeof(DateTime));

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
                row["CreatedAt"] = DateTime.Now;
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
                    bulkInsert.ColumnMappings.Add("CreatedAt", "CreatedAt");

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
            table.Columns.Add("MaterialNeeded", typeof(string));
            table.Columns.Add("WaterMix", typeof(string));
            table.Columns.Add("Temperature", typeof(string));
            table.Columns.Add("ThermalConductivity300", typeof(string));
            table.Columns.Add("ThermalConductivity700", typeof(string));
            table.Columns.Add("ThermalConductivity100", typeof(string));
            table.Columns.Add("CreatedAt", typeof(DateTime));


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
                row["CreatedAt"] = DateTime.Now;

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
                    bulkInsert.ColumnMappings.Add("CreatedAt", "CreatedAt");


                    await bulkInsert.WriteToServerAsync(table);
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }


        public async Task<List<ProviderBricksDto>> ListProviderBricks(DataTable table, int ProviderImportationId)
        {
            List<ProviderBricks> listaProviderBricks = new List<ProviderBricks>();
            listaProviderBricks = _context.ProviderBricks.Where(x => x.CreatedAt != null).ToList();
            bool iniciarLectura = false;
            List<ProviderBricksDto> Lista = new List<ProviderBricksDto>();

            int indexCol = 5;
            int indexRow = 1;

            using (var reader = table.CreateDataReader())
            {
                while (reader.Read())
                {

                    if (indexRow >= 4)
                    {
                        try
                        {

                            var name = reader.GetValue(indexCol - 1).ToString();
                            if (name == "")
                            {
                                continue;
                            }

                            var providerBricksDto = new ProviderBricksDto();
                            providerBricksDto.ProviderImportationId = ProviderImportationId;
                            providerBricksDto.Name = reader.GetValue(indexCol - 1).ToString();
                            providerBricksDto.RecommendedZone = reader.GetValue(indexCol).ToString();
                            providerBricksDto.Composition = reader.GetValue(indexCol+1).ToString();
                            providerBricksDto.Density = reader.GetValue(indexCol+2).ToString();
                            providerBricksDto.Porosity = reader.GetValue(indexCol+3).ToString();
                            providerBricksDto.Ccs = reader.GetValue(indexCol+4).ToString();

                            providerBricksDto.ThermalConductivity300 = reader.GetValue(indexCol+5).ToString();
                            providerBricksDto.ThermalConductivity700 = reader.GetValue(indexCol+6).ToString();
                            providerBricksDto.ThermalConductivity100 = reader.GetValue(indexCol + 7).ToString();

                            var existeproviderBricks = listaProviderBricks.Where(a => a.Name == providerBricksDto.Name).FirstOrDefault();
                            if (existeproviderBricks != null)
                            {
                                var ProviderBricks = _context.ProviderBricks.Where(a => a.Id == existeproviderBricks.Id).FirstOrDefault();
                                if (ProviderBricks != null)
                                {
                                    ProviderBricks.DeletedAt = DateTime.Now;

                                    await _context.SaveChangesAsync();
                                }
                            }
                            Lista.Add(providerBricksDto);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }

                    indexRow++;
                }
            }
            return Lista;
        }

        public async Task<List<ProviderInsulatingsDto>> ListProviderInsulatings(DataTable table, int ProviderImportationId)
        {
            List<ProviderInsulatings> listaProviderInsulatings = new List<ProviderInsulatings>();
            listaProviderInsulatings = _context.ProviderInsulatings.Where(x => x.CreatedAt != null).ToList();
            bool iniciarLectura = false;
            List<ProviderInsulatingsDto> Lista = new List<ProviderInsulatingsDto>();

            int indexCol = 5;
            int indexRow = 1;

            using (var reader = table.CreateDataReader())
            {
                while (reader.Read())
                {
                    if (indexRow>=5)
                    {
                        try
                        {
                            var name = reader.GetValue(indexCol - 1).ToString();
                            if (name == "")
                            {
                                continue;
                            }

                            var providerInsulatingsDto = new ProviderInsulatingsDto();
                            providerInsulatingsDto.ProviderImportationId = ProviderImportationId;
                            providerInsulatingsDto.Name = reader.GetValue(indexCol-1).ToString();
                            providerInsulatingsDto.RecommendedZone = reader.GetValue(indexCol).ToString();
                            providerInsulatingsDto.Composition = reader.GetValue(indexCol+1).ToString();
                            providerInsulatingsDto.MaterialNeeded = reader.GetValue(indexCol+2).ToString();
                            providerInsulatingsDto.WaterMix = reader.GetValue(indexCol+3).ToString();
                            providerInsulatingsDto.Temperature = reader.GetValue(indexCol+4).ToString();

                            providerInsulatingsDto.ThermalConductivity300 = reader.GetValue(indexCol+5).ToString();
                            providerInsulatingsDto.ThermalConductivity700 = reader.GetValue(indexCol+6).ToString();
                            providerInsulatingsDto.ThermalConductivity100 = reader.GetValue(indexCol+7).ToString();

                            var existeProviderInsulatings = listaProviderInsulatings.Where(a => a.Name == providerInsulatingsDto.Name).FirstOrDefault();
                            if (existeProviderInsulatings != null)
                            {
                                var ProviderInsulatings = _context.ProviderInsulatings.Where(a => a.Id == existeProviderInsulatings.Id).FirstOrDefault();
                                if (ProviderInsulatings != null)
                                {
                                    ProviderInsulatings.DeletedAt = DateTime.Now;

                                    await _context.SaveChangesAsync();
                                }
                            }

                            Lista.Add(providerInsulatingsDto);

                        }
                        catch (Exception ex)
                        {

                            throw ex;
                        }
                    }
                    
                    indexRow++;
                }
            }

            return Lista;
        }

        public async Task<List<ProviderConcretesDto>> ListProviderConcretes(DataTable table, int ProviderImportationId)
        {
            List<ProviderConcretes> listaProviderConcretes = new List<ProviderConcretes>();
            listaProviderConcretes = _context.ProviderConcretes.Where(x => x.CreatedAt != null).ToList();
            bool iniciarLectura = false;
            List<ProviderConcretesDto> Lista = new List<ProviderConcretesDto>();

            int indexCol = 5;
            int indexRow = 1;

            using (var reader = table.CreateDataReader())
            {
                while (reader.Read())
                {

                    if (indexRow >= 6)
                    {
                        try
                        {
                            var name = reader.GetValue(indexCol - 1).ToString();
                            if (name == "")
                            {
                                continue;
                            }

                            var providerConcretesDto = new ProviderConcretesDto();
                            providerConcretesDto.ProviderImportationId = ProviderImportationId;
                            providerConcretesDto.Name = reader.GetValue(indexCol-1).ToString();
                            providerConcretesDto.RecommendedZone = reader.GetValue(indexCol).ToString();
                            providerConcretesDto.Composition = reader.GetValue(indexCol+1).ToString();
                            providerConcretesDto.MaterialNeeded = reader.GetValue(indexCol+2).ToString();
                            providerConcretesDto.WaterMix = reader.GetValue(indexCol+3).ToString();
                            providerConcretesDto.Temperature = reader.GetValue(indexCol+4).ToString();

                            var ThermalConductivity300Val = reader.GetValue(indexCol+5).ToString();
                            providerConcretesDto.ThermalConductivity300 = ThermalConductivity300Val;

                            var ThermalConductivity700Val = reader.GetValue(indexCol+6).ToString();
                            providerConcretesDto.ThermalConductivity700 = ThermalConductivity700Val;

                            var ThermalConductivity100Val = reader.GetValue(indexCol+7).ToString();
                            providerConcretesDto.ThermalConductivity100 = ThermalConductivity100Val;

                            var existeProviderConcretes = listaProviderConcretes.Where(a => a.Name == providerConcretesDto.Name).FirstOrDefault();
                            if (existeProviderConcretes != null)
                            {
                                var ProviderInsulatings = _context.ProviderConcretes.Where(a => a.Id == existeProviderConcretes.Id).FirstOrDefault();
                                if (ProviderInsulatings != null)
                                {
                                    ProviderInsulatings.DeletedAt = DateTime.Now;

                                    await _context.SaveChangesAsync();
                                }
                            }

                            Lista.Add(providerConcretesDto);

                        }
                        catch (Exception ex)
                        {

                            throw ex;
                        }
                    }

                    indexRow++;
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
