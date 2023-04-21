using ExcelDataReader;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UNACEM.Common.Collection;
using UNACEM.Common.Mapping;
using UNACEM.Common.Paging;
using UNACEM.Domain;
using UNACEM.Persistence.Database;
using UNACEM.Service.Queries.DTO;
using UNACEM.Service.Queries.ViewModel.Response;

namespace UNACEM.Service.Queries
{
    public interface IFormatsQueryService
    {
        Task<BrickFormatsResponse> GetAll(int Start, int Limit, int Diameter);
        Task<BrickFormatsResponse> Upload(Stream stream);
       
    }
    public class FormatsQueryService : IFormatsQueryService
    {
        private readonly ApplicationDbContext _context;
        public FormatsQueryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<BrickFormatsResponse> GetAll(int diameter, int start, int limit)
        {            
            var result = new BrickFormatsResponse();
            try
            {
                var collection = await _context.BrickFormats.AsNoTracking().Where(a => a.Diameter == diameter && a.DeletedAt == null).OrderByDescending(x => x.Id).GetPagedAsync(start, limit); ;
                if (diameter==0)
                {
                    collection = await _context.BrickFormats.AsNoTracking().Where(a => a.DeletedAt == null).OrderByDescending(x => x.Id).GetPagedAsync(start, limit);
                }

                var providersresult = collection.MapTo<DataCollection<BrickFormatsDto>>();

                result.Success = true;
                result.Message = "Se realizó satisfactoriamente";
                result.Data = (List<BrickFormatsDto>)providersresult.Items;

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error al consultar";
                result.Details = ex.Message + " || " + ex.StackTrace;
            }

            return result;
        }

        public async Task<BrickFormatsResponse> Upload(Stream stream)
        {
            BrickFormatsResponse result = new BrickFormatsResponse();

            try
            {   
                DataTableCollection hojasExcel = Execute(stream);

                var brickGroup = "vdz";

                for (int i = 0; i < hojasExcel.Count; i++)
                {
                    string nombreHoja = hojasExcel[i].TableName;
                    DataTable table = hojasExcel[i];

                    if (nombreHoja.ToLower().Contains("iso"))
                    {
                        brickGroup = "iso";
                    }

                    var listBrickpairs = new List<string>();
                    listBrickpairs.Add("");
                    for (int iRow = 0; iRow < table.Rows.Count; iRow++)
                    {
                        // Header
                        if (iRow == 0)
                        {
                            var columns = table.Rows[iRow].ItemArray;
                            for (int iCol = 1; iCol < columns.Count(); iCol++)
                            {
                                var brickPair = columns[iCol].ToString();
                                brickPair = brickPair.Replace("\n", "");
                                listBrickpairs.Add(brickPair);
                                //var brickPairs = brickPair.Split(":");
                            }
                        }
                        else
                        {
                            // Body
                            var columns = table.Rows[iRow].ItemArray;
                            var diameter = 0;

                            for (int iCol = 0; iCol < columns.Count(); iCol++)
                            {
                                if (iCol == 0)
                                {
                                    var isDiameter = int.TryParse(columns[iCol].ToString(), out diameter);
                                }
                                else
                                {
                                    var brickPairQuantity = columns[iCol].ToString();
                                    brickPairQuantity = brickPairQuantity.Replace("\n", "");
                                    if (brickPairQuantity.Contains("-"))
                                    {
                                        continue;
                                    }
                                    else {

                                        var brickPairQ = brickPairQuantity.Split(":");

                                        var brickPairsString  = listBrickpairs[iCol];
                                        var brickPairs = brickPairsString.Split(':');

                                        if (brickPairs.Length > 2)
                                        {
                                            var newBrickPairsString = "";
                                            foreach (var bp in brickPairs)
                                            {
                                                var part = bp;
                                                if (bp.Length>3)
                                                {
                                                    part = bp.Substring(0, 3) + "-" + bp.Substring(3, 3);
                                                }

                                                newBrickPairsString += part + ":";
                                            }

                                            newBrickPairsString = newBrickPairsString.Substring(0, newBrickPairsString.Length - 1);

                                            brickPairs = newBrickPairsString.Split('-');
                                        }
                                        else
                                        {
                                            brickPairs = brickPairsString.Split('\n');
                                        }

                                        foreach (var bp in brickPairs)
                                        {
                                            var brickPair = bp.Split(":");

                                            if (brickPairQuantity != "")
                                            {
                                                var brickFormat = new BrickFormats();
                                                brickFormat.Group = brickGroup;
                                                brickFormat.BrickA = brickPair[0];
                                                brickFormat.BrickB = brickPair[1];
                                                brickFormat.QuantityA = int.Parse(brickPairQ[0]);
                                                brickFormat.QuantityB = int.Parse(brickPairQ[1]);   
                                                brickFormat.Diameter = diameter;

                                                await _context.AddAsync(brickFormat);
                                                await _context.SaveChangesAsync();
                                            }
                                        }

                                        
                                        
                                    }
                                }
                            }
                        }
                    }

                    /*using (var reader = table.CreateDataReader())
                    {
                        var readHeader = true;
                        while (reader.Read())
                        {
                            if (readHeader)
                            {

                            }
                        }
                    }*/
                }

                result.Success = true;
                result.Message = "Se realizó satisfactoriamente";
            }
            catch (Exception ex)
            {
                await _context.SaveChangesAsync();
                result.Success = false;
                result.Message = "Error al consultar";
                result.Details = ex.Message + " || " + ex.StackTrace;
            }

            return result;
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
    }
}
