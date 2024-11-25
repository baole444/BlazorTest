namespace FrontEnd.Models
{
	public class StudentModel
	{
		public int ID { get; set; }
		public string st_name { get; set; }
		public DateTime? birth {  get; set; }
		public string address { get; set; }
		public string photo { get; set; }
		public int class_id { get; set; }
		public string division_id { get; set; }
	}
}
