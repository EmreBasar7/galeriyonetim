using System.Data;

namespace galeriyonetim
{
    public class arac
    {
        public int Id { get; set; }
        public string AracMarka { get; set; } = string.Empty;
        public string AracModel { get; set; } = string.Empty;
        public string AracYılı { get; set; } = string.Empty;

    }
    //********//
    /*
    public class ReadArac : arac
    {
        public ReadArac(DataRow row)
        {
            Id = Convert.ToInt32(row["Id"]);
            AracMarka = row["AracMarka"].ToString();
            AracModel = row["AracModel"].ToString();
            AracYılı = row["AracYılı"].ToString();
        }
        public int Id { get; set; }
        public string AracMarka { get; set; } = string.Empty;
        public string AracModel { get; set; } = string.Empty;
        public string AracYılı { get; set; } = string.Empty;
    }
    */
}
