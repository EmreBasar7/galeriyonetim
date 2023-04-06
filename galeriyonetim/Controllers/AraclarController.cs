using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Collections.Generic;
using System;
using System.Net;
using System.Data.SqlClient;
//using Newtonsoft.Json;
//using System.Web.Http;


namespace galeriyonetim.Controllers
{
    [Route("api/[controller]")]  
    [ApiController]
    public class AraclarController : ControllerBase
    {

        private readonly DataContext _context;
       
        public AraclarController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<arac>> GetTumAraclar()//Başarılı
        {
            List<arac> aracs = new List<arac>();

            using (SqlConnection con = new SqlConnection(@"data source=DESKTOP-1BO408E\SQLEXPRESS; database=galeridb; Integrated Security=True;"))
            {
                con.Open();
                var query = "select * from arac";
                SqlCommand com = new SqlCommand(query, con);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        arac dbarac = new arac();
                        dbarac.Id = (int)dr["Id"];
                        dbarac.AracMarka = (string)dr["AracMarka"];
                        dbarac.AracModel = (string)dr["AracModel"];
                        dbarac.AracYılı = (string)dr["AracYılı"];
                        aracs.Add(dbarac);
                    }
                }
            }
            return Ok(aracs);
        }
        //public List<arac> GetTumAraclar() ÇALIŞAN KOD SQL
        //return aracs; ÇALIŞAN KOD SQL
        //ENTİTY ÇALIŞAN KOD return Ok(await _context.arac.ToListAsync());

        [HttpGet("[action]")]
        public async Task<ActionResult<arac>> GetID(int id)//id den araç çekme Başarılı
        {
            
            List<arac> aracs = new List<arac>();

            using (SqlConnection con = new SqlConnection(@"data source=DESKTOP-1BO408E\SQLEXPRESS; database=galeridb; Integrated Security=True;"))
            {
                con.Open();
                var query = $"Select Id, AracMarka, AracModel, AracYılı From arac Where Id={id}";
                using SqlCommand com = new SqlCommand(query, con);

                SqlDataReader dr =  com.ExecuteReader();
                if(dr.HasRows)
                {
                    while(dr.Read())
                    {
                        
                        arac dbarac = new arac();
                        dbarac.Id = (int)dr["Id"];
                        dbarac.AracMarka = (string)dr["AracMarka"];
                        dbarac.AracModel = (string)dr["AracModel"];
                        dbarac.AracYılı = (string)dr["AracYılı"];
                        aracs.Add(dbarac);
                        
                    }
                }



            }
            return Ok(aracs);
        }
        // ENTİTY ÇALIŞAN KOD
        /*
        var arac = await _context.arac.FindAsync(id); 
        if (arac == null)
            return BadRequest("Araç Bulunamadı.");
        return Ok(arac);
        */

        [HttpGet("[action]")]
        public async Task<ActionResult<arac>> GetMarka ([FromQuery]string aracMarka)//marka ile araç çekme  BAŞARILI
       {
            List<arac> aracs = new List<arac>();

            using (SqlConnection con = new SqlConnection(@"data source=DESKTOP-1BO408E\SQLEXPRESS; database=galeridb; Integrated Security=True;"))
            {
                con.Open();
                var query = $"Select Id, AracMarka, AracModel, AracYılı From arac Where AracMarka='{aracMarka}'";

                using SqlCommand com = new SqlCommand(query, con);

                SqlDataReader dr = com.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        arac dbarac = new arac();
                        dbarac.Id = (int)dr["Id"];
                        dbarac.AracMarka = (string)dr["AracMarka"];
                        dbarac.AracModel = (string)dr["AracModel"];
                        dbarac.AracYılı = (string)dr["AracYılı"];
                        aracs.Add(dbarac);
                    }
                }
            }
            return Ok(aracs);
            /* ENTİTY
            var arac = await _context.arac.Where(x=> x.AracMarka==aracMarka).ToListAsync();
            if (arac == null)
                return BadRequest("Araç Bulunamadı.");
            return Ok(arac);
            */
        }
        
        
        [HttpPost]
        public async Task<ActionResult<List<arac>>> AddArac(arac arac)//yeni araç ekleme Başarılı
        {
            
            using (SqlConnection con = new SqlConnection(@"data source=DESKTOP-1BO408E\SQLEXPRESS; database=galeridb; Integrated Security=True;"))
            {
                con.Open();
                var query = "insert into arac(AracMarka,AracModel,AracYılı) values (@AracMarka,@AracModel,@AracYılı)";
                using(SqlCommand com = new SqlCommand(query, con))
                {
                    com.Parameters.Add("@AracMarka",SqlDbType.VarChar,50).Value = arac.AracMarka;
                    com.Parameters.Add("@AracModel", SqlDbType.VarChar, 50).Value = arac.AracModel;
                    com.Parameters.Add("@AracYılı", SqlDbType.VarChar, 50).Value = arac.AracYılı;
                    com.ExecuteNonQuery();
                }
            }
            return Ok(arac);
        }
        /* ENTİTY 
            _context.arac.Add(arac);
            await _context.SaveChangesAsync();

            return Ok(await _context.arac.ToListAsync());
            */

        [HttpPut]// sadece düzenlenen aracı çek ??
        //public async Task<ActionResult<List<arac>>> UpdateArac(arac request)//araç güncelleme ENTİTY
        public async Task<ActionResult<List<arac>>> UpdateArac(arac request)//başarılı
        {
            var id = request.Id;
            using (SqlConnection con = new SqlConnection(@"data source=DESKTOP-1BO408E\SQLEXPRESS; database=galeridb; Integrated Security=True;"))
            {
                con.Open();
                var query = $"update  arac set  AracMarka=@AracMarka, AracModel=@AracModel,  AracYılı=@AracYılı where Id={id}";
                using (SqlCommand com = new SqlCommand(query, con))
                {
                    com.Parameters.Add("@AracMarka", SqlDbType.VarChar, 50).Value = request.AracMarka;
                    com.Parameters.Add("@AracModel", SqlDbType.VarChar, 50).Value = request.AracModel;
                    com.Parameters.Add("@AracYılı", SqlDbType.VarChar, 50).Value = request.AracYılı;
                    com.ExecuteNonQuery();
                }
            }
            return Ok(request);
            /* ENTİTY KOD
            var dbArac = await _context.arac.FindAsync(request.Id);
            if (dbArac == null)
                return BadRequest("Araç Bulunamadı.");

            dbArac.AracMarka = request.AracMarka;
            dbArac.AracModel = request.AracModel;
            dbArac.AracYılı = request.AracYılı;

            await _context.SaveChangesAsync();

            return Ok(dbArac);
            */

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<arac>>> Delete(int id)//araç silme Başarılı
        {

            using (SqlConnection con = new SqlConnection(@"data source=DESKTOP-1BO408E\SQLEXPRESS; Initial catalog=galeridb; Integrated Security=True;"))
            {
                con.Open();
                var query = $"DELETE from arac  where Id={id}";
                using (SqlCommand com = new SqlCommand(query, con))
                {
                    com.ExecuteNonQuery();
                }
            }
            return Ok("Deleted succesfuly");

            /*
            var dbArac = await _context.arac.FindAsync(id);
            if (dbArac == null)
                return BadRequest("Araç Bulunamadı.");

            _context.arac.Remove(dbArac);
            await _context.SaveChangesAsync();

            return Ok(await _context.arac.ToListAsync());
            */
        }        
    }
}
