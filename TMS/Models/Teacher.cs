namespace TMS.Models;

public class Teacher
{
	public int Id {  get; set; }
	public string Name { get; set; }=string.Empty;
	public int Phone {  get; set; }=int.MaxValue;
	public string Email { get; set; } = string.Empty;
	public string Address {  get; set; } = string.Empty;


}
