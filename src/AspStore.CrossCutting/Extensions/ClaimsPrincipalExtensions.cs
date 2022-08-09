using System;
using System.Security.Claims;

namespace AspStore.CrossCutting.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null) throw new ArgumentException(nameof(principal));

            var claim = principal.FindFirst(ClaimTypes.NameIdentifier);
            return claim?.Value;
        }

        public static string GetUserEmail(this ClaimsPrincipal principal)
        {
            if (principal == null) throw new ArgumentException(nameof(principal));

            var claim = principal.FindFirst(x => x.Type == "Email");
            return claim?.Value;
        }

        public static string GetUserApelido(this ClaimsPrincipal principal)
        {
            if (principal == null) throw new ArgumentException(nameof(principal));

            return principal.FindFirst(x => x.Type == "Apelido")?.Value;
        }

        public static string GetUserDataNascimento(this ClaimsPrincipal principal)
        {
            if (principal == null) throw new ArgumentException(nameof(principal));

            return principal.FindFirst(x => x.Type == "DataNascimento")?.Value;
        }

        public static string GetCPF(this ClaimsPrincipal principal)
        {
            if (principal == null) throw new ArgumentException(nameof(principal));

            return principal.FindFirst(x => x.Type == "CPF")?.Value;
        }

        public static string GetUserNomeCompleto(this ClaimsPrincipal principal)
        {
            if (principal == null) throw new ArgumentException(nameof(principal));

            return principal.FindFirst(x => x.Type == "NomeCompleto")?.Value;
        }

    }
}
