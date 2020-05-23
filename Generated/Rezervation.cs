/**
 * @(#) Rezervation.cs
 */

namespace Projektas.Models
{
	public class Rezervation
	{
		Integer id;
		
		date created;
		
		date reserved;
		
		Client reservingClient;
		
		Car reservedCar;
		
	}
	
}
