using API.Minimal.Core.Entities;
using API.Minimal.Infrastructre;
using Microsoft.EntityFrameworkCore;

namespace API.Minimal.Presentation.RoutesExtensions
{
    public static class UsuariosModule
    {
        public static void AddRoutesUsuarios(this IEndpointRouteBuilder app)
        {
            app.MapGet("Usuarios/ObtenerTodos", async (MinimalDB db) =>
            {
                return await db.Usuarios.ToListAsync();
            });

            app.MapPost("Usuarios/Agregar", async (Usuarios user, MinimalDB db) =>
            {
                db.Usuarios.Add(user);
                await db.SaveChangesAsync();
                return Results.Created("/Usuarios", user);
            });

        }
    }
}
