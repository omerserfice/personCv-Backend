﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace personApp.DAL.LoginSecurity.Extension
{
    public static class ClaimExtension
    {
        public static void AddUserIdentifier(this ICollection<Claim> claims, int id)
        {
            claims.Add(new Claim(PayloadClaimIdentifier.UserIdentifier, id.ToString()));
        }
        public static void AddFullName(this ICollection<Claim> claims, string fullname)
        {
            claims.Add(new Claim(PayloadClaimIdentifier.FullName, fullname));
        }

        public static void AddRole(this ICollection<Claim> claims, IEnumerable<string> roles)
        {
            foreach (var item in roles) claims.Add(new Claim(PayloadClaimIdentifier.Role, item));
        }

    }
}
