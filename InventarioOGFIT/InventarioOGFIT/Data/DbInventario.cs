using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using InventarioOGFIT.Models;

namespace InventarioOGFIT.Data
    {
        public class DbInventario
        {
            private readonly string _cs;

            public DbInventario()
            {
                _cs = ConfigurationManager
                    .ConnectionStrings["InventarioDB"]
                    .ConnectionString;
            }

            // LISTAR PRODUCTOS
            public List<ProductoDto> Productos_Listar()
            {
                var list = new List<ProductoDto>();

                using (var cn = new SqlConnection(_cs))
                using (var cmd = new SqlCommand("dbo.sp_Productos_Listar", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            list.Add(new ProductoDto
                            {
                                ProductoId = (int)dr["ProductoId"],
                                Nombre = dr["Nombre"].ToString(),
                                CategoriaId = (int)dr["CategoriaId"],
                                Categoria = dr["Categoria"].ToString(),
                                Precio = (decimal)dr["Precio"],
                                Stock = (int)dr["Stock"],
                                Activo = (bool)dr["Activo"]
                            });
                        }
                    }
                }

                return list;
            }

            // OBTENER PRODUCTO POR ID
            public ProductoDto Productos_ObtenerPorId(int productoId)
            {
                ProductoDto p = null;

                using (var cn = new SqlConnection(_cs))
                using (var cmd = new SqlCommand("dbo.sp_Productos_ObtenerPorId", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductoId", productoId);

                    cn.Open();

                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            p = new ProductoDto
                            {
                                ProductoId = (int)dr["ProductoId"],
                                Nombre = dr["Nombre"].ToString(),
                                CategoriaId = (int)dr["CategoriaId"],
                                Categoria = dr["Categoria"].ToString(),
                                Precio = (decimal)dr["Precio"],
                                Stock = (int)dr["Stock"],
                                Activo = (bool)dr["Activo"]
                            };
                        }
                    }
                }

                return p;
            }

            // REGISTRAR MOVIMIENTO + ACTUALIZAR STOCK
            public void Movimientos_Registrar(int productoId, string tipo, int cantidad, string nota)
            {
                using (var cn = new SqlConnection(_cs))
                using (var cmd = new SqlCommand("dbo.sp_Movimientos_Registrar", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ProductoId", productoId);
                    cmd.Parameters.AddWithValue("@Tipo", tipo);
                    cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@Nota", (object)nota ?? DBNull.Value);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }


