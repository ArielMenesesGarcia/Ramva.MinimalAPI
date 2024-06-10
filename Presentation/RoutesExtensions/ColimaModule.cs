using API.Minimal.Application.DTOs;
using API.Minimal.Core.Entities;
using API.Minimal.Infrastructre;
using API.Minimal.Utilities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Minimal.Presentation.RoutesExtensions
{
    public static class ColimaModule
    {
        public static async void AddRoutesColimaServices(this IEndpointRouteBuilder app)
        {
            app.MapPost("Codes/ProcessFile", (string path, MinimalDB context, IMapper mapper, LoggerService logger) =>
            {
                try
                {
                    IEnumerable<string> data = HelperFile.ReadCustomFileWithDelimiter(path, "|", 15);
                    if (data.Count() == 0)
                        return Results.BadRequest(new { Error = $"No records found in the path: {path}" });

                    var records = HelperFile.ConvertDataToModelArray<CodesStatesDTO>(data, "|");
                    var entities = mapper.Map<List<StateCodes>>(records);

                    context.CodeStates.AddRange(entities);
                    context.SaveChanges();

                    return Results.Ok();
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message);
                    return Results.BadRequest(new { error = ex.Message });
                }

            });
            app.MapGet("Codes/{cp}", async (MinimalDB context, string cp) =>
            {
                var record = await context.CodeStates.Where(x => x.CodigoPostal == cp).FirstOrDefaultAsync();
                if (record == null)
                    return Results.BadRequest(new { Error = $"The CP {cp} doesn't exist in DB." });
                return Results.Ok(record);
            });

            app.MapGet("Codes/Todos", async (MinimalDB context) =>
            {
                var results = await context.CodeStates.ToListAsync();
                return Results.Ok(results);
            });

        }
    }
}
