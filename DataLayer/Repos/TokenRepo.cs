using DataLayer.Interface;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repos
{
    internal class TokenRepo : Repo, IRepo<Token, string, Token>
    {
        public Token Create(Token obj)
        {
            db.Tokens.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }


        public Token Read(string id)
        {
            return db.Tokens.FirstOrDefault(t => t.TKey.Equals(id));
        }
        public List<Token> Read()
        {
            return db.Tokens.ToList();
        }

        public Token Update(Token obj)
        {
            var tk = Read(obj.TKey);
            db.Entry(tk).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0)
            {
                return tk;
            }
            return null;
        }
    }
}
