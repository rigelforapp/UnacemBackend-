using System;
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
            DataTableCollection hojas_excel = Execute(stream);
            var ProviderImportations = new ProviderImportations();

            try
            {
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
            listaProviderBricks= _context.ProviderBricks.Where(x => x.CreatedAt != null).ToList();
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
                            providerBricksDto.Name = reader.GetValue(0).ToString();
                            providerBricksDto.RecommendedZone = reader.GetValue(1).ToString();
                            providerBricksDto.Composition = reader.GetValue(2).ToString();
                            providerBricksDto.Density = reader.GetValue(3).ToString();
                            providerBricksDto.Porosity = reader.GetValue(4).ToString();
                            providerBricksDto.Ccs = reader.GetValue(5).ToString();

                            var ThermalConductivity300Val = reader.GetValue(6).ToString();
                            providerBricksDto.ThermalConductivity300 = ThermalConductivity300Val != "" ? Convert.ToDecimal(ThermalConductivity300Val) : -1;

                            var ThermalConductivity700Val = reader.GetValue(7).ToString();
                            providerBricksDto.ThermalConductivity700 = ThermalConductivity700Val != "" ? Convert.ToDecimal(ThermalConductivity700Val) : -1;

                            var ThermalConductivity100Val = reader.GetValue(8).ToString();
                            providerBricksDto.ThermalConductivity100 = ThermalConductivity100Val != "" ? Convert.ToDecimal(ThermalConductivity100Val) : -1;

                            /*providerBricksDto.ThermalConductivity300 = Convert.ToDecimal(reader.GetString(6));
                            providerBricksDto.ThermalConductivity700 = Convert.ToDecimal(reader.GetString(7));
                            providerBricksDto.ThermalConductivity100 = Convert.ToDecimal(reader.GetString(8));*/

                            var existeproviderBricks = listaProviderBricks.Where(a => a.Name == providerBricksDto.Name).FirstOrDefault();
                            if (existeproviderBricks!=null)
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
                            providerInsulatingsDto.MaterialNeeded = reader.GetString(3);
                            providerInsulatingsDto.WaterMix = reader.GetString(4);
                            providerInsulatingsDto.Temperature = reader.GetString(5);

                            providerInsulatingsDto.ThermalConductivity300 = reader.GetValue(6).ToString();
                            providerInsulatingsDto.ThermalConductivity700 = reader.GetValue(7).ToString();
                            providerInsulatingsDto.ThermalConductivity100 = reader.GetValue(8).ToString();

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
                            providerConcretesDto.MaterialNeeded = reader.GetValue(3).ToString();
                            providerConcretesDto.WaterMix = reader.GetString(4);                         
                            providerConcretesDto.Temperature =reader.GetString(5);
                            
                            var ThermalConductivity300Val = reader.GetValue(6).ToString();
                            providerConcretesDto.ThermalConductivity300 = ThermalConductivity300Val;

                            var ThermalConductivity700Val = reader.GetValue(7).ToString();
                            providerConcretesDto.ThermalConductivity700 = ThermalConductivity700Val;

                            var ThermalConductivity100Val = reader.GetValue(8).ToString();
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
