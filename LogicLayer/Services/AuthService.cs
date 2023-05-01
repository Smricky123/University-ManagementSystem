using AutoMapper;
using DataLayer;
using DataLayer.Models;
using LogicLayer.DTOS;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;

namespace LogicLayer.Services
{
    public class AuthService
    {
        public static TokenDto Authenticate(int id, string password)
        {
            var admin = DataAccessFactory.AdminAuthDataAccess().Authenticate(id, password);
            if (admin != null)
            {
                var token = new Token();
                token.AdminId = id;
                token.TKey = Guid.NewGuid().ToString();
                token.CreationTime = DateTime.Now;
                token.ExpirationTime = null;
                token.Type = "admin";             
                var tk = DataAccessFactory.TokenDataAccess().Create(token);            

                if (tk != null)
                {                 
                    var config = new MapperConfiguration(c => { c.CreateMap<Token, TokenDto>(); });
                    var mapper = new Mapper(config);
                    return mapper.Map<TokenDto>(token);
                }
                return null;
            }
            else
            {
                return null;
            }


        }
   

        public static bool IsValid(string token)
        {
            var data = DataAccessFactory.TokenDataAccess().Read(token);
            if (data == null)
            {
                return true;
            }
            return false;
        }

        public static TokenDto logout(string token)
        {
            var data = DataAccessFactory.TokenDataAccess().Read(token);

            if (data != null)
            {
                data.ExpirationTime = DateTime.Now;
                var tk = DataAccessFactory.TokenDataAccess().Update(data);
                var cfg = new MapperConfiguration(c => { c.CreateMap<Token, TokenDto>(); });
                var mapper = new Mapper(cfg);
                return mapper.Map<TokenDto>(tk);
            }
            return null;
        }
    }
}
