using Dapper;
using DataAccess.Entidades;
using DataAccess.Repositorios.Compra.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess.Repositorios.Compra
{
    public class CompraRepository : BaseRepository, ICompraRepository
    {
        public CompraRepository(IConfiguration configuration) : base(configuration) { }

        public CompraEntidad Create(CompraEntidad entity)
        {
            using (IDbConnection conn = new SqlConnection(ConnectionString))
            {
                var ultimoId = conn.Insert<int, CompraEntidad>(entity);
                entity.Id = ultimoId;
                return entity;
            }
        }
        


        public decimal GetMontoAcumulado(int idUsuario, string moneda)
        {
            using (IDbConnection conn = new SqlConnection(ConnectionString))
            {
                return conn.ExecuteScalar<decimal>(@"SELECT iif(sum(monto/cambio) is null,0,sum(monto/cambio)) 
                                                     FROM tblCompra
                                                     WHERE idUsuario = @idUsuario 
                                                            AND moneda = @moneda 
                                                            AND month(getdate()) = month(fecha)", 
                                                            new { 
                                                                    idUsuario,
                                                                    moneda});
            }
        }
    }
}
